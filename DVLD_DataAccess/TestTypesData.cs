using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypesData
    {


        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From TestTypes order by TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetAllTestTypes.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return dt;


        }

        public static bool GetTestType(int ID, ref string Title,ref string Description, ref float Fees)
        {
            bool resault = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From TestTypes where TestTypeID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    resault = true;
                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = Convert.ToSingle(reader["TestTypeFees"]);

                }
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetTestType.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return resault;
        }

        public static bool GetTestTypeByTitle(ref int ID, string Title,ref  string Descreption, ref float Fees)
        {
            bool resault = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From TestTypes where TestTypeTitle=@Title";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    resault = true;
                    ID = (int)reader["TestTypeID"];
                    Descreption = (string)reader["TestTypeDescription"];
                    Fees = Convert.ToSingle(reader["TestTypeFees"]);

                }
                reader.Close();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetTestTypeByTitle.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return resault;
        }

        public static bool UpdateTestType(int ID, string Title,string Description, float Fees)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestTypes
                               SET 
                                  TestTypeFees= @Fees
                                ,TestTypeTitle=@Title
                                ,TestTypeDescription=@Description
                             WHERE TestTypeID=@ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From UpdateTestType.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return rowAffected > 0;

        }

        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From AddNewTestType.", EventLogEntryType.Error );


            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }

    }
}

