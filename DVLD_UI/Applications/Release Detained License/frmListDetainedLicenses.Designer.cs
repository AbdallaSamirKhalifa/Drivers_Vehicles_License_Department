﻿namespace DVLD_UI.Applications.Release_Detained_License
{
    partial class frmListDetainedLicenses
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
            this.dgvListDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.cDetainID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDetainDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIsReleased = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cFineFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cReleaseApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.btnReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PesonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.cmsApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListDetainedLicenses
            // 
            this.dgvListDetainedLicenses.AllowUserToAddRows = false;
            this.dgvListDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvListDetainedLicenses.AllowUserToOrderColumns = true;
            this.dgvListDetainedLicenses.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDetainedLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDetainID,
            this.cLicenseID,
            this.cDetainDate,
            this.cIsReleased,
            this.cFineFees,
            this.cReleaseDate,
            this.cNationalNo,
            this.cFullName,
            this.cReleaseApplicationID});
            this.dgvListDetainedLicenses.ContextMenuStrip = this.cmsApplications;
            this.dgvListDetainedLicenses.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvListDetainedLicenses.Location = new System.Drawing.Point(11, 327);
            this.dgvListDetainedLicenses.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListDetainedLicenses.Name = "dgvListDetainedLicenses";
            this.dgvListDetainedLicenses.ReadOnly = true;
            this.dgvListDetainedLicenses.RowHeadersWidth = 51;
            this.dgvListDetainedLicenses.RowTemplate.Height = 24;
            this.dgvListDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListDetainedLicenses.Size = new System.Drawing.Size(1348, 314);
            this.dgvListDetainedLicenses.TabIndex = 3;
            // 
            // cDetainID
            // 
            this.cDetainID.DataPropertyName = "DetainID";
            this.cDetainID.HeaderText = "D.ID";
            this.cDetainID.MinimumWidth = 6;
            this.cDetainID.Name = "cDetainID";
            this.cDetainID.ReadOnly = true;
            this.cDetainID.Width = 90;
            // 
            // cLicenseID
            // 
            this.cLicenseID.DataPropertyName = "LicenseID";
            this.cLicenseID.HeaderText = "L.ID";
            this.cLicenseID.MinimumWidth = 6;
            this.cLicenseID.Name = "cLicenseID";
            this.cLicenseID.ReadOnly = true;
            this.cLicenseID.Width = 90;
            // 
            // cDetainDate
            // 
            this.cDetainDate.DataPropertyName = "DetainDate";
            this.cDetainDate.HeaderText = "D.Date";
            this.cDetainDate.MinimumWidth = 6;
            this.cDetainDate.Name = "cDetainDate";
            this.cDetainDate.ReadOnly = true;
            this.cDetainDate.Width = 160;
            // 
            // cIsReleased
            // 
            this.cIsReleased.DataPropertyName = "IsReleased";
            this.cIsReleased.HeaderText = "Is Released";
            this.cIsReleased.MinimumWidth = 6;
            this.cIsReleased.Name = "cIsReleased";
            this.cIsReleased.ReadOnly = true;
            this.cIsReleased.Width = 110;
            // 
            // cFineFees
            // 
            this.cFineFees.DataPropertyName = "FineFees";
            this.cFineFees.HeaderText = "Fine Fees";
            this.cFineFees.MinimumWidth = 6;
            this.cFineFees.Name = "cFineFees";
            this.cFineFees.ReadOnly = true;
            this.cFineFees.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cFineFees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cFineFees.Width = 110;
            // 
            // cReleaseDate
            // 
            this.cReleaseDate.DataPropertyName = "ReleaseDate";
            this.cReleaseDate.HeaderText = "Release Date";
            this.cReleaseDate.MinimumWidth = 6;
            this.cReleaseDate.Name = "cReleaseDate";
            this.cReleaseDate.ReadOnly = true;
            this.cReleaseDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cReleaseDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cReleaseDate.Width = 160;
            // 
            // cNationalNo
            // 
            this.cNationalNo.DataPropertyName = "NationalNo";
            this.cNationalNo.HeaderText = "N.No";
            this.cNationalNo.MinimumWidth = 6;
            this.cNationalNo.Name = "cNationalNo";
            this.cNationalNo.ReadOnly = true;
            this.cNationalNo.Width = 90;
            // 
            // cFullName
            // 
            this.cFullName.DataPropertyName = "FullName";
            this.cFullName.HeaderText = "Full Name";
            this.cFullName.MinimumWidth = 6;
            this.cFullName.Name = "cFullName";
            this.cFullName.ReadOnly = true;
            this.cFullName.Width = 330;
            // 
            // cReleaseApplicationID
            // 
            this.cReleaseApplicationID.DataPropertyName = "ReleaseApplicationID";
            this.cReleaseApplicationID.HeaderText = "Release App.ID";
            this.cReleaseApplicationID.MinimumWidth = 6;
            this.cReleaseApplicationID.Name = "cReleaseApplicationID";
            this.cReleaseApplicationID.ReadOnly = true;
            this.cReleaseApplicationID.Width = 150;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(385, 200);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(568, 42);
            this.lblTitle.TabIndex = 154;
            this.lblTitle.Text = "List Detained Licenses";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD_UI.Properties.Resources.Detain_512;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(567, 6);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 155;
            this.pbPersonImage.TabStop = false;
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseDetainedLicense.Image = global::DVLD_UI.Properties.Resources.Release_Detained_License_64;
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(1175, 247);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(88, 75);
            this.btnReleaseDetainedLicense.TabIndex = 162;
            this.btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetainLicense.Image = global::DVLD_UI.Properties.Resources.Detain_64;
            this.btnDetainLicense.Location = new System.Drawing.Point(1269, 247);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(88, 75);
            this.btnDetainLicense.TabIndex = 161;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(332, 297);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(121, 24);
            this.cbIsReleased.TabIndex = 166;
            this.cbIsReleased.Visible = false;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name",
            "Release Application ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(116, 297);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.cbFilterBy.TabIndex = 165;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(333, 298);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 22);
            this.txtFilterValue.TabIndex = 164;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 163;
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
            this.btnClose.Location = new System.Drawing.Point(1222, 646);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 36);
            this.btnClose.TabIndex = 167;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(134, 652);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(27, 20);
            this.lblTotalRecords.TabIndex = 169;
            this.lblTotalRecords.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 650);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 168;
            this.label5.Text = "# Records:";
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PesonDetailsToolStripMenuItem,
            this.showDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.toolStripMenuItem1,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(281, 190);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // PesonDetailsToolStripMenuItem
            // 
            this.PesonDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.PersonDetails_32;
            this.PesonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PesonDetailsToolStripMenuItem.Name = "PesonDetailsToolStripMenuItem";
            this.PesonDetailsToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.PesonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.PesonDetailsToolStripMenuItem.Click += new System.EventHandler(this.PesonDetailsToolStripMenuItem_Click);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.License_View_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.showDetailsToolStripMenuItem.Text = "&Show License Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(277, 6);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD_UI.Properties.Resources.Release_Detained_License_32;
            this.releaseDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(280, 38);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1369, 689);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReleaseDetainedLicense);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvListDetainedLicenses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmListDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDetainedLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListDetainedLicenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDetainID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDetainDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cIsReleased;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFineFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReleaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cReleaseApplicationID;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnReleaseDetainedLicense;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem PesonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}