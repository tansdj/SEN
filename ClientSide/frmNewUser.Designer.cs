namespace ClientSide
{
    partial class frmNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewUser));
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
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.lblAutoPw = new System.Windows.Forms.Label();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.btnGenPw = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblReEnter = new System.Windows.Forms.Label();
            this.txtRePw = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cmbAccess = new System.Windows.Forms.ComboBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAccess = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ttUsers = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMenu.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.gbUserInfo.SuspendLayout();
            this.gbLogin.SuspendLayout();
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
            this.btnCall.Location = new System.Drawing.Point(186, 485);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(54, 49);
            this.btnCall.TabIndex = 5;
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
            this.btnHome.Location = new System.Drawing.Point(0, 98);
            this.btnHome.Name = "btnHome";
            this.btnHome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnHome.Size = new System.Drawing.Size(243, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "        Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
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
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
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
            this.btnClose.TabIndex = 6;
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
            this.btnLoginLogout.Location = new System.Drawing.Point(763, 42);
            this.btnLoginLogout.Name = "btnLoginLogout";
            this.btnLoginLogout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLoginLogout.Size = new System.Drawing.Size(122, 50);
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
            this.lblDash.Size = new System.Drawing.Size(256, 48);
            this.lblDash.TabIndex = 4;
            this.lblDash.Text = "New User";
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
            // gbUserInfo
            // 
            this.gbUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.gbUserInfo.Controls.Add(this.lblAutoPw);
            this.gbUserInfo.Controls.Add(this.gbLogin);
            this.gbUserInfo.Controls.Add(this.cmbAccess);
            this.gbUserInfo.Controls.Add(this.txtSurname);
            this.gbUserInfo.Controls.Add(this.txtName);
            this.gbUserInfo.Controls.Add(this.lblAccess);
            this.gbUserInfo.Controls.Add(this.lblSurname);
            this.gbUserInfo.Controls.Add(this.lblName);
            this.gbUserInfo.Controls.Add(this.txtEmail);
            this.gbUserInfo.Controls.Add(this.lblEmail);
            this.gbUserInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbUserInfo.ForeColor = System.Drawing.Color.Snow;
            this.gbUserInfo.Location = new System.Drawing.Point(254, 120);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(619, 233);
            this.gbUserInfo.TabIndex = 5;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "User Information";
            // 
            // lblAutoPw
            // 
            this.lblAutoPw.AutoSize = true;
            this.lblAutoPw.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoPw.Location = new System.Drawing.Point(304, 199);
            this.lblAutoPw.Name = "lblAutoPw";
            this.lblAutoPw.Size = new System.Drawing.Size(127, 16);
            this.lblAutoPw.TabIndex = 17;
            this.lblAutoPw.Text = "Password Generation";
            // 
            // gbLogin
            // 
            this.gbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLogin.BackColor = System.Drawing.Color.Transparent;
            this.gbLogin.Controls.Add(this.btnGenPw);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Controls.Add(this.lblReEnter);
            this.gbLogin.Controls.Add(this.txtRePw);
            this.gbLogin.Controls.Add(this.txtPassword);
            this.gbLogin.Controls.Add(this.txtUsername);
            this.gbLogin.Controls.Add(this.lblUsername);
            this.gbLogin.ForeColor = System.Drawing.Color.Snow;
            this.gbLogin.Location = new System.Drawing.Point(301, 19);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(312, 177);
            this.gbLogin.TabIndex = 9;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login";
            // 
            // btnGenPw
            // 
            this.btnGenPw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenPw.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGenPw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenPw.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenPw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGenPw.Location = new System.Drawing.Point(63, 137);
            this.btnGenPw.Name = "btnGenPw";
            this.btnGenPw.Size = new System.Drawing.Size(215, 34);
            this.btnGenPw.TabIndex = 16;
            this.btnGenPw.Text = "Generate Strong Password";
            this.ttUsers.SetToolTip(this.btnGenPw, "Let the system create a randomized strong password.");
            this.btnGenPw.UseVisualStyleBackColor = false;
            this.btnGenPw.Click += new System.EventHandler(this.btnGenPw_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(28, 55);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 16);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // lblReEnter
            // 
            this.lblReEnter.AutoSize = true;
            this.lblReEnter.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReEnter.Location = new System.Drawing.Point(24, 86);
            this.lblReEnter.Name = "lblReEnter";
            this.lblReEnter.Size = new System.Drawing.Size(65, 32);
            this.lblReEnter.TabIndex = 5;
            this.lblReEnter.Text = "Re - enter\r\nPassword:";
            // 
            // txtRePw
            // 
            this.txtRePw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRePw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRePw.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRePw.ForeColor = System.Drawing.Color.Snow;
            this.txtRePw.Location = new System.Drawing.Point(99, 86);
            this.txtRePw.Name = "txtRePw";
            this.txtRePw.Size = new System.Drawing.Size(202, 26);
            this.txtRePw.TabIndex = 4;
            this.txtRePw.UseSystemPasswordChar = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Snow;
            this.txtPassword.Location = new System.Drawing.Point(99, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(202, 26);
            this.txtPassword.TabIndex = 3;
            this.ttUsers.SetToolTip(this.txtPassword, "Password should contains exactly 8 characters and must consist of digits, special" +
        " character, lower and uppercase characters.");
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Snow;
            this.txtUsername.Location = new System.Drawing.Point(99, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(202, 26);
            this.txtUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(24, 19);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(69, 16);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // cmbAccess
            // 
            this.cmbAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbAccess.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccess.ForeColor = System.Drawing.Color.Snow;
            this.cmbAccess.FormattingEnabled = true;
            this.cmbAccess.Items.AddRange(new object[] {
            "Standard",
            "Admin"});
            this.cmbAccess.Location = new System.Drawing.Point(80, 132);
            this.cmbAccess.Name = "cmbAccess";
            this.cmbAccess.Size = new System.Drawing.Size(202, 29);
            this.cmbAccess.TabIndex = 7;
            this.cmbAccess.Text = "None Selected";
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSurname.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.ForeColor = System.Drawing.Color.Snow;
            this.txtSurname.Location = new System.Drawing.Point(80, 64);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(202, 26);
            this.txtSurname.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtName.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.Snow;
            this.txtName.Location = new System.Drawing.Point(80, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(202, 26);
            this.txtName.TabIndex = 5;
            // 
            // lblAccess
            // 
            this.lblAccess.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccess.Location = new System.Drawing.Point(25, 132);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(47, 42);
            this.lblAccess.TabIndex = 4;
            this.lblAccess.Text = "Access Level:";
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(12, 67);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(62, 16);
            this.lblSurname.TabIndex = 3;
            this.lblSurname.Text = "Surname:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(29, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtEmail.Font = new System.Drawing.Font("Franklin Gothic Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Snow;
            this.txtEmail.Location = new System.Drawing.Point(80, 96);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(202, 26);
            this.txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(29, 99);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(43, 16);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.AutoSize = true;
            this.btnAddUser.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddUser.Location = new System.Drawing.Point(720, 482);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(153, 43);
            this.btnAddUser.TabIndex = 10;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(561, 482);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 42);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ttUsers
            // 
            this.ttUsers.ToolTipTitle = "Password Creation";
            // 
            // frmNewUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(885, 537);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbUserInfo);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.picLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMenu.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.ComboBox cmbAccess;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblReEnter;
        private System.Windows.Forms.TextBox txtRePw;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGenPw;
        private System.Windows.Forms.Label lblAutoPw;
        private System.Windows.Forms.ToolTip ttUsers;
    }
}

