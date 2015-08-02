using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbfl_lfg {
    public partial class GameView : UserControl {
        public event EventHandler RemoveClicked;

        public GameView(LobbyInfo lobby) {
            InitializeComponent();

            UpdateInfo(lobby);
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override String Text {
            get {
                return grpGame.Text;
            }
            set {
                grpGame.Text = value;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            if (RemoveClicked != null)
                RemoveClicked(this, e);
        }

        public void UpdateInfo(LobbyInfo lobby) {
            grpGame.Text = lobby.Name;

            lvwPlayers.Items.Clear();

            foreach (PlayerInfo player in lobby.Players.Values) {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = player.Name;
                int minutes = player.Idle / 60;
                lvi.SubItems.Add(string.Format("{0} minute{1}", minutes, minutes != 1 ? "s" : ""));
                lvwPlayers.Items.Add(lvi);
            }
        }
    }
}
