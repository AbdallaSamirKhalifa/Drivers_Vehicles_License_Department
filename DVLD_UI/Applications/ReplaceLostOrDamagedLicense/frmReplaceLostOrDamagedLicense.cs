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

namespace DVLD_UI.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {

        private int _NewLicenseID = -1;
        private clsLicense.enIssueReason _IssueReason = clsLicense.enIssueReason.DamagedReplacement;

        public clsLicense.enIssueReason IssueReason { 
            get 
            { 
                return _IssueReason;
            }
            set
            {
                _IssueReason = value;
                switch(_IssueReason)
                {
                    case clsLicense.enIssueReason.DamagedReplacement:
                        lblTitle.Text = "Replace For Damaged License";
                        this.Text = "Replace Damaged License";
                        lblApplicationFees.Text = clsApplicationType.Find
                            ((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();
                        break;
                    case clsLicense.enIssueReason.LostReplacement:
                        lblTitle.Text = "Replace For Lost License";
                        this.Text = "Replace Lost License";
                        lblApplicationFees.Text = clsApplicationType.Find
                            ((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).Fees.ToString();
                        break;
                }
            }
        }
        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            btnIssueReplacement.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            lblOldLicenseID.Text = "???";
        }
        private void _IssueLicense()
        {
            clsLicense NewLicense = 
                ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_IssueReason, clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Couldn't replace the license something went wrong, Please try again later", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            lblRreplacedLicenseID.Text = NewLicense.LicenseID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(),
                "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);


            gbReplacementFor.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnIssueReplacement.Enabled = false;
            llShowLicenseInfo.Enabled = true;


        }
        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            IssueReason = clsLicense.enIssueReason.DamagedReplacement;
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            IssueReason = clsLicense.enIssueReason.LostReplacement;

        }

        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Checked = true;

            _ResetDefaultValues();
        }


        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj == -1)
            {
                _ResetDefaultValues();

                return;
             }

            lblOldLicenseID.Text = obj.ToString();
            llShowLicenseHistory.Enabled = true;

            //not allowing replacement if not active
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {

                MessageBox.Show("The selected license is not active, Please select an active license", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            //not allowing replacement if expired
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("The selected license has expired, It need to be renewed", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            btnIssueReplacement.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm=new
                frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
        
           frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to replace this license", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _IssueLicense();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplaceLostOrDamagedLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
        }
    }
}
