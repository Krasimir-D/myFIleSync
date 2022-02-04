using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static MyFileSync.Watcher;
using System.Threading;
using MyFileSync;
using MyFileSync.DriveManager;

namespace UnitTest
{
	[TestClass]
	public class DriveManagerTests
	{
		[TestMethod]
		public void Authenticate()
		{
			GoogleDriveManager.Instance.Authenticate();
		}

	}
}
