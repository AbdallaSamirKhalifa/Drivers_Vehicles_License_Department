using System;
using DVLD_DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLD_Buisness
{
    public class clsCountry
    {
        public int CountryID { get; set; } 
        public string CountryName { get; set; }

 public clsCountry()
        {
            CountryID = -1;
            CountryName = "";
        }

        private clsCountry(int countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
        }

        public static clsCountry Find(int ID) {

            string CountryName = "";

            if(clsCountriesData.GetCountry(ID,ref CountryName))
                return new clsCountry(ID,CountryName);
            else
            return null;  
        }

        public static clsCountry Find(string CountryName )
        {

            int CountryID= -1;

            if (clsCountriesData.GetCountryByName(ref CountryID, CountryName))
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }
        public static DataTable GetAllCountries()
        {
            return clsCountriesData.GetAllCountries();
        }
    }
}
