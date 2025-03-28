using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DVLD_DataAccess
{
    public class clsTestsData
    {

        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult,
            ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * from Tests Where TestID=@TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    //reset the flasg to be true becouse the record is found
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];
                }
                reader.Close();
            }
            catch (Exception ex) 
            {
                Logger.Log( $"{ex.Message}, From GetTestInfoByID.", EventLogEntryType.Error );

            }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID, int LicenseClassID, 
            int TestTypeID,
            ref int TestID, ref int TestAppointmentID,
            ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand( query, connection );

            command.Parameters.AddWithValue( "@PersonID", PersonID );
            command.Parameters.AddWithValue( "@LicenseClassID", LicenseClassID );
            command.Parameters.AddWithValue( "@TestTypeID", TestTypeID );

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From GetLastTestByPersonAndTestTypeAndLicenseClass.", EventLogEntryType.Error );

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static DataTable GetAllTests()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests order by TestID";

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
                Logger.Log( $"{ex.Message}, From GetAllTests.", EventLogEntryType.Error );

            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult,
            string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into Tests (TestAppointmentID,TestResult,
                                                Notes,   CreatedByUserID)
                            Values (@TestAppointmentID,@TestResult,
                                                @Notes,   @CreatedByUserID);
                            
                                UPDATE TestAppointments 
                                SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;

                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);



            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From AddNewTest.", EventLogEntryType.Error );


            }

            finally
            {
                connection.Close();
            }


            return TestID;

        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
             string Notes, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Tests  
                            set TestAppointmentID = @TestAppointmentID,
                                TestResult=@TestResult,
                                Notes = @Notes,
                                CreatedByUserID=@CreatedByUserID
                                where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From UpdateTest.", EventLogEntryType.Error );

                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT count(TestTypeID) AS PassedTestCount
                    FROM     Tests INNER JOIN
                  TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
				  WHERE Tests.TestResult=1
				  and LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";


            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }
            }

            catch (Exception ex)
            {
                Logger.Log( $"{ex.Message}, From GetPassedTestCount.", EventLogEntryType.Error );


            }

            finally
            {
                connection.Close();
            }

            return PassedTestCount;
        }
    }
}
