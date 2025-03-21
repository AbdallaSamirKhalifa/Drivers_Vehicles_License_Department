using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.ApplicationTypes
{
    public partial class frmUpdateApllicationType : Form
    {

        private int _ID;
        private clsApplicationType _Application;
        public frmUpdateApllicationType(int id)
        {
            InitializeComponent();
            _ID = id;

        }
        private void _Save()
        {

            _Application.Title=txtTitle.Text.ToString();
            _Application.Fees = Convert.ToSingle(txtFees.Text.ToString());

            if (MessageBox.Show("Are you sure you want to update this application type","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                ==DialogResult.Yes)
            {
                if (_Application.Save())
                {
                    MessageBox.Show("Application updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Couldn't update the application some error acurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }


        private void _LoadData()
        {
            _Application = clsApplicationType.Find(_ID);

            if(_Application == null )
            {
                MessageBox.Show("Application not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblID.Text = _Application.ID.ToString();
            txtTitle.Text = _Application.Title.ToString();
            txtFees.Text = _Application.Fees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmUpdateApllicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }



        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled=!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel=true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty");

            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty");

            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }

            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid number");

            }else
                errorProvider1.SetError(txtFees, null);

        }
    }
}
