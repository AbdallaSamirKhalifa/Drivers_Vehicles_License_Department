using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Buisness;
using System.Windows.Forms;
using System.Data.SqlTypes;
using DVLD_UI.My_Forms;
using System.IO;
using DVLD_UI.People;

namespace DVLD_UI
{

    public partial class frm_ManagePeople : Form
    {
        public frm_ManagePeople()
        {
            InitializeComponent();

        }
        private static DataTable dtAllPeople = clsPerson.GetAllPeopleFromView();

        //selecting the needed columns from the table
        private DataTable dtPeople= dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gendor", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");


        //refreshing the people list 
       private void _RefreshPeopleList()
        {
            dtAllPeople = clsPerson.GetAllPeopleFromView();
            dtPeople = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gendor", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
            dgvListPeople.DataSource = dtPeople;
            cbFilter.SelectedIndex = 0;
            lblRecords.Text = dgvListPeople.Rows.Count.ToString();
        }


        //maping the filter
        private void _MapSelectedFilter()
        {
            string FilterCol = "";

            switch (cbFilter.Text)
            {
                case "Person ID":
                    FilterCol = "PersonID";
                    break;
                case "National No.":
                    FilterCol = "NationalNo";
                    break;

                case "First Name":
                    FilterCol= "FirstName";
                    break;

                case "Second Name":
                    FilterCol = "SecondName";
                    break;

                case "Third Name":
                    FilterCol = "ThirdName";
                    break;

                case "Last Name":
                    FilterCol = "LastName";
                    break;

                case "Nationality":
                    FilterCol = "CountryName";
                    break;

                case "Gendor":
                    FilterCol = "Gendor";
                    break;

                case "Phone":
                    FilterCol = "Phone";
                    break;

                case "Email":
                    FilterCol = "Email";
                    break;  

                default:
                    FilterCol = "None";
                    return;
            }


            if (txtFilter.Text.Trim() == "")
            {
                dtPeople.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListPeople.Rows.Count.ToString();
                return;

            }

            txtFilter.Focus();
            if (FilterCol == "PersonID")
            {
                if (int.TryParse(txtFilter.Text.Trim(), out int PersonID))
                {
                    dtPeople.DefaultView.RowFilter = $"{FilterCol} = {PersonID}";
                }
                else
                {
                    MessageBox.Show("Please Enter A Valid Number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                dtPeople.DefaultView.RowFilter = $"{FilterCol} like '%{txtFilter.Text.Trim()}%'";
            }

            lblRecords.Text = dgvListPeople.Rows.Count.ToString();


        }


        
        private void _DeletePerson()
        {
            if (dgvListPeople.SelectedRows.Count == 0 || dgvListPeople.SelectedRows.Count >1)
            {
                MessageBox.Show("Please Select A Person To Delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are You Sure You Want To Delete This Person {PersonID}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Person is not deleted due to data connected to", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilter.Text != "None");

            if(txtFilter.Text.Trim() != "")
            {
                txtFilter.Text = "";    
                txtFilter.Focus();
            }
                txtFilter.Focus();


        }

        private void frm_ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            //txtFilter2.Visible = (cbFilter.SelectedText != "None");

        }

        private void btnAddNewperson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson add= new frmAddUpdatePerson();
            add.ShowDialog();
            _RefreshPeopleList();
        }

        private void dgvListPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmPersonDetails frmPerson= new frmPersonDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
            //frmPerson.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frmPerson = new frmPersonDetails((int)dgvListPeople.CurrentRow.Cells[0].Value);
            frmPerson.ShowDialog();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson add = new frmAddUpdatePerson();
            add.ShowDialog();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson add = new frmAddUpdatePerson((int)dgvListPeople.CurrentRow.Cells[0].Value);
            add.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeletePerson();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if the selected filter is Person ID, then the user can only enter numbers

            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _MapSelectedFilter();

        }

        private void personWithFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindPerson frm = new frmFindPerson();
            frm.ShowDialog();
        }
    }
}

