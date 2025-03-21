namespace DVLD_UI.Users
{
    partial class frmAddUpdateUser
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
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.epAddUpdate = new System.Windows.Forms.ErrorProvider(this.components);
            this.tpPermessions = new System.Windows.Forms.TabPage();
            this.gbPermessions = new System.Windows.Forms.GroupBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkManagePeople = new System.Windows.Forms.CheckBox();
            this.chkManageUsers = new System.Windows.Forms.CheckBox();
            this.chkManageLocalLicenseApplications = new System.Windows.Forms.CheckBox();
            this.chkManageApplicationTypes = new System.Windows.Forms.CheckBox();
            this.chkManageDetainedLicenses = new System.Windows.Forms.CheckBox();
            this.chkManageInternationalLicenseApplications = new System.Windows.Forms.CheckBox();
            this.chkManageTestTypes = new System.Windows.Forms.CheckBox();
            this.chkRenewDrivingLicense = new System.Windows.Forms.CheckBox();
            this.chkReplaceDrivingLicense = new System.Windows.Forms.CheckBox();
            this.chkManageDrivers = new System.Windows.Forms.CheckBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnPermessions = new System.Windows.Forms.Button();
            this.ctrlPersonWithfilter2 = new DVLD_UI.People.My_Controls.ctrlPersonWithfilter();
            this.tabControl1.SuspendLayout();
            this.tpPersonInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddUpdate)).BeginInit();
            this.tpPermessions.SuspendLayout();
            this.gbPermessions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::DVLD_UI.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(562, 675);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPersonInfo);
            this.tabControl1.Controls.Add(this.tpLoginInfo);
            this.tabControl1.Controls.Add(this.tpPermessions);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 86);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(964, 572);
            this.tabControl1.TabIndex = 3;
            // 
            // tpPersonInfo
            // 
            this.tpPersonInfo.BackColor = System.Drawing.Color.White;
            this.tpPersonInfo.Controls.Add(this.btnNext);
            this.tpPersonInfo.Controls.Add(this.ctrlPersonWithfilter2);
            this.tpPersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tpPersonInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tpPersonInfo.Name = "tpPersonInfo";
            this.tpPersonInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tpPersonInfo.Size = new System.Drawing.Size(956, 539);
            this.tpPersonInfo.TabIndex = 0;
            this.tpPersonInfo.Text = "Person Info";
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD_UI.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(828, 492);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 40);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.White;
            this.tpLoginInfo.Controls.Add(this.btnPermessions);
            this.tpLoginInfo.Controls.Add(this.chkIsActive);
            this.tpLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.txtUserName);
            this.tpLoginInfo.Controls.Add(this.pictureBox4);
            this.tpLoginInfo.Controls.Add(this.pictureBox3);
            this.tpLoginInfo.Controls.Add(this.pictureBox2);
            this.tpLoginInfo.Controls.Add(this.pictureBox1);
            this.tpLoginInfo.Controls.Add(this.label5);
            this.tpLoginInfo.Controls.Add(this.label4);
            this.tpLoginInfo.Controls.Add(this.label3);
            this.tpLoginInfo.Controls.Add(this.lblUserID);
            this.tpLoginInfo.Controls.Add(this.label1);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 29);
            this.tpLoginInfo.Margin = new System.Windows.Forms.Padding(4);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tpLoginInfo.Size = new System.Drawing.Size(956, 539);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsActive.Location = new System.Drawing.Point(266, 263);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(75, 24);
            this.chkIsActive.TabIndex = 13;
            this.chkIsActive.Text = "Status";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Location = new System.Drawing.Point(266, 209);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(187, 27);
            this.txtConfirmPassword.TabIndex = 12;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(266, 161);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(187, 27);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Location = new System.Drawing.Point(266, 113);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(187, 27);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_UI.Properties.Resources.Number_32;
            this.pictureBox4.Location = new System.Drawing.Point(211, 209);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_UI.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(211, 161);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_UI.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(211, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(211, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Name:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(262, 65);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(39, 20);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.DarkRed;
            this.lblHeader.Location = new System.Drawing.Point(361, 15);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(241, 38);
            this.lblHeader.TabIndex = 14;
            this.lblHeader.Text = "Add New User";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD_UI.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(279, 675);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 35);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // epAddUpdate
            // 
            this.epAddUpdate.ContainerControl = this;
            // 
            // tpPermessions
            // 
            this.tpPermessions.BackColor = System.Drawing.Color.White;
            this.tpPermessions.Controls.Add(this.btnPrev);
            this.tpPermessions.Controls.Add(this.chkAdmin);
            this.tpPermessions.Controls.Add(this.gbPermessions);
            this.tpPermessions.Location = new System.Drawing.Point(4, 29);
            this.tpPermessions.Name = "tpPermessions";
            this.tpPermessions.Padding = new System.Windows.Forms.Padding(3);
            this.tpPermessions.Size = new System.Drawing.Size(956, 539);
            this.tpPermessions.TabIndex = 2;
            this.tpPermessions.Text = "Permessions";
            // 
            // gbPermessions
            // 
            this.gbPermessions.Controls.Add(this.chkManageDrivers);
            this.gbPermessions.Controls.Add(this.chkReplaceDrivingLicense);
            this.gbPermessions.Controls.Add(this.chkRenewDrivingLicense);
            this.gbPermessions.Controls.Add(this.chkManageTestTypes);
            this.gbPermessions.Controls.Add(this.chkManageInternationalLicenseApplications);
            this.gbPermessions.Controls.Add(this.chkManageDetainedLicenses);
            this.gbPermessions.Controls.Add(this.chkManageApplicationTypes);
            this.gbPermessions.Controls.Add(this.chkManageLocalLicenseApplications);
            this.gbPermessions.Controls.Add(this.chkManageUsers);
            this.gbPermessions.Controls.Add(this.chkManagePeople);
            this.gbPermessions.Location = new System.Drawing.Point(23, 63);
            this.gbPermessions.Name = "gbPermessions";
            this.gbPermessions.Size = new System.Drawing.Size(901, 447);
            this.gbPermessions.TabIndex = 0;
            this.gbPermessions.TabStop = false;
            this.gbPermessions.Text = "Permessions";
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdmin.Location = new System.Drawing.Point(356, 24);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(235, 33);
            this.chkAdmin.TabIndex = 1;
            this.chkAdmin.Text = "Set User As Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // chkManagePeople
            // 
            this.chkManagePeople.AutoSize = true;
            this.chkManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManagePeople.Location = new System.Drawing.Point(81, 86);
            this.chkManagePeople.Name = "chkManagePeople";
            this.chkManagePeople.Size = new System.Drawing.Size(172, 29);
            this.chkManagePeople.TabIndex = 0;
            this.chkManagePeople.Tag = "ManagePeople";
            this.chkManagePeople.Text = "Manage People";
            this.chkManagePeople.UseVisualStyleBackColor = true;
            this.chkManagePeople.CheckedChanged += new System.EventHandler(this.chkManagePeople_CheckedChanged);
            // 
            // chkManageUsers
            // 
            this.chkManageUsers.AutoSize = true;
            this.chkManageUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageUsers.Location = new System.Drawing.Point(81, 156);
            this.chkManageUsers.Name = "chkManageUsers";
            this.chkManageUsers.Size = new System.Drawing.Size(162, 29);
            this.chkManageUsers.TabIndex = 1;
            this.chkManageUsers.Tag = "ManageUsers";
            this.chkManageUsers.Text = "Manage Users";
            this.chkManageUsers.UseVisualStyleBackColor = true;
            this.chkManageUsers.CheckedChanged += new System.EventHandler(this.chkManageUsers_CheckedChanged);
            // 
            // chkManageLocalLicenseApplications
            // 
            this.chkManageLocalLicenseApplications.AutoSize = true;
            this.chkManageLocalLicenseApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageLocalLicenseApplications.Location = new System.Drawing.Point(81, 226);
            this.chkManageLocalLicenseApplications.Name = "chkManageLocalLicenseApplications";
            this.chkManageLocalLicenseApplications.Size = new System.Drawing.Size(342, 29);
            this.chkManageLocalLicenseApplications.TabIndex = 2;
            this.chkManageLocalLicenseApplications.Tag = "ManageLocalLicenseApplications";
            this.chkManageLocalLicenseApplications.Text = "Manage Local License Applications";
            this.chkManageLocalLicenseApplications.UseVisualStyleBackColor = true;
            this.chkManageLocalLicenseApplications.CheckedChanged += new System.EventHandler(this.chkManageLocalLicenseApplications_CheckedChanged);
            // 
            // chkManageApplicationTypes
            // 
            this.chkManageApplicationTypes.AutoSize = true;
            this.chkManageApplicationTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageApplicationTypes.Location = new System.Drawing.Point(620, 86);
            this.chkManageApplicationTypes.Name = "chkManageApplicationTypes";
            this.chkManageApplicationTypes.Size = new System.Drawing.Size(267, 29);
            this.chkManageApplicationTypes.TabIndex = 3;
            this.chkManageApplicationTypes.Tag = "ManageApplicationTypes";
            this.chkManageApplicationTypes.Text = "Manage Application Types";
            this.chkManageApplicationTypes.UseVisualStyleBackColor = true;
            this.chkManageApplicationTypes.CheckedChanged += new System.EventHandler(this.chkManageApplicationTypes_CheckedChanged);
            // 
            // chkManageDetainedLicenses
            // 
            this.chkManageDetainedLicenses.AutoSize = true;
            this.chkManageDetainedLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageDetainedLicenses.Location = new System.Drawing.Point(81, 366);
            this.chkManageDetainedLicenses.Name = "chkManageDetainedLicenses";
            this.chkManageDetainedLicenses.Size = new System.Drawing.Size(272, 29);
            this.chkManageDetainedLicenses.TabIndex = 4;
            this.chkManageDetainedLicenses.Tag = "ManageDetainedLicenses";
            this.chkManageDetainedLicenses.Text = "Manage Detained Licenses";
            this.chkManageDetainedLicenses.UseVisualStyleBackColor = true;
            this.chkManageDetainedLicenses.CheckedChanged += new System.EventHandler(this.chkManageDetainedLicenses_CheckedChanged);
            // 
            // chkManageInternationalLicenseApplications
            // 
            this.chkManageInternationalLicenseApplications.AutoSize = true;
            this.chkManageInternationalLicenseApplications.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageInternationalLicenseApplications.Location = new System.Drawing.Point(81, 296);
            this.chkManageInternationalLicenseApplications.Name = "chkManageInternationalLicenseApplications";
            this.chkManageInternationalLicenseApplications.Size = new System.Drawing.Size(401, 29);
            this.chkManageInternationalLicenseApplications.TabIndex = 5;
            this.chkManageInternationalLicenseApplications.Tag = "ManageInternationalLicenseApplications";
            this.chkManageInternationalLicenseApplications.Text = "Manage International License Applications";
            this.chkManageInternationalLicenseApplications.UseVisualStyleBackColor = true;
            this.chkManageInternationalLicenseApplications.CheckedChanged += new System.EventHandler(this.chkManageInternationalLicenseApplications_CheckedChanged);
            // 
            // chkManageTestTypes
            // 
            this.chkManageTestTypes.AutoSize = true;
            this.chkManageTestTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageTestTypes.Location = new System.Drawing.Point(620, 156);
            this.chkManageTestTypes.Name = "chkManageTestTypes";
            this.chkManageTestTypes.Size = new System.Drawing.Size(210, 29);
            this.chkManageTestTypes.TabIndex = 6;
            this.chkManageTestTypes.Tag = "ManageTestTypes";
            this.chkManageTestTypes.Text = "Manage Test Types";
            this.chkManageTestTypes.UseVisualStyleBackColor = true;
            this.chkManageTestTypes.CheckedChanged += new System.EventHandler(this.chkManageTestTypes_CheckedChanged);
            // 
            // chkRenewDrivingLicense
            // 
            this.chkRenewDrivingLicense.AutoSize = true;
            this.chkRenewDrivingLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRenewDrivingLicense.Location = new System.Drawing.Point(620, 226);
            this.chkRenewDrivingLicense.Name = "chkRenewDrivingLicense";
            this.chkRenewDrivingLicense.Size = new System.Drawing.Size(232, 29);
            this.chkRenewDrivingLicense.TabIndex = 7;
            this.chkRenewDrivingLicense.Tag = "RenewDrivingLicense";
            this.chkRenewDrivingLicense.Text = "Renew Driving License";
            this.chkRenewDrivingLicense.UseVisualStyleBackColor = true;
            this.chkRenewDrivingLicense.CheckedChanged += new System.EventHandler(this.chkRenewDrivingLicense_CheckedChanged);
            // 
            // chkReplaceDrivingLicense
            // 
            this.chkReplaceDrivingLicense.AutoSize = true;
            this.chkReplaceDrivingLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReplaceDrivingLicense.Location = new System.Drawing.Point(620, 296);
            this.chkReplaceDrivingLicense.Name = "chkReplaceDrivingLicense";
            this.chkReplaceDrivingLicense.Size = new System.Drawing.Size(243, 29);
            this.chkReplaceDrivingLicense.TabIndex = 8;
            this.chkReplaceDrivingLicense.Tag = "ReplaceDrivingLicense";
            this.chkReplaceDrivingLicense.Text = "Replace Driving License";
            this.chkReplaceDrivingLicense.UseVisualStyleBackColor = true;
            this.chkReplaceDrivingLicense.CheckedChanged += new System.EventHandler(this.chkReplaceDrivingLicense_CheckedChanged);
            // 
            // chkManageDrivers
            // 
            this.chkManageDrivers.AutoSize = true;
            this.chkManageDrivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManageDrivers.Location = new System.Drawing.Point(620, 366);
            this.chkManageDrivers.Name = "chkManageDrivers";
            this.chkManageDrivers.Size = new System.Drawing.Size(172, 29);
            this.chkManageDrivers.TabIndex = 9;
            this.chkManageDrivers.Tag = "ManageDrivers";
            this.chkManageDrivers.Text = "Manage Drivers";
            this.chkManageDrivers.UseVisualStyleBackColor = true;
            this.chkManageDrivers.CheckedChanged += new System.EventHandler(this.chkManageDrivers_CheckedChanged);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::DVLD_UI.Properties.Resources.Prev_32;
            this.btnPrev.Location = new System.Drawing.Point(23, 6);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(61, 51);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnPermessions
            // 
            this.btnPermessions.Image = global::DVLD_UI.Properties.Resources.Next_32;
            this.btnPermessions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPermessions.Location = new System.Drawing.Point(759, 496);
            this.btnPermessions.Name = "btnPermessions";
            this.btnPermessions.Size = new System.Drawing.Size(179, 36);
            this.btnPermessions.TabIndex = 14;
            this.btnPermessions.Text = "Permessions";
            this.btnPermessions.UseVisualStyleBackColor = true;
            this.btnPermessions.Click += new System.EventHandler(this.btnPermessions_Click);
            // 
            // ctrlPersonWithfilter2
            // 
            this.ctrlPersonWithfilter2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ctrlPersonWithfilter2.FilterEnabled = true;
            this.ctrlPersonWithfilter2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonWithfilter2.Location = new System.Drawing.Point(8, 19);
            this.ctrlPersonWithfilter2.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonWithfilter2.Name = "ctrlPersonWithfilter2";
            this.ctrlPersonWithfilter2.ShowAddPersonBtn = true;
            this.ctrlPersonWithfilter2.Size = new System.Drawing.Size(933, 455);
            this.ctrlPersonWithfilter2.TabIndex = 0;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(984, 722);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Update User";
            this.Activated += new System.EventHandler(this.frmAddUpdateUser_Activated);
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPersonInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epAddUpdate)).EndInit();
            this.tpPermessions.ResumeLayout(false);
            this.tpPermessions.PerformLayout();
            this.gbPermessions.ResumeLayout(false);
            this.gbPermessions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private People.My_Controls.ctrlPersonWithfilter ctrlPersonWithfilter2;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ErrorProvider epAddUpdate;
        private System.Windows.Forms.TabPage tpPermessions;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.GroupBox gbPermessions;
        private System.Windows.Forms.CheckBox chkManageDrivers;
        private System.Windows.Forms.CheckBox chkReplaceDrivingLicense;
        private System.Windows.Forms.CheckBox chkRenewDrivingLicense;
        private System.Windows.Forms.CheckBox chkManageTestTypes;
        private System.Windows.Forms.CheckBox chkManageInternationalLicenseApplications;
        private System.Windows.Forms.CheckBox chkManageDetainedLicenses;
        private System.Windows.Forms.CheckBox chkManageApplicationTypes;
        private System.Windows.Forms.CheckBox chkManageLocalLicenseApplications;
        private System.Windows.Forms.CheckBox chkManageUsers;
        private System.Windows.Forms.CheckBox chkManagePeople;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPermessions;
    }
}