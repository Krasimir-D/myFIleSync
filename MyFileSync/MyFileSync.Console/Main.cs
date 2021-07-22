using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
	}
}
