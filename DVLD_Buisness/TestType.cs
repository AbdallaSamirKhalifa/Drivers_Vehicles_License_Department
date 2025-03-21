using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsTestType
    {

        public enum enMode { AddNew=0,Update};
        public enMode Mode;

        public enum enTestType { VisionTest=1,WrittenTest=2,StreetTest=3};
        public enTestType ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public float Fees { get; set; }


        public clsTestType()
        {
            ID = enTestType.VisionTest;
            Title = "";
            Fees = 0;
            Description = "";
            Mode = enMode.AddNew;
        }

        private clsTestType(enTestType id, string title,string description, float fees)
        {
            this.ID = id;
            this.Title = title;
            this.Fees = fees;
            this.Description = description;
            Mode = enMode.Update;
        }


        public static clsTestType Find(enTestType ID)
        {
            string title = "";
            string description = "";
            float fees = 0;

            if (clsTestTypesData.GetTestType((int)ID, ref title,ref description, ref fees))
                return new clsTestType(ID, title,description, fees);
            else
                return null;
        }
        
        public static clsTestType Find(string Title)
        {
            int id= -1;
            string description = "";
            float fees = 0;

            if (clsTestTypesData.GetTestTypeByTitle(ref id,Title,ref description, ref fees))
                return new clsTestType((enTestType)id, Title,description, fees);
            else
                return null;
        }

        private bool _AddNew()
        {
            this.ID = (enTestType)clsTestTypesData.AddNewTestType(this.Title, this.Description, this.Fees);
            return this.Title != "";
        }
        private bool _Update()
        {
            return clsTestTypesData.UpdateTestType((int)this.ID, this.Title,this.Description, this.Fees);
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
        public static DataTable GetAllAplicationTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }
    }
}
