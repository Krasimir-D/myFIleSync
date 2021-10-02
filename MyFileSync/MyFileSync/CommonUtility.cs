using System;
using System.IO;

namespace MyFileSync
{
	public static class CommonUtility
	{
		public static string NormalizePath(string path)
		{
			if (path == null)
				return null;
			else
				return Path.GetFullPath(new Uri(path).LocalPath)
					   .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
					   .ToUpperInvariant();
		}

		public static bool ComparePaths(string path1, string path2)
		{
			return (NormalizePath(path1) == NormalizePath(path2));
		}
		public static bool CompareName(string path1, string path2 ) // compares whether the file's/folder's name is still the same in case of it being moved 
		{
			string[] pth1 = PathToArr(path1);
			int cnt1 = pth1.Length;
			string[] pth2 = PathToArr(path2);
			int cnt2= pth2.Length;
            if (pth1[cnt1-1]==pth2[cnt2-1])
            {
				return true;
            }
			return false;
		}
		public static bool isDirIdentical(string path1, string path2) // checks whether the path is the same except for the name in case of it being renamed event
		{
			bool answer = false;
			int m = 0, n = 0;
			string[] pth1 = PathToArr(path1);
			int cnt1 = pth1.Length;
			string[] pth2 = PathToArr(path2);
			int cnt2 = pth2.Length;
            while (m<cnt1-2&&n<cnt2-2)
            {
                if (pth1[m++]!=pth2[n++])
                {
					return answer;
                }				
            }
            if (m>cnt1-2||n>cnt2-2)
            {
				return answer;
            }
			answer = true;
			return answer;
		}

		public static string[] PathToArr(string path)
		{
			string[] separator = { @"\" };
			string[] pth= { };					
            for (int i = 0; i < path.Length; i++)
            {
				pth=path.Split(separator, StringSplitOptions.None);
            }
			return pth;
		}
		public static bool TimeComp(DateTime oldNtf,DateTime newNtf)
		{
			TimeSpan diff = newNtf - oldNtf;
			return (diff.TotalMilliseconds <= 10000);
		}
		public static bool isFile(string path)
		{
			FileInfo fi = new FileInfo(path);
			return fi.Exists;
		}
	}
}
