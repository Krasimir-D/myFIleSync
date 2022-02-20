using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSync.DriveManager
{
	public class GoogleDriveManager: CloudDriveManager
	{
		private string _gmail;
		protected UserCredential Token;
		protected DriveService Service { get; set; }

		public GoogleDriveManager(string gmail)
		{
			this._gmail = gmail;
		}

        public override async void Authenticate()
		{
			/*string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), GoogleWebAuthorizationBroker.Folder);
			string userName = this._gmail.Split('@')[0].ToLower();*/
			
			// Scopes for use with the Google Drive API
			string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile };
			// From https://console.developers.google.com
			var clientId = "815921599110-9h5b8ui2n56liq4fkauq3oold437j2al.apps.googleusercontent.com";
			var clientSecret = "_YHiScLaqUdhScdk8aAJIPE4";
			//Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
			var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
				new ClientSecrets
				{
					ClientId = clientId,
					ClientSecret = clientSecret
				},
				scopes,
				Environment.UserName,
				CancellationToken.None,
				 new FileDataStore("MyFileSync")
				);

			this.Token = credential;
			this.Service = new DriveService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = this.Token,
				ApplicationName = "My File Sync"
			}); 

		}

		private async Task<DriveService> getService()
		{
			int count = 0;
			while (this.Service == null)
			{
				await Task.Delay(1000);
				count++;
				if (count > 10)
				{
					MessageBox.Show("can't connect", "Error", MessageBoxButtons.OK);
					return null;
				}
			}
			return this.Service;
		}

		private async Task<User> GetUser()
        {
			DriveService service = await this.getService();

			if (service == null)
				return null;

			AboutResource.GetRequest request = service.About.Get();
			request.Fields = "user";

			About userInfo = null;
			try
			{
				userInfo = request.Execute();
			}
			catch (Exception ex)
            {
				//TODO
			}
			return userInfo.User;
		}

		public override async Task<string> GetUserName()
		{
			return (await this.GetUser()).DisplayName;
		}

		public override async Task<string> GetUserEmail()
		{
			return (await this.GetUser()).EmailAddress;
		}

		public async Task<bool> CanConnect(int maxAttempt = 60)
		{
			int count = 0;
			while (this.Service == null)
			{
				await Task.Delay(1000);
				count++;
				if (count > 60)
				{
					return false;
				}
			}
			return true;
		}
	}
}
