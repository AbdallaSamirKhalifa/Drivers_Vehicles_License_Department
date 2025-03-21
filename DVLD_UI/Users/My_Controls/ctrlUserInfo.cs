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

namespace DVLD_UI.Users.My_Controls
{
    public partial class ctrlUserInfo : UserControl
    {

        private clsUser _User ;
        public int UserId { get { return _User.UserID ; } }
        public clsUser SelectedUserInfo {  get { return _User ; } }    
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void _SetDefaultValues()
        {
            lblUserID.Text = "????";
            lblUserName.Text = "????";
            lblStatus.Text = "????";
            lblPermessions.Text = "????";
        }

        private void _FillUserInfo()
        {
                personCard1.LoadPersonInfo(_User.PersonID);
                lblUserID.Text = _User.UserID.ToString();
                lblUserName.Text = _User.UserName;
            lblPermessions.Text = _User.Permessions.ToString();

                lblStatus.Text=_User.IsActive ? "Yes" : "No";
        }
        public  bool LoadUserInfoByUserID(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User != null)
            {
                _FillUserInfo();
                return true;

            }else
            {
                _SetDefaultValues();
                MessageBox.Show("User Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;   
            }
        }

        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {
            //_SetDefaultValues();
        }
    }
}
