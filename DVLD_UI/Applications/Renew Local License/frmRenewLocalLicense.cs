using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Renew_Local_License
{


    public partial class frmRenewLocalLicense : Form
    {

        private int _NewLicenseID = -1;
        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text=clsApplicationType.
                Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            btnRenewLicense.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = false;
        }

        private void _FillFormOnSelction()
        {
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.
                LicenseClassInfo.ClassFees.ToString();

            lblTotalFees.Text = 
                (Convert.ToSingle(lblApplicationFees.Text.Trim()) + Convert.ToSingle(lblLicenseFees.Text.Trim())).ToString();
            lblOldLicenseID.Text 
                = ctrlDriverLicenseInfoWithFilter1.LicenseID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString();

            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;
        }

        private void _RenewLicense()
        {
            int ActiveLicenseID = clsLicense.GetActiveLicenseIDByPersonID
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID,ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID);

            if (ActiveLicenseID != -1)
            {
                MessageBox.Show("The person already have an active license with ID = "+ActiveLicenseID.ToString(), "Not Allowed",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterFocus();
                return;
            }

            clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.
                RenewLicense(clsGlobal.CurrentUser.UserID,txtNotes.Text.Trim());

            if (NewLicense == null)
            {
                MessageBox.Show("Error: Couldn't renew license something went wrong please try agin later", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _NewLicenseID = NewLicense.LicenseID;
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();

            MessageBox.Show("License renewed successfully", "Renewd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRenewLicense.Enabled = false;

            llShowLicenseInfo.Enabled = true;
            txtNotes.Enabled = false;

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj == -1)
                return;


            llShowLicenseHistory.Enabled = true;
            _FillFormOnSelction();
            //Check if license is expired
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected license is not yet expired, It will expire on: " + ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString(),
                    "Not Allowed",MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                return;
            }

            //chek if license is expired
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selectes license is not active, Choose an active license", "Not allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                return;
            }
            btnRenewLicense.Enabled = true;
            
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this license", "Confitmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _RenewLicense();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);

            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();

        }

        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
        }

        private void frmRenewLocalLicense_Activated(object sender, EventArgs e)
        {

            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
