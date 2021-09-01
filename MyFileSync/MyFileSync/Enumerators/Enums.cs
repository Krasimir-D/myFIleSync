using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileSync.Enumerators
{
	public enum SyncFrequencyType
	{
		Manual = 1,
		Continous = 2,
		Daily = 3,
		Weekly = 4,
		Monthly = 5,
	}

	public enum WatchActionType
	{
		Watch = 1,
		Ignore = 2,
		Sync = 3,
	}
}
