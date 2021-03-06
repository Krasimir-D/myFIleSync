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
		#region Static
		private static Watcher _watcher;
		private static List<char> _driveLetters;
		private static Dictionary<char, List<PathValue?>> _paths;
		#endregion






		private Queue<WatchNotification> _rawNotifications;
		protected Dictionary<int, WatchNotification> _notifications;
		private List<FileSystemWatcher> _systemWatchers;
		private Dictionary<int, List<WatchNotification>> _complexNotifications = new Dictionary<int, List<WatchNotification>>() ;

		public Dictionary<int, List<WatchNotification>> ComplexNotifications
		{
			get { return _complexNotifications; }
		}
		public Dictionary<int, WatchNotification> Notifications
		{
			get { return this._notifications; }
		}
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

		private static Dictionary<char, List<PathValue?>> Paths
		{
			get
			{
				if (_paths == null)
				{
					SetPaths();
				}
				return _paths;
			}
		}

		private static void SetPaths()
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
		public enum FileSystemActionType
		{
			Create,
			Delete,
			Rename,
			Move,
			FileChange,
			NoAction	
		}
		public enum AggregateType
		{
			Move, //create/delete combo of an item with different locations
			NewFolder, //all subitems of a newly created folder
			Rename, //rename a previously logged item or any of its subitem
			Delete, //delete a previously logged item or any of its subitem
			NoAction,// create + delete combo of an item with identical locations 
			Create,
		}
		public class WatchNotification
		{			
			public string Path;
			public string OldPath;
			public DateTime Time;
			public FileSystemActionType Type;

			public int CountChildren()
			{
				int count = 0;
				if (!CommonUtility.isFile(Path))
				{
					DirectoryInfo di = new DirectoryInfo(Path);
					object[] tmp = di.GetFiles("", SearchOption.AllDirectories);
					count = tmp.Length;
					tmp = di.GetDirectories("", SearchOption.AllDirectories);
					count += tmp.Length;
				}
				return count;
			}

			public WatchNotification(string path, DateTime time, FileSystemActionType type)
			{
				this.Path = path;
				this.OldPath = "";
				this.Time = time;
				this.Type = type;
			}

			public WatchNotification(string path, string oldPath, DateTime time, FileSystemActionType type)
			{
				this.Path = path;
				this.OldPath = oldPath;
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

		
		
		
		

		

		public void CleanConfig()
		{
			_paths = null;
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
		public Watcher()
		{ 
			
		}

		public void Start()
		{
			SetPaths();
			foreach (var watcher in this._systemWatchers)
			{
				watcher.Changed += new FileSystemEventHandler(Watcher_Event);
				watcher.Created += new FileSystemEventHandler(Watcher_Event);
				watcher.Deleted += new FileSystemEventHandler(Watcher_Event);
				watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);
			}
		}
		public void Stop()
		{
			foreach (var watcher in this._systemWatchers)
			{
				watcher.Changed -= new FileSystemEventHandler(Watcher_Event);
				watcher.Created -= new FileSystemEventHandler(Watcher_Event);
				watcher.Deleted -= new FileSystemEventHandler(Watcher_Event);
				watcher.Renamed -= new RenamedEventHandler(Watcher_Renamed);
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

			if (e.ChangeType == WatcherChangeTypes.Changed && !CommonUtility.isFile(e.FullPath))
				return;

			Console.Out.WriteLine("{0} {1}", e.FullPath, e.ChangeType.ToString());

			FileSystemActionType type = FileSystemActionType.Create;
			if (e.ChangeType == WatcherChangeTypes.Created)
				type = FileSystemActionType.Create;
			else if (e.ChangeType == WatcherChangeTypes.Deleted)
				type = FileSystemActionType.Delete;
			else if (e.ChangeType == WatcherChangeTypes.Changed)
				type = FileSystemActionType.FileChange;
			else if (e.ChangeType == WatcherChangeTypes.Renamed)
				type = FileSystemActionType.Rename;

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
					path = CommonUtility.NormalizePath(Path.GetDirectoryName(path));
				}
			}
			return actionType;
		}

		private void Watcher_Renamed(object sender, RenamedEventArgs e)
		{
			DateTime time = DateTime.Now;
			FileSystemActionType type = FileSystemActionType.Rename;
			List<PathValue?> paths = Paths[((FileSystemWatcher)sender).Path[0]];

			WatchActionType actionType = FindActionType(paths, e.FullPath);

			if (actionType == WatchActionType.Ignore)
				return;
			WatchNotification ntf = new WatchNotification(e.FullPath, e.OldFullPath, time, type);
			this._rawNotifications.Enqueue(ntf);
			
			Console.Out.WriteLine("{0} {1}", e.FullPath, e.ChangeType.ToString());
		}

		public void Raw2Aggregate()
		{			
			while(this._rawNotifications.Count != 0)
			{
				var ntf = this._rawNotifications.Peek();

				var result = this.CheckIfMoved(ntf);

				if (result == null)
				{
					int key = 0;
					if (this._notifications.Count > 0)
						key = this._notifications.Max(e => e.Key);
					this._notifications.Add(++key, ntf);
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
				}
				this._rawNotifications.Dequeue();
                if (_rawNotifications.Count==0)
                {
					this.Summerize(_notifications);
				}               
			}
		}
		
		public List<Tuple<string, string, DateTime>> preparedNotifications = new List<Tuple<string, string, DateTime>>();
		/*public List<Tuple<string, string, DateTime>> VizuallizeNotifications()
		{
			string type = "";
			string path = "";
			DateTime time;
			WatchNotification tmpNot;
            for(int cnt=0;cnt<_notifications.Count(); cnt++)
            {
				var item = _notifications.ElementAt(cnt);
				 tmpNot = item.Value;
                if (tmpNot.Type==FileSystemActionType.Create)
                {
					type = "Created";
					path = tmpNot.Path;
					time = tmpNot.Time;
					Tuple <string, string, DateTime> ntf = new Tuple<string, string, DateTime>(type,path,time);
					preparedNotifications.Add(ntf);
                }
                else if (tmpNot.Type==FileSystemActionType.Delete)
                {
					type = "Deleted";
					path = tmpNot.Path;
					time = tmpNot.Time;
					Tuple<string, string, DateTime> ntf = new Tuple<string, string, DateTime>(type, path, time);
					preparedNotifications.Add(ntf);
				}
				else if (tmpNot.Type == FileSystemActionType.FileChange)
				{
					type = "Changed";
					path = tmpNot.Path;
					time = tmpNot.Time;
					Tuple<string, string, DateTime> ntf = new Tuple<string, string, DateTime>(type, path, time);
					preparedNotifications.Add(ntf);
				}
				else if (tmpNot.Type == FileSystemActionType.Move)
				{
					type = "Moved";
					path = tmpNot.Path;
					time = tmpNot.Time;
					Tuple<string, string, DateTime> ntf = new Tuple<string, string, DateTime>(type, path, time);
					preparedNotifications.Add(ntf);
				}
				else if (tmpNot.Type == FileSystemActionType.Rename)
				{
					type = "Renamed";
					path = string.Format(" File renamed to {0}", tmpNot.Path);
					time = tmpNot.Time;
					Tuple<string, string, DateTime> ntf = new Tuple<string, string, DateTime>(type, path, time);
					preparedNotifications.Add(ntf);
				}
				else if (tmpNot.Type == FileSystemActionType.NoAction)
				{
					_notifications.Remove(item.Key);
				}

				//_notifications.Remove(item.Key); За Маркиране 
			}
			return preparedNotifications;
		}*/

		public Tuple<int, AggregateType> CheckIfMoved(WatchNotification ntf)
		{
			if (this._notifications.Count == 0)
				return null;
			else
			{
				
				int cnt=_notifications.Count;
				int oldKey = _notifications.ElementAt(cnt - 1).Key;
				var oldNtf = _notifications.ElementAt(cnt - 1).Value;
				if (ntf.Type == FileSystemActionType.Delete && oldNtf.Type == FileSystemActionType.Create || ntf.Type == FileSystemActionType.Create && oldNtf.Type == FileSystemActionType.Delete)// Try- catch moved event
				{
					if (CommonUtility.CompareName(ntf.Path, oldNtf.Path) && !CommonUtility.isDirIdentical(ntf.Path, oldNtf.Path))
					{
						if (CommonUtility.TimeComp(oldNtf.Time, ntf.Time))
						{
							ntf.Type = FileSystemActionType.Move;
							Tuple<int, AggregateType> sysEvent = new Tuple<int, AggregateType>(oldKey, AggregateType.Move);
							return sysEvent;
						}
					}				
				}
				string parentDir = Path.GetDirectoryName(ntf.Path);
				foreach (var exixstingNtf in _notifications)
				{
					if (exixstingNtf.Value.Type == FileSystemActionType.Create &&
						parentDir.StartsWith(exixstingNtf.Value.Path))
					{
						Tuple<int, AggregateType> sysEvent = new Tuple<int, AggregateType>(exixstingNtf.Key, AggregateType.NewFolder);
						return sysEvent;
					}
				}
			}
			return null;
		}

		/*public void Inhabit_testNotifications()
		{
			WatchNotification fl = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.FileChange);
			WatchNotification dl = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.Delete);
			WatchNotification cr = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.Create);
			WatchNotification rn = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.Rename);
			_notifications.Add(1, fl);
			_notifications.Add(2, dl);
			_notifications.Add(3, cr);
			_notifications.Add(4, rn);
		}*/

		public Dictionary<int, WatchNotification> Summerize(Dictionary<int, WatchNotification> notifications)
        {
            int cnt = notifications.Count - 1;
            int loop = 0;          
            WatchNotification currentNtf, nextNtf;
            
            while (loop < cnt)
            {
				RefreshSummerize(notifications, loop, out currentNtf, out nextNtf);
				List<WatchNotification> complexNtf = new List<WatchNotification>();
				if (currentNtf.Type == FileSystemActionType.Create && nextNtf.Type == FileSystemActionType.Delete)// catch cr+ dl sequence
                {
                    if (CommonUtility.CompareName(currentNtf.Path, nextNtf.Path) && CommonUtility.isDirIdentical(currentNtf.Path, nextNtf.Path))
                    {
                        if (CommonUtility.TimeComp(nextNtf.Time, currentNtf.Time))
                        {
                            Console.Out.WriteLine("catch cr+dl sequence success");
							notifications.Remove(notifications.ElementAt(loop + 1).Key);
							notifications.Remove(notifications.ElementAt(loop).Key);
							if (loop > 0)
								loop--;
                        }
                    }
                }
                else if (nextNtf.Type == FileSystemActionType.Delete && currentNtf.Type == FileSystemActionType.FileChange)// catch fl+dl sequence
                {
                    if (CommonUtility.CompareName(currentNtf.Path, nextNtf.Path))
                    {
                        if (CommonUtility.TimeComp(nextNtf.Time, currentNtf.Time))
                        {
                            Console.Out.WriteLine("catch fl+dl catched");
							complexNtf.Add(currentNtf);
							complexNtf.Add(nextNtf);
							_complexNotifications.Add(loop, complexNtf);
                            notifications.Remove(notifications.ElementAt(loop).Key);
                        }
                    }
                }
                else if (nextNtf.Type == FileSystemActionType.Rename && currentNtf.Type == FileSystemActionType.Create)// catch cr+rn sequence
                {
                    if (CommonUtility.isDirIdentical(currentNtf.Path, nextNtf.Path))
                    {
                        if (CommonUtility.TimeComp(nextNtf.Time, currentNtf.Time))
                        {
                            Console.Out.WriteLine("cr+rn catched");
							complexNtf.Add(currentNtf);
							complexNtf.Add(nextNtf);
							_complexNotifications.Add(loop, complexNtf);
							notifications.ElementAt(loop).Value.Path = nextNtf.Path;
                            notifications.Remove(notifications.ElementAt(loop+1).Key);
                        }
                    }
                }
                else if (nextNtf.Type == FileSystemActionType.FileChange && currentNtf.Type == FileSystemActionType.Create)// catch cr+fl sequence
                {
                    if (CommonUtility.isDirIdentical(currentNtf.Path, nextNtf.Path))
                    {
                        if (CommonUtility.TimeComp(nextNtf.Time, currentNtf.Time))
                        {
							complexNtf.Add(currentNtf);
							complexNtf.Add(nextNtf);
							_complexNotifications.Add(loop, complexNtf);
							notifications.Remove(notifications.ElementAt(loop+1).Key);
                        }
                    }
                }
                else if (nextNtf.Type == FileSystemActionType.Move && currentNtf.Type == FileSystemActionType.Create)//catch cr+mv 
                {
                    if (CommonUtility.CompareName(currentNtf.Path, nextNtf.Path))
                    {
                        if (CommonUtility.TimeComp(nextNtf.Time, currentNtf.Time))
                        {
							complexNtf.Add(currentNtf);
							complexNtf.Add(nextNtf);
							_complexNotifications.Add(loop, complexNtf);
							notifications.ElementAt(loop).Value.Path = nextNtf.Path;
                            notifications.Remove(notifications.ElementAt(loop+1).Key);
                        }
                    }
                }
				else if (nextNtf.Type == FileSystemActionType.Delete && currentNtf.Type == FileSystemActionType.Move)// catch mv+dl sequence
				{
					if (CommonUtility.CompareName(currentNtf.Path, nextNtf.Path))
					{
						if (CommonUtility.TimeComp(nextNtf.Time, currentNtf.Time))
						{
							Console.Out.WriteLine("catch mv+dl catched");
							complexNtf.Add(currentNtf);
							complexNtf.Add(nextNtf);
							_complexNotifications.Add(loop, complexNtf);
							notifications.ElementAt(loop).Value.Path = nextNtf.Path;
							notifications.Remove(notifications.ElementAt(loop).Key);
						}
					}
				} else
				{
					loop += 1;
				}
				cnt = notifications.Count - 1;
            }
			return notifications;
        }

		void RefreshSummerize(Dictionary<int, WatchNotification> notifications, int loop, out WatchNotification currentNtf, out WatchNotification nextNtf)
		{
			currentNtf = notifications.ElementAt(loop).Value;
			nextNtf = notifications.ElementAt(loop + 1).Value;
		}
	}
}
