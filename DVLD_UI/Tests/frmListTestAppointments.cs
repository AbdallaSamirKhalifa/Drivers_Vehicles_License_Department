using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Tests
{

    
    public partial class frmListTestAppointments : Form
    {

        private clsTestType.enTestType _TestType;
        private int _LocalDrivingLicenseAppID;
        private DataTable _dtAppointments;

        public frmListTestAppointments(int localDrivingLicenseAppID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = localDrivingLicenseAppID;
            _TestType= TestType;   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {
                case clsTestType.enTestType.VisionTest:
                    this.Text =  lblHeader.Text = "Vision Test Appointments";
                    pbImage.Image = Properties.Resources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    this.Text =  lblHeader.Text = "Written Test Appointments";
                    pbImage.Image = Properties.Resources.Written_Test_512;
                    break;

                case clsTestType.enTestType.StreetTest:
                    this.Text =lblHeader.Text = "Street Test Appointments" ;
                    pbImage.Image = Properties.Resources.driving_test_512;
                    break;
            }
        }
        private void _RefreshList()
        {

            ctrlDrivingLicenseApplication1.LoadApplicationInfoByLocalDrivingAppID(_LocalDrivingLicenseAppID);
            _dtAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseAppID, _TestType);
            dgvListAppointments.DataSource = _dtAppointments;

            lblRecordsCount.Text=dgvListAppointments.RowCount.ToString();


        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            _RefreshList();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication Local = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);

            if (Local.IsThereAnActiveScheduledTest(_TestType))
            {

                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsTest LastTest=Local.GetLatTestPerTestType(_TestType);

            if(LastTest  == null)
            {
                frmSchedualTest frm = new frmSchedualTest(_LocalDrivingLicenseAppID,_TestType);
                frm.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;

            }

            if (LastTest.TestResult )
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmSchedualTest frm2 = new frmSchedualTest(_LocalDrivingLicenseAppID, _TestType);
            frm2.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListAppointments.SelectedRows.Count > 1|| dgvListAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to edit info", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            frmSchedualTest frm =new frmSchedualTest(_LocalDrivingLicenseAppID, _TestType, (int)dgvListAppointments.CurrentRow.Cells[0].Value);
                frm.ShowDialog();

                frmListTestAppointments_Load(null, null);
                return;



        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListAppointments.SelectedRows.Count > 1 || dgvListAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to to take its test", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTakeTest frm = new frmTakeTest((int)dgvListAppointments.CurrentRow.Cells[0].Value, _TestType);
                frm.ShowDialog();
                frmListTestAppointments_Load(null, null);
        }
    }
}
