using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Buisness
{
    public class clsLicense
    {
       public enum enMode { AddNew=0,Update};
        public enMode Mode=enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public enIssueReason IssueReason = enIssueReason.FirstTime;

        public string IssueReasonString
        {
            get
            {
                return _GetIssueReasonText(this.IssueReason);
            }
        }
        public int LicenseID { get; set; }
        public int ApplicationID {  get; set; } 
        public int DriverID {  get; set; }
        public clsDriver DriverInfo;
        public int LicenseClassID {  get; set; }

        public clsLicenseClass LicenseClassInfo;

        public int CreatedByUserID {  get; set; }   

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }   

        public string Notes {  get; set; }  
        public float PaidFees {  get; set; }
        public bool IsActive { get; set; }

        public clsDetainedLicense DetainedLicenseInfo{ set; get; }

        public bool IsDetained { get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); } }




        public clsLicense()
        {
            Mode = enMode.AddNew;
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            CreatedByUserID = -1;
            IssueDate=DateTime.MinValue;
            ExpirationDate = DateTime.MinValue;
            Notes = "";
            PaidFees = 0;
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;

        }

        private clsLicense(  int licenseID, int applicationID, int driverID, int licenseClassID,
            int createdByUserID, DateTime issueDate, DateTime expirationDate,
            string notes, float paidFees, enIssueReason issueReason, bool isActive)
        {
            IssueReason = issueReason;
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClassID = licenseClassID;
            CreatedByUserID = createdByUserID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            
            DriverInfo = clsDriver.FindByDriverID(DriverID);
            LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            DetainedLicenseInfo=clsDetainedLicense.FindByLicenseID(this.LicenseID);
            Mode = enMode.Update;
        }


        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(ApplicationID, DriverID, LicenseClassID
                , IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);
            return LicenseID != -1;
        }
        
        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(LicenseID,ApplicationID, DriverID, LicenseClassID
                , IssueDate, ExpirationDate, Notes, PaidFees, IsActive, (byte)IssueReason, CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update:
                    return _UpdateLicense();
            }
            return false;
        }


        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClassID = -1, CreatedByUserID = -1;
            DateTime IssueDate=DateTime.MinValue,ExpirationDate=DateTime.MinValue;
            bool IsActive=false;
            string Notes = "";
            float PaidFees = 0;
            byte IssueReason = 0;

            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID
                , ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive,
                ref IssueReason, ref CreatedByUserID))
                
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, CreatedByUserID
                    , IssueDate, ExpirationDate, Notes, PaidFees, (enIssueReason)IssueReason, IsActive);

            return null;
        }


        public static DataTable GetAllLicenses()
        
        {
            return clsLicenseData.GetAllLicenses();
        }

        public static bool IsLicenseExistByPersonID(int PersonID,int LicenseClassID)
        {
            return clsLicenseData.IsLicenseExistForPerson(PersonID, LicenseClassID);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID,int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);   

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        public bool DeactivateCurrentLicense()
        {
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }

        private string _GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement For Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement For Lost";
                default
                    :
                    return "First Time";

            }

        }

        public clsLicense RenewLicense(int CreatedByUserID, string Notes)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
               return null;

            clsLicense NewLicense = new clsLicense();


            NewLicense.ApplicationID=Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID= this.LicenseClassID;
            NewLicense.IssueDate= DateTime.Now;
            NewLicense.ExpirationDate= DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.CreatedByUserID= CreatedByUserID;

            if (!NewLicense.Save())
                return null;

            //deactivate the current License Before Go
            DeactivateCurrentLicense();
            
            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
                return null;

            clsLicense NewLicense= new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save()) return null;

            //deactivate the old license first
            DeactivateCurrentLicense();
            return NewLicense;


        }

        public int Detain(float FineFees,int CreatedByUserID)
        {


            clsDetainedLicense Detain = new clsDetainedLicense();
            Detain.LicenseID = this.LicenseID;
            Detain.FineFees = FineFees;
            Detain.CreatedByUserID= CreatedByUserID;
            Detain.DetainDate = DateTime.Now;

            if (!Detain.Save())
                return -1;



            return Detain.DetainID;
        }

        public bool ReleaseDetainedLicese(int ReleasedByUserID,ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedLicense;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = 
                clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedLicense).Fees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }
            ApplicationID=Application.ApplicationID;

            return this.DetainedLicenseInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);
                
        }
    }
}
