using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyFileSync.Enumerators;
using System.Threading;
using System.Timers;
using static MyFileSync.Watcher;
using MyFileSync.DriveManager;

namespace MyFileSync.Console
{
	public partial class Main : Form 
	{
		public Main()
		{
			InitializeComponent();			
		}		
		private int _num = 0;
		public void Notification(int x)
		{
			_num = x;
			if (_num >= 1)
			{
				notifyIcon1.Text = "MyFileSync";
				notifyIcon1.Icon = SystemIcons.Application;
				notifyIcon1.Icon = new Icon("app.ico");
				notifyIcon1.BalloonTipText = "You have " + _num.ToString() + " notifications";
				notifyIcon1.ShowBalloonTip(500);
                if (this.ShowInTaskbar)
                {
					this.ShowInTaskbar = false;					
                }
				
				notifyIcon1.Visible = true;
			}
		}

		private void Main_Load(object sender, EventArgs e)
        {
			LoadListViewConfig();
			Watcher.Instance.Raw2Aggregate();
			LoadListViewNotif(Watcher.Instance.Notifications);				
		}

		private void LoadListViewConfig()
		{
			listView_Paths.Items.Clear();
			foreach (var item in ConfigManager.Config.Paths)
			{
				string[] values = { item.PathOnDisk, item.PathOnDrive, ((WatchActionType)item.Action).ToString() };
				this.listView_Paths.Items.Add(new ListViewItem(values)).Tag = item;
			}
			this.listView_Paths.Refresh();
		}
		private void LoadListViewNotif(Dictionary<int, Watcher.WatchNotification> notifications)
		{

            string type = "";
            string path = "";
            DateTime time;
			string oldPath = "";
            Watcher.WatchNotification tmpNot;
            for (int cnt = 0; cnt < notifications.Count(); cnt++)
            {
                var item = notifications.ElementAt(cnt);
                tmpNot = item.Value;
                if (tmpNot.Type == FileSystemActionType.Create)
                {
                    type = "Created";
                    path = tmpNot.Path;
                    time = tmpNot.Time;
					string[] values = { time.ToString(), path, type.ToString() };
                    this.listView_Notifications.Items.Add(new ListViewItem(values));

                }
                else if (tmpNot.Type == FileSystemActionType.Delete)
                {
                    type = "Deleted";
                    path = tmpNot.Path;
                    time = tmpNot.Time;
					string[] values = { time.ToString(), path, type.ToString() };
                    this.listView_Notifications.Items.Add(new ListViewItem(values));
                }
                else if (tmpNot.Type == FileSystemActionType.FileChange)
                {
                    type = "Changed";
                    path = tmpNot.Path;
                    time = tmpNot.Time;
					string[] values = { time.ToString(), path, type.ToString() };
                    this.listView_Notifications.Items.Add(new ListViewItem(values));
                }
                else if (tmpNot.Type == FileSystemActionType.Move)
                {
                    type = "Moved";
                    path = tmpNot.Path;
                    time = tmpNot.Time;
					string[] values = { time.ToString(), path, type.ToString() };
                    this.listView_Notifications.Items.Add(new ListViewItem(values));
                }
                else if (tmpNot.Type == FileSystemActionType.Rename)
                {
                    type = "Renamed";
					oldPath = tmpNot.OldPath;
					path = string.Format(" File from {0} to {1}", oldPath, tmpNot.Path); 
                    time = tmpNot.Time;
                    string[] values = { time.ToString(), path, type.ToString() };
                    this.listView_Notifications.Items.Add(new ListViewItem(values)); 
                }
                else if (tmpNot.Type == FileSystemActionType.NoAction)
                {
                    notifications.Remove(item.Key);
                }
            }
			notifications.Clear();
        }	

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
			this.WindowState = FormWindowState.Normal;

			this.ShowInTaskbar = true;
			notifyIcon1.Visible = false;
		}

