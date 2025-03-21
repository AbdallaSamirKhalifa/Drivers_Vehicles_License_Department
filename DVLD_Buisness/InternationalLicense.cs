using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsInternationalLicense:clsApplication
    {
        public new enum enMode { AddNew=0,Update};
        public new enMode Mode=enMode.AddNew;

        public int InternationalLicenseID {  get; set; }    

        public int DriverID {  get; set; }  
        public int IssuedUsingLocalLicenseID {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate {  get; set; }   
        public bool IsActive {  get; set; }

        public clsDriver DriverInfo;
        public clsInternationalLicense()
        {

            //here we set the application type
            this.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationaLicense;

            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;

            this.IsActive = true;
            Mode = enMode.AddNew;

        }

        private clsInternationalLicense(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            enApplicationStatus ApplicationStatus, DateTime LastStatusDate, 
            float PaidFees, int CreatedByUserID, int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
            : base(ApplicationID, ApplicantPersonID, ApplicationDate,
                  (int)clsApplication.enApplicationType.NewInternationaLicense, ApplicationStatus, LastStatusDate
                  , PaidFees, CreatedByUserID)
        {


            this.InternationalLicenseID= InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.DriverInfo=clsDriver.FindByDriverID(this.DriverID);
            Mode = enMode.Update;
            


        }


        private bool _AddNewInternationLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.
                AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate
                , this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return this.InternationalLicenseID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, this.ApplicationID,
                this.DriverID, this.IssuedUsingLocalLicenseID , this.IssueDate, this.ExpirationDate
                , this.IsActive, this.CreatedByUserID);
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalLicenseID = -1, CreatedByUserID = -1;

            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            bool IsActive = false;

            if(clsInternationalLicenseData.GetInternationalLicenseByID(InternationalLicenseID,ref ApplicationID,ref DriverID,
                ref IssuedUsingLocalLicenseID
                ,ref IssueDate,ref ExpirationDate,ref IsActive,ref CreatedByUserID))
            {
                clsApplication Application= clsApplication.FindBaseApplication(ApplicationID);

                return new clsInternationalLicense(Application.ApplicationID,Application.ApplicantPersonID,
                    Application.ApplicationDate,( enApplicationStatus)Application.ApplicationStatus
                    ,Application.LastStatusDate,Application.PaidFees,Application.CreatedByUserID,InternationalLicenseID,
                    DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive);

            }
            return null;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();

        }

        public new bool Save()
        {
            //becouse of the inheritance first we call the save method of the base application
            //it will take care of the adding all informatioins to the application table.

            base.Mode = (clsApplication.enMode)Mode;
            if(!base.Save())
                return false;

            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationLicense())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateInternationalLicense();
            }
            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public static DataTable GetDriverInternationLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }

        public static bool IsInternationLicenseExists(int DriverID)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExists(DriverID);
        }
    }
}
