using DVLD_Buisness;
using System;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;


namespace DVLD_UI.GlobalClasses
{
    internal static class clsGlobal
    {

        private const string KeyPath = @"SOFTWARE\DVLD";
        private const string valueNameForUserName = "UserName";
        private const string valueNameForPass = "Password";
        public static clsUser CurrentUser;

        public static bool CheckForRegisterValues()
        {

            try
            { 
                 using (RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath,true))
                 {
                     if (key != null)
                     {
                        if (key.GetValueNames().Length > 1)
                        {
                            key.DeleteValue(valueNameForUserName);
                            key.DeleteValue(valueNameForPass);

                        }
                    }
                    else
                        throw new Exception("Key not found");

                }
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Unauthorized Access Exception: Run the program with administrative privileges",
                    "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Some error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool SaveCredintiolsInRegistry(string UserName, string Password)
        {
            if(!CheckForRegisterValues()) 
                return false;
            
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath,true))
                {

                    if (key != null)
                    {
                        

                        key.SetValue(valueNameForUserName, UserName, RegistryValueKind.String);
                        key.SetValue(valueNameForPass, Password, RegistryValueKind.String);


                    }
                    else
                        throw new Exception("Key not found");
                }

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Unauthorized Access Exception: Run the program with administrative privileges",
                    "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Some error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
        }
        public static bool GetStoredCredintialsFromRegistry(ref string UserName, ref string Password)
        {


            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyPath, false))
                {
                    if (key != null)
                    {
                        string UserNameValue=key.GetValue(valueNameForUserName, null) as string;
                        string PasswordValue=key.GetValue(valueNameForPass, null) as string;

                        if (UserNameValue != null && PasswordValue != null)
                        {
                            UserName = UserNameValue;
                            Password = PasswordValue;
                        }
                        else
                            return false;
                       

                    }
                    else
                        throw new Exception("Key not found");

                }

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Unauthorized Access Exception: Run the program with administrative privileges",
                    "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Some error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            

        }

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
