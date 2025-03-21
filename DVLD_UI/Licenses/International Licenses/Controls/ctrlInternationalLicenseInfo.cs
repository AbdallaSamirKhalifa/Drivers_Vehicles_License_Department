using DVLD_Buisness;
using DVLD_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Licenses.International_Licenses.Controls
{
    

    public partial class ctrlInternationalLicenseInfo : UserControl
    {

        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;

        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }
        public clsInternationalLicense SelectedInternationalLicense { get { return _InternationalLicense; } }

        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            string ImagePath=_InternationalLicense.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if(File.Exists(ImagePath)) 
                pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.Find(_InternationalLicenseID);

            if (_InternationalLicense == null)
            {
                MessageBox.Show("Could not find Internationa License ID = " + _InternationalLicenseID.ToString(),
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }

            lblFullName.Text = _InternationalLicense.ApplicantFullName;
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicense.PersonInfo.NationalNo;
            lblGendor.Text = _InternationalLicense.PersonInfo.GenderString;
            if (lblGendor.Text == "Male")
            {
                pbGendor.Image = Resources.Man_32;
                pbPersonImage.Image = Resources.Male_512;
            }
            else 
            {
                pbGendor.Image = Resources.Woman_32;
                pbPersonImage.Image= Resources.Female_512;
            }
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text=_InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text=_InternationalLicense.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text=_InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            _LoadPersonImage();

        }
    }
}
