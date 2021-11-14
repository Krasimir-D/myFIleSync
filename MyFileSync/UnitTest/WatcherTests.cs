using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static MyFileSync.Watcher;

namespace UnitTest
{
	[TestClass]
	public class WatcherTests
	{
		private string LoadTestPath()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			DirectoryInfo di = Directory.GetParent(Path.GetDirectoryName(assembly.Location));
			di = Directory.GetParent(di.FullName);
			FileInfo fi = new FileInfo(Path.Combine(di.FullName, "TestPaths.txt"));
			return fi.OpenText().ReadToEnd();
		}

		[TestMethod]
		public void Summerize()
		{
			string testPath = this.LoadTestPath();

			Dictionary<int, WatchNotification> testNotifications = new Dictionary<int, WatchNotification>();
			WatchNotification fl = new WatchNotification(Path.Combine(testPath, "Summerize"), DateTime.Now, FileSystemActionType.FileChange);
			WatchNotification dl = new WatchNotification(Path.Combine(testPath, "Summerize"), DateTime.Now, FileSystemActionType.Delete);
			WatchNotification cr = new WatchNotification(Path.Combine(testPath, "Summerize"), DateTime.Now, FileSystemActionType.Create);
			WatchNotification rn = new WatchNotification(Path.Combine(testPath, "Renamed"), DateTime.Now, FileSystemActionType.Rename);
			testNotifications.Add(1, fl);
			testNotifications.Add(2, dl);
			testNotifications.Add(3, cr);
			testNotifications.Add(4, rn);

			Instance.Start();
			testNotifications = Instance.Summerize(testNotifications);
			Instance.Stop();

			Assert.IsTrue(testNotifications.Count == 2);
		}
	}
}
