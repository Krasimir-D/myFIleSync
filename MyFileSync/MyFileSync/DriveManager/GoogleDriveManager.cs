using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFileSync.DriveManager
{
	public class GoogleDriveManager: CloudDriveManager
	{
		private string _gmail;
		protected UserCredential Token;
		protected DriveService Service;

		public GoogleDriveManager(string gmail)
		{
			this._gmail = gmail;
		}

        public override void Authenticate()
		{
			/*string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), GoogleWebAuthorizationBroker.Folder);
			string userName = this._gmail.Split('@')[0].ToLower();*/
			
			// Scopes for use with the Google Drive API
			string[] scopes = new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile };
			// From https://console.developers.google.com
			var clientId = "815921599110-9h5b8ui2n56liq4fkauq3oold437j2al.apps.googleusercontent.com";
			var clientSecret = "_YHiScLaqUdhScdk8aAJIPE4";
			//Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
			var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
				new ClientSecrets
				{
					ClientId = clientId,
					ClientSecret = clientSecret
				},
				scopes,
				Environment.UserName,
				CancellationToken.None
				//, new FileDataStore("Daimto.GoogleDrive.Auth.Store")
				).Result;

			this.Token = credential;
			this.Service = new DriveService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = this.Token,
				ApplicationName = "My File Sync"
			}); 

		}

		public override string GetUserName()
        {
			AboutResource.GetRequest request = this.Service.About.Get();
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
			return userInfo.User.DisplayName;
		}
	}
}
