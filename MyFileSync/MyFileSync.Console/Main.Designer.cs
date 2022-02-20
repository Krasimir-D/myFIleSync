
namespace MyFileSync.Console
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAggregate = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listView_Paths = new System.Windows.Forms.ListView();
            this.PathOnDisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathOnDrive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabNotifications = new System.Windows.Forms.TabControl();
            this.tabDir = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_Notifications = new System.Windows.Forms.ListView();
            this.columnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnActionType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_ConnectToAccount = new System.Windows.Forms.Button();
            this.btnChangeAcc = new System.Windows.Forms.Button();
            this.tabNotifications.SuspendLayout();
            this.tabDir.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(50, 61);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(214, 61);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 28);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(376, 61);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnAggregate
            // 
            this.btnAggregate.Enabled = false;
            this.btnAggregate.Location = new System.Drawing.Point(898, 61);
            this.btnAggregate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggregate.Name = "btnAggregate";
            this.btnAggregate.Size = new System.Drawing.Size(154, 28);
            this.btnAggregate.TabIndex = 6;
            this.btnAggregate.Text = "Refresh notifications";
            this.btnAggregate.UseVisualStyleBackColor = true;
            this.btnAggregate.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(4, 7);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 28);
            this.btnChange.TabIndex = 8;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.bntChange_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(239, 7);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listView_Paths
            // 
            this.listView_Paths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Paths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PathOnDisk,
            this.PathOnDrive,
            this.Action});
            this.listView_Paths.HideSelection = false;
            this.listView_Paths.Location = new System.Drawing.Point(0, 40);
            this.listView_Paths.Name = "listView_Paths";
            this.listView_Paths.Size = new System.Drawing.Size(511, 320);
            this.listView_Paths.TabIndex = 10;
            this.listView_Paths.UseCompatibleStateImageBehavior = false;
            this.listView_Paths.View = System.Windows.Forms.View.Details;
            this.listView_Paths.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // PathOnDisk
            // 
            this.PathOnDisk.Text = "Path on disk";
            this.PathOnDisk.Width = 121;
            // 
            // PathOnDrive
            // 
            this.PathOnDrive.Text = "Path on drive";
            this.PathOnDrive.Width = 138;
            // 
            // Action
            // 
            this.Action.Text = "Action";
            this.Action.Width = 259;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(122, 7);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabNotifications
            // 
            this.tabNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabNotifications.Controls.Add(this.tabDir);
            this.tabNotifications.Controls.Add(this.tabPage2);
            this.tabNotifications.Location = new System.Drawing.Point(537, 138);
            this.tabNotifications.Name = "tabNotifications";
            this.tabNotifications.SelectedIndex = 0;
            this.tabNotifications.Size = new System.Drawing.Size(519, 385);
            this.tabNotifications.TabIndex = 12;
            // 
            // tabDir
            // 
            this.tabDir.Controls.Add(this.listView_Paths);
            this.tabDir.Controls.Add(this.btnDelete);
            this.tabDir.Controls.Add(this.btnAdd);
            this.tabDir.Controls.Add(this.btnChange);
            this.tabDir.Location = new System.Drawing.Point(4, 25);
            this.tabDir.Name = "tabDir";
            this.tabDir.Padding = new System.Windows.Forms.Padding(3);
            this.tabDir.Size = new System.Drawing.Size(511, 356);
            this.tabDir.TabIndex = 0;
            this.tabDir.Text = "Directories";
            this.tabDir.UseVisualStyleBackColor = true;
            this.tabDir.Click += new System.EventHandler(this.tabDir_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView_Notifications);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(511, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Notifications";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // listView_Notifications
            // 
            this.listView_Notifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Notifications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTime,
            this.columnFile,
            this.columnActionType});
            this.listView_Notifications.HideSelection = false;
            this.listView_Notifications.Location = new System.Drawing.Point(3, 3);
            this.listView_Notifications.Name = "listView_Notifications";
            this.listView_Notifications.Size = new System.Drawing.Size(505, 353);
            this.listView_Notifications.TabIndex = 0;
            this.listView_Notifications.UseCompatibleStateImageBehavior = false;
            this.listView_Notifications.View = System.Windows.Forms.View.Details;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Time";
            this.columnTime.Width = 72;
            // 
            // columnFile
            // 
            this.columnFile.Text = "File";
            this.columnFile.Width = 192;
            // 
            // columnActionType
            // 
            this.columnActionType.Text = "Action";
            this.columnActionType.Width = 76;
            // 
            // btn_ConnectToAccount
            // 
            this.btn_ConnectToAccount.Location = new System.Drawing.Point(50, 170);
            this.btn_ConnectToAccount.Name = "btn_ConnectToAccount";
            this.btn_ConnectToAccount.Size = new System.Drawing.Size(159, 28);
            this.btn_ConnectToAccount.TabIndex = 13;
            this.btn_ConnectToAccount.Text = "Connect to Account";
            this.btn_ConnectToAccount.UseVisualStyleBackColor = true;
            this.btn_ConnectToAccount.Click += new System.EventHandler(this.btn_ConnectToAccount_Click);
            // 
            // btnChangeAcc
            // 
            this.btnChangeAcc.Location = new System.Drawing.Point(50, 238);
            this.btnChangeAcc.Name = "btnChangeAcc";
            this.btnChangeAcc.Size = new System.Drawing.Size(159, 29);
            this.btnChangeAcc.TabIndex = 14;
            this.btnChangeAcc.Text = "Change account";
            this.btnChangeAcc.UseVisualStyleBackColor = true;
            this.btnChangeAcc.Click += new System.EventHandler(this.btnChangeAcc_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 598);
            this.Controls.Add(this.btnChangeAcc);
            this.Controls.Add(this.btn_ConnectToAccount);
            this.Controls.Add(this.tabNotifications);
            this.Controls.Add(this.btnAggregate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.tabNotifications.ResumeLayout(false);
            this.tabDir.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnAggregate;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView listView_Paths;
        private System.Windows.Forms.ColumnHeader PathOnDisk;
        private System.Windows.Forms.ColumnHeader PathOnDrive;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tabNotifications;
        private System.Windows.Forms.TabPage tabDir;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView_Notifications;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.ColumnHeader columnFile;
        private System.Windows.Forms.ColumnHeader columnActionType;
        private System.Windows.Forms.Button btn_ConnectToAccount;
        private System.Windows.Forms.Button btnChangeAcc;
    }
}

