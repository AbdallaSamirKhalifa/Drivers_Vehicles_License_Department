using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsTest
    {
        public enum enMode { AddNew = 0, Update };
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { set; get; }

        public clsTestAppointment TestAppointmentInfo { set; get; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            Mode = enMode.AddNew;
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            CreatedByUserID = -1;
            Notes = "";
        }

        private clsTest(int TestID, int TestAppointmentID,
        bool TestResult, string Notes, int CreatedByUserID)

        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;


        }

        private bool _AddNewTest()
        {
            this.TestID=clsTestsData.AddNewTest(this.TestAppointmentID,this.TestResult,this.Notes,this.CreatedByUserID);
            return this.TestID != -1;
        }

        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateTest();
            }
            return false;
        }

        public static clsTest Find(int TestID)

        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            string Notes = "";
            bool TestResult = false;

            if(clsTestsData.GetTestInfoByID(TestID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreatedByUserID))
                return new clsTest(TestID,TestAppointmentID,TestResult,Notes,CreatedByUserID);  
            else
                return null;
        }

        public static clsTest FindLastTestByPersonAndTestTypeAndLicenseClass(int PersonID,int LicenseClassID,
            clsTestType.enTestType TestTypeID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1,TestID=-1;
            string Notes = "";
            bool TestResult = false;

            if(clsTestsData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID,LicenseClassID,(int)TestTypeID,
                ref TestID,ref TestAppointmentID,ref TestResult,ref Notes,ref CreatedByUserID))
                return new clsTest(TestID,TestAppointmentID,TestResult,Notes,CreatedByUserID);  
            else
                return null;    


        }

        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();

        }

        public static byte GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if passed tests less than 3 it will return false otherwise it will return true
            return clsTestsData.GetPassedTestCount(LocalDrivingLicenseApplicationID)==3;
        }
    }
}
