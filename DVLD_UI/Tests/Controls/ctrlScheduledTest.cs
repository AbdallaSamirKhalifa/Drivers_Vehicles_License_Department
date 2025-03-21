using DVLD_Buisness;
using DVLD_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        private int _TestID=-1;
        private int _AppointmentID=-1;
        private int _LocalDrivinLicenseApplicationID = -1;
        private clsTestAppointment _TestAppointment;
       private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsTestType.enTestType _TestType;
        public clsTestType.enTestType TestType
        {
            get{return _TestType; }
            set
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;

                            break;


                        }
                }
            }
        }


        public int TestID { get { return _TestID; } }

        public int AppointmentID { get { return _AppointmentID; } }

        public void LoadData(int AppointmentID)
        {
            _AppointmentID = AppointmentID;
            _TestAppointment = clsTestAppointment.Find(_AppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("No Appointment ID= " + _AppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _AppointmentID = -1;
                return;

            }

            _TestID = _TestAppointment.TestID;
            _LocalDrivinLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;


            _LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivinLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivinLicenseApplicationID.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivinLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLicenseApplication.PersonFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestType).ToString();
            
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            lblTestID.Text = (_TestAppointment.TestID == -1 ? "Not Taken Yet" : _TestAppointment.TestID.ToString());


        }

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }
    }
}
