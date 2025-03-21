using DVLD_Buisness;
using DVLD_UI.Licenses.Detain_License;
using DVLD_UI.Licenses.Local_Licenses;
using DVLD_UI.My_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.Release_Detained_License
{
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _dtDetainedLicense;

        private void _RefreshDefaltValues()
        {
            _dtDetainedLicense=clsDetainedLicense.GetAllDetainedLicenses();
            dgvListDetainedLicenses.DataSource = _dtDetainedLicense;

            lblTotalRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;


        }

        private void _MapFilterValue()
        {
            string FilterValue = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterValue = "DetainID";
                    break;
                case "National No":
                    FilterValue = "NationalNo";
                    break;
                case "Full Name":
                    FilterValue = "FullName";
                    break;
                case "Release Application ID":
                    FilterValue = "ReleaseApplicationID";
                    break;
                case "Is Released":
                    FilterValue = "IsReleased";
                    break;
                default:
                    FilterValue = "None";
                    break;

            }

            if(FilterValue=="None"||txtFilterValue.Text=="")
            {
                _dtDetainedLicense.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();

                return;
            }


            if(FilterValue == "DetainID" || FilterValue == "ReleaseApplicationID")
            {
                _dtDetainedLicense.DefaultView.RowFilter = $"{FilterValue} = {txtFilterValue.Text.Trim()}";
            }
            else
            {
                _dtDetainedLicense.DefaultView.RowFilter = $"{FilterValue} like  '{txtFilterValue.Text.Trim()}%'";

            }
                lblTotalRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();

        }
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();

            frm.ShowDialog();
            _RefreshDefaltValues();

        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {


            frmDetainLicense frm =new frmDetainLicense();
            frm.ShowDialog(); 
            _RefreshDefaltValues();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _MapFilterValue();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbIsReleased.Text)
            {
                case "All":
                    _dtDetainedLicense.DefaultView.RowFilter = "";
                    break;
                case "Yes":
                    _dtDetainedLicense.DefaultView.RowFilter = "IsReleased = 1";
                    break;
                case "No":
                    _dtDetainedLicense.DefaultView.RowFilter = "IsReleased = 0";
                    break;

            }

            lblTotalRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIsReleased.Visible = false;
            txtFilterValue.Visible = false;

            if(cbFilterBy.Text == "Is Released")
            {
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = 0;
                return;

            }
            if (cbFilterBy.Text!="None")
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();

            }
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDefaltValues();
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListDetainedLicenses.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show its detailes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int  PersonID= clsLicense.Find((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID;

            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListDetainedLicenses.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show its detailes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            frmShowLicenseInfo frm =new frmShowLicenseInfo
                ((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListDetainedLicenses.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show its detailes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int PersonID = clsLicense.Find((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value).DriverInfo.PersonID;

            frmShowPersonLicenseHistory frm =new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled =
                !(bool)dgvListDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListDetainedLicenses.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show its detailes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication
                ((int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value);
            frm.Show();
            _RefreshDefaltValues();
        }
    }
}
