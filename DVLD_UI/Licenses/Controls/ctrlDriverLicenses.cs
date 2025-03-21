using DVLD_Buisness;
using DVLD_UI.Licenses.International_Licenses;
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

namespace DVLD_UI.Licenses.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {

        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicenses;
        private DataTable _dtDriverInternationalLicenses;


        public ctrlDriverLicenses()
        {
            InitializeComponent();


        }


        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicenses = clsLicense.GetDriverLicenses(_DriverID);
            dgvLocalLicenses.DataSource = _dtDriverLocalLicenses;
            lblLocalRecords.Text=dgvLocalLicenses.Rows.Count.ToString();


        }

        private void _LoadInternationalLicenses()
        {
            _dtDriverInternationalLicenses=clsInternationalLicense.GetDriverInternationLicenses(_DriverID);

            dgvInternationalLicenses.DataSource= _dtDriverInternationalLicenses;
            lblInternationalRecords.Text=dgvInternationalLicenses.Rows.Count.ToString() ;

        }
        public void LoadInfo(int DriverID)
        {
            _Driver=clsDriver.FindByDriverID(DriverID);

            if (_Driver == null)
            {
                MessageBox.Show("Couldn't find driver with ID = " + DriverID.ToString(), "Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID = DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenses();

        }

        public void LoadByPersonID(int PersonID)
        {
            _Driver=clsDriver.FindByPersonID(PersonID);

            if(_Driver==null)
            {
                MessageBox.Show("Tere is no driver linked with person ID = " + PersonID.ToString(), "Not Found",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.DriverID;
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenses();
        }

        public void Clear()
        {
            _dtDriverLocalLicenses.Clear();
            _dtDriverInternationalLicenses.Clear();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenses.SelectedRows.Count > 1|| dgvLocalLicenses.SelectedRows.Count <= 0 )
            {
                MessageBox.Show("Select only one row to show it's license", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only one row to show it's details", "Warnig", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo
                ((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }


    }
}
