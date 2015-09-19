using System;
using System.Windows.Forms;

namespace sbfl_lfg {
    public partial class JoinLobbyForm : Form {
        public JoinLobbyForm() {
            InitializeComponent();
        }

        public JoinLobbyForm(string game) {
            InitializeComponent();

            Text = string.Format("Join {0} Lobby", game);
            lblPrompt.Text = string.Format("When would you like to play {0}?", game);
        }

        public DateTime? From {
            get {
                if (rdoFromTime.Checked)
                    return dtpFrom.Value;
                else
                    return DateTime.Now;
            }
        }

        public DateTime? To {
            get {
                if (rdoToTime.Checked)
                    return dtpTo.Value;
                else
                    return null;
            }
        }

        private void FromRadioButton_CheckedChanged(object sender, EventArgs e) {
            dtpFrom.Enabled = rdoFromTime.Checked;
        }

        private void ToRadioButton_CheckedChanged(object sender, EventArgs e) {
            dtpTo.Enabled = rdoToTime.Checked;
        }
    }
}
