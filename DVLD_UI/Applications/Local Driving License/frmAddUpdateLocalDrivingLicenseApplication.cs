using DVLD_Buisness;
using DVLD_UI.Applications.Controls;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {

        public enum enMode { AddNew = 1, Update };


        private enMode _Mode;
        private int _SelectedPersonID = -1;
        private int _LocalDrivingLicenseAppID = -1;

        private clsLocalDrivingLicenseApplication _LicenseApplication;


        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            _Mode = enMode.Update;
        }


        private bool _CheckPersonAge()
        {
            if (_SelectedPersonID != -1)
            {
                int MinimumAllowedAge = clsLicenseClass.Find(cbLicenseClass.Text).MinimumAllowedAge;
                if (DateTime.Now.Year - ctrlPersonWithfilter1.SelectedPersonInfo.DateOfBirth.Year 
                    < MinimumAllowedAge)
                {
                    MessageBox.Show("The selected person cannot have a " + cbLicenseClass.Text 
                        + " license his age is less than the minimum " +
                        ", he should be " + MinimumAllowedAge.ToString() + " Years", "Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnSave.Enabled = false;
                    cbLicenseClass.Focus();
                    return false;
                }
                else
                    if (_SelectedPersonID != -1)
                    { btnSave.Enabled = true; return true; }

                return false;

            }
            return false;
        }
        private void _FillComboBox()
        {
            DataTable dt = clsLicenseClass.GetLicenseClasses();
            dt.Rows.RemoveAt(7);
            foreach (DataRow row in dt.Rows)
                cbLicenseClass.Items.Add(row["ClassName"].ToString());

            

        }

        private void _ResetDefaultValues()
        {
            _FillComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblHeader.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonWithfilter1.FilterFocus();
                tbApplicationInfo.Enabled = false;

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblHeader.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tbApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {
            ctrlPersonWithfilter1.FilterEnabled = false;

            _LicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);

            if (_LicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseAppID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlPersonWithfilter1.LoadPersonInfo(_LicenseApplication.ApplicantPersonID);
            tbApplicationInfo.Enabled = true;
            btnSave.Enabled= true;
            lblID.Text = _LicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LicenseApplication.ApplicationDate.ToShortDateString();
            lblFees.Text=_LicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = _LicenseApplication.CreatedByUserInfo.UserName;
            //lblCreatedBy.Text=clsUser.FindByUserID(_LicenseApplication.CreatedByUserID).UserName;
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.Find(_LicenseApplication.LicenseClassID).ClassName);

        }

        private void _Next() 
        {

            if (_Mode == enMode.Update)
            {

                btnSave.Enabled = _CheckPersonAge();
                tbApplicationInfo.Enabled= true;    
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tbApplicationInfo"];
                return;
            }

            //incase add new
            if (ctrlPersonWithfilter1.PersonID != -1)
            {
                btnSave.Enabled = _CheckPersonAge();
                tbApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tbApplicationInfo"];
            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonWithfilter1.FilterFocus();
            }
        }



        private void _Save() 
        {
            int LicenseClassID=clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID,
                clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

            //check if the person already has an active application
            if(ActiveApplicationID != -1)
            {
                MessageBox.Show(@"Choose Another License Class, The selected Person Already Have An Activeapplication For The Selected Class With ID=" + ActiveApplicationID, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            //check if person already issued license for the same drivig class

            if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID,LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            _LicenseApplication.ApplicantPersonID = _SelectedPersonID;
            _LicenseApplication.ApplicationDate = DateTime.Now;
            _LicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LicenseApplication.LastStatusDate = DateTime.Now;
            _LicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LicenseApplication.LicenseClassID = LicenseClassID;

            if (_LicenseApplication.Save())
            {
                lblID.Text = _LicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblHeader.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private void DataBackEvent(object sender,int PersonID)
        {
            //Handle the data received

            _SelectedPersonID = PersonID;
            ctrlPersonWithfilter1.LoadPersonInfo(PersonID);
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();

            if(_Mode==enMode.Update)
                _LoadData();

        }

        private void ctrlPersonWithfilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID= obj;
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonWithfilter1.FilterFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _Save();
        }

        private void btnApplicationInfoNext_Click(object sender, EventArgs e)
        {
            _Next();
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            _CheckPersonAge();
        }

        private void tbApplicationInfo_Enter(object sender, EventArgs e)
        {
            _CheckPersonAge();
        }
    }
}
