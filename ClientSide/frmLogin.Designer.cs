namespace ClientSide
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDash = new System.Windows.Forms.Label();
            this.picLogoSmall = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblFormCommand = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRecPw = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTop.Controls.Add(this.lblDash);
            this.pnlTop.Controls.Add(this.picLogoSmall);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(504, 92);
            this.pnlTop.TabIndex = 1;
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Copperplate Gothic Bold", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDash.Location = new System.Drawing.Point(92, 33);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(293, 48);
            this.lblDash.TabIndex = 4;
            this.lblDash.Text = "Dashboard";
            // 
            // picLogoSmall
            // 
            this.picLogoSmall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogoSmall.BackgroundImage")));
            this.picLogoSmall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogoSmall.Cursor = System.Windows.Forms.Cursors.Default;
            this.picLogoSmall.Location = new System.Drawing.Point(3, 0);
            this.picLogoSmall.Name = "picLogoSmall";
            this.picLogoSmall.Size = new System.Drawing.Size(83, 81);
            this.picLogoSmall.TabIndex = 3;
            this.picLogoSmall.TabStop = false;
            this.picLogoSmall.Click += new System.EventHandler(this.picLogoSmall_Click);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(12, 84);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(430, 355);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblFormCommand
            // 
            this.lblFormCommand.AutoSize = true;
            this.lblFormCommand.BackColor = System.Drawing.Color.Transparent;
            this.lblFormCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFormCommand.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormCommand.ForeColor = System.Drawing.Color.YellowGreen;
            this.lblFormCommand.Location = new System.Drawing.Point(28, 104);
            this.lblFormCommand.Name = "lblFormCommand";
            this.lblFormCommand.Size = new System.Drawing.Size(212, 25);
            this.lblFormCommand.TabIndex = 18;
            this.lblFormCommand.Text = "Enter Login Details:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(61, 212);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 16);
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Snow;
            this.txtPassword.Location = new System.Drawing.Point(132, 207);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(225, 26);
            this.txtPassword.TabIndex = 21;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Snow;
            this.txtUsername.Location = new System.Drawing.Point(132, 173);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(225, 26);
            this.txtUsername.TabIndex = 20;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(57, 176);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(69, 16);
            this.lblUsername.TabIndex = 19;
            this.lblUsername.Text = "Username:";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.YellowGreen;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.Location = new System.Drawing.Point(232, 304);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(153, 43);
            this.btnLogin.TabIndex = 24;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRecPw
            // 
            this.btnRecPw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecPw.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRecPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecPw.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecPw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecPw.Location = new System.Drawing.Point(53, 305);
            this.btnRecPw.Name = "btnRecPw";
            this.btnRecPw.Size = new System.Drawing.Size(173, 42);
            this.btnRecPw.TabIndex = 23;
            this.btnRecPw.Text = "Recover Password";
            this.btnRecPw.UseVisualStyleBackColor = false;
            this.btnRecPw.Click += new System.EventHandler(this.btnRecPw_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(504, 436);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRecPw);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblFormCommand);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogoSmall;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.Label lblFormCommand;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRecPw;
    }
}

