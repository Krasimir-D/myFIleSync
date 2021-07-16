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
		public struct WatchNotification
		{
			string Path;
			DateTime Time;
			FileSystemActionType Type;

			internal WatchNotification(string path, DateTime time, FileSystemActionType type)
			{
				this.Path = path;
				this.Time = time;
				this.Type = type;
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

		private List<WatchNotification> _notifications;
		private List<FileSystemWatcher> _systemWatchers;

		public static List<char> DriveLetters
		{
			get
			{
				if (_driveLetters == null)
				{
					_driveLetters = new List<char>();
					_driveLetters.Add('C');
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
			this._notifications = new List<WatchNotification>();
			this._systemWatchers = new List<FileSystemWatcher>();
			foreach(char letter in driveLetters)
			{
				var watcher = new FileSystemWatcher(String.Format("{0}:\\", letter));
				watcher.EnableRaisingEvents = true;
				watcher.IncludeSubdirectories = true;
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
			int count = this._notifications.Count;
		}

		private void Watcher_Event(object sender, FileSystemEventArgs e)
		{
			List<PathValue?> paths = Paths[((FileSystemWatcher)sender).Path[0]];

			WatchActionType actionType = WatchActionType.Watch;
			string path = CommonUtility.NormalizePath(e.FullPath);
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

			if (actionType == WatchActionType.Ignore)
				return;

			if (e.ChangeType == WatcherChangeTypes.Changed)			{
				FileInfo fi = new FileInfo(e.FullPath);
				if (!fi.Exists)
					return;
			}

			Console.Out.WriteLine("{0} {1}", e.FullPath, e.ChangeType.ToString());

			//TODO
			if (e.ChangeType == WatcherChangeTypes.Created)
			{
				var not = new WatchNotification(e.FullPath, DateTime.Now, FileSystemActionType.Create);
				this._notifications.Add(new WatchNotification(e.FullPath, DateTime.Now, FileSystemActionType.Create));


			}
		}

		private void Watcher_Renamed(object sender, RenamedEventArgs e)
		{
			if (!e.FullPath.StartsWith(@"C:\ZZZ"))
				return;

			//TODO
			Console.Out.WriteLine("{0} {1}", e.FullPath, e.ChangeType.ToString());
		}
	}
}
