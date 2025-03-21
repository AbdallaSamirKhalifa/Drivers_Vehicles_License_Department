using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLicenseClass
    {

        public enum enMode { AddNew=0,Update}

        enMode Mode=enMode.AddNew;

            public int LicenseClassID { get; set; }

        public string ClassName { get; set; }

        public string ClassDescription { get;set; }

        public byte MinimumAllowedAge { get; set; }

        public byte DefaultValidityLength { get; set; }

        public float ClassFees { get;set; }

       public clsLicenseClass()
        {
            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = 18;
            DefaultValidityLength = 10;
            ClassFees = 0;
            Mode = enMode.AddNew;
        }

        private clsLicenseClass(int licenseClassID, string className, string classDescription,
            byte minimumAllowedAge, byte defaultValidityLength, float classFees)
        {
            Mode = enMode.Update;
            this.LicenseClassID = licenseClassID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinimumAllowedAge = minimumAllowedAge;
            this.DefaultValidityLength = defaultValidityLength;
            this.ClassFees = classFees;
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string className = "", classDescription = "";
            byte minimumAllowedAge = 18, defaultValidityLength = 10;
            float classFees = 0;

            if (LicenceClassData.GetLicenceClassInfoByID(LicenseClassID, ref className, ref classDescription, ref minimumAllowedAge, ref defaultValidityLength,
                ref classFees))
                return new clsLicenseClass(LicenseClassID, className, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
            else return null;
        }

        public static clsLicenseClass Find(string ClassName)
        {
            int ID = 0;
            string classDescription = "";
            byte minimumAllowedAge = 18, defaultValidityLength = 10;
            float classFees = 0;

            if (LicenceClassData.GetLicenceClassInfoByClassName( ClassName, ref ID,ref classDescription, ref minimumAllowedAge, ref defaultValidityLength,
                ref classFees))
                return new clsLicenseClass(ID, ClassName, classDescription, minimumAllowedAge, defaultValidityLength, classFees);
            else return null;
        }

        public static DataTable GetLicenseClasses()
        {
            return LicenceClassData.GetAllLicenseClasses();

        }


        private bool _AddNew()
        {
            this.LicenseClassID =LicenceClassData.AddNewLicenseClass(this.ClassName,this.ClassDescription,this.MinimumAllowedAge,this.DefaultValidityLength
                ,this.ClassFees);


            return this.LicenseClassID!=-1;
        }

        private bool _Update()
        {
            return LicenceClassData.UpdateLicenseClass(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength
                ,this.ClassFees);
            

        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update; 
                        return true;
                    }
                   else
                        return false;

                case enMode.Update:
                    return _Update();

            }
            return false;
        }
    }
}
