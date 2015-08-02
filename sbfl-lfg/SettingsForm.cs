using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbfl_lfg {
    public partial class SettingsForm : Form {
        public SettingsForm() {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            txtUsername.Text = Properties.Settings.Default.SBFLUsername;
            txtPassword.Text = Properties.Settings.Default.SBFLPassword;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            NetworkCredential nc = new NetworkCredential(txtUsername.Text, txtPassword.Text);

            try {
                BotClient bc = new BotClient(nc);
                bc.GetGames();
            } catch (WebException) {
                MessageBox.Show(this, "The specified username and password are not valid.", "SBFL LFG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }

            Properties.Settings.Default.SBFLUsername = nc.UserName;
            Properties.Settings.Default.SBFLPassword = nc.Password;
            Properties.Settings.Default.Save();
        }
    }
}
