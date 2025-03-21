using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsTestAppointment
    {

        public enum enMode { AddNew=0,Update};
        private enMode _Mode;
        public int AppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID { set; get; }

        public DateTime AppointmentDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }

        public bool IsLocked { set; get; }
        public int RetakeTestApplicationID { set;get; }

        public clsApplication RetakeTestAppInfo { set; get; }

        public int TestID { get { return _GetTestID(); } }

        public clsTestAppointment()
        {
            _Mode = enMode.AddNew;
            AppointmentID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            LocalDrivingLicenseApplicationID = -1;  
            AppointmentDate = DateTime.Now; 
            PaidFees = 0;
            CreatedByUserID = -1;
            RetakeTestApplicationID = -1;   

        }

        private clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,
           int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)

        {
            this.AppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestAppInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);
            _Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.AppointmentID = clsTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID
                , this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.RetakeTestApplicationID);
            return this.AppointmentID != -1;
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.AppointmentID,(int)this.TestTypeID,this.LocalDrivingLicenseApplicationID
                ,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
        }

        public static clsTestAppointment Find(int AppointmentID)
        {
            int TestTypeID = -1,LocalDriverLicenseID=-1,CreatedByUserID=-1,RetakeTestApplicationID=-1;
            bool IsLocked = false;
            DateTime AppointmentDate = DateTime.MinValue;   
            float PaidFees = 0;

            bool isFound = clsTestAppointmentData.GetTestAppointmentByID(AppointmentID, ref TestTypeID, ref LocalDriverLicenseID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);

            if(isFound)
            {
                return new clsTestAppointment(AppointmentID, (clsTestType.enTestType)TestTypeID, LocalDriverLicenseID
                    , AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            }else
                return null;
        }

        public static clsTestAppointment GetLastTestAppointment(int LocalDriverLicenseID, clsTestType.enTestType TestTypeID)
        {
            int AppointmentID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
            bool IsLocked = false;
            float PaidFees = 0;
            DateTime AppointmentDate = DateTime.MinValue;

            bool isFound = clsTestAppointmentData.GetLastTestAppointment(LocalDriverLicenseID, (int) TestTypeID, ref AppointmentID,
               ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);

            if(isFound)
            {
                return new clsTestAppointment(AppointmentID, (clsTestType.enTestType)TestTypeID, LocalDriverLicenseID
                    , AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);

            }
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        _Mode=enMode.Update;
                        return true;
                    }else
                        return false;
                case enMode.Update:
                    return _UpdateTestAppointment();
            }   
            return false;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointment.GetAllTestAppointments();

        }

        private int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(this.AppointmentID);
        }

        public  DataTable GetApplicationTestAppointmentsPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public  static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        
    }
}
