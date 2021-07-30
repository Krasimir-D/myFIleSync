using MyFileSync.Config;
using System;
using System.IO;
using System.Reflection;

namespace MyFileSync
{
	public static class ConfigManager
	{
		private static Configuration _defaultConfig;
		private static Configuration _config;

		private static string ConfigFilePath
		{
			get
			{
				return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config.xml");
			}
		}

		public static Configuration Config
		{
			get
			{
				if (_config == null)
				{
					_config = Read();
					if (_config == null)
						_config = DefaultConfig;
				}
				return _config;
			}
		}

		private static Configuration DefaultConfig
		{
			get
			{
				if (_defaultConfig == null)
				{
					_defaultConfig = new Configuration();

					AddIgnorePath(_defaultConfig, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
					AddIgnorePath(_defaultConfig, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
					AddIgnorePath(_defaultConfig, Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
					AddIgnorePath(_defaultConfig, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
					AddIgnorePath(_defaultConfig, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
					AddIgnorePath(_defaultConfig, Environment.GetFolderPath(Environment.SpecialFolder.Windows));
					AddIgnorePath(_defaultConfig, @"C:\$Recycle.Bin");


					_defaultConfig.Paths.AddPathsRow(@"C:\TestIgnore1", "", 2, null);
					_defaultConfig.Paths.AddPathsRow(@"C:\TestIgnore2\Watch1", "", 1, null);
					_defaultConfig.Paths.AddPathsRow(@"C:\TestIgnore3", "", 2, null);

				}
				return _defaultConfig;
			}
		}

		private static void AddIgnorePath(Configuration configuration, string path)
		{
			foreach(var pathRow in configuration.Paths)
			{
				if (CommonUtility.ComparePaths(pathRow.PathOnDisk, path))
					return;
			}
			configuration.Paths.AddPathsRow(path, "", 2, null);
		}

		public static void Save(Configuration config)
		{
			if (config == null)
				config = DefaultConfig;
			config.WriteXml(ConfigFilePath);
		}

		private static Configuration Read()
		{
			FileInfo fi = new FileInfo(ConfigFilePath);
			if (fi.Exists)
			{
				Configuration config = new Configuration();
				config.ReadXml(ConfigFilePath);
				return config;
			}
			else
				return null;
		}
	}
}
