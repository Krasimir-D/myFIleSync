using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static MyFileSync.Watcher;
using System.Threading;

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
		public void Summerize1()
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
			Assert.IsTrue(testNotifications[2].Type == FileSystemActionType.Delete);
			Assert.IsTrue(testNotifications[3].Type == FileSystemActionType.Create);
		}

		[TestMethod]
		public void Summerize2()
		{
			string testPath = this.LoadTestPath();

			Dictionary<int, WatchNotification> testNotifications = new Dictionary<int, WatchNotification>();
			WatchNotification fl = new WatchNotification(Path.Combine(testPath, "nullify"), DateTime.Now, FileSystemActionType.Create);
			WatchNotification dl = new WatchNotification(Path.Combine(testPath, "nullify"), DateTime.Now, FileSystemActionType.Delete);
			testNotifications.Add(1, fl);
			testNotifications.Add(2, dl);

			Instance.Start();
			testNotifications = Instance.Summerize(testNotifications);
			Instance.Stop();

			Assert.IsTrue(testNotifications.Count == 0);
		}
		[TestMethod]
		public void Raw2Aggregate()
		{
			string testPath = this.LoadTestPath();
			Instance.Start();
			Thread.Sleep(2000);
			File.Create(Path.Combine(testPath, "testRaw"));
			Thread.Sleep(2000);
			Instance.Raw2Aggregate();
			Assert.IsTrue(Instance.Notifications.Count==1);
			Instance.Stop();
		}
		[TestMethod]
		public void Raw2Aggregate_move()
		{
			//Test preparation
			string testPath = this.LoadTestPath();
			Directory.CreateDirectory(Path.Combine(testPath, "Start"));
			Directory.CreateDirectory(Path.Combine(testPath, "End"));
			string testRaw_pth = Path.Combine(testPath, @"Start\testRaw");
			File.Create(testRaw_pth).Close();
			string testRaw_pth_new = Path.Combine(testPath, "End\\testRaw");
			if (File.Exists(testRaw_pth_new))
				File.Delete(testRaw_pth_new);
			Thread.Sleep(2000);

			//Test body
			Instance.Start();
			Thread.Sleep(2000);
			File.Move(testRaw_pth, Path.Combine(testPath, "End\\testRaw"));
			Thread.Sleep(5000);
			Instance.Raw2Aggregate();
			Assert.IsTrue(Instance.Notifications.Count == 1);
			Assert.IsTrue(Instance.Notifications[1].Type == FileSystemActionType.Move);
			Instance.Stop();
		}		
	}
}
