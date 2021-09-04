using MyFileSync.Enumerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFileSync
{
    public partial class ConfigForm : Form
    {
        public Config.Configuration.PathsRow PathRow;

        public ConfigForm()
        {
            InitializeComponent();

            comboBox_Action.Items.Add(WatchActionType.Ignore);
            comboBox_Action.Items.Add(WatchActionType.Sync);
            comboBox_Action.Items.Add(WatchActionType.Watch);
        }
        public ConfigForm(ListViewItem item):this()
        {
            this.PathRow = (Config.Configuration.PathsRow)item.Tag;
            txtPath.Text = this.PathRow.PathOnDisk;
            comboBox_Action.SelectedItem = (WatchActionType)this.PathRow.Action;
        }
        public ConfigForm(string path):this()
        {
            txtPath.Text = path;
            comboBox_Action.SelectedItem = WatchActionType.Ignore;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (PathRow!=null)
            {
                this.PathRow.PathOnDrive = txtPath.Text;
                this.PathRow.Action = (short)((WatchActionType)comboBox_Action.SelectedItem);
            }
            else
            {
                var newRow = ConfigManager.Config.Paths.NewPathsRow();
                ConfigManager.Config.Paths.AddPathsRow(txtPath.Text, "", 2, null);
            }
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {            
          
        }
    }
}
