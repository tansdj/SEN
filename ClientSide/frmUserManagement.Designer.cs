﻿namespace ClientSide
{
    partial class frmUserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserManagement));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnTecManagement = new System.Windows.Forms.Button();
            this.btnProdManagement = new System.Windows.Forms.Button();
            this.btnClientManagement = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoginLogout = new System.Windows.Forms.Button();
            this.lblDash = new System.Windows.Forms.Label();
            this.picLogoSmall = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.pnlMenu.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMenu.Controls.Add(this.btnCall);
            this.pnlMenu.Controls.Add(this.btnHome);
            this.pnlMenu.Controls.Add(this.btnUserManagement);
            this.pnlMenu.Controls.Add(this.btnTecManagement);
            this.pnlMenu.Controls.Add(this.btnProdManagement);
            this.pnlMenu.Controls.Add(this.btnClientManagement);
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(243, 537);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnCall
            // 
            this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCall.BackgroundImage")));
            this.btnCall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCall.Location = new System.Drawing.Point(186, 488);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(54, 49);
            this.btnCall.TabIndex = 6;
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Copperplate Gothic Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 108);
            this.btnHome.Name = "btnHome";
            this.btnHome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHome.Size = new System.Drawing.Size(243, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "        Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUserManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Copperplate Gothic Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnUserManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnUserManagement.Image")));
            this.btnUserManagement.Location = new System.Drawing.Point(0, 406);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnUserManagement.Size = new System.Drawing.Size(243, 64);
            this.btnUserManagement.TabIndex = 4;
            this.btnUserManagement.Text = "       User             Management";
            this.btnUserManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserManagement.UseVisualStyleBackColor = true;
            // 
            // btnTecManagement
            // 
            this.btnTecManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTecManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTecManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTecManagement.Font = new System.Drawing.Font("Copperplate Gothic Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTecManagement.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnTecManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnTecManagement.Image")));
            this.btnTecManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTecManagement.Location = new System.Drawing.Point(0, 310);
            this.btnTecManagement.Name = "btnTecManagement";
            this.btnTecManagement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnTecManagement.Size = new System.Drawing.Size(243, 90);
            this.btnTecManagement.TabIndex = 3;
            this.btnTecManagement.Text = "        Employee   Management";
            this.btnTecManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTecManagement.UseVisualStyleBackColor = true;
            this.btnTecManagement.Click += new System.EventHandler(this.btnTecManagement_Click);
            // 
            // btnProdManagement
            // 
            this.btnProdManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProdManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProdManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdManagement.Font = new System.Drawing.Font("Copperplate Gothic Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdManagement.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnProdManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnProdManagement.Image")));
            this.btnProdManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdManagement.Location = new System.Drawing.Point(0, 231);
            this.btnProdManagement.Name = "btnProdManagement";
            this.btnProdManagement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnProdManagement.Size = new System.Drawing.Size(243, 73);
            this.btnProdManagement.TabIndex = 2;
            this.btnProdManagement.Text = "       Product     Management";
            this.btnProdManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProdManagement.UseVisualStyleBackColor = true;
            this.btnProdManagement.Click += new System.EventHandler(this.btnProdManagement_Click);
            // 
            // btnClientManagement
            // 
            this.btnClientManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClientManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClientManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientManagement.Font = new System.Drawing.Font("Copperplate Gothic Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientManagement.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnClientManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnClientManagement.Image")));
            this.btnClientManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientManagement.Location = new System.Drawing.Point(0, 154);
            this.btnClientManagement.Name = "btnClientManagement";
            this.btnClientManagement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClientManagement.Size = new System.Drawing.Size(243, 71);
            this.btnClientManagement.TabIndex = 1;
            this.btnClientManagement.Text = "        Client          Management";
            this.btnClientManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientManagement.UseVisualStyleBackColor = true;
            this.btnClientManagement.Click += new System.EventHandler(this.btnClientManagement_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.btnLoginLogout);
            this.pnlTop.Controls.Add(this.lblDash);
            this.pnlTop.Controls.Add(this.picLogoSmall);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(885, 92);
            this.pnlTop.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnClose.Location = new System.Drawing.Point(845, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "X";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoginLogout
            // 
            this.btnLoginLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoginLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLoginLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoginLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginLogout.Font = new System.Drawing.Font("Copperplate Gothic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginLogout.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnLoginLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoginLogout.Location = new System.Drawing.Point(761, 42);
            this.btnLoginLogout.Name = "btnLoginLogout";
            this.btnLoginLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLoginLogout.Size = new System.Drawing.Size(124, 50);
            this.btnLoginLogout.TabIndex = 5;
            this.btnLoginLogout.Text = "Logout";
            this.btnLoginLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLoginLogout.UseVisualStyleBackColor = true;
            this.btnLoginLogout.Click += new System.EventHandler(this.btnLoginLogout_Click);
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Font = new System.Drawing.Font("Copperplate Gothic Bold", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDash.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDash.Location = new System.Drawing.Point(92, 33);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(462, 48);
            this.lblDash.TabIndex = 4;
            this.lblDash.Text = "User Management";
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
            // 
            // picLogo
            // 
            this.picLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(239, 62);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(634, 463);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewUser.AutoSize = true;
            this.btnNewUser.BackColor = System.Drawing.Color.YellowGreen;
            this.btnNewUser.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNewUser.Location = new System.Drawing.Point(262, 116);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(202, 148);
            this.btnNewUser.TabIndex = 5;
            this.btnNewUser.Text = "Add new User";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditUser.AutoSize = true;
            this.btnEditUser.BackColor = System.Drawing.Color.YellowGreen;
            this.btnEditUser.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEditUser.Location = new System.Drawing.Point(485, 116);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(180, 148);
            this.btnEditUser.TabIndex = 6;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveUser.AutoSize = true;
            this.btnRemoveUser.BackColor = System.Drawing.Color.YellowGreen;
            this.btnRemoveUser.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRemoveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoveUser.Location = new System.Drawing.Point(684, 116);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(189, 148);
            this.btnRemoveUser.TabIndex = 7;
            this.btnRemoveUser.Text = "Remove User";
            this.btnRemoveUser.UseVisualStyleBackColor = false;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // frmUserManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(885, 537);
            this.Controls.Add(this.btnRemoveUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMenu.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox picLogoSmall;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnTecManagement;
        private System.Windows.Forms.Button btnProdManagement;
        private System.Windows.Forms.Button btnClientManagement;
        private System.Windows.Forms.Button btnLoginLogout;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnRemoveUser;
    }
}

