  using DVLD_Buisness;
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

namespace DVLD_UI.Applications.Local_Driving_License
{
    public partial class ctrlDrivingLicenseApplication : UserControl
    {

        private clsLocalDrivingLicenseApplication _LDLApplication;

        private int _LocalDrivingLiceseApplicationID;

        public int LocalDrivingLicenseApplicationID { get { return _LocalDrivingLiceseApplicationID; } }


        public ctrlDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LDLApplication == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
                _FillApllicationData();

        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(ApplicationID);
            if (_LDLApplication== null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApllicationData();
        }
        private void _FillApllicationData()
        {

            llShowLicenceInfo.Enabled = _LDLApplication.IsLicenseIssued();

            _LocalDrivingLiceseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LDLApplication.ApplicationID);
            lblAppliedFor.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLiceseApplicationID.ToString();
            lblPassedTests.Text = _LDLApplication.GetPassedTestCount().ToString() + "/3";

        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLiceseApplicationID = -1;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedFor.Text = "[????]";

        }
        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             
            int LicenseID=_LDLApplication.GetActiveLicenseID();
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();

        }
    }
}
