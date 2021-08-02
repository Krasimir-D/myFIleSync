using MyFileSync.Config;
using MyFileSync.Enumerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyFileSync
{
	public class Watcher
	{
		public enum FileSystemActionType
		{
			Create,
			Delete,
			Rename,
			Move,
			FileChange
		}
		public enum AggregateType
		{
			Move,
			NewFolder
		}
		public class WatchNotification
		{
			public string Path;
			public string OldPath;
			public DateTime Time;
			public FileSystemActionType Type;
			public int ChildrenCount;

			internal WatchNotification(string path, DateTime time, FileSystemActionType type)
			{
				this.Path = path;
				this.OldPath = "";
				this.Time = time;
				this.Type = type;
				this.ChildrenCount = 0;
			}
		}

		private struct PathValue
		{
			internal string Path;
			internal WatchActionType ActionType;

			public PathValue(string path, WatchActionType actionType)
			{
				this.Path = path;
				this.ActionType = actionType;
			}
		}

		#region Static
		private static Watcher _watcher;
		private static List<char> _driveLetters;
		private static Dictionary<char, List<PathValue?>> _paths;
		#endregion

		private Queue<WatchNotification> _rawNotifications;
		private Dictionary<int, WatchNotification> _notifications;
		private List<FileSystemWatcher> _systemWatchers;

		public static List<char> DriveLetters
		{
			get
			{
				if (_driveLetters == null)
				{
					_driveLetters = new List<char>();
					_driveLetters.Add('C');
					_driveLetters.Add('D');
				}
				return _driveLetters;
			}
			set
			{
				_driveLetters = value;
			}
		}

		private static Dictionary<char, List<PathValue?>> Paths
		{
			get
			{
				if (_paths == null)
				{
					_paths = new Dictionary<char, List<PathValue?>>();
					foreach (var path in ConfigManager.Config.Paths)
					{
						char driveLetter = Path.GetPathRoot(path.PathOnDisk)[0];
						if (!_paths.ContainsKey(driveLetter))
							_paths.Add(driveLetter, new List<PathValue?>());

						_paths[driveLetter].Add(new PathValue(CommonUtility.NormalizePath(path.PathOnDisk), (WatchActionType)path.Action));
					}
				}
				return _paths;
			}
		}

		public static Watcher Instance
		{
			get
			{
				if (_watcher == null)
				{
					_watcher = new Watcher(DriveLetters);
				}
				return _watcher;
			}
		}

		private Watcher(List<char> driveLetters)
		{
			this._rawNotifications = new Queue<WatchNotification>();
			this._notifications = new Dictionary<int, WatchNotification>();
			this._systemWatchers = new List<FileSystemWatcher>();
			foreach (char letter in driveLetters)
			{
				var watcher = new FileSystemWatcher(String.Format("{0}:\\", letter));
				watcher.EnableRaisingEvents = true;
				watcher.IncludeSubdirectories = true;
				watcher.NotifyFilter = NotifyFilters.DirectoryName
									 | NotifyFilters.FileName
									 | NotifyFilters.LastWrite;
				_systemWatchers.Add(watcher);
			}
		}

		public void Start()
		{
			foreach (var watcher in this._systemWatchers)
			{
				watcher.Changed += new FileSystemEventHandler(Watcher_Event);
				watcher.Created += new FileSystemEventHandler(Watcher_Event);
				watcher.Deleted += new FileSystemEventHandler(Watcher_Event);
				watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);
			}
		}

		public void Debug()
		{
			int count = this._rawNotifications.Count;

			//string test = CommonUtility.NormalizePath(@"C:\Users\FilipD\AppData\Local\Microsoft\Edge\User Data\Default\Service Worker\CacheStorage\7bdbbfec6db2a08f00d7b918391e00812b956f61\443dbc0a-1022-4d9b-8257-530ceba561e9\index-dir\the-real-index~RF222b7a5e.TMP");

			//string test2 = Path.GetDirectoryName(test);

			//test2 = Path.GetDirectoryName(test2);

		}

		private void Watcher_Event(object sender, FileSystemEventArgs e)
		{
			DateTime time = DateTime.Now;

			List<PathValue?> paths = Paths[((FileSystemWatcher)sender).Path[0]];

			WatchActionType actionType = FindActionType(paths, e.FullPath);

			if (actionType == WatchActionType.Ignore)
				return;

			if (e.ChangeType == WatcherChangeTypes.Changed && !this.isFile(e.FullPath))
				return;

			Console.Out.WriteLine("{0} {1}", e.FullPath, e.ChangeType.ToString());

			FileSystemActionType type = FileSystemActionType.Create;
			if (e.ChangeType == WatcherChangeTypes.Created)
				type = FileSystemActionType.Create;
			else if (e.ChangeType == WatcherChangeTypes.Deleted)
				type = FileSystemActionType.Delete;
			else if (e.ChangeType == WatcherChangeTypes.Changed)
				type = FileSystemActionType.FileChange;

			WatchNotification ntf = new WatchNotification(e.FullPath, time, type);
			this._rawNotifications.Enqueue(ntf);
		}

		private static WatchActionType FindActionType(List<PathValue?> paths, string path)
		{
			path = CommonUtility.NormalizePath(path);
			WatchActionType actionType = WatchActionType.Watch;
			while (path != null)
			{
				var match = paths.Find(p => p.Value.Path == path);
				if (match != null)
				{
					actionType = match.Value.ActionType;
					path = null;
				}
				else
				{
					path = Path.GetDirectoryName(path);
				}
			}
			return actionType;
		}

		private void Watcher_Renamed(object sender, RenamedEventArgs e)
		{
			if (!e.FullPath.StartsWith(@"C:\ZZZ"))
				return;

			//TODO
			Console.Out.WriteLine("{0} {1}", e.FullPath, e.ChangeType.ToString());
		}

		public void Raw2Aggregate()
		{
			while(this._rawNotifications.Count != 0)
			{
				var ntf = this._rawNotifications.Peek();

				var result = this.CheckIfCanAddToExisting(ntf);

				if (result == null)
				{
					int key = 0;
					if (this._notifications.Count > 0)
						key = this._notifications.Max(e => e.Key);
					this._notifications.Add(key, ntf);
				}
				else //add to existing
				{
					var existingNtf = this._notifications[result.Item1];
					if (result.Item2 == AggregateType.Move)
					{
						if (existingNtf.Type == FileSystemActionType.Create)
						{
							existingNtf.OldPath = ntf.Path;
						}
						else if (existingNtf.Type == FileSystemActionType.Delete)
						{
							existingNtf.OldPath = existingNtf.Path;
							existingNtf.Path = ntf.Path;
						}
						existingNtf.Type = FileSystemActionType.Move;
					}
					else if (result.Item2 == AggregateType.NewFolder)
					{
						existingNtf.ChildrenCount++;
						// TODO
						// if delete ChildrenCount--;
						// if change do nothing
					}
				}

				this._rawNotifications.Dequeue();
			}
		}

		private Tuple<int, AggregateType> CheckIfCanAddToExisting(WatchNotification ntf)
		{
			if (this._notifications.Count == 0)
				return null;
			else
			{
				// TODO

				// MOVE - the created/deleted item has the same name as previously deleted/created item 
				// return new Tuple<WatchNotification, AggregateType>(ntfCreate/Delete, AggregateType.Move);
				int cnt=_notifications.Count;
				int oldKey = _notifications.ElementAt(cnt - 1).Key;
				var oldNtf = _notifications.ElementAt(cnt - 1).Value;
				string oldNtfName = oldNtf.Path;
				string newNtfName = ntf.Path;
                if (ntf.Type==FileSystemActionType.Create&&oldNtf.Type==FileSystemActionType.Delete|| ntf.Type == FileSystemActionType.Delete && oldNtf.Type == FileSystemActionType.Create)
                {
					if (CommonUtility.CompareDir(oldNtfName, newNtfName))
					{
						if (CommonUtility.TimeComp(oldNtf.Time, ntf.Time))
						{
							ntf.Type = FileSystemActionType.Move;
							Tuple<int, AggregateType> sysEvent = new Tuple<int, AggregateType>(oldKey, AggregateType.Move);
							return sysEvent;
						}
					}
				}			

				// NEW FOLDER - the item is located in a folder that has been created previously
				// return new Tuple<WatchNotification, AggregateType>(ntfNewFolder, AggregateType.NewFolder);
			}
			return null;
		}

		private bool isFile(string path)
		{
			FileInfo fi = new FileInfo(path);
			return fi.Exists;
		}
	}
}
