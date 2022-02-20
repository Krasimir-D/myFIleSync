
namespace MyFileSync.DriveManager
{
    partial class Login_Form
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
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_UsedEmails
            // 
            this.comboBox_UsedEmails.FormattingEnabled = true;
            this.comboBox_UsedEmails.Location = new System.Drawing.Point(48, 197);
            this.comboBox_UsedEmails.Name = "comboBox_UsedEmails";
            this.comboBox_UsedEmails.Size = new System.Drawing.Size(234, 24);
            this.comboBox_UsedEmails.TabIndex = 0;
            // 
            // btn_Change
            // 
            this.btn_Change.Location = new System.Drawing.Point(48, 250);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(121, 31);
            this.btn_Change.TabIndex = 1;
            this.btn_Change.Text = "Change";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Account";
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(48, 87);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(234, 22);
            this.textBox_Email.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter new email";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(313, 85);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(143, 26);
            this.btn_Add.TabIndex = 6;
            this.btn_Add.Text = "Add new account";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 386);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Change);
            this.Controls.Add(this.comboBox_UsedEmails);
            this.Name = "Login_Form";
            this.Text = "Login_Form";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_UsedEmails;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Add;
    }
}