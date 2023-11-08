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


        //  --- SQL Variables for connection ---
        internal readonly static Dictionary<string, string[]> SQLLogins = new Dictionary<string, string[]>
        {
            { "Dataterm", new string[] { @"tndb01", @"dataterm", @"ro", @"read" } },
            { "SPCReports", new string[] { @"tndb01", @"SPCReports", @"SPCReporter", @"test" } },
            { "PlanningDB", new string[] { @"tndb01", @"PlanningDB", @"ro", @"read" } }
        };

        // Language mode of the application
        internal static bool englishMode = false;
    }

    /// <summary>
    /// Enumerator for the auto sizing modes in a data Grid View
    /// </summary>
    internal enum AutoSizeModes
    {
        FirstFill,
        LastFill,
        Evenly
    }

    /// <summary>
    /// Class to list all of stored procedures in DB, tuple of string and bool for the name and if procedure returns value
    /// </summary>
    internal static class SQLProcedures
    {
        internal static readonly ProcedureInfo InsertNewReport = new ProcedureInfo("InsertNewReport", true);
        internal static readonly ProcedureInfo InsertNewDefect = new ProcedureInfo("InsertNewDefect", false);
        internal static readonly ProcedureInfo GetReports = new ProcedureInfo("GetReports", true);
        internal static readonly ProcedureInfo GetDefectsFromReport = new ProcedureInfo("GetDefectsFromReport", true);
        internal static readonly ProcedureInfo UpdateReport = new ProcedureInfo("UpdateReport", false);
        internal static readonly ProcedureInfo DeleteReport = new ProcedureInfo("DeleteReport", false);
        internal static readonly ProcedureInfo DeleteAllDefects = new ProcedureInfo("DeleteAllDefects", false);
        internal static readonly ProcedureInfo RequestLogin = new ProcedureInfo("RequestLogin", true);

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
