using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UI.GlobalClasses
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool SaveCredintiols(string UserName, string Passeword)
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            string fileName = currentDirectory + "\\RememberMe.txt";

            try
            {
                if (UserName == "" && System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                    return true;

                }

                string dataToSave = UserName + "#//#" + Passeword;

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(dataToSave);
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredintials(ref string UserName, ref string Password)
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            string fileName = currentDirectory + "\\RememberMe.txt";
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string Line = "";
                        while ((Line = reader.ReadLine()) != null)
                        {
                            string[] data = Line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            UserName = data[0];
                            Password = data[1];
                        }
                            return true;

                    }
                }else
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public enum enPersmessions
        {
            Admin= -1,
            ManagePeople=1,
            ManageUsers=2,
            ManageLocalLicenseApplications=4,
            ManageInternationalLicenseApplications=8,
            ManageDetainedLicenses=16,

            ManageApplicationTypes=32,

            ManageTestTypes=64,
            RenewDrivingLicense=128,
            ReplaceDrivingLicense=256,
            ManageDrivers=512
                
        };
        public static enPersmessions Permessions { get; }

        public static bool CheckPermesstions(enPersmessions Permession)
        {


            return (CurrentUser.Permessions & (int)Permession) == (int)Permession;
        }

        public static bool CheckPermesstions(clsUser user,enPersmessions Permession)
        {


            return (user.Permessions & (int)Permession) == (int)Permession;
        }
    }
}
