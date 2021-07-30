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
		public static bool CompareDir(string path1, string path2 )
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
			double diff = (newNtf.ToOADate()-oldNtf.ToOADate());			
            if (diff<=0.08)
            {
				return true;
            }
			return false;
		}
	}
}
