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
        /// ExecuteSQLQuery Method
        /// Execute an SQL query with the specified login
        /// </summary>
        /// <param name="query"></param>
        /// <param name="logins"></param>
        /// <returns>
        /// DataTable with the results of the query
        /// </returns>
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
        /// <param name="logins"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="procedureParameters"></param>
        /// <returns>
        /// DataTable with the results of the procedure (if any)
        /// </returns>
        internal static DataTable ExecuteStoredProcedure(string[] logins, SQLProcedures.ProcedureInfo storedProcedureName, Dictionary<string, object>? procedureParameters = null)
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
        /// AddNewEmptyDataRow Method
        /// Add a new empty row to a DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        internal static DataTable AddNewEmptyDataRow(DataTable dt)
        {
            //use the NewRow to create a DataRow.
            DataRow newRow;
            newRow = dt.NewRow();

            foreach (DataColumn col in dt.Columns)
            {
                if (!col.AllowDBNull)
                {
                    col.AllowDBNull = true;
                }
            }

            // Then add the new row to the collection.
            dt.Rows.InsertAt(newRow, 0);
            return dt;
        }


        /// <summary>
        /// GetAllInspectors Method
        /// Retrieve the list of the inspectors present in the SPC Database
        /// </summary>
        /// <returns>
        /// DataTable with the list of ID and Name of the existing inspectors
        /// </returns>
        internal static DataTable GetAllInspectors()
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.GetAllInspectors;

            DataTable data = ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure);

            return data;
        }


        /// <summary>
        /// GetDatatermUsers Method
        /// Retrieve the list of the users present in the dataterm DB (with Eolane ID)
        /// </summary>
        /// <returns>
        /// DataTable with the list of possible users
        /// </returns>
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
        /// GetInspectionTypes Method
        /// Retrieve the list of the inspection types present in the SPC reports datsbase
        /// </summary>
        /// <returns>
        /// DataTable with the list of possible inspection types
        /// </returns>
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
        /// GetManufacturingSteps Method
        /// Retrieve the list of the Manufacturing Steps present in the SPC reports datsbase
        /// </summary>
        /// <returns>
        /// DataTable with the list of possible Manufacturing Steps
        /// </returns>
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
        /// GetErrorTypes Method
        /// Retrieve the list of the Error Types present in the SPC reports datsbase
        /// </summary>
        /// <returns>
        /// DataTable with the list of possible Error Types
        /// </returns>
        internal static DataTable GetErrorTypes()
        {
            String query = $@"
                SELECT *
                FROM Errors";

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["SPCReports"]);

            return data;
        }


        /// <summary>
        /// GetProductionOrders Method
        /// Retrieve the list of production orders available for a specified product
        /// </summary>
        /// <param name="material"></param>
        /// <returns>
        /// DataTable with the list of Production Orders
        /// </returns>
        internal static DataTable GetProductionOrders(string material)
        {
            String query = $@"
                SELECT Order1 AS [Order], Material, [Material Description] AS Description, [Target Qty], MIN(DATEADD(ms, DATEDIFF(ms, '00:00:00', [Act Start]), CONVERT(DATETIME, [ActStart]))) AS StartTime
                FROM OnePlan_DefaultView
                WHERE ActStart IS NOT NULL
	                AND Material = '" + material + $@"'
                GROUP BY Order1, Material, [Material Description], [Target Qty]
                ORDER BY StartTime DESC";

            query = query.Replace("\r\n", "");

            DataTable data = ExecuteSQLQuery(query, Globals.SQLLogins["PlanningDB"]);

            return data;
        }


        /// <summary>
        /// GetReports Method
        /// Retrieve the last reports from the SPC reports database
        /// The number of report is limited to the number of Top Rows and they should match the criterias included in the parameters
        /// </summary>
        /// <param name="topRows"></param>
        /// <param name="parameters"></param>
        /// <returns>
        /// DataTable with the last reports matching the criterias in the parameters
        /// </returns>
        internal static DataTable GetReports(int topRows, Dictionary<string, object>? parameters = null)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.GetReports;

            Dictionary<string, object> procedureParameters = parameters ?? new Dictionary<string, object>();
            procedureParameters.Add("TopRows", topRows);

            // Specifing in which language the App is
            if (Globals.englishMode)
            {
                procedureParameters.Add("Language", "en");
            }
            else
            {
                procedureParameters.Add("Language", "ru");
            }

            DataTable data = ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);

            return data;
        }


        /// <summary>
        /// GetDefectsFromReport Method
        /// Retrieve all the defects related to the specified report ID
        /// </summary>
        /// <param name="reportId"></param>
        /// <returns>
        /// DataTable with all the defects found
        /// </returns>
        internal static DataTable GetDefectsFromReport(int reportId)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.GetDefectsFromReport;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("ReportID", reportId);

            if (Globals.englishMode)
            {
                procedureParameters.Add("Language", "en");
            }
            else
            {
                procedureParameters.Add("Language", "ru");
            }

            DataTable data = ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);

            return data;
        }


        /// <summary>
        /// RequestLogin Method
        /// Send the hash of the password entered by the user for comparaison with the value in the DB
        /// </summary>
        /// <param name="password"></param>
        /// <returns>
        /// Result of the comparaison as a int (1 if success, 0 if fail)
        /// </returns>
        internal static int RequestLogin(string password)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.RequestLogin;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("PasswordHash", password);

            DataTable data = ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);

            return (int)data.Rows[0][0];
        }


        /// <summary>
        /// InsertNewReport Method
        /// Insert the header information in the SPC report Database
        /// </summary>
        /// <param name="report"></param>
        /// <returns>
        /// The ID of the new report created as an int
        /// </returns>
        internal static int InsertNewReport(HeaderForm report)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.InsertNewReport;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("StartDate", report.StartDate);
            procedureParameters.Add("InspectorID", report.UserID);
            procedureParameters.Add("InspectorName", report.UserName);
            procedureParameters.Add("InspectionID", report.InspectionID);
            procedureParameters.Add("ProductCode", report.ProductCode);
            procedureParameters.Add("ProductionOrder", report.ProductionOrder);
            procedureParameters.Add("ProductionOrderQty", report.ProductionOrderQty);
            procedureParameters.Add("QtyChecked", report.QtyChecked);
            procedureParameters.Add("QtyDefective", report.QtyDefective);
            procedureParameters.Add("EndTime", report.EndDate);

            DataTable data = ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);

            int reportId = 0;

            reportId = (int)(Decimal)data.Rows[0][0];

            return reportId;
        }


        /// <summary>
        /// InsertNewDefect Method
        /// Insert a new defect which will be related to the specified report ID
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="defect"></param>
        internal static void InsertNewDefect(int reportId, DataRow defect)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.InsertNewDefect;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("@ReportID", reportId);
            procedureParameters.Add("@ManufacturingStepID", defect["ManufacturingStepID"]);
            procedureParameters.Add("@ErrorID", defect["ErrorID"]);
            procedureParameters.Add("@DefectCode", defect["DefectCode"]);
            procedureParameters.Add("@Reference", defect["Reference"]);
            procedureParameters.Add("@Comment", defect["Comment"]);

            ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);
        }


        /// <summary>
        /// UpdateReport Method
        /// Update the header information of a report
        /// </summary>
        /// <param name="report"></param>
        internal static void UpdateReport(HeaderForm report)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.UpdateReport;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("ReportId", report.ReportId);
            procedureParameters.Add("StartDate", report.StartDate);
            procedureParameters.Add("InspectorID", report.UserID);
            procedureParameters.Add("InspectorName", report.UserName);
            procedureParameters.Add("InspectionID", report.InspectionID);
            procedureParameters.Add("ProductCode", report.ProductCode);
            procedureParameters.Add("ProductionOrder", report.ProductionOrder);
            procedureParameters.Add("ProductionOrderQty", report.ProductionOrderQty);
            procedureParameters.Add("QtyChecked", report.QtyChecked);
            procedureParameters.Add("QtyDefective", report.QtyDefective);
            procedureParameters.Add("EndTime", report.EndDate);

            ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);
        }


        /// <summary>
        /// DeleteReport Method
        /// Delete the report with the provided ID from the SPC report Database
        /// </summary>
        /// <param name="reportId"></param>
        internal static void DeleteReport(int reportId)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.DeleteReport;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("ReportId", reportId);

            ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);
        }


        /// <summary>
        /// DeleteAllDefects Method
        /// Delete all the defects related to the provided ID from the SPC report Database
        /// </summary>
        /// <param name="reportId"></param>
        internal static void DeleteAllDefects(int reportId)
        {
            SQLProcedures.ProcedureInfo procedure = SQLProcedures.DeleteAllDefects;

            Dictionary<string, object> procedureParameters = new Dictionary<string, object>();
            procedureParameters.Add("ReportId", reportId);

            ExecuteStoredProcedure(Globals.SQLLogins["SPCReports"], procedure, procedureParameters);
        }
    }
}
