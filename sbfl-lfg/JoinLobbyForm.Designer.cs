namespace sbfl_lfg {
    partial class JoinLobbyForm {
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
            this.lblPrompt = new System.Windows.Forms.Label();
            this.grpAvailableFrom = new System.Windows.Forms.GroupBox();
            this.rdoFromTime = new System.Windows.Forms.RadioButton();
            this.rdoFromNow = new System.Windows.Forms.RadioButton();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.grpAvailableTo = new System.Windows.Forms.GroupBox();
            this.rdoToTime = new System.Windows.Forms.RadioButton();
            this.rdoToUnspecified = new System.Windows.Forms.RadioButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnJoin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAvailableFrom.SuspendLayout();
            this.grpAvailableTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new System.Drawing.Point(13, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(189, 13);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "When would you like to play <Game>?";
            // 
            // grpAvailableFrom
            // 
            this.grpAvailableFrom.Controls.Add(this.rdoFromTime);
            this.grpAvailableFrom.Controls.Add(this.rdoFromNow);
            this.grpAvailableFrom.Controls.Add(this.dtpFrom);
            this.grpAvailableFrom.Location = new System.Drawing.Point(16, 36);
            this.grpAvailableFrom.Name = "grpAvailableFrom";
            this.grpAvailableFrom.Size = new System.Drawing.Size(295, 77);
            this.grpAvailableFrom.TabIndex = 2;
            this.grpAvailableFrom.TabStop = false;
            this.grpAvailableFrom.Text = "Available From";
            // 
            // rdoFromTime
            // 
            this.rdoFromTime.AutoSize = true;
            this.rdoFromTime.Location = new System.Drawing.Point(6, 42);
            this.rdoFromTime.Name = "rdoFromTime";
            this.rdoFromTime.Size = new System.Drawing.Size(88, 17);
            this.rdoFromTime.TabIndex = 2;
            this.rdoFromTime.TabStop = true;
            this.rdoFromTime.Text = "Specific time:";
            this.rdoFromTime.UseVisualStyleBackColor = true;
            this.rdoFromTime.CheckedChanged += new System.EventHandler(this.FromRadioButton_CheckedChanged);
            // 
            // rdoFromNow
            // 
            this.rdoFromNow.AutoSize = true;
            this.rdoFromNow.Checked = true;
            this.rdoFromNow.Location = new System.Drawing.Point(6, 19);
            this.rdoFromNow.Name = "rdoFromNow";
            this.rdoFromNow.Size = new System.Drawing.Size(47, 17);
            this.rdoFromNow.TabIndex = 1;
            this.rdoFromNow.TabStop = true;
            this.rdoFromNow.Text = "Now";
            this.rdoFromNow.UseVisualStyleBackColor = true;
            this.rdoFromNow.CheckedChanged += new System.EventHandler(this.FromRadioButton_CheckedChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "HH:mm";
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(117, 42);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowUpDown = true;
            this.dtpFrom.Size = new System.Drawing.Size(97, 20);
            this.dtpFrom.TabIndex = 3;
            // 
            // grpAvailableTo
            // 
            this.grpAvailableTo.Controls.Add(this.rdoToTime);
            this.grpAvailableTo.Controls.Add(this.rdoToUnspecified);
            this.grpAvailableTo.Controls.Add(this.dtpTo);
            this.grpAvailableTo.Location = new System.Drawing.Point(16, 119);
            this.grpAvailableTo.Name = "grpAvailableTo";
            this.grpAvailableTo.Size = new System.Drawing.Size(295, 77);
            this.grpAvailableTo.TabIndex = 3;
            this.grpAvailableTo.TabStop = false;
            this.grpAvailableTo.Text = "Available Until";
            // 
            // rdoToTime
            // 
            this.rdoToTime.AutoSize = true;
            this.rdoToTime.Location = new System.Drawing.Point(6, 42);
            this.rdoToTime.Name = "rdoToTime";
            this.rdoToTime.Size = new System.Drawing.Size(88, 17);
            this.rdoToTime.TabIndex = 5;
            this.rdoToTime.TabStop = true;
            this.rdoToTime.Text = "Specific time:";
            this.rdoToTime.UseVisualStyleBackColor = true;
            this.rdoToTime.CheckedChanged += new System.EventHandler(this.ToRadioButton_CheckedChanged);
            // 
            // rdoToUnspecified
            // 
            this.rdoToUnspecified.AutoSize = true;
            this.rdoToUnspecified.Checked = true;
            this.rdoToUnspecified.Location = new System.Drawing.Point(6, 19);
            this.rdoToUnspecified.Name = "rdoToUnspecified";
            this.rdoToUnspecified.Size = new System.Drawing.Size(84, 17);
            this.rdoToUnspecified.TabIndex = 4;
            this.rdoToUnspecified.TabStop = true;
            this.rdoToUnspecified.Text = "Open-ended";
            this.rdoToUnspecified.UseVisualStyleBackColor = true;
            this.rdoToUnspecified.CheckedChanged += new System.EventHandler(this.ToRadioButton_CheckedChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "HH:mm";
            this.dtpTo.Enabled = false;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(117, 42);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowUpDown = true;
            this.dtpTo.Size = new System.Drawing.Size(97, 20);
            this.dtpTo.TabIndex = 6;
            // 
            // btnJoin
            // 
            this.btnJoin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnJoin.Location = new System.Drawing.Point(155, 203);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 7;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(236, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // JoinLobbyForm
            // 
            this.AcceptButton = this.btnJoin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(323, 235);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.grpAvailableTo);
            this.Controls.Add(this.grpAvailableFrom);
            this.Controls.Add(this.lblPrompt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JoinLobbyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Join <Game> Lobby";
            this.grpAvailableFrom.ResumeLayout(false);
            this.grpAvailableFrom.PerformLayout();
            this.grpAvailableTo.ResumeLayout(false);
            this.grpAvailableTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.GroupBox grpAvailableFrom;
        private System.Windows.Forms.RadioButton rdoFromTime;
        private System.Windows.Forms.RadioButton rdoFromNow;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.GroupBox grpAvailableTo;
        private System.Windows.Forms.RadioButton rdoToTime;
        private System.Windows.Forms.RadioButton rdoToUnspecified;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Button btnCancel;
    }
}