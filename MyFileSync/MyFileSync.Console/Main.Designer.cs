
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
			this.btnPush = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
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
			this.txtNotif.Location = new System.Drawing.Point(329, 322);
			this.txtNotif.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtNotif.Name = "txtNotif";
			this.txtNotif.Size = new System.Drawing.Size(146, 20);
			this.txtNotif.TabIndex = 2;
			// 
			// btnPush
			// 
			this.btnPush.Location = new System.Drawing.Point(94, 316);
			this.btnPush.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnPush.Name = "btnPush";
			this.btnPush.Size = new System.Drawing.Size(124, 24);
			this.btnPush.TabIndex = 3;
			this.btnPush.Text = "Push notification";
			this.btnPush.UseVisualStyleBackColor = true;
			this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(94, 149);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(217, 149);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Debug";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(338, 149);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Save";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnPush);
			this.Controls.Add(this.txtNotif);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button btnPush;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}

