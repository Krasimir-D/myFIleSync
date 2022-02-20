using MyFileSync.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSync.Console
{
    public partial class CloudAccountsForm : Form
    {       
        private List<string> _usedEmails = new List<string>(); // Съхрянява използваните имейли
        private string _newEmail= String.Empty;

        public CloudAccountsForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            foreach (var row in ConfigManager.Config.CloudAccounts)
                _usedEmails.Add(row.Email);

            this.comboBox_UsedEmails.Items.AddRange(_usedEmails.ToArray());
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            _newEmail = textBox_Email.Text;

            foreach (var row in ConfigManager.Config.CloudAccounts)
                row.IsCurrent = (row.Email == _newEmail);

            if (!_usedEmails.Contains(_newEmail))
                ConfigManager.Config.CloudAccounts.AddCloudAccountsRow(_newEmail, (int)CloudAccountType.Google, true);

            ConfigManager.Save();
        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {
            string email = textBox_Email.Text;
            bool valid = this.isValidEmail(email);
            this.btn_Change.Enabled = valid;

            if (valid)
			{
                this._newEmail = email;
                if (this._usedEmails.Contains(email))
				{
                    if (comboBox_UsedEmails.SelectedItem == null || comboBox_UsedEmails.SelectedItem.ToString() != email)
                        comboBox_UsedEmails.SelectedItem = email;
                } else
				{
                    comboBox_UsedEmails.SelectedItem = null;
                }
			}
        }

        private bool isValidEmail(string email)
		{
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

		private void comboBox_UsedEmails_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (comboBox_UsedEmails.SelectedItem == null)
                return;

            if (comboBox_UsedEmails.SelectedItem.ToString() == this._newEmail)
                return;

            this.textBox_Email.Text = comboBox_UsedEmails.SelectedItem.ToString();

        }

		private void comboBox_UsedEmails_DrawItem(object sender, DrawItemEventArgs e)
		{
            
		}
	}
}
