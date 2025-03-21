using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {

        public enum enModeP { AddNew=0,Update};

        public new enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        
        public int LicenseClassID { get; set; }

        public clsLicenseClass LicenseClassInfo;

        public string PersonFullName
        {
            get { return ApplicantFullName; }

        }

        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;

            Mode = enMode.AddNew;   
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingApplicationID, int ApplicationID,
            int ApplicantPersonID,DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate,float PaidFees,int CreatedByUserID,int LicenseClassID)
           
            : base(ApplicationID,ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate
                  ,PaidFees,CreatedByUserID)

        {
            this.LocalDrivingLicenseApplicationID= LocalDrivingApplicationID;
            this.LicenseClassID= LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);

            Mode = enMode.Update;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID=
                clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(ApplicationID,LicenseClassID);

            return this.LocalDrivingLicenseApplicationID != -1;
        }

        private bool _UpdateLocalDrivingClassApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication
                (LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
        }

        public new bool Save()
        {

            //becouse of inheritence first we call the save method of the base class,
            //it will take care of adding all info to the application table 
            base.Mode = Mode;
            if (!base.Save())
                return false;

            //after we save the base application now we save the sub application

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update:
                    return _UpdateLocalDrivingClassApplication();
            }
            return false;
        }

        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicatioID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicetionByID(LocalDrivingLicenseApplicatioID,
                ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                //now we find the base application 
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication
                    (LocalDrivingLicenseApplicatioID, ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate, Application
                    .PaidFees, Application.CreatedByUserID
                    , LicenseClassID);

            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicatioID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicetionByID(ApplicationID,
                ref LocalDrivingLicenseApplicatioID, ref LicenseClassID);

            if (IsFound)
            {
                //now we find the base application 
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsLocalDrivingLicenseApplication
                    (LocalDrivingLicenseApplicatioID, ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate, Application
                    .PaidFees, Application.CreatedByUserID
                    , LicenseClassID);

            }
            else
                return null;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public new bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            //first we delete the local driving application 
            IsLocalDrivingApplicationDeleted=clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID); 


            if(!IsLocalDrivingApplicationDeleted)
                return false;

            //then we delete the base application
             IsBaseApplicationDeleted = clsApplicationData.DeleteApplication(ApplicationID);
          
            return IsBaseApplicationDeleted;

            
        }


        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID,(int)TestTypeID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestType.enTestType TestTypeID)
        {
            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    //in this case no required previous tests
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    //written test , you cannot schedual it before person pass the vesion test
                    //we check if he passed the vision test 1

                    return DoesPassTestType(clsTestType.enTestType.VisionTest);

                case clsTestType.enTestType.StreetTest:
                    //street Test , you cannot schedual it before person pass the Written test
                    //we check if he passed the written test 2

                    return DoesPassTestType(clsTestType.enTestType.WrittenTest);
                default:
                    return false;
            }
        }
      
        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool AttendedTest(clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }

        public static bool AttendedTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID) > 0;
        }


        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest( LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public clsTest GetLatTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestByPersonAndTestTypeAndLicenseClass(this.ApplicantPersonID,this.LicenseClassID,TestTypeID);
        }


        public byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestsCount(this.LocalDrivingLicenseApplicationID);
        }
        
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.GetPassedTestsCount(LocalDrivingLicenseApplicationID);
        }

        public bool PassedAllTests()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return clsTest.PassedAllTests(LocalDrivingLicenseApplicationID);
        }


        public int IssueLicenseForTheFirstTime(string Notes,int CreatedByUserID)
        {
            int DriverID = -1;
            clsDriver driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (driver == null)
            {
                driver = new clsDriver();
                driver.CreatedByUserID = CreatedByUserID;
                driver.PersonID = this.ApplicantPersonID;
                driver.CreatedDate = DateTime.Now;

                if (!driver.Save())
                    return -1;

                DriverID = driver.DriverID;
            }else
                DriverID = driver.DriverID; 

            //now we have a driver, So we add new lciense
            clsLicense NewLicense= new clsLicense();
            NewLicense.DriverID = DriverID;
            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate= DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees=this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.FirstTime;
            NewLicense.CreatedByUserID= CreatedByUserID;
            
            if (!NewLicense.Save())
                return -1;

            //we should set the application statust to complete
            this.SetComplete();
            return NewLicense.LicenseID;

        }

        public bool IsLicenseIssued()
        {
            return clsLicense.IsLicenseExistByPersonID(this.ApplicantPersonID,this.LicenseClassID);
        }

        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
    }
}
