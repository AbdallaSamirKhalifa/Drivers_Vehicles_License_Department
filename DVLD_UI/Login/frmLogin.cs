using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using DVLD_UI.My_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Users.My_Controls
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool _CheckCredintials() 
        {

            clsGlobal.CurrentUser = clsUser.FindByUserNameAndPassword(txtUserName.Text.Trim(),clsGlobal.ComputeHash(txtPassword.Text.Trim()));

            if (clsGlobal.CurrentUser != null)
            {
                if (clsGlobal.CurrentUser.IsActive)
                {
                    return true;
                }
                else
                {
                    txtUserName.Focus();
                MessageBox.Show("Your account is deactivated please contact your admin","Information",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
                }
            }
            else
            {
                    txtUserName.Focus();
                MessageBox.Show("Invalid username / password.","Wrong Credintials",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        
        
        
        }

  
        private void _FillLoginInfo()
        {
            string UserName = "", Password ="";

            
            if (clsGlobal.GetStoredCredintialsFromRegistry(ref UserName,ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;

            }
            else
            {
                chkRememberMe.Checked = false;
            }
        }

        private void _SaveLoginInfo()
        {
            if(chkRememberMe.Checked)
            {
                
                clsGlobal.SaveCredintiolsInRegistry(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            }
            else
            {
                clsGlobal.CheckForRegisterValues();

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_CheckCredintials())
            {
                _SaveLoginInfo();
                this.Hide();
                DVLDMainForm form=new DVLDMainForm(this);
                form.ShowDialog();
            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _FillLoginInfo();

        }
    }
}
