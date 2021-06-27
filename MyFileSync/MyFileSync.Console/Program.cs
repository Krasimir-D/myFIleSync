using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSync.Console
{
    static class Program
    {
        private static NotifyIcon _notifyIcon;
        private static MyFileSync.Console.Main _form;

        public static NotifyIcon NotifyIcon
        {
            get
			{
                return _notifyIcon;
			}
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem1 = new MenuItem();
            MenuItem menuItem2 = new MenuItem();
            MenuItem menuItem3 = new MenuItem();
            contextMenu.MenuItems.AddRange(new MenuItem[1]
            {
                menuItem1
            });
            contextMenu.MenuItems.AddRange(new MenuItem[1]
            {
                menuItem2
            });
            contextMenu.MenuItems.AddRange(new MenuItem[1]
            {
                menuItem3
            });
            menuItem1.Index = 0;
            menuItem1.Text = "Pause watcher";
            menuItem1.Click += new EventHandler(Program.PauseItem_Click);
            menuItem2.Index = 1;
            menuItem2.Text = "Start watcher";
            menuItem2.Visible = false;
            menuItem2.Click += new EventHandler(Program.StartItem_Click);
            menuItem3.Index = 2;
            menuItem3.Text = "Exit MyFileSync";
            menuItem3.Click += new EventHandler(Program.ExitItem_Click);
            Program._notifyIcon = new NotifyIcon();
            Program._notifyIcon.Icon = new Icon("Google-Drive.ico");
            Program._notifyIcon.Text = "MyFileSync";
            Program._notifyIcon.ContextMenu = contextMenu;
            Program._notifyIcon.MouseClick += new MouseEventHandler(Program.NotifyIcon_MouseClick);
            Program._notifyIcon.Visible = true;

			Application.ApplicationExit += Application_ApplicationExit;

            Application.Run();
        }

		private static void Application_ApplicationExit(object sender, EventArgs e)
		{
            Program._notifyIcon.Dispose();
        }

		private static MyFileSync.Console.Main Form
        {
            get
            {
                if (Program._form == null || Program._form.IsDisposed)
                {
                    Program._form = new MyFileSync.Console.Main();
                    Program._form.StartPosition = FormStartPosition.CenterScreen;
                }
                return Program._form;
            }
        }

        private static void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Program.Form.Show();
        }

        private static void StartItem_Click(object sender, EventArgs e)
        {
            ContextMenu parent = (ContextMenu)((MenuItem)sender).Parent;
            parent.MenuItems[0].Visible = true;
            parent.MenuItems[1].Visible = false;
        }

        private static void ExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void PauseItem_Click(object sender, EventArgs e)
        {
            ContextMenu parent = (ContextMenu)((MenuItem)sender).Parent;
            parent.MenuItems[0].Visible = false;
            parent.MenuItems[1].Visible = true;
        }
    }
}
