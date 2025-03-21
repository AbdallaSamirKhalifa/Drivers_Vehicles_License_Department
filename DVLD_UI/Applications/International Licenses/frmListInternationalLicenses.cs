using DVLD_Buisness;
using DVLD_UI.Licenses.International_Licenses;
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

namespace DVLD_UI.Applications.International_Licenses
{
    public partial class frmListInternationalLicenses : Form
    {
        private DataTable _dtInternationalLicenses;

        private void _RefreshInternationalLicensesList()
        {
            _dtInternationalLicenses=clsInternationalLicense.GetAllInternationalLicenses();

            dgvListInternationalLicenses.DataSource= _dtInternationalLicenses;
            lblInternationalLicensesRecords.Text = dgvListInternationalLicenses.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

        }


        private void _MapFilterValue()
        {
            string FilterValue = "";

            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    FilterValue = "InternationalLicenseID";
                    break;
                case "Application ID":
                    FilterValue = "ApplicationID";
                    break;
                case "Driver ID":
                    FilterValue = "DriverID";
                    break;
                case "Local License ID":
                    FilterValue = "IssuedUsingLocalLicenseID";
                    break;
                default:
                    FilterValue="None";
                    break;
            }

            if (FilterValue == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtInternationalLicenses.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text = dgvListInternationalLicenses.Rows.Count.ToString();
                return;
            }

            if (cbFilterBy.Text != "Is Active")
                _dtInternationalLicenses.DefaultView.RowFilter = $"{FilterValue} = {txtFilterValue.Text.Trim()}";

                lblInternationalLicensesRecords.Text = dgvListInternationalLicenses.Rows.Count.ToString();

                
            

        }
        public frmListInternationalLicenses()
        {
            InitializeComponent();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Is Active" || cbFilterBy.Text != "None")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text=="Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = 0;
                cbIsReleased.Focus();
                return;
            }

            if (cbFilterBy.Text != "None")
            {
                txtFilterValue.Visible = true;
                cbIsReleased.Visible= false;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
                return; 
            }
            
            cbIsReleased.Visible= false;
                txtFilterValue.Visible = false;
        }

        private void frmListInternationalLicenses_Load(object sender, EventArgs e)
        {

            _RefreshInternationalLicensesList();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.Text)
            {
                case "Yes":
                    _dtInternationalLicenses.DefaultView.RowFilter = "IsActive = 1";
                    break;
                case "No":
                    _dtInternationalLicenses.DefaultView.RowFilter = "IsActive = 0";
                    break;
                default:
                    _dtInternationalLicenses.DefaultView.RowFilter = "";
                    break;

            }
            lblInternationalLicensesRecords.Text = dgvListInternationalLicenses.Rows.Count.ToString();

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _MapFilterValue();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is not implemented yet", "Not Implemented", MessageBoxButtons.OK,
            //MessageBoxIcon.Information);

            frmNewInternationalLicenseApplication frm
                =new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvListInternationalLicenses.SelectedRows.Count>1)
            {
                MessageBox.Show("Select only one row to show it's details", "Warnig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int PersonID= clsDriver.FindByDriverID
                ((int)dgvListInternationalLicenses.CurrentRow.Cells[2].Value).PersonID;

            if(PersonID != -1)
            {
                frmPersonDetails frm = new frmPersonDetails( PersonID);
                frm.ShowDialog();   
            }else
                MessageBox.Show("Error: Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListInternationalLicenses.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show it's details", "Warnig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int PersonID = clsDriver.FindByDriverID
                        ((int)dgvListInternationalLicenses.CurrentRow.Cells[2].Value).PersonID;

            if (PersonID != -1)
            {
                frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Error: Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListInternationalLicenses.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show it's details", "Warnig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo
                ((int)dgvListInternationalLicenses.CurrentRow.Cells[0].Value);
             frm.ShowDialog();

        }
    }
}
