using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsDriver
    {

        public enum enMode { AddNew=0,Update};
        public enMode Mode = enMode.AddNew;
        public int DriverID { set; get; }   
        public int PersonID {  set; get; }  
        public int CreatedByUserID { set; get; }

        public clsPerson PersonInfo;
        public DateTime CreatedDate { set; get; }


        public clsDriver()
        {
            Mode = enMode.AddNew;
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.MinValue;
        }

        private clsDriver( int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            Mode = enMode.Update;
            this.DriverID = driverID;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.Find(this.PersonID);
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID);
            return (DriverID != -1);

        }

        private bool _Update()
        {
            return clsDriverData.UpdateDriver(this.DriverID,this.PersonID,this.CreatedByUserID);    

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: 
                    return _Update();   
            }
            return false;
        }

        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if(clsDriverData.GetDriverInfoByDriverID(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate))
                return new clsDriver(DriverID,PersonID,CreatedByUserID,CreatedDate);

            return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            if (clsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);

            return null;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
    }
}
