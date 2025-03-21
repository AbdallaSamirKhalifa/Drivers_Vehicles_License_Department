using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.Local_Licenses.Controls
{

    
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        //Define cutome event handle delegate with parameters
        public event Action<int> OnLicenseSelected;
        

        //create a protected virtual method to raise the event with parameters
        protected virtual void LicenseSelected(int LicenseID)  
        {
            Action<int> Handler = OnLicenseSelected;

            if(Handler != null)
                Handler(LicenseID);//raise the event with the parameters

        }

        private int _LicenseID = -1;

        public int LicenseID { get { return _LicenseID; } }

        private bool _FilterEnabled = true;

        public bool FilterEnabled 
        {
            get 
            { 
                return _FilterEnabled;
            } 
            set 
            {
                _FilterEnabled = value; 
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; }
        }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            //FilterEnabled = false;
            txtLicenseID.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
            if(ctrlDriverLicenseInfo1.SelectedLicenseInfo!=null)
            _LicenseID=ctrlDriverLicenseInfo1.LicenseID;
            else
                _LicenseID = -1;


            if(OnLicenseSelected!= null)
                OnLicenseSelected(_LicenseID);


        }

        public void FilterFocus()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
           
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }


        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;
            }
            _LicenseID = int.Parse(txtLicenseID.Text);
            LoadLicenseInfo(_LicenseID);
        }
    }
}
