using DVLD_UI.Applications.International_Licenses;
using DVLD_UI.Applications.Local_Driving_License;
using DVLD_UI.Applications.Release_Detained_License;
using DVLD_UI.Applications.Renew_Local_License;
using DVLD_UI.Applications.ReplaceLostOrDamagedLicense;
using DVLD_UI.ApplicationTypes;
using DVLD_UI.Drivers;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses.Detain_License;
using DVLD_UI.Tests;
using DVLD_UI.Users;
using DVLD_UI.Users.My_Controls;
using System;
using static DVLD_UI.GlobalClasses.clsGlobal;
using System.Windows.Forms;

namespace DVLD_UI.My_Forms
{

    public partial class DVLDMainForm : Form
    {
        private frmLogin _FrmLogin;
        public DVLDMainForm(frmLogin frmLogin)
        {
            InitializeComponent();
            _FrmLogin = frmLogin;

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ManagePeople frm = new frm_ManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = null;   
            _FrmLogin.Show();
            this.Close();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm
             = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();  
            frm.ShowDialog();
        }


        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication form=new frmAddUpdateLocalDrivingLicenseApplication();   
            form.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm=new frmListLocalDrivingLicenseApplications();    
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm=new frmListDrivers();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm =new frmListInternationalLicenses();   
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm=new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicense frm=new frmReplaceLostOrDamagedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm=new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm=new frmReleaseDetainedLicenseApplication();
            frm.Show();
        }

        private void releaseDetatainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.Show();
        }

        private void DVLDMainForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser.Permessions == -1)
                return;

            peopleToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManagePeople);
            driversToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageDrivers);
            usersToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageUsers);
            localLicenseToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageLocalLicenseApplications);
            internationalLicenseToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageInternationalLicenseApplications);
            renewDrivingLicenseToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.RenewDrivingLicense);
            replacementForLostOrDamagedLicenseToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ReplaceDrivingLicense);
            releaseDetatainedDrivingLicenseToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageDetainedLicenses);
            retakeTestToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageLocalLicenseApplications);
            localDrivingLicenseApplicationToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageLocalLicenseApplications);
            internationalLicenseApplicationToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageInternationalLicenseApplications);
            detainLicencesToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageDetainedLicenses);
            manageApplicationTypesToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageApplicationTypes);

            manageTestTypesToolStripMenuItem.Enabled = CheckPermesstions(enPersmessions.ManageTestTypes);

        }

        private void DVLDMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
