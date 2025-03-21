using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UI.Tests
{
    public partial class frmUpdateTestTypes : Form
    {

        private clsTestType _TestType;
        private clsTestType.enTestType _ID;
        public frmUpdateTestTypes(int ID)
        {
            InitializeComponent();

            this._ID = (clsTestType.enTestType)ID;
        }


        private void _LoadData()
        {

            _TestType = clsTestType.Find(_ID);

            if (_TestType != null)
            {
                lblID.Text = ((int)_TestType.ID).ToString();
                txtDescription.Text = _TestType.Description.ToString();
                txtTitle.Text = _TestType.Title.ToString();
                txtFees.Text = _TestType.Fees.ToString();

            }
            else{
                MessageBox.Show("Could not find Test Type with id = " + _ID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void _Save()
        {

            _TestType.Title = txtTitle.Text.ToString();
            _TestType.Description = txtDescription.Text.ToString();
            _TestType.Fees = Convert.ToSingle(txtFees.Text.ToString());

            if (MessageBox.Show("Are you sure you want to update this application type", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (_TestType.Save())
                {
                    MessageBox.Show("Application updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Couldn't update the application some error acurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && char.IsControl(e.KeyChar);  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _Save();
        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            };
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            };
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            };


            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            };
        }
    }
}
