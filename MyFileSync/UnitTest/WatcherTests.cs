using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static MyFileSync.Watcher;

namespace UnitTest
{
	[TestClass]
	public class WatcherTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			bool error = false;

			Dictionary<int, WatchNotification> testNotifications = new Dictionary<int, WatchNotification>();
			WatchNotification fl = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.FileChange);
			WatchNotification dl = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.Delete);
			WatchNotification cr = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.Create);
			WatchNotification rn = new WatchNotification(@"D:\Test\Summerise", DateTime.Now, FileSystemActionType.Rename);
			testNotifications.Add(1, fl);
			testNotifications.Add(2, dl);
			testNotifications.Add(3, cr);
			testNotifications.Add(4, rn);

			try
			{
				Instance.Start();
				testNotifications = Instance.Summerize(testNotifications);
				Instance.Stop();
			}
			catch(Exception ex)
			{
				error = true;
			}
			Assert.IsFalse(error);
			Assert.IsFalse(testNotifications.Count == 2);
		}
	}
}
