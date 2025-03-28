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
    public class clsPeopleData
    {
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
                                         , ref DateTime DOB, ref string Gender, ref string Address, ref string Phone, ref string Email,
                                            ref string CountryName, ref string ImagePath)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From PeopleView Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    
                    LastName = (string)reader["LastName"];
                    DOB = (DateTime)reader["DateOfBirth"];
                    Gender = (string)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                   
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                    
                    CountryName = (string)reader["CountryName"];
                   
                    
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

                }
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetPersonInfoByID.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return result;

        }


        public static bool GetPersonInfoByN(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
                                 , ref DateTime DOB, ref string Gender, ref string Address, ref string Phone, ref string Email,
                                    ref string CountryName, ref string ImagePath)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From PeopleView Where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)reader["LastName"];
                    DOB = (DateTime)reader["DateOfBirth"];
                    Gender = (string)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                    CountryName = (string)reader["CountryName"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From GetPersonInfoByN.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return result;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName
                                 , DateTime DOB, byte Gender, string Address, string Phone, string Email,
                                    int NationalityCountryID, string ImagePath)
        {
            int PeronID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT Into People (NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID
                            ,ImagePath)
                            Values
                            (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName
                            ,@DOB,@Gender,@Address,@Phone,@Email,@NationalityCountryID
                            ,@ImagePath);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName == "")
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DOB", DOB);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email == "")
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath == "")
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PeronID = insertedID;

                }

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From AddNewPerson.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return PeronID;
        }

        public static bool UpdatePersosn(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName
                                 , DateTime DOB, byte Gender, string Address, string Phone, string Email,
                                    int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People 
                            SET
                            NationalNo=@NationalNo,FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName,LastName=@LastName
                            ,DateOfBirth=@DOB,Gendor=@Gender,Address=@Address,Phone=@Phone,Email=@Email,NationalityCountryID=@NationalityCountryID
                            ,ImagePath=@ImagePath
                                Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName == "")
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DOB", DOB);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email == "")
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath == "")
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From UpdatePersosn.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return rowsAffected > 0;
        }

        public static bool DeletePerson(int PersonID)
        {
            int rowAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete People where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From DeletePerson.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return rowAffected > 0;

        }

        public static DataTable GetAllPeople()
        {

            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From People";

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
                Logger.Log( $"{ex.Message}, From GetAllPeople.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return dataTable;
        }

        public static DataTable GetAllPeopleFromView()
        {

            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * From PeopleView";

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
                Logger.Log( $"{ex.Message}, From GetAllPeopleFromView.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return dataTable;
        }
        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select Found =1 From People where PersonID=@PersonID";

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
                Logger.Log( $"{ex.Message}, From IsPersonExistByID.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select Found =1 From People where NationalNo=@NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From IsPersonExistByNaNo.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool IsEmailExist(string Email)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "Select Found =1 From People where Email=@Email";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();

            }
            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From IsEmailExist.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return IsFound;
        }
    }
}
