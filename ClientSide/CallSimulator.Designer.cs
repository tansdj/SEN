namespace ClientSide
{
    partial class CallSimulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallSimulator));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDash = new System.Windows.Forms.Label();
            this.picLogoSmall = new System.Windows.Forms.PictureBox();
            this.tabCall = new System.Windows.Forms.TabControl();
            this.callCreator = new System.Windows.Forms.TabPage();
            this.callHandler = new System.Windows.Forms.TabPage();
            this.cmbClients = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDialing = new System.Windows.Forms.Label();
            this.cmbClientsHandler = new System.Windows.Forms.ComboBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.lblComments = new System.Windows.Forms.Label();
            this.rtxtRemarks = new System.Windows.Forms.RichTextBox();
            this.callTime = new System.Windows.Forms.Timer(this.components);
            this.lblTimer = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).BeginInit();
            this.tabCall.SuspendLayout();
            this.callCreator.SuspendLayout();
            this.callHandler.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lblDash);
            this.pnlTop.Controls.Add(this.picLogoSmall);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(382, 55);
            this.pnlTop.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnClose.Location = new System.Drawing.Point(342, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Copperplate Gothic Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDash.Location = new System.Drawing.Point(60, 18);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(202, 24);
            this.lblDash.TabIndex = 4;
            this.lblDash.Text = "Call Simulator";
            // 
            // picLogoSmall
            // 
            this.picLogoSmall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogoSmall.BackgroundImage")));
            this.picLogoSmall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoSmall.Cursor = System.Windows.Forms.Cursors.Default;
            this.picLogoSmall.Location = new System.Drawing.Point(3, 0);
            this.picLogoSmall.Name = "picLogoSmall";
            this.picLogoSmall.Size = new System.Drawing.Size(51, 51);
            this.picLogoSmall.TabIndex = 3;
            this.picLogoSmall.TabStop = false;
            // 
            // tabCall
            // 
            this.tabCall.Controls.Add(this.callCreator);
            this.tabCall.Controls.Add(this.callHandler);
            this.tabCall.Location = new System.Drawing.Point(3, 71);
            this.tabCall.Name = "tabCall";
            this.tabCall.SelectedIndex = 0;
            this.tabCall.Size = new System.Drawing.Size(379, 330);
            this.tabCall.TabIndex = 3;
            this.tabCall.Tag = "";
            // 
            // callCreator
            // 
            this.callCreator.BackColor = System.Drawing.Color.Black;
            this.callCreator.Controls.Add(this.lblDialing);
            this.callCreator.Controls.Add(this.button1);
            this.callCreator.Controls.Add(this.cmbClients);
            this.callCreator.Location = new System.Drawing.Point(4, 22);
            this.callCreator.Name = "callCreator";
            this.callCreator.Padding = new System.Windows.Forms.Padding(3);
            this.callCreator.Size = new System.Drawing.Size(371, 304);
            this.callCreator.TabIndex = 0;
            this.callCreator.Text = "Make Call";
            // 
            // callHandler
            // 
            this.callHandler.BackColor = System.Drawing.Color.Black;
            this.callHandler.Controls.Add(this.lblTimer);
            this.callHandler.Controls.Add(this.rtxtRemarks);
            this.callHandler.Controls.Add(this.lblComments);
            this.callHandler.Controls.Add(this.btnDecline);
            this.callHandler.Controls.Add(this.btnAnswer);
            this.callHandler.Controls.Add(this.cmbClientsHandler);
            this.callHandler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.callHandler.Location = new System.Drawing.Point(4, 22);
            this.callHandler.Name = "callHandler";
            this.callHandler.Padding = new System.Windows.Forms.Padding(3);
            this.callHandler.Size = new System.Drawing.Size(371, 304);
            this.callHandler.TabIndex = 1;
            this.callHandler.Text = "Handle Call";
            // 
            // cmbClients
            // 
            this.cmbClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbClients.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClients.ForeColor = System.Drawing.Color.Snow;
            this.cmbClients.FormattingEnabled = true;
            this.cmbClients.Location = new System.Drawing.Point(17, 34);
            this.cmbClients.Name = "cmbClients";
            this.cmbClients.Size = new System.Drawing.Size(346, 29);
            this.cmbClients.TabIndex = 10;
            this.cmbClients.Text = "Select Client";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(17, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 71);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDialing
            // 
            this.lblDialing.AutoSize = true;
            this.lblDialing.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDialing.Location = new System.Drawing.Point(93, 207);
            this.lblDialing.Name = "lblDialing";
            this.lblDialing.Size = new System.Drawing.Size(48, 13);
            this.lblDialing.TabIndex = 12;
            this.lblDialing.Text = "Dialing...";
            this.lblDialing.Visible = false;
            // 
            // cmbClientsHandler
            // 
            this.cmbClientsHandler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbClientsHandler.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClientsHandler.ForeColor = System.Drawing.Color.Snow;
            this.cmbClientsHandler.FormattingEnabled = true;
            this.cmbClientsHandler.Location = new System.Drawing.Point(17, 83);
            this.cmbClientsHandler.Name = "cmbClientsHandler";
            this.cmbClientsHandler.Size = new System.Drawing.Size(346, 29);
            this.cmbClientsHandler.TabIndex = 11;
            this.cmbClientsHandler.Text = "Select Client";
            this.cmbClientsHandler.Visible = false;
            // 
            // btnAnswer
            // 
            this.btnAnswer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnswer.BackgroundImage")));
            this.btnAnswer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer.Location = new System.Drawing.Point(43, 3);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 74);
            this.btnAnswer.TabIndex = 12;
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDecline.BackgroundImage")));
            this.btnDecline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecline.Location = new System.Drawing.Point(124, 0);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(80, 71);
            this.btnDecline.TabIndex = 13;
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComments.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblComments.Location = new System.Drawing.Point(14, 115);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(86, 20);
            this.lblComments.TabIndex = 14;
            this.lblComments.Text = "Comments";
            // 
            // rtxtRemarks
            // 
            this.rtxtRemarks.Location = new System.Drawing.Point(18, 139);
            this.rtxtRemarks.Name = "rtxtRemarks";
            this.rtxtRemarks.Size = new System.Drawing.Size(345, 159);
            this.rtxtRemarks.TabIndex = 15;
            this.rtxtRemarks.Text = "";
            // 
            // callTime
            // 
            this.callTime.Interval = 1000;
            this.callTime.Tick += new System.EventHandler(this.callTime_Tick);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTimer.Location = new System.Drawing.Point(258, 7);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 13);
            this.lblTimer.TabIndex = 16;
            // 
            // CallSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(382, 413);
            this.Controls.Add(this.tabCall);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CallSimulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CallSimulator";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).EndInit();
            this.tabCall.ResumeLayout(false);
            this.callCreator.ResumeLayout(false);
            this.callCreator.PerformLayout();
            this.callHandler.ResumeLayout(false);
            this.callHandler.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.PictureBox picLogoSmall;
        private System.Windows.Forms.TabControl tabCall;
        private System.Windows.Forms.TabPage callCreator;
        private System.Windows.Forms.TabPage callHandler;
        private System.Windows.Forms.Label lblDialing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.RichTextBox rtxtRemarks;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.ComboBox cmbClientsHandler;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer callTime;
    }
}