
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
			this.comboBox_Accounts = new System.Windows.Forms.ComboBox();
			this.btn_Change = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// comboBox_Accounts
			// 
			this.comboBox_Accounts.FormattingEnabled = true;
			this.comboBox_Accounts.Location = new System.Drawing.Point(37, 57);
			this.comboBox_Accounts.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox_Accounts.Name = "comboBox_Accounts";
			this.comboBox_Accounts.Size = new System.Drawing.Size(176, 21);
			this.comboBox_Accounts.TabIndex = 0;
			this.comboBox_Accounts.SelectedIndexChanged += new System.EventHandler(this.comboBox_Accounts_SelectedIndexChanged);
			// 
			// btn_Change
			// 
			this.btn_Change.Location = new System.Drawing.Point(36, 121);
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
			this.label1.Location = new System.Drawing.Point(34, 42);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Previously used accounts";
			// 
			// CloudAccountsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 180);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_Change);
			this.Controls.Add(this.comboBox_Accounts);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "CloudAccountsForm";
			this.Text = "Login_Form";
			this.Load += new System.EventHandler(this.Login_Form_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Accounts;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Label label1;
	}
}