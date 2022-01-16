using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static MyFileSync.Watcher;
using System.Threading;
using MyFileSync;

namespace UnitTest
{
	[TestClass]
	public class DriveManagerTests
	{
		[TestMethod]
		public void Authenticate()
		{
			DriveManager.Instance.Authenticate();
		}

	}
}
