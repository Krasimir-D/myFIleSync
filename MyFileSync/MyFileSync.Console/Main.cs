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
        }

		void LoadListViewConfig()
		{
			listView_Paths.Items.Clear();
			foreach (var item in ConfigManager.Config.Paths)
			{
				string[] values = { item.PathOnDisk, item.PathOnDrive, ((WatchActionType)item.Action).ToString() };
				this.listView_Paths.Items.Add(new ListViewItem(values)).Tag = item;
			}
			this.listView_Paths.Refresh();
		}

		private void btnPush_Click(object sender, EventArgs e)        {

			int x = int.Parse(txtNotif.Text);
			Notification(x);
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

		private void button1_Click(object sender, EventArgs e)
		{
			MyFileSync.Watcher.Instance.Start();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MyFileSync.Watcher.Instance.Debug();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ConfigManager.Save(null);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			MyFileSync.Watcher.Instance.Raw2Aggregate();
		}        

        private void bntChange_Click(object sender, EventArgs e)
        {
			ConfigForm f = new ConfigForm(listView_Paths.SelectedItems[0]);
			var result = f.ShowDialog();
			if (result == DialogResult.OK) {
				ConfigManager.Save();
				this.LoadListViewConfig();
			}
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
			ConfigManager.Save();
			LoadListViewConfig();
		}

        private void btnAdd_Click(object sender, EventArgs e)
        {
			FolderBrowserDialog choosePath = new FolderBrowserDialog();
			choosePath.ShowDialog();
			var newPath = choosePath.SelectedPath;
			ConfigForm f = new ConfigForm(newPath);
			var result = f.ShowDialog();
			if (result == DialogResult.OK)
			{
				ConfigManager.Save();
				this.LoadListViewConfig();
			}
		}
    }
}
