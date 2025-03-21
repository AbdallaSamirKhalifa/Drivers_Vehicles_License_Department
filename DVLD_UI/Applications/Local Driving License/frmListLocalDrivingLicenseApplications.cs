using DVLD_Buisness;
using DVLD_UI.Licenses;
using DVLD_UI.Licenses.Local_Licenses;
using DVLD_UI.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {

        private DataTable _dtApplications;

        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void _DeleteApplication()
        {
            if (MessageBox.Show("Are you sure you want to delete this Application", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            clsLocalDrivingLicenseApplication App = clsLocalDrivingLicenseApplication.
                FindByLocalDrivingAppLicenseID((int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);

            if (App != null)
            {
                if (App.Delete())
                {
                    MessageBox.Show("Application deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    App = null;
                    _RefreshApplicationsList();
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _CancelApplication()
        {
            if (MessageBox.Show("Are you sure you want to cancel this Application", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication App = clsLocalDrivingLicenseApplication.
                FindByLocalDrivingAppLicenseID((int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            if(App != null) 
            {
                if (App.Cancel())
                {
                    MessageBox.Show("Application Cancelled successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refreshing the list
                    frmListLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void _RefreshApplicationsList()
        {
            _dtApplications=clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvListLocalDrivingLicenseApplication.DataSource = _dtApplications;

            lblRecordsCount.Text=dgvListLocalDrivingLicenseApplication.RowCount.ToString();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _MapFilter() 
        {
            string FilterValue = "";

            switch (cbFilterBy.Text) 
            {
                case "L.D.L.AppID":
                    FilterValue = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterValue = "NationalNo";
                    break;
                case "Full Name":
                    FilterValue = "FullName";
                    break;
                case "Status":
                    FilterValue = "Status";
                    break;
                case "None":
                    FilterValue= "None";
                    break;
            }

            if (FilterValue == "None")
                return;


            if (FilterValue == "LocalDrivingLicenseApplicationID" && int.TryParse(txtFilterValue.Text.Trim(), out int filter))
                //in this case we deal with integer not string.
                _dtApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterValue, filter);
            else
                _dtApplications.DefaultView.RowFilter = "";

            if (FilterValue != "LocalDrivingLicenseApplicationID" && FilterValue != "None")
                _dtApplications.DefaultView.RowFilter = $"{FilterValue} like '{txtFilterValue.Text.Trim()}%'";

            lblRecordsCount.Text = dgvListLocalDrivingLicenseApplication.Rows.Count.ToString();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _RefreshApplicationsList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = cbFilterBy.Text != "None";
            if(cbFilterBy.Text != "None")
               { txtFilterValue.Focus(); txtFilterValue.Text = ""; }
            _dtApplications.DefaultView.RowFilter = "";

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "L.D.L.AppID")
                e.Handled=!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _MapFilter();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm =new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to show info", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int LocalApplicaitonId =(int) dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(LocalApplicaitonId);
            frm.ShowDialog();

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to edit info", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication
                ((int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationsList();

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _DeleteApplication();


        }





        private void tmsCancel_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _CancelApplication();

        }



        private void schedualVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to schedule test", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int LocalDrivingLicenseApplicationID = (int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            frmListTestAppointments frm=new frmListTestAppointments(LocalDrivingLicenseApplicationID,clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            _RefreshApplicationsList();


        }

        private void schedualWrrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to schedule test", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            frmListTestAppointments frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            _RefreshApplicationsList();

        }

        private void issuDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to issue license for", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime
                ((int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to show info", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                ((int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value).GetActiveLicenseID();

            if (LicenseID == -1)
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show the detailes for.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);

            
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(LocalDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();

        }

        private void schedualStreetTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListLocalDrivingLicenseApplication.SelectedRows.Count > 1 || dgvListLocalDrivingLicenseApplication.SelectedRows.Count == 0)
            {
                MessageBox.Show("Warning, Select Row to schedule test for", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            frmListTestAppointments frm = new frmListTestAppointments(LocalDrivingLicenseApplicationID, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            _RefreshApplicationsList();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivngLicenseApplicationID = (int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.
                FindByLocalDrivingAppLicenseID(LocalDrivngLicenseApplicationID);

            int TotalPassedTests = (int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[5].Value;

            bool LicenseExists=localDrivingLicenseApplication.IsLicenseIssued();

            //only enabled if he passed all tests and have no license
            issuDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3 )&& (!LicenseExists);

            //enable and disable show license we only enable if the person have a license
            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            //we only enable if the application is new and the person have no license
            editApplicationToolStripMenuItem.Enabled = (!LicenseExists&&
                localDrivingLicenseApplication.ApplicationStatus==clsApplication.enApplicationStatus.New);

            //we only enable if the application is new
            tmsCancel.Enabled=localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New;

            //we only enable if the application is new 
            deleteApplicationToolStripMenuItem.Enabled=localDrivingLicenseApplication.ApplicationStatus 
                == clsApplication.enApplicationStatus.New;


            //Enable/Disable schedual test menue item and its submenues
            bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);

            schedualTestToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) &&
                (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (schedualTestToolStripMenuItem.Enabled)
            {
                //to allow schedual vision test person must not passed the same test before
                schedualVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //to allow schedual written test, person must be passed the vision test, and not passed the same test
                schedualWrrToolStripMenuItem.Enabled = PassedVisionTest&&!PassedWrittenTest;

                //to allow schedual street test, person must be passed vision and written test, and not passed same test before
                schedualStreetTToolStripMenuItem.Enabled = PassedVisionTest&&PassedWrittenTest&&!PassedStreetTest;
            }




        }

        private void dgvListLocalDrivingLicenseApplication_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int LocalApplicaitonId = (int)dgvListLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(LocalApplicaitonId);
            frm.ShowDialog();
        }
    }
}
