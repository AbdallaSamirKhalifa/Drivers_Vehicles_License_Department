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
    public partial class frmManageTestTypes : Form
    {

        private DataTable _dtTestTypes;

        private void _RefreshList()
        {
            _dtTestTypes=clsTestType.GetAllAplicationTypes();

            dgvListTestTypes.DataSource = _dtTestTypes;

            lblRecords.Text=dgvListTestTypes.Rows.Count.ToString();


        }


        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frm=new frmUpdateTestTypes((int)dgvListTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        }

        private void dgvListTestTypes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frmUpdateTestTypes frm = new frmUpdateTestTypes((int)dgvListTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshList();
        } 
    }
}
