using MyFileSync.DriveManager;
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
        public class AccountItem
		{
            public string Email;
            public CloudAccountType AccountType;
            public bool IsNew;

            public override string ToString()
			{
                if (this.IsNew)
				{
                    return String.Format("Connect new {0} account", this.AccountType.ToString());
				} else
				{
                    return String.Format("{0} ({1})", this.Email, this.AccountType.ToString());
				}
			}
		}

        private string _newEmail= String.Empty;

        public CloudAccountsForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            this.comboBox_Accounts.Items.Add(new AccountItem() { IsNew = true, AccountType = CloudAccountType.Google }); // add new account

            foreach (var row in ConfigManager.Config.CloudAccounts) // connected accounts
			{
                int i = this.comboBox_Accounts.Items.Add(new AccountItem() { Email = row.Email, AccountType = (CloudAccountType)row.Type });
                if (row.IsCurrent)
				{
                    this.comboBox_Accounts.SelectedIndex = i;
                }
            }
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            //_newEmail = textBox_Email.Text;

            //foreach (var row in ConfigManager.Config.CloudAccounts)
            //    row.IsCurrent = (row.Email == _newEmail);

            //if (!_usedEmails.Contains(_newEmail))
            //    ConfigManager.Config.CloudAccounts.AddCloudAccountsRow(_newEmail, (int)CloudAccountType.Google, true);

            //ConfigManager.Save();
        }

		private void comboBox_Accounts_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (this.comboBox_Accounts.SelectedItem == this.comboBox_Accounts.Items[0])
            {
                this.comboBox_Accounts.DropDownStyle = ComboBoxStyle.DropDown;
            }
            AccountItem item = (AccountItem)this.comboBox_Accounts.SelectedItem;
            if (item.IsNew)
			{
                if (item.AccountType == CloudAccountType.Google)
				{
                    this.connectToGoogleAccount();
                }
            }
        }

        private async void connectToGoogleAccount()
        {
            var driveManager = new GoogleDriveManager(String.Empty);
            string message = await driveManager.GetUserName();
            if (message != null)
                MessageBox.Show(message, "GetUserName_result", MessageBoxButtons.OK);
        }
    }
}
