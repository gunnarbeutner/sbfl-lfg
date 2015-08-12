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
        public GameView() {
            InitializeComponent();
        }

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

        public void UpdateInfo(LobbyInfo lobby) {
            grpGame.Text = lobby.Name;

            lvwPlayers.Items.Clear();

            if (lobby.Players != null) {
                foreach (PlayerInfo player in lobby.Players.Values) {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = player.Name;
                    double minutes = player.Idle / 60;
                    lvi.SubItems.Add(string.Format("{0} minute{1}", (int)minutes, minutes != 1 ? "s" : ""));

                    string from = "Now";
                    if (player.From.HasValue && player.From.Value > DateTime.UtcNow)
                        from = player.From.Value.ToLocalTime().ToShortTimeString();
                    lvi.SubItems.Add(from);

                    string to = "N/A";
                    if (player.To.HasValue && player.To.Value > DateTime.UtcNow)
                        to = player.To.Value.ToLocalTime().ToShortTimeString();
                    lvi.SubItems.Add(to);

                    lvwPlayers.Items.Add(lvi);
                }
            }
        }
    }
}
