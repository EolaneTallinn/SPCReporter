using SPCReportingTool.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPCReportingTool.Forms
{
    /// <summary>
    /// ViewReportsForm Class
    /// Form which displays the registered reports in a Grid View
    /// Upon login, the edit mode can be unlocked and reports can be selected for edition.
    /// </summary>
    public partial class ViewReportsForm : Form
    {
        #region Constructors
        /// <summary>
        /// ViewReportsFrom Constructor
        /// Initialize all the form's components
        /// Get the last 100 reports, load them in the Grid View and get the defects related to the last report and load them in the grid view
        /// </summary>
        public ViewReportsForm()
        {
            //Default Components Initialization
            InitializeComponent();

            // By default edit mode is switched off
            this._editMode = false;
            this.btn_EditMode.Text = Resources.String.EnterEditModeBtn;
            this.btn_EditMode.ForeColor = Color.DarkGreen;

            // Inserting date filter options
            this.cmbbx_DateSelection.Items.Add(Resources.String.NoDateFilter);
            this.cmbbx_DateSelection.Items.Add(Resources.String.StartDateFilter);
            //this.cmbbx_DateSelection.Items.Add(Resources.String.EndDateFilter); //Not needed according to Leonid
            this.cmbbx_DateSelection.SelectedIndex = 0;

            // Disable datetime picker elements (No date filter enabled by default)
            this.dateTime_From.Enabled = false;
            this.dateTime_To.Enabled = false;

            // Set Date and time search value to today 00:00 (Start) and 23:59 (End)
            this.dateTime_From.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            this.dateTime_To.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            // Search by inspector name by default
            this.rbtn_InspectorName.Checked = true;
            this.rbtn_InspectorID.Checked = false;

            // Get List of inspection types and insert them in the corresponding combo box
            this._inspTypes = DatabaseManager.GetInspectionTypes();
            DataTable inspTypesDataSource = DatabaseManager.AddNewEmptyDataRow(this._inspTypes);
            this.cmbbx_InspectionType.DataSource = inspTypesDataSource;
            this.cmbbx_InspectionType.DisplayMember = inspTypesDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
            this.cmbbx_InspectionType.ValueMember = inspTypesDataSource.Columns[Resources.String.DBNameColumn]?.ToString();

            // Get List of inspection types and insert them in the corresponding combo box
            this._inspectors = DatabaseManager.GetAllInspectors();
            DataTable inspectorsDataSource = DatabaseManager.AddNewEmptyDataRow(this._inspectors);
            this.cmbbx_Inspector.DataSource = inspectorsDataSource;
            this.cmbbx_Inspector.DisplayMember = inspectorsDataSource.Columns["InspectorName"]?.ToString();
            this.cmbbx_Inspector.ValueMember = inspectorsDataSource.Columns["InspectorName"]?.ToString();

            //Get the last 100 reports
            this._reports = DatabaseManager.GetReports(100);
            this.dataGV_Reports.DataSource = _reports;
            AutoSizeDataGV(this.dataGV_Reports, AutoSizeModes.Evenly);

            //Get the defects related to the last report
            this._selectedRowIndex = 0;
            this._reportID = (int)this._reports.Rows[this._selectedRowIndex][Resources.String.DBReportIDReportView];
            this._defects = DatabaseManager.GetDefectsFromReport(this._reportID);
            this.dataGV_Defects.DataSource = this._defects;
            AutoSizeDataGV(this.dataGV_Defects, AutoSizeModes.LastFill);
        }
        #endregion


        #region Properties
        #endregion


        #region Variables
        private DataTable _reports;
        private DataTable _defects;

        private DataTable _inspTypes;

        private DataTable _inspectors;

        private int _selectedRowIndex;

        private int _reportID;

        private bool _editMode;
        #endregion


        #region EventHandlers
        /// <summary>
        /// dataGV_Reports_CurrentCellChanged Event Handler
        /// Triggered when the active cell is changed in the report grid view
        /// Load the defects related to the newly selected report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGV_Reports_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                this._selectedRowIndex = this.dataGV_Reports.CurrentCell.RowIndex;
            }
            catch
            {
                this._selectedRowIndex = 0;
            }

            try
            {
                this._reportID = (int)this._reports.Rows[this._selectedRowIndex][Resources.String.DBReportIDReportView];
                this._defects = DatabaseManager.GetDefectsFromReport(this._reportID);
                this.dataGV_Defects.DataSource = this._defects;
                AutoSizeDataGV(this.dataGV_Defects, AutoSizeModes.LastFill);
            }
            catch
            {
                this._defects = new DataTable();
                //Nothing to do more here
            }
        }


        /// <summary>
        /// cmbbx_DateSelection_SelectedIndexChanged Event Handler
        /// Triggered when a new item is selected in the Date combo box
        /// Enable or disable the datetime picker based on the selected date filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbbx_DateSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cmbbx_DateSelection.SelectedItem ?? String.Empty).ToString() == Resources.String.StartDateFilter || (this.cmbbx_DateSelection.SelectedItem ?? String.Empty).ToString() == Resources.String.EndDateFilter)
            {
                //Enable if filtering by Start Date or End Date
                this.dateTime_From.Enabled = true;
                this.dateTime_To.Enabled = true;
            }
            else
            {
                //Disable if no date filtering is selected
                this.dateTime_From.Enabled = false;
                this.dateTime_To.Enabled = false;
            }
        }



        /// <summary>
        /// cmbbx_DateSelection_SelectedIndexChanged Event Handler
        /// Triggered when a new item is selected in the Date combo box
        /// Enable or disable the datetime picker based on the selected date filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chсkbx_DateFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chсkbx_DateFilter.Checked)
            {
                //Enable if filtering by Start Date or End Date
                this.dateTime_From.Enabled = true;
                this.dateTime_To.Enabled = true;
            }
            else
            {
                //Disable if no date filtering is selected
                this.dateTime_From.Enabled = false;
                this.dateTime_To.Enabled = false;
            }
        }



        /// <summary>
        /// rbtn_InspectorID_CheckedChanged Event Handler
        /// Triggered when the Inspector ID radio button is checked or unchecked
        /// When checked, update the item list in the combo box for inspector selection with available inspector ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_InspectorID_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtn_InspectorID.Checked)
            {
                this._inspectors = DatabaseManager.GetAllInspectors();
                DataTable inspectorsDataSource = DatabaseManager.AddNewEmptyDataRow(this._inspectors);
                this.cmbbx_Inspector.DataSource = inspectorsDataSource;
                this.cmbbx_Inspector.DisplayMember = inspectorsDataSource.Columns["InspectorID"]?.ToString();
                this.cmbbx_Inspector.ValueMember = inspectorsDataSource.Columns["InspectorID"]?.ToString();

                this.cmbbx_Inspector.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// rbtn_InspectorName_CheckedChanged Event Handler
        /// Triggered when the Inspector Name radio button is checked or unchecked
        /// When checked, update the item list in the combo box for inspector selection with available inspector Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_InspectorName_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtn_InspectorName.Checked)
            {
                this._inspectors = DatabaseManager.GetAllInspectors();
                DataTable inspectorsDataSource = DatabaseManager.AddNewEmptyDataRow(this._inspectors);
                this.cmbbx_Inspector.DataSource = inspectorsDataSource;
                this.cmbbx_Inspector.DisplayMember = inspectorsDataSource.Columns["InspectorName"]?.ToString();
                this.cmbbx_Inspector.ValueMember = inspectorsDataSource.Columns["InspectorName"]?.ToString();

                this.cmbbx_Inspector.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// btn_Search_Click Event Handler
        /// Triggered when the "Search" button is clicked
        /// Refresh the results with the reports corresponding to the search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            RefreshReports();
        }


        /// <summary>
        /// btn_Refresh_Click Event Handler
        /// Triggered when the "Refresh" button is clicked
        /// Refresh the results with the reports corresponding to the search criteria. Added to have a more intuitive action for user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            RefreshReports();
        }



        /// <summary>
        /// btn_EditMode_Click Event Handler
        /// Triggered when the "Edit Mode" button is clicked
        /// Toggle the edit mode and ask a login for entering into edit mode
        /// When edit mode is activate, a button column is added to the report grid view and events are added when clicking on this button or double clicking on a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_EditMode_Click(object sender, EventArgs e)
        {
            //Toggle edit mode
            if (!this._editMode)
            {
                //Ask for login
                var loginForm = new LoginForm();
                loginForm.ShowDialog();

                if (loginForm.DialogResult == DialogResult.OK)
                {
                    // Enter edit mode if the login is successful
                    this._editMode = true;

                    //Add button column to the reports grid view
                    DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                    editColumn.Name = Resources.String.EditButton;
                    editColumn.Text = Resources.String.EditButton;
                    editColumn.UseColumnTextForButtonValue = true;

                    if (this.dataGV_Reports.Columns[Resources.String.EditButton] == null)
                    {
                        this.dataGV_Reports.Columns.Insert(0, editColumn);
                    }

                    //Add events to react on the button click and when double-clicking on a cell
                    this.dataGV_Reports.CellDoubleClick += dataGV_Reports_CellDoubleClick;
                    this.dataGV_Reports.CellContentClick += dataGV_Reports_CellContentClick;

                    // Changing text on "Edit Mode" button 
                    this.btn_EditMode.Text = Resources.String.ExitEditModeBtn;
                    this.btn_EditMode.ForeColor = Color.DarkRed;
                }

            }
            else
            {
                //Exit edit mode
                this._editMode = false;

                //Remove edit button column
                this.dataGV_Reports.Columns.RemoveAt(0);

                //Remove events
                this.dataGV_Reports.CellDoubleClick -= dataGV_Reports_CellDoubleClick;
                this.dataGV_Reports.CellContentClick -= dataGV_Reports_CellContentClick;

                // Changing text on "Edit Mode" button 
                this.btn_EditMode.Text = Resources.String.EnterEditModeBtn;
                this.btn_EditMode.ForeColor = Color.DarkGreen;
            }
        }


        /// <summary>
        /// dataGV_Reports_CellDoubleClick Event Handler
        /// Triggered when the user double click on a cell in the report grid view
        /// Select the report corresponding to the cell and call a new Headerform for edition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGV_Reports_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;

                DataRow selectedReport = this._reports.Rows[index];

                var headerForm = new HeaderForm(selectedReport);
                headerForm.ReportView = this;
                headerForm.Show();
            }
        }


        /// <summary>
        /// dataGV_Reports_CellContentClick Event Handler
        /// Triggered when the user click on a cell in the report grid view
        /// If the cell belongs to a button column, it select the report corresponding to the cell and call a new Headerform for edition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGV_Reports_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)(sender ?? new DataGridView());

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int index = e.RowIndex;

                DataRow selectedReport = this._reports.Rows[index];

                var headerForm = new HeaderForm(selectedReport);
                headerForm.ReportView = this;
                headerForm.Show();
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// AutoSizeDataGV Method
        /// Compute the size of each column of a Grid View depending on the mode
        /// The available modes are described in the Globals class
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="mode"></param>
        private static void AutoSizeDataGV(DataGridView dgv, AutoSizeModes mode)
        {
            switch (mode)
            {
                //For having auto sized columns and the first one filling the remaining place
                case AutoSizeModes.FirstFill:
                    for (int i = dgv.Columns.Count - 1; i >= 0; i--)
                    {
                        if (i > 0)
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        }
                        else
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                    break;

                //For having auto sized columns and the last one filling the remaining place
                case AutoSizeModes.LastFill:
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (i < dgv.Columns.Count - 1)
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        }
                        else
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                    break;

                //For having auto sized columns in the available place.
                case AutoSizeModes.Evenly:
                    foreach (DataGridViewColumn dgvc in dgv.Columns)
                    {
                        dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    break;
            }

        }


        /// <summary>
        /// GetSearchParameters Method
        /// Gather all the search criterias entered by the user in a Dictionary (that will be passed on to a SQL Stored Procedure)
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> GetSearchParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            #region Start Date
            if ((this.cmbbx_DateSelection.SelectedItem ?? String.Empty).ToString() == Resources.String.StartDateFilter)
            {
                parameters.Add("StartDateFrom", this.dateTime_From.Value);
                parameters.Add("StartDateTo", this.dateTime_To.Value);
            }
            #endregion

            #region End Date
            else if ((this.cmbbx_DateSelection.SelectedItem ?? String.Empty).ToString() == Resources.String.EndDateFilter)
            {
                parameters.Add("EndDateFrom", this.dateTime_From.Value);
                parameters.Add("EndDateTo", this.dateTime_To.Value);
            }
            #endregion

            #region Date
            else if (this.chсkbx_DateFilter.Checked)
            {
                parameters.Add("DateFrom", this.dateTime_From.Value);
                parameters.Add("DateTo", this.dateTime_To.Value);
            }
            #endregion

            #region Report ID
            if (this.txtbx_ReportID.Text != String.Empty)
            {
                parameters.Add("ReportID", this.txtbx_ReportID.Text);
            }
            #endregion

            #region Inspector
            if (this.cmbbx_Inspector.Text != String.Empty)
            {
                if (this.rbtn_InspectorID.Checked)
                {
                    parameters.Add("InspectorID", this.cmbbx_Inspector.Text);
                }
                else
                {
                    parameters.Add("InspectorName", this.cmbbx_Inspector.Text);
                }
            }
            #endregion

            #region Inspection Type
            if ((this.cmbbx_InspectionType.SelectedValue ?? String.Empty).ToString() != String.Empty)
            {
                parameters.Add("InspectionType", this.cmbbx_InspectionType.SelectedValue ?? String.Empty);
            }
            #endregion

            #region Product
            if (this.txtbx_ProductCode.Text != String.Empty)
            {
                parameters.Add("ProductCode", this.txtbx_ProductCode.Text);
            }
            #endregion

            #region Production Order
            if (this.txtbx_ProductionOrder.Text != String.Empty)
            {
                parameters.Add("ProductionOrder", this.txtbx_ProductionOrder.Text);
            }
            #endregion

            return parameters;
        }


        /// <summary>
        /// RefreshReports Method
        /// Get the list of the last 100 reports corresponding to the current search criterias
        /// </summary>
        internal void RefreshReports()
        {
            this._reports = DatabaseManager.GetReports(100, GetSearchParameters());
            this.dataGV_Reports.DataSource = this._reports;
            AutoSizeDataGV(this.dataGV_Reports, 0);
        }
        #endregion
    }
}
