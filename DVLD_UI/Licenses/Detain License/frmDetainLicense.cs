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

namespace DVLD_UI.Licenses.Detain_License
{
    public partial class frmDetainLicense : Form
    {

        private int _SelectedLicenseID = -1;

        private void _ResetDefaultValues()
        {
            lblDetainID.Text = "???";
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblLicenseID.Text= "???";
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            btnDetain.Enabled = false;



        }

        private void _DetaineLicense()
        {
             int DetainedLicenseID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text),
                clsGlobal.CurrentUser.UserID);

            if (DetainedLicenseID == -1)
            {
                MessageBox.Show("Failed to detain this license, Please try again later", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainID.Text = DetainedLicenseID.ToString();

            MessageBox.Show("License Detained successfully", "Detained",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


            btnDetain.Enabled = false;
            llShowLicenseInfo.Enabled = true;
            txtFineFees.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;

        }
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
            _ResetDefaultValues();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (obj == -1)
            {
                _ResetDefaultValues();
                return;
            }

            lblLicenseID.Text =(_SelectedLicenseID = obj).ToString();
            llShowLicenseHistory.Enabled = true;
            

            //make sure the license is active
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected license is not active, Please choose an active one.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //make sure the license is not already detained
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected license is alredey detained, Please release the license first.", "Not Allowed",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            btnDetain.Enabled = true;
        }


        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "This filed cannot be empty");
            }
            else
                errorProvider1.SetError(txtFineFees, null);

            
            
            if (clsValidation.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number");
            }
            else
                errorProvider1.SetError(txtFineFees, null);

            
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid, please hover the red alarm to see the error",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _DetaineLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
        }
    }
}
