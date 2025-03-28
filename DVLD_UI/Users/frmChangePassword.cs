using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Users
{
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        private int _UserID;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            this._UserID = UserID;


        }
        private void _ChangePassword()
        {
            if(!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to change this users password","Question"
                ,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
            if (_User.ChangePassword(clsGlobal.ComputeHash(txtNewPassword.Text)))
            {
                    MessageBox.Show("Password changed successfully", "Information"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
                    MessageBox.Show("Couldn't change the password some error accured", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtCurrentPassword.Text ))
            {
                e.Cancel = true;
                epChangePassword.SetError(txtCurrentPassword, "This field is required");
            }else
                epChangePassword.SetError(txtCurrentPassword, null);

            if(txtCurrentPassword.Text != _User.Password)
            {

                e.Cancel = true;
                epChangePassword.SetError(txtCurrentPassword, "Current password is wrong");
            }else
                epChangePassword.SetError(txtCurrentPassword, null);



        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text) )
            {
                e.Cancel = true;
                epChangePassword.SetError(txtNewPassword, "This field is required");
            }
            else
                epChangePassword.SetError(txtNewPassword, null);

           
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {


            if (txtConfirmPassword.Text.Trim()!= txtNewPassword.Text.Trim())
            {

                e.Cancel = true;
                epChangePassword.SetError(txtConfirmPassword, "Password confirmation does not match new password!");


            }
            else
               {
                epChangePassword.SetError(txtConfirmPassword, null); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ChangePassword();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            
            _ResetDefualtValues();

            if (!ctrlUserInfo1.LoadUserInfoByUserID(_UserID))
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not find user with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }

            _User = ctrlUserInfo1.SelectedUserInfo;
        }
    }
}
