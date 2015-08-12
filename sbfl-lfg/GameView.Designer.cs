namespace sbfl_lfg {
    partial class GameView {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpGame = new System.Windows.Forms.GroupBox();
            this.lvwPlayers = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdleTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAvailableFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAvailableUntil = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGame
            // 
            this.grpGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGame.Controls.Add(this.lvwPlayers);
            this.grpGame.Location = new System.Drawing.Point(3, 3);
            this.grpGame.Name = "grpGame";
            this.grpGame.Size = new System.Drawing.Size(387, 244);
            this.grpGame.TabIndex = 0;
            this.grpGame.TabStop = false;
            this.grpGame.Text = "groupBox1";
            // 
            // lvwPlayers
            // 
            this.lvwPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colIdleTime,
            this.colAvailableFrom,
            this.colAvailableUntil});
            this.lvwPlayers.Location = new System.Drawing.Point(6, 19);
            this.lvwPlayers.Name = "lvwPlayers";
            this.lvwPlayers.Size = new System.Drawing.Size(375, 219);
            this.lvwPlayers.TabIndex = 3;
            this.lvwPlayers.UseCompatibleStateImageBehavior = false;
            this.lvwPlayers.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 110;
            // 
            // colIdleTime
            // 
            this.colIdleTime.Text = "Idle Time";
            this.colIdleTime.Width = 70;
            // 
            // colAvailableFrom
            // 
            this.colAvailableFrom.Text = "Available From";
            this.colAvailableFrom.Width = 90;
            // 
            // colAvailableUntil
            // 
            this.colAvailableUntil.Text = "Available Until";
            this.colAvailableUntil.Width = 90;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpGame);
            this.Name = "GameView";
            this.Size = new System.Drawing.Size(393, 250);
            this.grpGame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGame;
        private System.Windows.Forms.ListView lvwPlayers;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIdleTime;
        private System.Windows.Forms.ColumnHeader colAvailableFrom;
        private System.Windows.Forms.ColumnHeader colAvailableUntil;
    }
}
