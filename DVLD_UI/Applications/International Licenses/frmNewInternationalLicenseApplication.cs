using DVLD_Buisness;
using DVLD_UI.GlobalClasses;
using DVLD_UI.Licenses.International_Licenses;
using DVLD_UI.Licenses.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.Applications.International_Licenses
{
    public partial class frmNewInternationalLicenseApplication : Form
    {

        private int _InternationalLicenseID = -1;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
        }


        private bool _CheckForLicenseExistense()
        {
            int ActiveInternationalLicense = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);
            if (ActiveInternationalLicense != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternationalLicense.ToString(),
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);


                llShowLicenseHistory.Enabled = true;
                llShowLicenseInfo.Enabled = true;
                btnIssueLicense.Enabled = false;

                clsInternationalLicense InternationalLicense = clsInternationalLicense.Find(ActiveInternationalLicense);

                lblInternationalLicenseID.Text= ActiveInternationalLicense.ToString();
                lblApplicationDate.Text = InternationalLicense.ApplicationDate.ToShortDateString();
                lblIssueDate.Text=InternationalLicense.IssueDate.ToShortDateString();
                lblFees.Text=InternationalLicense.PaidFees.ToString();
                lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                lblLocalLicenseID.Text=InternationalLicense.IssuedUsingLocalLicenseID.ToString();
                lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();
                lblCreatedByUser.Text = InternationalLicense.CreatedByUserInfo.UserName;

                _InternationalLicenseID = InternationalLicense.InternationalLicenseID;

                return true;
            }
            return false;
        }

        private bool _IssueLicense()
        {
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            //those are the ingormation for the base class, becouse of the inheritance 
            //they are part of the sub class

            InternationalLicense.ApplicantPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate=DateTime.Now;
            InternationalLicense.LastStatusDate= DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.PaidFees = Convert.ToSingle(lblFees.Text.Trim());
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            //this is for the subclass

            InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseInfoWithFilter1.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            
            InternationalLicense.ExpirationDate =
                DateTime.Now.AddYears(clsLicenseClass.Find("Class 8 - International License").DefaultValidityLength);
            

            if(!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return  false;
            }

            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;

            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(),
                "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;


        }
        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            if (SelectedLicenseID == -1)
                return;

            if (_CheckForLicenseExistense())
                return;

            lblLocalLicenseID.Text=SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = true;

            //checks for the license class it should be class 3

            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmNewInternationalLicenseApplication_Load(null, null); 
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not active, select another one.",
                         "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmNewInternationalLicenseApplication_Load(null, null);

                return;

            }
            btnIssueLicense.Enabled = true;
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {

            lblApplicationID.Text = "???";
            lblInternationalLicenseID.Text = "???";
            lblLocalLicenseID.Text = "???";
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblApplicationDate.Text;

            lblFees.Text = clsApplicationType.
                Find((int)clsApplication.enApplicationType.NewInternationaLicense).Fees.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort
                (DateTime.Now.AddYears(clsLicenseClass.Find("Class 8 - International License").DefaultValidityLength));
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            btnIssueLicense.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();

        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if (_IssueLicense())
            {
                llShowLicenseInfo.Enabled = true;
                btnIssueLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            }

        }

        private void frmNewInternationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.FilterFocus();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm=
                new frmShowPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);

            frm.ShowDialog();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();


        }
    }
}
