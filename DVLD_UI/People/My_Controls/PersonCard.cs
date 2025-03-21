using DVLD_Buisness;
using DVLD_UI.My_Forms;
using DVLD_UI.People;
using DVLD_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.My_Controls
{

    public partial class PersonCard : UserControl
    {



        private clsPerson _Person;

        private int _PersonID = -1;
        public int PersonID { get { return _PersonID; } }

        public clsPerson SelectedPersonInfo { get { return _Person; } }
        private void _FillPersonInfo()
        {
          
                _PersonID = _Person.ID;
            lblID.Text = _Person.ID.ToString();
                lblName.Text = _Person.FullName;
                lblNationalNo.Text = _Person.NationalNo;
                lblEmail.Text = _Person.Email;
                lblAddress.Text = _Person.Address;
                lblPhone.Text = _Person.Phone;
                lblCountry.Text= _Person.CountryName;
                lblDOB.Text = _Person.DateOfBirth.ToShortDateString();
                lblGender.Text = _Person.GenderString;

            _LoadPersonImage();
                

        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with ID " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillPersonInfo();
            
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _FillPersonInfo();

        }

        private void _LoadPersonImage()
        {

            if (_Person.GenderString == "Male")
               pbGender.Image= pbImage.Image = Properties.Resources.Male_512;
            else
                pbGender.Image = pbImage.Image = Properties.Resources.Female_512;


            string ImagePath = _Person.ImagePath;

            if(ImagePath == "")
            {
                return;
            }

            if (File.Exists(ImagePath))
                pbImage.ImageLocation = ImagePath;
            else
                MessageBox.Show("Image " + ImagePath + " not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;

            lblID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblName.Text = "[????]";
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDOB.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbImage.Image = Resources.Male_512;
        } 
        public PersonCard()
        {
            InitializeComponent();
        }


        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm= new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();

            //Refresh the Person Info
            LoadPersonInfo(_PersonID);
        }


    }
}
