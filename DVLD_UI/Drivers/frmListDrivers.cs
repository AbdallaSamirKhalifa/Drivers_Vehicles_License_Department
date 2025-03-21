using DVLD_Buisness;
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

namespace DVLD_UI.Drivers
{
    public partial class frmListDrivers : Form
    {

        private DataTable _dtDrivers;


        private void _RefreshDriversList()
        {
            _dtDrivers=clsDriver.GetAllDrivers();

           dgvListDrivers.DataSource = _dtDrivers;
            lblRecordsCount.Text=dgvListDrivers.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

        }

        private void _MapSelectedFilter()
        {
            string FilterValue = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterValue = "PersonID";
                    break;
                case "Driver ID":
                    FilterValue = "DriverID";
                    break;
                case "National No":
                    FilterValue = "NationalNo";
                    break;
                case "Full Name":
                    FilterValue = "FullName";
                    break;
                default:
                    FilterValue = "None";
                    break;  
            }

            if (FilterValue == "None"|| txtFilterValue.Text.Trim() == "")
            {
                _dtDrivers.DefaultView.RowFilter = $"";
                lblRecordsCount.Text = dgvListDrivers.Rows.Count.ToString();


                return; 
            }

            if (FilterValue == "PersonID" || FilterValue == "DriverID")
                _dtDrivers.DefaultView.RowFilter = $"{FilterValue} = {txtFilterValue.Text.Trim()}";
            else
                _dtDrivers.DefaultView.RowFilter = $"{FilterValue} like '{txtFilterValue.Text.Trim()}%'";
            

            lblRecordsCount.Text = dgvListDrivers.Rows.Count.ToString();

        }
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversList();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "Driver ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _MapSelectedFilter();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
                txtFilterValue.Text = "";
            }

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvListDrivers.SelectedRows.Count>1)
            {
                MessageBox.Show("Select only one row to show the detailes for.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmPersonDetails frm = new frmPersonDetails((int)dgvListDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();

        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet","Note",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvListDrivers.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show the detailes for.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmShowPersonLicenseHistory frm =new frmShowPersonLicenseHistory((int)dgvListDrivers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
