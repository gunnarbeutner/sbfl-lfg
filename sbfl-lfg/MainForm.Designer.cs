namespace sbfl_lfg {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.nicTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.cboGames = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.flpGames = new System.Windows.Forms.FlowLayoutPanel();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.cmsTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // nicTrayIcon
            // 
            this.nicTrayIcon.BalloonTipTitle = "SBFL LFG";
            this.nicTrayIcon.ContextMenuStrip = this.cmsTrayMenu;
            this.nicTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nicTrayIcon.Icon")));
            this.nicTrayIcon.Text = "SBFL LFG";
            this.nicTrayIcon.Visible = true;
            this.nicTrayIcon.DoubleClick += new System.EventHandler(this.tsmPlay_Click);
            // 
            // cmsTrayMenu
            // 
            this.cmsTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmPlay,
            this.tsmSettings,
            this.toolStripMenuItem1,
            this.tsmQuit});
            this.cmsTrayMenu.Name = "cmsTrayMenu";
            this.cmsTrayMenu.Size = new System.Drawing.Size(153, 98);
            // 
            // tsmPlay
            // 
            this.tsmPlay.Name = "tsmPlay";
            this.tsmPlay.Size = new System.Drawing.Size(152, 22);
            this.tsmPlay.Text = "&Play game...";
            this.tsmPlay.Click += new System.EventHandler(this.tsmPlay_Click);
            // 
            // tsmSettings
            // 
            this.tsmSettings.Name = "tsmSettings";
            this.tsmSettings.Size = new System.Drawing.Size(152, 22);
            this.tsmSettings.Text = "&Settings...";
            this.tsmSettings.Click += new System.EventHandler(this.tsmSettings_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsmQuit
            // 
            this.tsmQuit.Name = "tsmQuit";
            this.tsmQuit.Size = new System.Drawing.Size(152, 22);
            this.tsmQuit.Text = "&Quit";
            this.tsmQuit.Click += new System.EventHandler(this.tsmQuit_Click);
            // 
            // cboGames
            // 
            this.cboGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGames.FormattingEnabled = true;
            this.cboGames.Location = new System.Drawing.Point(12, 12);
            this.cboGames.Name = "cboGames";
            this.cboGames.Size = new System.Drawing.Size(316, 21);
            this.cboGames.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(334, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 21);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "LFG!";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // flpGames
            // 
            this.flpGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpGames.AutoScroll = true;
            this.flpGames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGames.Location = new System.Drawing.Point(12, 44);
            this.flpGames.Name = "flpGames";
            this.flpGames.Size = new System.Drawing.Size(393, 315);
            this.flpGames.TabIndex = 4;
            this.flpGames.WrapContents = false;
            this.flpGames.SizeChanged += new System.EventHandler(this.flpGames_SizeChanged);
            this.flpGames.Resize += new System.EventHandler(this.flpGames_Resize);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 60000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 371);
            this.Controls.Add(this.flpGames);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboGames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(433, 410);
            this.MinimumSize = new System.Drawing.Size(271, 80);
            this.Name = "MainForm";
            this.Text = "SBFL LFG";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.cmsTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon nicTrayIcon;
        private System.Windows.Forms.ContextMenuStrip cmsTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmPlay;
        private System.Windows.Forms.ToolStripMenuItem tsmSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmQuit;
        private System.Windows.Forms.ComboBox cboGames;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flpGames;
        private System.Windows.Forms.Timer tmrUpdate;
    }
}

