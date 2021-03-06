using MyFileSync.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFileSync.Enumerators;

namespace MyFileSync.DriveManager
{
    public abstract class CloudDriveManager
    {
		#region Static
		protected static CloudDriveManager _driveManager;
		#endregion
		private string _currentEmail;
		public string CurrentEmail
		{
			set { this._currentEmail = string.Format(@"{0}",value); }
			get { return this._currentEmail; }
		}

		public abstract void Authenticate();

		public abstract Task<string> GetUserName();

		public abstract Task<string> GetUserEmail();

		public static Configuration.CloudAccountsRow CloudAccount
		{
			get
			{
				//return @"filip.draganov@gmail.com";
				//return @"krasimir.dyakov29@gmail.com";
				//TODO - read from ConfigManager
				//return ConfigManager.Config;
				var ds = new Configuration();
				return ds.CloudAccounts.AddCloudAccountsRow(@"krasimir.dyakov29@gmail.com", 1, true);				
			}
		}
		public static CloudDriveManager Instance
		{
			get
			{
				if (_driveManager == null)
				{					
                    if (CloudAccount.Type==(int)CloudAccountType.Google)
                    {
						_driveManager = new GoogleDriveManager(CloudAccount.Email);
					}

					_driveManager.Authenticate();
				}
				return _driveManager;
			}
		}
	}
}
