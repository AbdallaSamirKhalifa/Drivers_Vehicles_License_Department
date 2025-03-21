using System;
using System.ComponentModel;
using System.Data;
using DVLD_DataAccess;


namespace DVLD_Buisness
{
    public class clsPerson
    {

        public enum enMode { AddNew = 0, Update }
        public enMode Mode;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        private byte Gender;

        public string GenderString
        { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public string CountryName { get; }
        public clsPerson()
        {
            Mode = enMode.AddNew;
            ID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            NationalNo = "";
            DateOfBirth = DateTime.Now;
            GenderString = "";
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

        }

        private clsPerson(int iD, string firstName, string secondName, string thirdName,
            string lastName, string nationalNo,
            DateTime dateOfBirth, string gender, string address, string phone,
            string email, string CountryName, string imagePath)
        {
            Mode = enMode.Update;
            this.ID = iD;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNo = nationalNo;
            this.DateOfBirth = dateOfBirth;
            this.GenderString = gender;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.CountryName = CountryName;
            this.ImagePath = imagePath;
        }

        public static clsPerson Find(int PersonID)
        {
            //int nationalityCountryID = -1;
            //byte gender = 0;
            string firstName = "", secondName = "", thirdName = "",CountryName="", lastName = "", nationalNo = "", address = "", phone = "", email = "", imagePath = "",GenderString="";
            DateTime dateOfBirth = DateTime.Now;



            if (clsPeopleData.GetPersonInfoByID(PersonID, ref nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref GenderString
                , ref address, ref phone, ref email, ref CountryName, ref imagePath))
            {
                //genderString = gender == 0 ? "Male" : "Female";
                return new clsPerson(PersonID, firstName, secondName, thirdName, lastName, nationalNo, dateOfBirth, GenderString
                , address, phone, email, CountryName, imagePath);

            }

            return null;
        }


        public static clsPerson Find(string NationalNo)
        {
            //int nationalityCountryID = -1;
            int PersonID = -1;
            //byte Gender = 0;
            string firstName = "", secondName = "",CountryName="", thirdName = "", lastName = "", address = "", phone = "", email = "", imagePath = "",GenderString="";
            DateTime dateOfBirth = DateTime.Now;



            if (clsPeopleData.GetPersonInfoByN(ref PersonID, NationalNo, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref GenderString
                , ref address, ref phone, ref email, ref CountryName, ref imagePath))
            {
                //genderString = Gender == 0 ? "Male" : "Female";

                return new clsPerson(PersonID, firstName, secondName, thirdName, lastName, NationalNo, dateOfBirth, GenderString
                , address, phone, email, CountryName, imagePath);

            }

            return null;
        }



        private bool _AddNew()
        {
            Gender = GenderString == "Male" ?Convert.ToByte( 0) : Convert.ToByte(1);
            this.ID = clsPeopleData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address
                , this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

            return this.ID != -1;
        }

        private bool _Update()
        {
            Gender = GenderString == "Male" ? Convert.ToByte(0) : Convert.ToByte(1);

            return clsPeopleData.UpdatePersosn(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }
        
        public static DataTable GetAllPeopleFromView()
        {
            return clsPeopleData.GetAllPeopleFromView();
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPeopleData.IsPersonExist(PersonID);
        }
        
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPeopleData.IsPersonExist(NationalNo);
        }

        public static bool IsEmailExist(string Email)
        {
            return clsPeopleData.IsEmailExist(Email);
        }

    }
}