        private void Main_SizeChanged(object sender, EventArgs e)
        {
			bool isMousePointerNotOnTaskbar = Screen.GetWorkingArea(this).Contains(Cursor.Position);
			if (this.WindowState == FormWindowState.Minimized && isMousePointerNotOnTaskbar)
			{
                notifyIcon1.Text = "myfilesync";
                notifyIcon1.Icon = SystemIcons.Application;
				notifyIcon1.Icon = new Icon("Google-Drive.ico");
				notifyIcon1.BalloonTipText = "Your program has been minimized to system tray";
				notifyIcon1.ShowBalloonTip(500);
				this.ShowInTaskbar = false;
				notifyIcon1.Visible = true;
			}
		}
		
		private void btnStart_Click(object sender, EventArgs e)
		{
			Watcher.Instance.Start();
			btnAggregate.Enabled = true;
			//SetTimer();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			btnStop.Enabled = true;
			MyFileSync.Watcher.Instance.Stop();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ConfigManager.Save(null);
		}
		private static System.Timers.Timer checkUpTimer;
		private void SetTimer()
		{
			double interval = 10000;
			checkUpTimer = new System.Timers.Timer(interval);
			checkUpTimer.Elapsed += this.TimedAggregate;
			checkUpTimer.AutoReset = true;
			checkUpTimer.Enabled = true;
		}
	
		private void TimedAggregate(Object source, ElapsedEventArgs e)
		{
			if (this.InvokeRequired)
			{
				MyFileSync.Watcher.Instance.Raw2Aggregate();				
				Action safeWrite = delegate { LoadListViewNotif(Watcher.Instance.Notifications); };
				this.Invoke(safeWrite);
			}
			else
				this.LoadListViewNotif(Watcher.Instance.Notifications);			
		}
		private void button4_Click(object sender, EventArgs e)
		{			
			MyFileSync.Watcher.Instance.Raw2Aggregate();
			LoadListViewNotif(Watcher.Instance.Notifications);
		  }		

        private void bntChange_Click(object sender, EventArgs e)
        {
			ConfigForm f = new ConfigForm(listView_Paths.SelectedItems[0]);
			var result = f.ShowDialog();
			if (result == DialogResult.OK)
            {
                ChangeConfig();
            }
        }

        private void ChangeConfig()
        {
            ConfigManager.Save();
			ConfigManager.Read();
			Watcher.Instance.CleanConfig();
            this.LoadListViewConfig();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnChange.Enabled = listView_Paths.SelectedItems.Count > 0;			
		}		
		
		private void btnDelete_Click(object sender, EventArgs e)
        {
			Config.Configuration.PathsRow deletedPathRow;
			deletedPathRow = (Config.Configuration.PathsRow)listView_Paths.SelectedItems[0].Tag;
            int tmpCnt = ConfigManager.Config.Paths.Count;
            ConfigManager.Config.Paths.RemovePathsRow(deletedPathRow);
			ChangeConfig();
		}

        private void btnAdd_Click(object sender, EventArgs e)
        {
			FolderBrowserDialog choosePath = new FolderBrowserDialog();
			if (choosePath.ShowDialog() == DialogResult.OK)
			{
				var newPath = choosePath.SelectedPath;
				ConfigForm f = new ConfigForm(newPath);
				var result = f.ShowDialog();
				if (result == DialogResult.OK)
				{
					ChangeConfig();
				}
			}
		}

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabDir_Click(object sender, EventArgs e)
        {

        }

        private void btn_Summerise_Click(object sender, EventArgs e)
        {
			Watcher.Instance.Raw2Aggregate();
			Watcher.Instance.Summerize(Watcher.Instance.Notifications);
        }

		private void btn_ConnectToAccount_Click(object sender, EventArgs e)
		{
			//this.connectToAccount();

			CloudAccountsForm form = new CloudAccountsForm();
			form.Show();
		}

		private async void connectToAccount()
        {
			string message = await CloudDriveManager.Instance.GetUserName();
			if (message != null)
				MessageBox.Show(message, "GetUserName_result", MessageBoxButtons.OK);
        }
    }
}
