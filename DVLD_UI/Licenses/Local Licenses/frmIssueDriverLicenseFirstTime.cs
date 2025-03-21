using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        private bool _CheckApplication()
        {
            _LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.
                FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID); 



            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("No application with ID = " + _LocalDrivingLicenseApplicationID, "Not Allowed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int LicenseID=_LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("Person already have an active license from the same type license with ID =" + LicenseID.ToString(),
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;
        }

        private void _IssueLicense()
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime
                (txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License issued successfully with ID = " + LicenseID.ToString(), "Succeeded", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnIssueLicense.Enabled = false;
                txtNotes.Enabled = false;
            }
            else
                MessageBox.Show("License was not issued something went wrong", "Faild", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);


        
        }
        public frmIssueDriverLicenseFirstTime(int LocalDrivingLicenseApplicatioinID)
        {
            
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicatioinID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();
              
            if(_CheckApplication())
                ctrlDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseApplicationID);
            else
                this.Close();

        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        
        {
            if (MessageBox.Show("Are you sure you want to issue license", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            _IssueLicense();
        }
    }
}
