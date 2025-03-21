namespace DVLD_UI.Applications.Local_Driving_License
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.dgvListLocalDrivingLicenseApplication = new System.Windows.Forms.DataGridView();
            this.c_L_D_LAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cApplicationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPassedTestCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmsCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.schedualTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualWrrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualStreetTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.issuDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListLocalDrivingLicenseApplication)).BeginInit();
            this.cmsApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(339, 208);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(568, 50);
            this.lblTitle.TabIndex = 131;
            this.lblTitle.Text = "Local Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD_UI.Properties.Resources.Local_32;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(697, 81);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 133;
            this.pictureBox1.TabStop = false;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD_UI.Properties.Resources.Applications;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(521, 14);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 132;
            this.pbPersonImage.TabStop = false;
            // 
            // dgvListLocalDrivingLicenseApplication
            // 
            this.dgvListLocalDrivingLicenseApplication.AllowUserToAddRows = false;
            this.dgvListLocalDrivingLicenseApplication.AllowUserToDeleteRows = false;
            this.dgvListLocalDrivingLicenseApplication.AllowUserToOrderColumns = true;
            this.dgvListLocalDrivingLicenseApplication.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListLocalDrivingLicenseApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListLocalDrivingLicenseApplication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_L_D_LAppID,
            this.cClassName,
            this.cNationalNo,
            this.cFullName,
            this.cApplicationDate,
            this.cPassedTestCount,
            this.cStatus});
            this.dgvListLocalDrivingLicenseApplication.ContextMenuStrip = this.cmsApplications;
            this.dgvListLocalDrivingLicenseApplication.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvListLocalDrivingLicenseApplication.Location = new System.Drawing.Point(11, 345);
            this.dgvListLocalDrivingLicenseApplication.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListLocalDrivingLicenseApplication.Name = "dgvListLocalDrivingLicenseApplication";
            this.dgvListLocalDrivingLicenseApplication.ReadOnly = true;
            this.dgvListLocalDrivingLicenseApplication.RowHeadersWidth = 51;
            this.dgvListLocalDrivingLicenseApplication.RowTemplate.Height = 24;
            this.dgvListLocalDrivingLicenseApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListLocalDrivingLicenseApplication.Size = new System.Drawing.Size(1223, 314);
            this.dgvListLocalDrivingLicenseApplication.TabIndex = 134;
            this.dgvListLocalDrivingLicenseApplication.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListLocalDrivingLicenseApplication_CellContentDoubleClick);
            // 
            // c_L_D_LAppID
            // 
            this.c_L_D_LAppID.DataPropertyName = "LocalDrivingLicenseApplicationID";
            this.c_L_D_LAppID.HeaderText = "L.D.L AppID";
            this.c_L_D_LAppID.MinimumWidth = 6;
            this.c_L_D_LAppID.Name = "c_L_D_LAppID";
            this.c_L_D_LAppID.ReadOnly = true;
            this.c_L_D_LAppID.Width = 125;
            // 
            // cClassName
            // 
            this.cClassName.DataPropertyName = "ClassName";
            this.cClassName.HeaderText = "Class Name";
            this.cClassName.MinimumWidth = 6;
            this.cClassName.Name = "cClassName";
            this.cClassName.ReadOnly = true;
            this.cClassName.Width = 250;
            // 
            // cNationalNo
            // 
            this.cNationalNo.DataPropertyName = "NationalNo";
            this.cNationalNo.HeaderText = "National No";
            this.cNationalNo.MinimumWidth = 6;
            this.cNationalNo.Name = "cNationalNo";
            this.cNationalNo.ReadOnly = true;
            this.cNationalNo.Width = 125;
            // 
            // cFullName
            // 
            this.cFullName.DataPropertyName = "FullName";
            this.cFullName.HeaderText = "Full Name";
            this.cFullName.MinimumWidth = 6;
            this.cFullName.Name = "cFullName";
            this.cFullName.ReadOnly = true;
            this.cFullName.Width = 300;
            // 
            // cApplicationDate
            // 
            this.cApplicationDate.DataPropertyName = "ApplicationDate";
            this.cApplicationDate.HeaderText = "Application Date";
            this.cApplicationDate.MinimumWidth = 6;
            this.cApplicationDate.Name = "cApplicationDate";
            this.cApplicationDate.ReadOnly = true;
            this.cApplicationDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cApplicationDate.Width = 150;
            // 
            // cPassedTestCount
            // 
            this.cPassedTestCount.DataPropertyName = "PassedTestCount";
            this.cPassedTestCount.HeaderText = "Passed Tests";
            this.cPassedTestCount.MinimumWidth = 6;
            this.cPassedTestCount.Name = "cPassedTestCount";
            this.cPassedTestCount.ReadOnly = true;
            this.cPassedTestCount.Width = 125;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "status";
            this.cStatus.HeaderText = "Status";
            this.cStatus.MinimumWidth = 6;
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            this.cStatus.Width = 125;
            // 
            // cmsApplications
            // 
            this.cmsApplications.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripMenuItem3,
            this.tmsCancel,
            this.toolStripMenuItem2,
            this.schedualTestToolStripMenuItem,
            this.toolStripMenuItem4,
            this.issuDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showLicenseToolStripMenuItem,
            this.toolStripMenuItem6,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsApplications.Name = "cmsApplications";
            this.cmsApplications.Size = new System.Drawing.Size(340, 328);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.PersonDetails_32;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.showToolStripMenuItem.Text = "Show Application Details";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(336, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(336, 6);
            // 
            // tmsCancel
            // 
            this.tmsCancel.Image = global::DVLD_UI.Properties.Resources.Delete_32;
            this.tmsCancel.Name = "tmsCancel";
            this.tmsCancel.Size = new System.Drawing.Size(339, 36);
            this.tmsCancel.Text = "Cancel Application";
            this.tmsCancel.Click += new System.EventHandler(this.tmsCancel_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(336, 6);
            // 
            // schedualTestToolStripMenuItem
            // 
            this.schedualTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schedualVisionTestToolStripMenuItem,
            this.schedualWrrToolStripMenuItem,
            this.schedualStreetTToolStripMenuItem});
            this.schedualTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Schedule_Test_32;
            this.schedualTestToolStripMenuItem.Name = "schedualTestToolStripMenuItem";
            this.schedualTestToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.schedualTestToolStripMenuItem.Text = "Schedual Tests";
            // 
            // schedualVisionTestToolStripMenuItem
            // 
            this.schedualVisionTestToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Vision_Test_32;
            this.schedualVisionTestToolStripMenuItem.Name = "schedualVisionTestToolStripMenuItem";
            this.schedualVisionTestToolStripMenuItem.Size = new System.Drawing.Size(268, 36);
            this.schedualVisionTestToolStripMenuItem.Text = "Schedual Vision test";
            this.schedualVisionTestToolStripMenuItem.Click += new System.EventHandler(this.schedualVisionTestToolStripMenuItem_Click);
            // 
            // schedualWrrToolStripMenuItem
            // 
            this.schedualWrrToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Written_Test_32;
            this.schedualWrrToolStripMenuItem.Name = "schedualWrrToolStripMenuItem";
            this.schedualWrrToolStripMenuItem.Size = new System.Drawing.Size(268, 36);
            this.schedualWrrToolStripMenuItem.Text = "Schedual Written test";
            this.schedualWrrToolStripMenuItem.Click += new System.EventHandler(this.schedualWrrToolStripMenuItem_Click);
            // 
            // schedualStreetTToolStripMenuItem
            // 
            this.schedualStreetTToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Street_Test_32;
            this.schedualStreetTToolStripMenuItem.Name = "schedualStreetTToolStripMenuItem";
            this.schedualStreetTToolStripMenuItem.Size = new System.Drawing.Size(268, 36);
            this.schedualStreetTToolStripMenuItem.Text = "Schedual Street Test";
            this.schedualStreetTToolStripMenuItem.Click += new System.EventHandler(this.schedualStreetTToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(336, 6);
            // 
            // issuDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issuDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.IssueDrivingLicense_32;
            this.issuDrivingLicenseFirstTimeToolStripMenuItem.Name = "issuDrivingLicenseFirstTimeToolStripMenuItem";
            this.issuDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.issuDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            this.issuDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issuDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(336, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(336, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(339, 36);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.Image = global::DVLD_UI.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1145, 265);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(88, 75);
            this.btnAddNewApplication.TabIndex = 135;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(109, 312);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.cbFilterBy.TabIndex = 138;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(326, 312);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 22);
            this.txtFilterValue.TabIndex = 137;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 136;
            this.label1.Text = "Filter By:";
            // 
            // btnClose
            // 
            this.btnClose.AutoEllipsis = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD_UI.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1098, 664);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 139;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(119, 667);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(27, 20);
            this.lblRecordsCount.TabIndex = 141;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 667);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 140;
            this.label2.Text = "# Records:";
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1245, 712);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.dgvListLocalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListLocalDrivingLicenseApplication)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvListLocalDrivingLicenseApplication;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem schedualTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualWrrToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem issuDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tmsCancel;
        private System.Windows.Forms.ToolStripMenuItem schedualStreetTToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_L_D_LAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cApplicationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPassedTestCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
    }
}