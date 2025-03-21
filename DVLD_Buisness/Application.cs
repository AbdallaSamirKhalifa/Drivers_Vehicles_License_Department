using DVLD_DataAccess;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsApplication
    {

        public enum enMode { AddNew=0,Update};
        public enMode Mode=enMode.AddNew;

        public enum enApplicationType { NewDrivingLicense=1, RenewDrivingLicense=2, ReplaceLostDrivingLicense=3, 
        ReplaceDamagedDrivingLicense=4, ReleaseDetainedLicense=5,NewInternationaLicense=6, RetakeTest=7};

        public enum enApplicationStatus { New=1,Cancelled=2,Completed=3};

        public enApplicationStatus ApplicationStatus { set; get; }
        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }
        public clsPerson PersonInfo { set; get; }

        public string ApplicantFullName { get { return PersonInfo.FullName; } }

        public DateTime ApplicationDate { set; get; }

        public int ApplicationTypeID { set; get; }

        public clsApplicationType ApplicationTypeInfo;

        public string StatusText { get
            
                {switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";

                    case enApplicationStatus.Cancelled:
                        return "Cancelled";

                    case enApplicationStatus.Completed:
                        return "Completed";

                    default:
                        return "Unknown";
                }
            }
            } 

        public DateTime LastStatusDate { set; get; }

        public float PaidFees { set; get; }

        public int CreatedByUserID { set; get; }

        public clsUser CreatedByUserInfo;

        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1; 
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate=DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;


            Mode = enMode.AddNew;

        }

        protected clsApplication(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID)
        {
            
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID
                = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return this.ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID,this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now,LastSatatusDate=DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 1;
            int CreatedByUserID = -1;
            float PaidFees = 0;

            bool IsFound = clsApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate,
                ref ApplicationTypeID,
                ref ApplicationStatus, ref LastSatatusDate, ref PaidFees, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsApplication(ApplicationID,ApplicantPersonID,ApplicationDate,ApplicationTypeID,
                    (enApplicationStatus)ApplicationStatus,LastSatatusDate
                    ,PaidFees,CreatedByUserID);    
            }else
                return null;
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID,2);
        }

        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(this.ApplicationID, 3);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateApplication();
            }

            return false;
        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }

        public static bool IsApplicationExist(int ApplicationID)
        {
            return clsApplicationData.IsApplicationExist(ApplicationID);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID,int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);

        }
        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(this.ApplicantPersonID, ApplicationTypeID);

        }

        public static int GetActiveApplicationID(int PersonID,enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID,(int)ApplicationTypeID);
        }

        public int GetActiveApplicationID(enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(this.ApplicantPersonID, (int)ApplicationTypeID);
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID,int LicenceClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID,LicenceClassID);
        }

    }
}
