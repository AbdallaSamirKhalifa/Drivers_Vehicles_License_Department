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

namespace DVLD_UI.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {

        private DataTable _dtAllApplicationTypes;

        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshList()
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllAplicationTypes();

            dgvListApplicationTypes.DataSource= _dtAllApplicationTypes;

            lblRecords.Text=dgvListApplicationTypes.Rows.Count.ToString();

        }

        private void femManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApllicationType frm = new frmUpdateApllicationType((int)dgvListApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void dgvListApplicationTypes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUpdateApllicationType frm = new frmUpdateApllicationType((int)dgvListApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }
    }
}
