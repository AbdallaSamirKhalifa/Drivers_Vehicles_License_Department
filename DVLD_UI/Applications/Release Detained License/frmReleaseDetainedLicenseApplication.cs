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

namespace DVLD_UI.Applications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {

        private int _SelectedLicenseID = -1;

        private void _ResetDefaultValues()
        {
            btnRelease.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;

            lblDetainID.Text = "???";
            lblDetainDate.Text = "??/??/????";

            lblTotalFees.Text = "0";
            lblLicenseID.Text = "???";
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblFineFees.Text = "0";
            lblApplicationID.Text = "???";

        }

        private void _ReleaseLicense()
        {
            int ApplicationID = -1;

            if(!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.
                ReleaseDetainedLicese(clsGlobal.CurrentUser.UserID,ref ApplicationID))
            {
                MessageBox.Show("Couldn't release license, Please try again later", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("License released successfully", "Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblApplicationID.Text = ApplicationID.ToString();

            llShowLicenseInfo.Enabled = true;
            btnRelease.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;

        }
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        
        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID=LicenseID;

        }

        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsApplicationType.Find
            ((int)clsApplication.enApplicationType.ReleaseDetainedLicense).Fees.ToString();


            _ResetDefaultValues();

            this.CenterToParent();
            
            if(_SelectedLicenseID!=-1)
            {
                ctrlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            }
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj == -1)
            {
                _ResetDefaultValues();
                return;

            }

            _SelectedLicenseID = obj;
            llShowLicenseHistory.Enabled = true;

            lblLicenseID.Text= _SelectedLicenseID.ToString();

            //check the license is detained 
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected license is not detained, Please select another one",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblDetainID.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.
                DetainedLicenseInfo.DetainID.ToString();
            lblDetainDate.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.
                DetainedLicenseInfo.DetainDate.ToShortDateString();

            lblFineFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.
                DetainedLicenseInfo.FineFees.ToString();

            lblTotalFees.Text = (Convert.ToSingle( lblApplicationFees.Text) +
                Convert.ToSingle(lblFineFees.Text)).ToString();


            btnRelease.Enabled = true;


        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _ReleaseLicense();
            
        }


        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1
                .SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
   

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectedLicenseID)
                ;
            frm.ShowDialog();
        }

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
