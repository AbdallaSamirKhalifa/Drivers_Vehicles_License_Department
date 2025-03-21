using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Tests
{
    public partial class frmSchedualTest : Form
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        int _AppointmentID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public frmSchedualTest(int LocalDrivingLicenseApplicationID,clsTestType.enTestType TestTypeID,int AppointmentID=-1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _TestTypeID= TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmSchedualTest_Load(object sender, EventArgs e)
        {
            ctrlSchedualTest1.TestType = _TestTypeID;
            ctrlSchedualTest1._LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }
    }
}
