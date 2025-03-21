using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Tests.Controls
{
    public partial class ctrlSchedualTest : UserControl
    {
        public  enum enMode { AddNew=1,Update};
        public enum enCreationMode { FirstTimeSchedule=0,RetakeTestSchedule};

        private enMode _Mode = enMode.AddNew;
       
        private enCreationMode _CreationMode=enCreationMode.FirstTimeSchedule;
       
        private clsTestType.enTestType _TestType=clsTestType.enTestType.VisionTest;
      
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
      
        private int _LocalDrivingLicenseApplicationID = -1;
      
        private clsTestAppointment _TestAppointment;
      
        private int _TestAppointmentID = -1;     

        //this property will be added as a misc in the design time 
        public clsTestType.enTestType TestType
        {
            get { return _TestType; }
            set
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbImage.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbImage.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbImage.Image = Resources.driving_test_512;
                            break;


                        }
                }
            }
        }


        public void _LoadInfo(int LocalDrivingLicenseApplicationID, int TestAppointmentID = -1)
        {

            //if no appointment id this means addnew otherwise it's update
            if (TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);



            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }


            //decide if the current mode is retake test or not based if the person attended this test before
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestType))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeAppFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblHeader.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";

            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRetakeAppFees.Text = "0";
                lblHeader.Text = "Schedule Test";
                lblRetakeTestAppID.Text = "N/A";
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;

            //this will show the trials for this test before
            byte trials = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestType);
            lblTrial.Text = trials==0?"First Time":trials.ToString();

            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(_TestType).Fees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointment();

            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentContstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;

        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();

            //we compare the current date to the appointment date to set the min date
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeTestAppID.Text = "N/A";
                lblRetakeAppFees.Text = "0";
                //gbRetakeTestInfo.Enabled = false;

            }
            else
            {
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString();
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblHeader.Text = "Schedule Retake Test";

            }
            return true;

        }

        private bool _HandleActiveTestAppointmentContstraint()
        {
            if (_Mode == enMode.AddNew && _LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Person already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            else
                lblMessage.Visible = false;

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {

            //if the appintment is locked that means that the person already sat for this test
            //we cannot update lockd appointment 
            if (_TestAppointment.IsLocked)
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Person already sat for this test, the appintment is locked";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            else
                lblMessage.Visible = false;

            return true;
        }

        private bool _HandlePreviousTestConstraint()
        {
            if (!_LocalDrivingLicenseApplication.DoesPassPreviousTest(_TestType))
            {
                lblMessage.Visible = true;
                btnSave.Enabled = false;
                switch (_TestType)
                {
                    case clsTestType.enTestType.WrittenTest:
                        lblMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        break;
                    case clsTestType.enTestType.StreetTest:
                        lblMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        break;

                }
                return false;
            }
            lblMessage.Visible = false;
            btnSave.Enabled = true;
            dtpTestDate.Enabled = true;

            return true;
        }

        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not
            //and will create it if needed, then link it to the appintment

            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {

                //incase the mode is add new and creation mode is retake test we should create a seperate application for it
                //then we link it with the appointment

                clsApplication Application = new clsApplication();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest).Fees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = 0;
                    MessageBox.Show("Faild to Create retake test application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }
            return true;
        }

        private void _Save()
        {
            if (!_HandleRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestType;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        public ctrlSchedualTest()
        {
            InitializeComponent();
            
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }
    }
}
