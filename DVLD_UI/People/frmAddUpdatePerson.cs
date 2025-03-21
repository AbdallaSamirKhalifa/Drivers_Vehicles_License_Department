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
using DVLD_Buisness;
using DVLD_UI.GlobalClasses;

namespace DVLD_UI.People
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew,Edit};
        private enMode _Mode;
        private int _PersonID;
        private clsPerson _Person;


        //private DataTable _DtCountries;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode=enMode.AddNew;
        }
        
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Edit;
        }

        private void _FillComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();

            foreach (DataRow row in dt.Rows)
                cbCountry.Items.Add(row["CountryName"]);
            

            
        }
        private void _SetDefaultValues()
        {
            _FillComboBox();

            if(_Mode==enMode.Edit)
                lblHeader.Text= "Update Person";
            else
            {
                _Person = new clsPerson();
                lblHeader.Text= "Add New Person";
            }

            //if(rbMale.Checked)
            //    pbImage.Image = Properties.Resources.Male_512;
            //else
            //    pbImage.Image = Properties.Resources.Female_512 ;

            llRemoveImage.Visible = pbImage.ImageLocation!=null;

            dtpDOB.MaxDate = DateTime.Now.AddYears(-18);
            dtpDOB.Value=dtpDOB.MaxDate;

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            cbCountry.SelectedItem = "Egypt";
            rbMale.Checked = true;

        }

        private bool _HandlePersonImage()
        {

            //this procedure will take handle the person image
            //it will take care of deleting the old image from the folder
            //in case the image changed then it will rename the new image with guid and 
            //place it in the images folder

            //we check if the person has an perviuos image and if there is any we delete it then we change it 
            if (_Person.ImagePath != pbImage.ImageLocation && _Person.ImagePath != "")
            {
                //first we delete the old image from the image folder in case there is any
                try
                {
                    File.Delete(_Person.ImagePath);
                }
                catch (IOException ex)
                {
                    //couldn't delete the image
                }
            }

            if (pbImage.ImageLocation!=null)
            {
                //then we copy the image to the image folder after we rename it 
                string sourceFile = pbImage.ImageLocation.ToString();

                if (clsUtil.CopyImageToProjectImagesPath(ref sourceFile))
                {
                    pbImage.ImageLocation=sourceFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void _LoadDate()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblPersonID.Text = _Person.ID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;

            cbCountry.SelectedItem = _Person.CountryName;
            //cbCountry.SelectedText = _Person.CountryName;
            dtpDOB.Value = _Person.DateOfBirth;
           
            if (_Person.GenderString=="Male")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;



            if(llRemoveImage.Visible = _Person.ImagePath != "")
                pbImage.ImageLocation = _Person.ImagePath;
        }

        private void _Save()
        {
            if (!this.ValidateChildren())
            {
                //here we don't continue becouse the form is not valid

                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error"
                , "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!_HandlePersonImage()) { 
                MessageBox.Show("Data not Handlin Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                 }
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text.Trim()).CountryID;
            _Person.DateOfBirth = dtpDOB.Value;
            _Person.GenderString = rbMale.Checked ? "Male" : "Female";

            if(pbImage.ImageLocation != null)
                _Person.ImagePath = pbImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lblPersonID.Text = _Person.ID.ToString();
                _Mode = enMode.Edit;
                lblHeader.Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.ID);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }


        private void frmAddUpdaqtePerson_Load(object sender, EventArgs e)
        {
            _SetDefaultValues();

            if (_Mode == enMode.Edit)
                _LoadDate();
        }



        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
            pbImage.Image= Properties.Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Properties.Resources.Female_512;
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;

            if (rbMale.Checked)
                pbImage.Image = Properties.Resources.Male_512;
            else
                pbImage.Image = Properties.Resources.Female_512;

            llRemoveImage.Visible = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdAddUpdatePerson.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdAddUpdatePerson.FilterIndex = 1;
            ofdAddUpdatePerson.RestoreDirectory = true;

            if (ofdAddUpdatePerson.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = ofdAddUpdatePerson.FileName;
                pbImage.ImageLocation=selectedFilePath;
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void ValidatingTextBox(object sender,CancelEventArgs e)
        {
            TextBox Box=((TextBox)sender);
            
            if (string.IsNullOrEmpty(Box.Text.Trim())){
                e.Cancel = true;
                epAddUpdatePerson.SetError(Box, "This Field is requuired");
            }
            else
                epAddUpdatePerson.SetError(Box, null);


        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {


            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                epAddUpdatePerson.SetError(txtEmail, "Invalid Email Format Please Enter Another or it might be used by another person");
                e.Cancel = true;
            }
            else
                epAddUpdatePerson.SetError(txtEmail, null);
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                epAddUpdatePerson.SetError(txtNationalNo, "This Field is requuired");
                return;
            }

            if (_Person.NationalNo != txtNationalNo.Text.Trim() && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                epAddUpdatePerson.SetError(txtNationalNo, $"National No {txtNationalNo.Text} is used by another person");
            }
            else
                epAddUpdatePerson.SetError(txtNationalNo, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
