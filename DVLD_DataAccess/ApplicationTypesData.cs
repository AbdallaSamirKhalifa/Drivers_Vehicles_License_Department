﻿using System;
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
    public class clsApplicationTypesData
    {


        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From ApplicationTypes order by ApplicationTypeTitle";
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
                Logger.Log( $"{ex.Message}, From GetAllApplicationTypes.", EventLogEntryType.Error );
            }
            finally { connection.Close(); }

            return dt;


        }

        public static bool GetApplicationType(int ID, ref string Title, ref float Fees)
        {
            bool resault = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From ApplicationTypes where ApplicationTypeID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    resault = true;
                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees =Convert.ToSingle(reader["ApplicationFees"]);

                }
                reader.Close();

            }catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From GetApplicationType.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }
            return resault;
        }
        
        public static bool GetApplicationTypeByTitle(ref int ID, string Title, ref float Fees)
        {
            bool resault = false;


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * From ApplicationTypes where ApplicationTypeTitle=@Title";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    resault = true;
                    ID= (int)reader["ApplicationTypeID"];
                    Fees = Convert.ToSingle( reader["ApplicationFees"]);

                }
                reader.Close();

            }catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetApplicationTypeByTitle.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return resault;
        }

        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From AddNewApplicationType.", EventLogEntryType.Error );


            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;

        }
        public static bool UpdateApplicationType(int ID,string Title,float Fees)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE ApplicationTypes
                               SET 
                                  ApplicationFees= @Fees,ApplicationTypeTitle=@Title
                             WHERE ApplicationTypeID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@Title", Title);

            try
            {
                connection.Open();
                rowAffected = command.ExecuteNonQuery();
                
            }catch(Exception ex)
            {
                Logger.Log( $"{ex.Message}, From UpdateApplicationType.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return rowAffected > 0;

        }
        
    }
}

