using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class LicenceClassData
    {

        public static bool GetLicenceClassInfoByID(int LicenseClassID, ref string ClassName, ref string ClassDescription
                                    ,ref byte MinimumAllowedAge,ref byte DefaultValidityLength,ref float ClassFees)
        {
            bool result = false;
            SqlConnection connection=new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From LicenseClasses where LicenseClassID =@LicenseClassID";

            SqlCommand command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = Convert.ToSingle(reader["ClassFees"]);
                }
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetLicenceClassInfoByID.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            
            return result;
        }

        public static bool GetLicenceClassInfoByClassName(string ClassName,ref int LicenseClassID, ref string ClassDescription
                            , ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From LicenseClasses where ClassName =@ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    result = true;
                    LicenseClassID= (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (float)reader["ClassFees"];
                }
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetLicenceClassInfoByClassName.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return result;
        }



        public static DataTable GetAllLicenseClasses() 
        { 
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From LicenseClasses ";

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
                Logger.Log( $"{ex.Message}, From GetAllLicenseClasses.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return dataTable;
        }


        public static int AddNewLicenseClass(string ClassName,  string ClassDescription
                            , byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees) {

            int LicenceClassID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * INSERT INTO LicenseClasses
           (ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength,ClassFees)
     VALUES
           (@ClassName, @ClassDescription, @MinimumAllowedAge,@DefaultValidityLength ,@ClassFees );
                Select Scope_Identity();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);

            try
            {
                connection.Open();

                object resault=command.ExecuteScalar();

                if (resault!=null&&int.TryParse(resault.ToString(),out int InsertedID))
                {

                    LicenceClassID = InsertedID;
                }
               

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From AddNewLicenseClass.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return LicenceClassID;
        }

        public static bool UpdateLicenseClass(int LicenseClassID,string ClassName, string ClassDescription
                    , byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  LicenseClasses  
                            set ClassName = @ClassName,
                                ClassDescription = @ClassDescription,
                                MinimumAllowedAge = @MinimumAllowedAge,
                                DefaultValidityLength = @DefaultValidityLength,
                                ClassFees = @ClassFees
                                where LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From UpdateLicenseClass.", EventLogEntryType.Error );

                return false;
            }

            finally
            {
                connection.Close();
            }
            return rowsAffected >0;
        }
    }
}
