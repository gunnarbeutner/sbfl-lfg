using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dynamitey;
using Json;
using System.Runtime.InteropServices;

namespace sbfl_lfg {
    public partial class MainForm : Form {
        private int SYSMENU_ABOUT_ID = 0x1;

        private bool _AppExiting = false;

        private const int UpdateInterval = 60;
        private int _UpdateTick = 0;

        private Dictionary<string, GameView> _Games = new Dictionary<string, GameView>();
    
        public MainForm() {
            InitializeComponent();

            UpdateGames();
            ResizeForm();
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
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (lvwGames.SelectedItems.Count != 1)
                return;

            string game = lvwGames.SelectedItems[0].Text;

            if (game == "" || _Games.ContainsKey(game))
                return;

            try {
                Program.BotClient.JoinLobby(game);
            } catch (WebException) {
                MessageBox.Show(this, "Could not join the lobby '" + game + "'.", "SBFL LFG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try {
                UpdateGames();
            } catch (WebException) {
                /* Do nothing. */
            }
        }

        private void GameView_RemoveClicked(object sender, EventArgs e) {
            GameView gvw = (GameView)sender;
            string game = gvw.Text;

            try {
                Program.BotClient.LeaveLobby(gvw.Text);
            } catch (WebException) {
                MessageBox.Show(this, "Could not remove you from the lobby '" + game + "'.", "SBFL LFG", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try {
                UpdateGames();
            } catch (WebException) {
                /* Do nothing. */
            }
        }

        private void flpGames_SizeChanged(object sender, EventArgs e) {
            ResizeGameViews();
        }

        private void ResizeGameViews() {
            flpGames.SuspendLayout();
            foreach (Control control in flpGames.Controls) {
                control.Width = flpGames.ClientSize.Width - 10;
            }
            flpGames.ResumeLayout();
        }

        private void ResizeForm() {
            int height = 0;

            foreach (GameView gvw in _Games.Values) {
                height += gvw.Height;
            }

            height += Height - flpGames.Height + 25;

            if (_Games.Values.Count == 0)
                height = 254;

            MaximumSize = new Size(MaximumSize.Width, height);

            if (_Games.Values.Count <= 2)
                Height = height;

            if (_Games.Values.Count <= 1)
                MinimumSize = new Size(MinimumSize.Width, MaximumSize.Height);
        }

        private void flpGames_Resize(object sender, EventArgs e) {
            Utility.ShowScrollBar(flpGames.Handle, Utility.SB_HORZ, false);
        }

        private void tmrUpdate_Tick(object sender, EventArgs e) {
            _UpdateTick += tmrUpdate.Interval / 1000;

            if (_UpdateTick > UpdateInterval) {
                _UpdateTick = 0;

                lblRefreshStatus.Text = "Updating...";
                Refresh();

                try {
                    UpdateGames();

                    LASTINPUTINFO lii = new LASTINPUTINFO();
                    lii.cbSize = Marshal.SizeOf(lii);
                    Utility.GetLastInputInfo(out lii);

                    Program.BotClient.SetIdleTime((Environment.TickCount - lii.dwTime) / 1000);
                } catch (WebException) {
                    /* Do nothing. */
                }
            }

            lblRefreshStatus.Text = string.Format("Next update in {0} seconds", UpdateInterval - _UpdateTick);
        }

        private void UpdateGames() {
            var lobbies = Program.BotClient.GetLobbies();

            string selected = null;
                
            if (lvwGames.SelectedItems.Count > 0)
                selected = lvwGames.SelectedItems[0].Text;

            lvwGames.Items.Clear();
            foreach (JsonObject game in Program.BotClient.GetMyGames()) {
                string name = Dynamic.InvokeGet(game, "name");
                string title = name;
                LobbyInfo lobby;

                ListViewItem lvi = new ListViewItem();
                lvi.Text = name;

                if (lobbies.TryGetValue(name, out lobby))
                    lvi.SubItems.Add(lobby.Players.Count.ToString());
                else
                    lvi.SubItems.Add("0");

                if (name == selected)
                    lvi.Selected = true;

                lvwGames.Items.Add(lvi);
            }

            Dictionary<string, GameView> games = new Dictionary<string, GameView>();

            List<Control> toAdd = new List<Control>();

            foreach (var game in lobbies) {
                string name = game.Key;

                if (!game.Value.Players.ContainsKey(Properties.Settings.Default.SBFLUsername))
                    continue;

                if (_Games.ContainsKey(name)) {
                    GameView view = _Games[name];
                    view.UpdateInfo(game.Value);
                    games.Add(name, _Games[name]);
                }  else {
                    GameView view = new GameView(game.Value);
                    view.RemoveClicked += GameView_RemoveClicked;

                    games.Add(name, view);
                    toAdd.Add(view);
                }
            }

            _Games = games;

            List<Control> toRemove = new List<Control>();

            foreach (Control control in flpGames.Controls) {
                if (!_Games.ContainsKey(control.Text))
                    toRemove.Add(control);
            }

            foreach (Control control in toRemove) {
                flpGames.Controls.Remove(control);
            }

            foreach (GameView view in toAdd) {
                flpGames.Controls.Add(view);
            }

            ResizeGameViews();
            ResizeForm();
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
    }
}
