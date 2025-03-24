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
using static DVLD_UI.GlobalClasses.clsGlobal;

namespace DVLD_UI.Users
{
    public partial class frmManageUsers : Form
    {

        private DataTable _dtUsers;
        public frmManageUsers()
        {
            InitializeComponent();
        }


        private void _DeleteUser()  
        {
            int UserID = int.Parse(dgvListUsers.CurrentRow.Cells[0].Value.ToString());
            clsUser User = clsUser.FindByUserID(UserID);
            if (User == null)
            {
                MessageBox.Show($"User {UserID} not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CurrentUser.UserID == UserID||User.Permessions==-1)
            {
                MessageBox.Show($"The selected User Can't be deleted", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if(MessageBox.Show($"Are you sure you want to delete this user the user will be deleted permenetly","Question",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show($"User deleted successfulyy","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmManageUsers_Load(null, null);
                }else
                    MessageBox.Show($"User {UserID}  is not deleted due to data connected to","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

        }
        private void _RefreshUsersList()
        {
            _dtUsers = clsUser.GetAllUsers();
            dgvListUsers.DataSource = _dtUsers;
            lblRecords.Text = dgvListUsers.Rows.Count.ToString();
        }
        private void _SetDefaultValues()
        {
            _RefreshUsersList();

            cbFilterBy.SelectedIndex = 0;
            cbFilterValue.Visible = false;
            txtFilterValue.Visible = false;
        }

   
        private void _MapSelectedFilter()
        {
            string FilterBy = "";
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    FilterBy = "UserID";
                    break;
                case 2:
                    FilterBy = "PersonID";
                    break;
                case 3:
                    FilterBy = "FullName";
                    break;
                case 4:
                    FilterBy = "UserName";
                    break;
                default:
                    FilterBy = "None";
                    break;

            }

            //reset the filters in case nothing selected or filter containg nothing

            if (txtFilterValue.Text.Trim() == ""||FilterBy=="None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListUsers.Rows.Count.ToString();
                return;

            }
            if (FilterBy == "UserID" || FilterBy == "PersonID")
            {
                txtFilterValue.Focus();
                _dtUsers.DefaultView.RowFilter=string.Format("{0}={1}", FilterBy, txtFilterValue.Text);
            }
            else
            {
                txtFilterValue.Focus();
                _dtUsers.DefaultView.RowFilter=$"{FilterBy} like '{txtFilterValue.Text}%'";

            }
            lblRecords.Text= dgvListUsers.Rows.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow noly numbers in these two cases

            if(cbFilterBy.Text=="Person ID"|| cbFilterBy.Text == "User ID")
                e.Handled=!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _MapSelectedFilter();
        }

        private void cbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterValue.Text)
            {
                case "Yes":
                    _dtUsers.DefaultView.RowFilter = $"IsActive=1";
                    break;
                case "No":
                    _dtUsers.DefaultView.RowFilter = $"IsActive=0";
                    break;
                default:
                    _dtUsers.DefaultView.RowFilter = "";
                    break;
            }
            lblRecords.Text = dgvListUsers.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "Status")
            {
                txtFilterValue.Visible = false;
                cbFilterValue.Visible = true;
                cbFilterValue.Focus();
                cbFilterValue.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbFilterValue.Visible = false;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }


        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUserDetails frm=new frmUserDetails(int.Parse(dgvListUsers.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeleteUser();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(int.Parse(dgvListUsers.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
        }

        //private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmAddUpdateUser frm = new frmAddUpdateUser();
        //    frm.ShowDialog();
        //    frmManageUsers_Load(null, null);
        //}

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm=new frmAddUpdateUser(int.Parse(dgvListUsers.CurrentRow.Cells[0].Value.ToString()));
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void dgvListUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserDetails frm = new frmUserDetails((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
