
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
            this.txtNotif = new System.Windows.Forms.TextBox();
            this.btnPushNot = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDialog = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAggregate = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listView_Paths = new System.Windows.Forms.ListView();
            this.PathOnDisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PathOnDrive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Action = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // txtNotif
            // 
            this.txtNotif.Location = new System.Drawing.Point(340, 138);
            this.txtNotif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNotif.Name = "txtNotif";
            this.txtNotif.Size = new System.Drawing.Size(193, 22);
            this.txtNotif.TabIndex = 2;
            // 
            // btnPushNot
            // 
            this.btnPushNot.Location = new System.Drawing.Point(125, 130);
            this.btnPushNot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPushNot.Name = "btnPushNot";
            this.btnPushNot.Size = new System.Drawing.Size(165, 30);
            this.btnPushNot.TabIndex = 3;
            this.btnPushNot.Text = "Push notification";
            this.btnPushNot.UseVisualStyleBackColor = true;
            this.btnPushNot.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(125, 61);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDialog
            // 
            this.btnDialog.Location = new System.Drawing.Point(289, 61);
            this.btnDialog.Margin = new System.Windows.Forms.Padding(4);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(100, 28);
            this.btnDialog.TabIndex = 4;
            this.btnDialog.Text = "Debug";
            this.btnDialog.UseVisualStyleBackColor = true;
            this.btnDialog.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(451, 61);
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
            this.btnAggregate.Location = new System.Drawing.Point(744, 61);
            this.btnAggregate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggregate.Name = "btnAggregate";
            this.btnAggregate.Size = new System.Drawing.Size(100, 28);
            this.btnAggregate.TabIndex = 6;
            this.btnAggregate.Text = "Aggregate";
            this.btnAggregate.UseVisualStyleBackColor = true;
            this.btnAggregate.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnChange
            // 
            this.btnChange.Enabled = false;
            this.btnChange.Location = new System.Drawing.Point(589, 491);
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
            this.btnDelete.Location = new System.Drawing.Point(869, 491);
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
            this.listView_Paths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PathOnDisk,
            this.PathOnDrive,
            this.Action});
            this.listView_Paths.HideSelection = false;
            this.listView_Paths.Location = new System.Drawing.Point(589, 138);
            this.listView_Paths.Name = "listView_Paths";
            this.listView_Paths.Size = new System.Drawing.Size(380, 315);
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
            this.btnAdd.Location = new System.Drawing.Point(727, 491);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 598);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listView_Paths);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnAggregate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDialog);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPushNot);
            this.Controls.Add(this.txtNotif);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox txtNotif;
        private System.Windows.Forms.Button btnPushNot;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnDialog;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnAggregate;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView listView_Paths;
        private System.Windows.Forms.ColumnHeader PathOnDisk;
        private System.Windows.Forms.ColumnHeader PathOnDrive;
        private System.Windows.Forms.ColumnHeader Action;
        private System.Windows.Forms.Button btnAdd;
    }
}

