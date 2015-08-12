using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dynamitey;
using Json;
using System.Runtime.InteropServices;
using System.Threading;

namespace sbfl_lfg {
    public partial class MainForm : Form {
        private int SYSMENU_ABOUT_ID = 0x1;

        private bool _AppExiting = false;
        private bool _UpdatingGames = false;
        private object _SyncObject = new object();

        private const int UpdateInterval = 60;
        private int _UpdateTick = 0;
   
        public MainForm() {
            InitializeComponent();

            UpdateGames();
        }

        private void tsmPlay_Click(object sender, EventArgs e) {
            Program.MainForm.Show();
            Program.MainForm.Activate();
        }

        private void tsmSettings_Click(object sender, EventArgs e) {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog(this);
            Program.InitBotClient();
        }

        private void tsmQuit_Click(object sender, EventArgs e) {
            _AppExiting = true;
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (!_AppExiting) {
                Hide();
                e.Cancel = true;
            }

            SetUpdateEvent(false);
        }

        private void tmrUpdate_Tick(object sender, EventArgs e) {
            _UpdateTick += tmrUpdate.Interval / 1000;

            if (_UpdateTick >= UpdateInterval) {
                _UpdateTick = 0;

                lblRefreshStatus.Text = "Updating...";
                Refresh();

                try {
                    UpdateGames();

                    LASTINPUTINFO lii = new LASTINPUTINFO();
                    lii.cbSize = Marshal.SizeOf(lii);
                    Utility.GetLastInputInfo(out lii);

                    Program.BotClient.SetIdleTime((Environment.TickCount - lii.dwTime) / 1000);
                } catch (Exception) {
                    /* Do nothing. */
                }
            }

            lblRefreshStatus.Text = string.Format("Next update in {0} seconds", UpdateInterval - _UpdateTick);
        }

        private void InvokeForm(MethodInvoker mi) {
            if (InvokeRequired)
                Invoke(mi);
            else
                mi();
        }

        private void UpdateGamesSync() {
            lock (_SyncObject) {
                Dictionary<string, LobbyInfo> lobbies = Program.BotClient.GetLobbies();

                string selected = gvwGame.Text;

                InvokeForm(delegate {
                    _UpdatingGames = true;

                    SetUpdateEvent(false);
                });

                List<ListViewItem> items = new List<ListViewItem>();

                foreach (JsonObject game in Program.BotClient.GetMyGames()) {
                    string name = Dynamic.InvokeGet(game, "name");
                    string title = name;
                    LobbyInfo lobby;

                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = name;

                    if (!lobbies.TryGetValue(name, out lobby)) {
                        lobby = new LobbyInfo();
                        lobby.Name = name;
                        lobby.Players = new Dictionary<string, PlayerInfo>();
                    }

                    lvi.SubItems.Add(lobby.Players.Count.ToString());

                    if (lobby.Players.ContainsKey(Properties.Settings.Default.SBFLUsername))
                        lvi.Checked = true;

                    lvi.Tag = lobby;

                    if (name == selected) {
                        lvi.Selected = true;
                        InvokeForm(delegate {
                            gvwGame.UpdateInfo(lobby);
                        });
                    }

                    items.Add(lvi);
                }

                InvokeForm(delegate {
                    lvwGames.Items.Clear();
                    lvwGames.Items.AddRange(items.ToArray());

                    SetUpdateEvent(true);

                    _UpdatingGames = false;
                });
            }
        }

        private void UpdateGames() {
            Thread t = new Thread(UpdateGamesSync);
            t.Start();
        }

        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);

            IntPtr hSysMenu = Utility.GetSystemMenu(this.Handle, false);
            Utility.AppendMenu(hSysMenu, Utility.MF_SEPARATOR, 0, string.Empty);
            Utility.AppendMenu(hSysMenu, Utility.MF_STRING, SYSMENU_ABOUT_ID, "&About…");
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);

            if ((m.Msg == Utility.WM_SYSCOMMAND) && ((int)m.WParam == SYSMENU_ABOUT_ID)) {
                new AboutForm().ShowDialog(this);
            }
        }

        private void lblRefreshStatus_Click(object sender, EventArgs e) {
            _UpdateTick = UpdateInterval;
            tmrUpdate_Tick(null, null);
        }

        private void lvwGames_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (_UpdatingGames)
                return;

            string game = e.Item.Text;

            if (e.Item.Checked) {
                JoinLobbyForm jlf = new JoinLobbyForm(game);
                if (jlf.ShowDialog(this) != DialogResult.OK) {
                    e.Item.Checked = false;
                    return;
                }

                try {
                    Program.BotClient.JoinLobby(game, jlf.From, jlf.To);
                } catch (Exception) {
                    MessageBox.Show(this, "Could not join the lobby '" + game + "'.", "SBFL LFG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                try {
                    Program.BotClient.LeaveLobby(game);
                } catch (Exception) {
                    MessageBox.Show(this, "Could not remove you from the lobby '" + game + "'.", "SBFL LFG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try {
                UpdateGames();
            } catch (Exception ex) {
                MessageBox.Show(this, ex.ToString());
                /* Do nothing. */
            }
        }

        private void lvwGames_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvwGames.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = lvwGames.SelectedItems[0];

            string game = lvi.Text;
            LobbyInfo lobby = (LobbyInfo)lvi.Tag;

            gvwGame.UpdateInfo(lobby);
        }

        private void SetUpdateEvent(bool add) {
            if (add && Visible)
                lvwGames.ItemChecked += lvwGames_ItemChecked;
            else
                lvwGames.ItemChecked -= lvwGames_ItemChecked;
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            SetUpdateEvent(true);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (Properties.Settings.Default.ShowTrayHint) {
                Properties.Settings.Default.ShowTrayHint = false;
                Properties.Settings.Default.Save();

                nicTrayIcon.ShowBalloonTip(5000, "SBFL LFG", "You can open the client by double-clicking on this icon.", ToolTipIcon.Info);
            }
        }
    }
}
