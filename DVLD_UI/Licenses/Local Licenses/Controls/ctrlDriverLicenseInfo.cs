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

namespace DVLD_UI.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        private int _LicenseID = -1;
        private clsLicense _License;

        public int LicenseID { get { return _LicenseID; } }
        public clsLicense SelectedLicenseInfo{ get { return _License; } }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if ( ImagePath != "")
            {

                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            if (lblGendor.Text == "Male")
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);

            if(_License == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Couldn't find license with ID = " + LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _LicenseID.ToString();
            lblNationalNo.Text=_License.DriverInfo.PersonInfo.NationalNo.ToString();
            lblGendor.Text = _License.DriverInfo.PersonInfo.GenderString;
            pbGendor.Image = lblGendor.Text == "Male" ? Resources.Man_32 : Resources.Woman_32;
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReasonString;
            lblNotes.Text=_License.Notes==""?"No Notes":_License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text=_License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = _License.IsDetained?"Yes":"No";
          
            _LoadPersonImage();

        }

        private void _ResetDefaultValues()
        {
            lblClass.Text = "????";
            lblFullName.Text = "????";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "??";
            pbGendor.Image = Resources.Man_32 ;
            pbPersonImage.Image = Resources.Male_512 ;
            lblIssueDate.Text = "??/??/????";
            lblIssueReason.Text ="????";
            lblNotes.Text = "????";
            lblIsActive.Text ="???";
            lblDateOfBirth.Text = "??/??/????";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "??/??/????";
            lblIsDetained.Text = "???";
        }
    }
}
