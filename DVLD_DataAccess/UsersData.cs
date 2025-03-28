using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsUsersData
    {
        public static bool GetUserInfoByID(int UserID,ref int PersonID,ref string FullName,ref string UserName,
            ref string Password,ref int Permessions,ref bool IsActive)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From UsersView Where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    PersonID=(int )reader["PersonID"];
                    FullName = (string)reader["FullName"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];

                    IsActive = (bool)reader["IsActive"];

                    Permessions = (int)reader["Permessions"];



                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From GetUserInfoByID.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return result;

        }


        public static bool GetUserInfoByPersonID(ref int UserID, int PersonID, ref string FullName,ref string UserName
            , ref string Password, ref int Permessions,ref bool IsActive)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From UsersView Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                   UserID=(int )reader["UserID"];
                    FullName = (string)reader["FullName"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

                    Permessions = (int)reader["Permessions"];
                   
                }
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetUserInfoByPersonID.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return result;
        }

        public static bool GetUserInfoByUserNameAndPassword(ref int UserID,ref int PersonID, ref string FullName, string UserName
            ,string Password, ref int Permessions,ref bool IsActive)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From UsersView Where UserName=@UserName And Password=@Password";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    UserID = (int)reader["UserID"];
                    PersonID= (int)reader["PersonID"];
                    FullName = (string)reader["FullName"];

                    IsActive = (bool)reader["IsActive"];

                    Permessions = (int)reader["Permessions"];

                }
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetUserInfoByUserNameAndPassword.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return result;
        }

        public static int AddNewUser(int PersonID,string UserName,  string Password, int Permessions,bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT Into Users (PersonID,UserName,Password,Permessions,IsActive)
                            Values
                            (@PersonID,@UserName,@Password,@Permessions,@IsActive);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue( "@Permessions", Permessions);
            
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;

                }

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From AddNewUser.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return UserID;
        }

        public static bool UpdateUser(int UserID,int PersonID, string UserName, string Password, int Permessions, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users 
                            SET
                            PersonID=@PersonID,UserName=@UserName,Password=@Password,IsActive=@IsActive,
                            Permessions=@Permessions
                                Where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue( "@Permessions", Permessions);
           

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From UpdateUser.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }

        public static bool DeleteUser(int UserID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Users where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From DeleteUser.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return rowAffected > 0;

        }


        public static DataTable GetAllUsers()
        {

            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From UsersView";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetAllUsers.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return dataTable;
        }
        public static bool IsUserExist(int UserID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select Found =1 From Users where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From IsUserExist.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool IsUserExist(string UserName)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select Found =1 From Users where UserName=@UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From IsUserExist.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select Found =1 From Users where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From IsUserExistForPersonID.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool ChangePassword(int UserID,string Password)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users 
                            SET
                            Password=@Password
                                Where UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From ChangePassword.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }

    }
}
