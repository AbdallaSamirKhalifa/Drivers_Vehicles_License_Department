using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsApplicationType
    {
        public enum enMode { AddNew=0,Update};

        public enMode Mode;
        public int ID { get; set; }

        public string Title{ get; set; }    

        public float Fees { get; set; }


        public clsApplicationType()
        {

            ID = -1;
            Title = "";
            Fees = 0;
            Mode = enMode.AddNew;

        }

        private clsApplicationType(int id,string title,float fees)
        {

            this.ID = id;
            this.Title = title;
            this.Fees = fees;
            Mode = enMode.Update;
        }


        public static clsApplicationType Find(int ID)
        {
            string title = "";
            float fees = 0;

            if(clsApplicationTypesData.GetApplicationType(ID,ref title,ref fees))
                return new clsApplicationType(ID,title,fees);
            else
            return null;
        }
        
        public static clsApplicationType Find(string title)
        {
            int id= 0;
            float fees = 0;

            if(clsApplicationTypesData.GetApplicationTypeByTitle(ref id, title,ref fees))
                return new clsApplicationType(id,title,fees);
            else
            return null;
        }

        private bool _Update()
        {
            return clsApplicationTypesData.UpdateApplicationType(this.ID, this.Title,this.Fees);
        }

        private bool _AddNew()
        {
            this.ID = clsApplicationTypesData.AddNewApplicationType(this.Title, this.Fees);
            return this.ID != -1;
        }

        public static DataTable GetAllAplicationTypes() 
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
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
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }
    }
}
