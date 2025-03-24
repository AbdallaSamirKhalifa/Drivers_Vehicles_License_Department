using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using DVLD_UI.People.My_Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using static DVLD_UI.GlobalClasses.clsGlobal;
namespace DVLD_UI.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private int _UserID;
        private int Permessions = 0;
        private enum enMode { AddNew=0,Update};

        private enMode _Mode=enMode.AddNew;

        private clsUser _User;
        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
            
        }

        public frmAddUpdateUser(int Userid)
        {
            InitializeComponent();

            this._UserID = Userid;
            _Mode = enMode.Update;
   

        }

        private void _ResetCheckBoxes()
        {
            chkManagePeople.Checked =
                CheckPermesstions(_User, enPersmessions.ManagePeople);

            chkManageUsers.Checked =
                CheckPermesstions(_User, enPersmessions.ManageUsers);

            chkManageLocalLicenseApplications.Checked = 
                CheckPermesstions(_User, enPersmessions.ManageLocalLicenseApplications);

            chkManageInternationalLicenseApplications.Checked =
                CheckPermesstions(_User, enPersmessions.ManageInternationalLicenseApplications);
            
            chkManageDetainedLicenses.Checked = 
                CheckPermesstions(_User, enPersmessions.ManageDetainedLicenses);
          
            chkManageApplicationTypes.Checked =
                CheckPermesstions(_User, enPersmessions.ManageApplicationTypes);
           
            chkManageTestTypes.Checked = 
                CheckPermesstions(_User, enPersmessions.ManageTestTypes);
            
            chkRenewDrivingLicense.Checked = 
                CheckPermesstions(_User, enPersmessions.RenewDrivingLicense);
            
            chkReplaceDrivingLicense.Checked
                = CheckPermesstions(_User, enPersmessions.ReplaceDrivingLicense);
           
            chkManageDrivers.Checked = 
                CheckPermesstions(_User, enPersmessions.ManageDrivers);


        }

        private void _ResetDefaultValues()
        {
            if(_Mode == enMode.AddNew)
            {
                lblHeader.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

                tpLoginInfo.Enabled = false;
                tpPermessions.Enabled = false;
                ctrlPersonWithfilter2.FilterFocus();
            }
            else
            {
                lblHeader.Text = "Update User";
                this.Text = "Update User";

                tpLoginInfo.Enabled = true;
                tpPermessions.Enabled=true;
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
            btnSave.Enabled = false;
            
        }

        private void _LoadData()
        {
            this.Text = "Update User";
            lblHeader.Text = "Update User";
            ctrlPersonWithfilter2.FilterEnabled = false;
            _User = clsUser.FindByUserID(_UserID);


            if (_User == null)
            {
                MessageBox.Show("User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            else
            {

                lblUserID.Text = _User.UserID.ToString();
                txtUserName.Text = _User.UserName.ToString();
                txtPassword.Text = _User.Password.ToString();
                txtConfirmPassword.Text = _User.Password.ToString();
                chkIsActive.Checked = _User.IsActive;
                ctrlPersonWithfilter2.LoadPersonInfo(_User.PersonID);
                if (_User.Permessions == -1)
                    chkAdmin.Checked = true;
                else
                _ResetCheckBoxes();
            }
        }
        
        private void _Save()
        {
            _User.PersonID = ctrlPersonWithfilter2.PersonID;
            _User.UserName= txtUserName.Text;
            _User.Password= txtPassword.Text;
            _User.IsActive=chkIsActive.Checked;
            _User.Permessions = Permessions;
            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                
                _Mode = enMode.Update;
                this.Text = "Update User";
                lblHeader.Text = "Update User";
                ctrlPersonWithfilter2.FilterEnabled = false;
                MessageBox.Show("Data Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Couldent Save The Data Some Error Accured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void _Next()
        {
            if (_Mode == enMode.Update)
            {
                tpLoginInfo.Enabled = true;
                tabControl1.SelectTab(tabControl1.TabPages[1]);
                return;
            }

            //incase adding new
            if (ctrlPersonWithfilter2.PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(ctrlPersonWithfilter2.PersonID))
                {
                    MessageBox.Show("This Person Already Has A User", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctrlPersonWithfilter2.FilterFocus();
                }
                else
                {
                    tpLoginInfo.Enabled = true;
                    tabControl1.SelectTab(tabControl1.TabPages[1]);
                }
            }
            else
            {
                MessageBox.Show("You Must Choose A Person To connect With A User", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrlPersonWithfilter2.FilterFocus();
            }
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

            if (Permessions == 0)
            {
                MessageBox.Show("You need to set permessions for the user (Its mandatory)",
                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                        
            _Save();
               
            
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            
            
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
            {

                _LoadData();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text == "")
            {
                e.Cancel = true;
                epAddUpdate.SetError(txtUserName, "This Field Is Required");
                return;

            }
            else{
                epAddUpdate.SetError(txtUserName, null);
            }


            if(_Mode == enMode.AddNew) {

                if (clsUser.IsUserExist(txtUserName.Text))
                {
                    e.Cancel = true;
                    epAddUpdate.SetError(txtUserName, "This Field Is Required");
                    MessageBox.Show($"This User Name {txtUserName.Text} Already Exists Choose Another One");
                }
                else
                    epAddUpdate.SetError(txtUserName, null);
            }
            else
            {
                if (txtUserName.Text != _User.UserName)
                {

                    //incase updating username make sure using another one

                    if (clsUser.IsUserExist(txtUserName.Text))
                    {
                        e.Cancel = true;
                        epAddUpdate.SetError(txtUserName, "This Field Is Required");
                        MessageBox.Show($"This User Name {txtUserName.Text} Already Exists Choose Another One");
                    }
                    else
                        epAddUpdate.SetError(txtUserName, null);
                }
                
            
        
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                epAddUpdate.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                epAddUpdate.SetError(txtPassword, null);
            };

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                epAddUpdate.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                epAddUpdate.SetError(txtConfirmPassword, null);
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _Next();

        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonWithfilter2.FilterFocus();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAdmin.Checked)
            {
                Permessions = (int)clsGlobal.enPersmessions.Admin;
                gbPermessions.Enabled = false;
                return;
            }
            Permessions = _User.Permessions;
            gbPermessions.Enabled = true;
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabControl1.TabPages[1]);

        }

        private void btnPermessions_Click(object sender, EventArgs e)
        {

                btnSave.Enabled = true;
                tabControl1.SelectTab(tabControl1.TabPages[2]);
            tpPermessions.Enabled = true;
        }

        private void chkManagePeople_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;

            enPersmessions Permession = (enPersmessions)Enum.Parse(typeof(enPersmessions), box.Tag.ToString());

            if(box.Checked)
                Permessions += (int)Permession;
            else
            {
                if (CheckPermesstions(Permession))
                    Permessions -= (int)Permession;
            }



        }

       
    }
}
