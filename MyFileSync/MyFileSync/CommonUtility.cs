using System;
using System.IO;

namespace MyFileSync
{
	public static class CommonUtility
	{
		public static string NormalizePath(string path)
		{
			return Path.GetFullPath(new Uri(path).LocalPath)
					   .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
					   .ToUpperInvariant();
		}

		public static bool ComparePaths(string path1, string path2)
		{
			return (NormalizePath(path1) == NormalizePath(path2));
		}
	}
}
