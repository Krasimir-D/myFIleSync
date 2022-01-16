using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFileSync
{
	public class DriveManager
	{
		#region Static
		private static DriveManager _driveManager;
		#endregion

		private string _gmail;

		public DriveManager(string gmail)
		{
			this._gmail = gmail;
		}

		public static string Gmail
		{
			get
			{
				return @"filip.draganov@gmail.com";
				//return @"krasimir.dyakov29@gmail.com";
				//TODO - read from ConfigManager
				//return ConfigManager.Config;
			}
		}

		public static DriveManager Instance
		{
			get
			{
				if (_driveManager == null)
				{
					_driveManager = new DriveManager(Gmail);
				}
				return _driveManager;
			}
		}

		public UserCredential Authenticate()
		{
			string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), GoogleWebAuthorizationBroker.Folder);
			string userName = this._gmail.Split('@')[0].ToLower();
			DirectoryInfo di = new DirectoryInfo(Path.Combine(folderPath, userName));
			bool hasToSaveToken = true;
			if (di.Exists)
			{
				var tokens = di.GetFiles("Google.Apis.Auth.OAuth2.Responses*");
				if (tokens != null && tokens.Length > 0)
				{
					hasToSaveToken = false;
					FileInfo fi = tokens[0];
					fi.CopyTo(Path.Combine(di.Parent.FullName, fi.Name), true);
					//TODO date compare
					//DateTime dt = fi.LastWriteTime;
				}
			}
			else
				di.Create();



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

			if (hasToSaveToken)
			{
				var tokens = di.Parent.GetFiles("Google.Apis.Auth.OAuth2.Responses*", System.IO.SearchOption.TopDirectoryOnly);
				System.IO.FileInfo fi = tokens[0];
				fi.CopyTo(System.IO.Path.Combine(di.FullName, fi.Name), true);
			}

			return credential;
		}

	}
}
