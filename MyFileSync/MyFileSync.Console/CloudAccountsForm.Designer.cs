
namespace MyFileSync.Console
{
    partial class CloudAccountsForm
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
			this.comboBox_UsedEmails = new System.Windows.Forms.ComboBox();
			this.btn_Change = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox_CloudProvider = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// comboBox_UsedEmails
			// 
			this.comboBox_UsedEmails.FormattingEnabled = true;
			this.comboBox_UsedEmails.Location = new System.Drawing.Point(37, 139);
			this.comboBox_UsedEmails.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox_UsedEmails.Name = "comboBox_UsedEmails";
			this.comboBox_UsedEmails.Size = new System.Drawing.Size(176, 21);
			this.comboBox_UsedEmails.TabIndex = 0;
			this.comboBox_UsedEmails.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox_UsedEmails_DrawItem);
			this.comboBox_UsedEmails.SelectedIndexChanged += new System.EventHandler(this.comboBox_UsedEmails_SelectedIndexChanged);
			// 
			// btn_Change
			// 
			this.btn_Change.Location = new System.Drawing.Point(36, 203);
			this.btn_Change.Margin = new System.Windows.Forms.Padding(2);
			this.btn_Change.Name = "btn_Change";
			this.btn_Change.Size = new System.Drawing.Size(91, 25);
			this.btn_Change.TabIndex = 1;
			this.btn_Change.Text = "Change";
			this.btn_Change.UseVisualStyleBackColor = true;
			this.btn_Change.Click += new System.EventHandler(this.btn_Login_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 124);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Previously used accounts";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(34, 34);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Choose cloud service";
			// 
			// comboBox_CloudProvider
			// 
			this.comboBox_CloudProvider.FormattingEnabled = true;
			this.comboBox_CloudProvider.Items.AddRange(new object[] {
            "Google Drive"});
			this.comboBox_CloudProvider.Location = new System.Drawing.Point(36, 49);
			this.comboBox_CloudProvider.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox_CloudProvider.Name = "comboBox_CloudProvider";
			this.comboBox_CloudProvider.Size = new System.Drawing.Size(176, 21);
			this.comboBox_CloudProvider.TabIndex = 0;
			this.comboBox_CloudProvider.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox_UsedEmails_DrawItem);
			this.comboBox_CloudProvider.SelectedIndexChanged += new System.EventHandler(this.comboBox_UsedEmails_SelectedIndexChanged);
			// 
			// CloudAccountsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 267);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_Change);
			this.Controls.Add(this.comboBox_CloudProvider);
			this.Controls.Add(this.comboBox_UsedEmails);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "CloudAccountsForm";
			this.Text = "Login_Form";
			this.Load += new System.EventHandler(this.Login_Form_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_UsedEmails;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox_CloudProvider;
	}
}