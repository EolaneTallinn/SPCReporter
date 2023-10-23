using Microsoft.VisualBasic.ApplicationServices;
using SPCReportingTool.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace SPCReportingTool.Classes
{
    /// <summary>
    /// This class is meant for everything that is related to the Database data manipulation and exectuion.
    /// </summary>
    internal class DatabaseManager
    {
        /// <summary>
        /// This Method will query the SQL server accessible through the provide login and with the provided query. If the parameter output is true, then it will expect the query to give a result.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="logins"></param>
        /// <param name="output"></param>
        /// <returns>dictionnary of query's result</returns>
        internal static List<Dictionary<string, object>> GetListFromSQLQuery(String query, string[] logins, Boolean output)
        {
            List<Dictionary<string, object>> outResult = new List<Dictionary<string, object>>();

            try
            {
                String connetionString = $@"Server={logins[0]};Database={logins[1]};User Id={logins[2]};Password={logins[3]};";
                using (SqlConnection sqlConn = new SqlConnection(connetionString))
                {
                    sqlConn.Open();

                    // create a command object identifying the stored procedure
                    SqlCommand sqlCmd = new SqlCommand(query, sqlConn);

                    // execute the command
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        //if storedProcedure returns data, we read it
                        if (output)
                        {
                            while (reader.Read())
                            {
                                Dictionary<string, object> subOutResult = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    subOutResult.Add(reader.GetName(i), reader.GetValue(i));
                                }
                                outResult.Add(subOutResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                //MessageManager.InitializeMessage(AppSteps.Running, "ExecuteSQLQuery : " + exception.Message, SeverityEnum.Error);
            }

            if (output && outResult.Count <= 0)
            {
                throw new ArgumentException("There were no records returned from the stored query:\n'" + query + "'");
            }

            //MessageManager.InitializeMessage(AppSteps.Running, "Query:\n'" + query + "' - Executed successfuly.", SeverityEnum.Debug);

            return outResult;
        }

        internal static DataTable ExecuteSQLQuery(String query, string[] logins)
        {
            DataTable dt = new DataTable();
            try
            {
                String connetionString = $@"Server={logins[0]};Database={logins[1]};User Id={logins[2]};Password={logins[3]};";
                using (SqlConnection sqlConn = new SqlConnection(connetionString))
                {
                    sqlConn.Open();

                    // execute the command
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlConn);
                    da.Fill(dt);
                }
            }
            catch (Exception exception)
            {
                //MessageManager.InitializeMessage(AppSteps.Running, "ExecuteSQLQuery : " + exception.Message, SeverityEnum.Error);
            }

            //MessageManager.InitializeMessage(AppSteps.Running, "Query:\n'" + query + "' - Executed successfuly.", SeverityEnum.Debug);

            return dt;
        }

        /// <summary>
        /// This Method executes a provided to it stored procedure, with it's adjacent parameters.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="procedureParameters"></param>
        /// <returns>dictionnary of query's result</returns>
        internal static List<Dictionary<string, object>> ExecuteStoredProcedure(string[] logins, SQLProcedures.ProcedureInfo storedProcedureName, bool output, Dictionary<string, object> procedureParameters = null)
        {
            List<Dictionary<string, object>> outResult = new List<Dictionary<string, object>>();


            try
            {
                using (SqlConnection sqlConn = new SqlConnection($@"Server={logins[0]};Database={logins[1]};User Id={logins[2]};Password={logins[3]};"))
                {
                    sqlConn.Open();

                    // create a command object identifying the stored procedure
                    SqlCommand sqlCmd = new SqlCommand(storedProcedureName.Name, sqlConn);

                    // set the command object so it knows to execute a stored procedure
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    // add parameter to command, which will be passed to the stored procedure
                    if(procedureParameters != null)
                    {
                        foreach (KeyValuePair<string, object> param in procedureParameters)
                        {
                            sqlCmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    // execute the command
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        //if storedProcedure returns data, we read it
                        if (storedProcedureName.Return)
                        {
                            while(reader.Read())
                            {
                                Dictionary<string, object> subOutResult = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    subOutResult.Add(reader.GetName(i), reader.GetValue(i));
                                }
                                outResult.Add(subOutResult);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                //MessageManager.InitializeMessage(AppSteps.Running, "ExecuteStoredProcedure : " + exception.Message, SeverityEnum.Error);
            }

            if (storedProcedureName.Return && outResult.Count <= 0)
            {
                throw new ArgumentException("There were no records returned from the stored procedure - '" + storedProcedureName.Name + "'");
            }

            //MessageManager.InitializeMessage(AppSteps.Running, "Procedure '" + storedProcedureName.Name + "' - Executed successfuly.", SeverityEnum.Debug);

            return outResult;
        }

        /// <summary>
        /// This Method executes a provided to it stored procedure, with it's adjacent parameters.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="procedureParameters"></param>
        /// <returns>dictionnary of query's result</returns>
        internal static DataTable ExecuteStoredProcedure(string[] logins, SQLProcedures.ProcedureInfo storedProcedureName, Dictionary<string, object> procedureParameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                String connetionString = $@"Server={logins[0]};Database={logins[1]};User Id={logins[2]};Password={logins[3]};";

                using (SqlConnection sqlConn = new SqlConnection(connetionString))
                {
                    SqlCommand sqlCmd = new SqlCommand(storedProcedureName.Name, sqlConn);

                    // set the command object so it knows to execute a stored procedure
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    // add parameter to command, which will be passed to the stored procedure
                    if (procedureParameters != null)
                    {
                        foreach (KeyValuePair<string, object> param in procedureParameters)
                        {
                            sqlCmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    sqlConn.Open();

                    // execute the command
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    dt.Load(reader);
                }
            }
            catch (Exception exception)
            {
                //MessageManager.InitializeMessage(AppSteps.Running, "ExecuteSQLQuery : " + exception.Message, SeverityEnum.Error);
            }

            //MessageManager.InitializeMessage(AppSteps.Running, "Query:\n'" + query + "' - Executed successfuly.", SeverityEnum.Debug);

            return dt;
        }

        /// <summary>
        /// This method check whether the DBs are available.
        /// </summary>
        /// <param name="sqlConn"></param>
        internal static void PingDB()
        {
            try
            {
                foreach (var kvp in Globals.SQLLogins)
                {
                    string[] loginInfo = kvp.Value;
                    using (SqlConnection sqlConn = new SqlConnection($@"Server={loginInfo[0]};Database={loginInfo[1]};User Id={loginInfo[2]};Password={loginInfo[3]};"))
                    {
                        //MessageManager.InitializeMessage(AppSteps.Initializion, $"Trying to connect to {loginInfo[1]}", SeverityEnum.Debug);
                        sqlConn.Open();
                        //MessageManager.InitializeMessage(AppSteps.Initializion, $"Successfully established a connection to {loginInfo[1]}.", SeverityEnum.Debug);
                    }
                }
            }
            catch (Exception exception)
            {
                //MessageManager.InitializeMessage(AppSteps.Initializion, "PingDB :" + exception.Message, SeverityEnum.Error);
            }
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static List<Dictionary<string, object>> GetListFromDataTable(DataTable dt)
        {
            return null;
        }


        internal static DataTable AddNewEmptyDataRow(DataTable dt)
        {
            //use the NewRow to create a DataRow.
            DataRow newRow;
            newRow = dt.NewRow();
            // Then add the new row to the collection.
            dt.Rows.InsertAt(newRow, 0);
            return dt;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static DataTable GetDatatermUsers()
        {
            String query = $@"
                SELECT fname AS UserID, name AS UserName
                FROM [dataterm].[dbo].[userdata]";

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["Dataterm"]);

            return data;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static DataTable GetInspectionTypes()
        {
            String query = $@"
                SELECT *
                FROM Inspections";

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["SPCReports"]);

            return data;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static DataTable GetManufacturingSteps()
        {
            String query = $@"
                SELECT *
                FROM ManufacturingSteps";

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["SPCReports"]);

            return data;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static DataTable GetErrorTypes(int inspectionID)
        {
            String query = $@"
                SELECT *
                FROM Errors
                WHERE InspectionID = " + inspectionID.ToString();

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["SPCReports"]);

            return data;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static DataTable GetProductionOrders(string material)
        {
            String query = $@"
                SELECT DISTINCT Order1 AS [Order], Material, [Material Description] AS Description, [Target Qty]
                FROM OnePlan_DefaultView
                WHERE Material = '" + material + "'";

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["PlanningDB"]);

            return data;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static DataTable GetReports()
        {
            String query = $@"
                SELECT *
                FROM ReportsView
                WHERE StartDate > DATEADD(D, -7, GETDATE())";

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["SPCReports"]);

            return data;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static DataTable GetDefectsFromReport(int reportId)
        {
            String query = $@"
                SELECT ManufacturingStep, ErrorType, ErrorCode, Reference, Comment
                FROM DefectsView
                WHERE ReportID = " + reportId.ToString();

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["SPCReports"]);

            return data;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static int InsertNewReport(HeaderForm report)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.InsertNewReport;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("StartDate", report.startDate);
            procedureParameters.Add("InspectorID", report.userID);
            procedureParameters.Add("InspectorName", report.userName);
            procedureParameters.Add("InspectionID", report.inspectionID);
            procedureParameters.Add("ProductCode", report.productCode);
            procedureParameters.Add("ProductionOrder", report.productionOrder);
            procedureParameters.Add("ProductionOrderQty", report.productionOrderQty);
            procedureParameters.Add("QtyChecked", report.qtyChecked);
            procedureParameters.Add("QtyDefective", report.qtyDefective);
            procedureParameters.Add("EndTime", report.endDate);

            DataTable data = ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);

            int reportId = 0;
            /*
            foreach(DataRow dr in data.Rows)
            {
                reportId = (int)dr[0];
            }*/

            reportId = (int)(Decimal)data.Rows[0][0];

            return reportId;
        }

        /// <summary>
        /// Method to retriev the open tickets present in the OsTicket DB.
        /// The Department should be specified
        /// </summary>
        /// <param name="Department"></param>
        /// <returns>A dictionnary with the list of open tickets. The key is the ticket ID</returns>
        internal static void InsertNewDefect(int reportId, DataRow defect)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.InsertNewDefect;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("@ReportID", reportId);
            procedureParameters.Add("@ManufacturingStepID", defect["ManufacturingStepID"]);
            procedureParameters.Add("@ErrorID", defect["ErrorID"]);
            procedureParameters.Add("@ErrorCode", defect["ErrorCode"]);
            procedureParameters.Add("@Reference", defect["Reference"]);
            procedureParameters.Add("@Comment", defect["Comment"]);

            ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);
        }
    }
}
