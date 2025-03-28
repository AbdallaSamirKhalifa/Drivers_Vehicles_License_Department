using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Buisness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update };
        public enMode Mode=enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get;  set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        
        public clsPerson PersonInfo;
        public int Permessions { get; set; }


        public clsUser()
        {
            Mode = enMode.AddNew;
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = true;
            FullName = "";
            this.Permessions = 0;
        }

        private clsUser(int userid, int personID, string userName,
            string password, int Permessions,bool isActive,string fullName)
        {
            Mode = enMode.Update;
            this.UserID = userid;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.FullName = fullName;
            this.Permessions = Permessions;
            this.PersonInfo = clsPerson.Find(personID);
        }


        public static clsUser FindByUserID(int UserID)
        {
            string UserName = "";
            string Password = "";
            int PersonID = -1;
            bool IsActive = true;
            string FullName = "";

            int Permession = 0;
        
            if(clsUsersData.GetUserInfoByID(UserID,ref PersonID, ref FullName,ref UserName, ref Password, ref Permession,ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, Permession,IsActive, FullName);
            }
            else
                return null;
            


        }

        public static clsUser FindByUserNameAndPassword(string UserName,string Password)
        {

            int UserID = -1;
            int PersonID = -1;
            bool IsActive = true;
            string FullName = "";
            int Permessions = 0;

            if (clsUsersData.GetUserInfoByUserNameAndPassword(ref UserID,ref PersonID, ref FullName,  UserName, Password, ref Permessions,ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, Permessions,IsActive, FullName);
            }
            else
                return null;



        }
        public static clsUser FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string Password = "";
            string UserName= "";
            bool IsActive = true;
            string FullName = "";
            int Permessions = 0;

            if (clsUsersData.GetUserInfoByPersonID(ref UserID,PersonID, ref FullName, ref UserName, ref Password, ref Permessions, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, Permessions,IsActive, FullName);
            }
            else
                return null;



        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersData.AddNewUser(this.PersonID,this.UserName,this.Password,this.Permessions,this.IsActive);

            return (this.UserID!=-1);
        }

        private bool _UpdateUser()
        {


            return clsUsersData.UpdateUser(this.UserID,this.PersonID,this.UserName,this.Password,this.Permessions,this.IsActive);
        }

        public bool ChangePassword(string NewPassword)
        {

            if (clsUsersData.ChangePassword(this.UserID, NewPassword))
            {
                this.Password = NewPassword;
                return true;
            }
            return false;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    if (_UpdateUser())
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
    
        public static bool IsUserExist(int userID)
        {
            return clsUsersData.IsUserExist(userID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUsersData.IsUserExist(UserName);
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistForPersonID(PersonID);
        }


        public static DataTable GetAllUsers()
        {
            return clsUsersData.GetAllUsers();
        }
    }
}
