using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSync.DriveManager
{
    public partial class Login_Form : Form
    {       
        private List<string> _usedEmails = new List<string>(); // Съхрянява използваните имейли        
        string currentEmail= string.Empty;
        GoogleDriveManager acc;

        public Login_Form()
        {
            InitializeComponent();            
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }
        private bool CompareEmails(string email)
        {
            int listLength = _usedEmails.Count;
            for (int i = 0; i < listLength; i++)
            {
                if (email == _usedEmails[i])
                {
                    return true; // Такъв имейл вече съществува
                }               
            }
            return false; // Такъв имейл не е въвеждан и сега ще бъде съхранен 
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string newAccount = this.comboBox_UsedEmails.SelectedItem.ToString();
            acc = new GoogleDriveManager(newAccount);
            acc.CurrentEmail = newAccount;
            acc.Authenticate();
        }
        private void LoadComboBox()
        {
            comboBox_UsedEmails.Items.Clear();
            comboBox_UsedEmails.Items.AddRange(_usedEmails.ToArray());
            this.comboBox_UsedEmails.Refresh();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string newAccount = textBox_Email.Text;
            if (CompareEmails(newAccount) == false)
            {
                if (newAccount != string.Empty || newAccount != null)
                    _usedEmails.Add(newAccount);
                LoadComboBox();
                textBox_Email.Clear();
            }
        }
    }
}
