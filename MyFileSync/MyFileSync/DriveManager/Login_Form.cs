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
        string currentEmail= "";

        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

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
            currentEmail = textBox_Email.Text;
            if (CompareEmails(currentEmail) == false)
            {
                _usedEmails.Add(currentEmail);
            }
            
        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {
            textBox_Email.Text = comboBox_UsedEmails.SelectedItem.ToString();
        }
    }
}
