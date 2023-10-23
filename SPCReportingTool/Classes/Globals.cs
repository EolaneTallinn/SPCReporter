using System;
using System.Collections.Generic;
using System.Net;


namespace SPCReportingTool.Classes
{
    /// <summary>
    /// This is a class for storing primarily readonly static parameters / methods.
    /// </summary>
    internal static class Globals
    {

        //  --- Read-only variables. (Grouped by context) ---
        internal readonly static string computerName = Dns.GetHostName().ToUpper();
        internal readonly static string executingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        internal readonly static int msTimeOut = 200;
        internal readonly static int msMainLoopTimeOut = 5000;

        internal readonly static string configurationPath = executingDirectory + @"DATAPUMP.YAML";
        internal readonly static string VersionPath = executingDirectory + @"Version.str";

        //  --- FTP Variables ---

        internal readonly static string ftpUsername = computerName;
        internal readonly static string ftpPassword = @"";
        internal readonly static string ftpPath = @"ftp://scriptftp/";

        //  --- SFTP Variables --- NOT IMPLEMENTED YET

        internal readonly static string sftpUsername = @"";
        internal readonly static string sftpPassword = @"";
        internal readonly static int sftpPort = 22;
        internal readonly static string sftpHost = @"";

        //  --- SQL Variables for connection ---

        internal readonly static Dictionary<string, string[]> SQLLogins = new Dictionary<string, string[]>
        {
            //{ "DBName", new string[] { server, db, user, password} }
            //{ "TestDB", new string[] { @"tndb01", @"TestDB", @"sequence", @"seq" } },
            { "Dataterm", new string[] { @"tndb01", @"dataterm", @"ro", @"read" } },
            { "SPCReports", new string[] { @"tndb01", @"SPCReports", @"SPCReporter", @"test" } },
            { "PlanningDB", new string[] { @"tndb01", @"PlanningDB", @"ro", @"read" } }
        };

        //  --- Live variables. (Variables that can be manipulated through the application life-cycle) ---

        //Whether the application is running - ActionLoop();
        //internal static bool isRunning = true;
        //internal static Random randomGen = new Random();
    }

    internal enum InspectionType
    {
        Type1,
        Type2,
        Type3
    }

    internal enum FileError
    {
        EmptyFile,
        ServerMoving,
        DBError,
        Delete
    }

    /// <summary>
    /// This enumerator is used for defining abstract level of severity.
    /// </summary>
    internal enum SeverityEnum
    {
        Error,
        Warning,
        Notice,
        Info,
        Debug
    }

    internal enum AppSteps
    {
        Initializion,
        Configuration,
        Running,
        Restart
    }

    /// <summary>
    /// Class to list all of stored procedures in DB, tuple of string and bool for the name and if procedure returns value
    /// </summary>
    internal static class SQLProcedures
    {
        internal static readonly ProcedureInfo InsertNewReport = new ProcedureInfo("InsertNewReport", true);
        internal static readonly ProcedureInfo InsertNewDefect = new ProcedureInfo("InsertNewDefect", false);
        internal static readonly ProcedureInfo NewActivityTrace = new ProcedureInfo("NewActivityTrace", false);
        internal static readonly ProcedureInfo NewNotification = new ProcedureInfo("NewNotification", false);
        internal static readonly ProcedureInfo GetTracePartionning = new ProcedureInfo("GetTracePartionning", true);

        //Just for attempts
        internal static readonly ProcedureInfo ProcedureTest = new ProcedureInfo("ProcedureTest", false);

        //intern class to clarify access to SQLProcedures.Procedure (we can use storedProcedureName.Name) for exemple
        internal class ProcedureInfo
        {
            internal string Name { get; }
            internal bool Return { get; }
            internal ProcedureInfo(string name, bool _return)
            {
                Name = name;
                Return = _return;
            }
        }
    }
}
