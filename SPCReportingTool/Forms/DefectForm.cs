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
    /// DefectForm Class
    /// Form for Defect info input and change
    /// Supposed to be called by a Header Form as a Dialog box
    /// </summary>
    public partial class DefectForm : Form
    {
        #region Constructors
        /// <summary>
        /// DefectForm Constructor 1
        /// Initialize all the form components with empty values.
        /// All the comboboxes will have their datasource assigned
        /// The purpose of this is to create a new defect
        /// </summary>
        /// <param name="defects"></param>
        /// <param name="inspectionID"></param>
        public DefectForm(DataTable defects, int inspectionID)
        {
            InitializeComponent();

            this.CurrentDefect = defects.NewRow();

            this.btn_AddDefect.Enabled = CheckData();

            this._manSteps = DatabaseManager.GetManufacturingSteps();
            DataTable manStepsDataSource = DatabaseManager.AddNewEmptyDataRow(this._manSteps);
            this.cmbbx_Step.DataSource = manStepsDataSource;
            this.cmbbx_Step.DisplayMember = manStepsDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
            this.cmbbx_Step.ValueMember = manStepsDataSource.Columns["StepID"]?.ToString();

            this._errTypes = DatabaseManager.GetErrorTypes();
            this.cmbbx_ErrorType.Enabled = false;

            this._references = new DataTable();
            //DataTable referencesDataSource = DatabaseManager.AddNewEmptyDataRow(this._references);
            //this.cmbbx_Reference.DataSource = referencesDataSource;
            //this.cmbbx_Reference.DisplayMember = referencesDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
            //this.cmbbx_Reference.ValueMember = referencesDataSource.Columns["InspectionID"]?.ToString();
        }


        /// <summary>
        /// DefectForm Constructor 2
        /// Initialize all the form components with values from an existing defect.
        /// All the comboboxes will have their datasource assigned.
        /// The purpose of this is to edit an existing defect
        /// </summary>
        /// <param name="defect"></param>
        /// <param name="defectView"></param>
        /// <param name="inspectionID"></param>
        public DefectForm(DataRow defect, DataRow defectView, int inspectionID)
        {
            InitializeComponent();

            this.CurrentDefect = defect;

            this.btn_AddDefect.Text = "OK";

            this._editMode = true;

            this._manSteps = DatabaseManager.GetManufacturingSteps();
            DataTable manStepsDataSource = DatabaseManager.AddNewEmptyDataRow(this._manSteps);
            this.cmbbx_Step.DataSource = manStepsDataSource;
            this.cmbbx_Step.DisplayMember = manStepsDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
            this.cmbbx_Step.ValueMember = manStepsDataSource.Columns["StepID"]?.ToString();

            this._errTypes = DatabaseManager.GetErrorTypes();
            this.cmbbx_ErrorType.Enabled = false;

            this._references = new DataTable();
            //DataTable referencesDataSource = DatabaseManager.AddNewEmptyDataRow(this._references);
            //this.cmbbx_Reference.DataSource = referencesDataSource;
            //this.cmbbx_Reference.DisplayMember = referencesDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
            //this.cmbbx_Reference.ValueMember = referencesDataSource.Columns["InspectionID"]?.ToString();

            LoadData(defectView);

        }
        #endregion


        #region Properties
        // CurrentDefect represents the Defect that is currently created or edited.
        internal DataRow CurrentDefect { get; set; }
        #endregion


        #region Variables
        private bool _editMode;

        private DataTable _manSteps;
        private DataTable _errTypes;
        private DataTable _references;
        #endregion


        #region EventHandlers
        /// <summary>
        /// cmbbx_Step_SelectedIndexChanged Event Handler
        /// Triggered when selecting an item in the Manufacturing Step combobox
        /// Will refresh the Manufacturing step info and check if the defect data is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbbx_Step_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshManufacturingStepInfo();
            this.btn_AddDefect.Enabled = CheckData();
        }


        /// <summary>
        /// cmbbx_ErrorType_SelectedIndexChanged Event Handler
        /// Triggered when selecting an item in the Error Type combobox
        /// Will refresh the Error Type info and check if the defect data is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbbx_ErrorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshErrorTypeInfo();
            this.btn_AddDefect.Enabled = CheckData();
        }


        /// <summary>
        /// cmbbx_Reference_SelectedIndexChanged Event Handler
        /// Triggered when selecting an item in the Reference combobox
        /// Will refresh the Reference info and check if the defect data is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbbx_Reference_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReferenceInfo();
            this.btn_AddDefect.Enabled = CheckData();
        }


        /// <summary>
        /// cmbbx_Reference_LostFocus Event Handler
        /// Triggered when the Reference combobox lose focus
        /// Will refresh the Reference info and check if the defect data is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbbx_Reference_LostFocus(object sender, EventArgs e)
        {
            RefreshReferenceInfo();
            this.btn_AddDefect.Enabled = CheckData();
        }


        /// <summary>
        /// btn_AddDefect_Click Event Handler
        /// Triggered when the "Add Defect" button is clicked
        /// Will save the comment, put the DialogResult on "OK" state and close the Defect window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddDefect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.CurrentDefect["Comment"] = rtxtbox_Comment.Text;
            this.Close();
        }


        /// <summary>
        /// btn_Cancel_Click Event Handler
        /// Triggered when the "Cancel" button is clicked
        /// Will put the DialogResult on "Cancel" state and close the Defect window. No data is saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion


        #region Methods
        /// <summary>
        /// RefreshManufacturingStepInfo Method
        /// Save the step ID of the Manufacturing Step selected in the combo box in CurrentDefect.
        /// Build the defect code
        /// <remark>
        /// The ID will be -1 if the current selected step does not have a valid ID value
        /// </remark>
        /// </summary>
        private void RefreshManufacturingStepInfo()
        {
            try
            {
                this.CurrentDefect["ManufacturingStepID"] = int.Parse(cmbbx_Step.SelectedValue?.ToString() ?? "-1");

                DataView dv = new DataView(this._errTypes);
                dv.RowFilter = "ManufacturingStepId = " + this.CurrentDefect["ManufacturingStepID"]; // query example = "id = 10"

                DataTable errTypesDataSource = DatabaseManager.AddNewEmptyDataRow(dv.ToTable());
                this.cmbbx_ErrorType.DataSource = errTypesDataSource;
                this.cmbbx_ErrorType.DisplayMember = errTypesDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
                this.cmbbx_ErrorType.ValueMember = errTypesDataSource.Columns["ErrorID"]?.ToString();

                this.cmbbx_ErrorType.Enabled = true;
            }
            catch
            {
                this.CurrentDefect["ManufacturingStepID"] = -1;
            }
        }


        /// <summary>
        /// RefreshErrorTypeInfo Method
        /// Save the error ID of the Error type selected in the combo box in CurrentDefect.
        /// Build the defect code
        /// <remark>
        /// The ID will be -1 if the current selected error does not have a valid ID value
        /// </remark> 
        /// </summary>
        private void RefreshErrorTypeInfo()
        {
            try
            {
                this.CurrentDefect["ErrorID"] = int.Parse(cmbbx_ErrorType.SelectedValue?.ToString() ?? "-1");
                BuildDefectCode();

            }
            catch
            {
                this.CurrentDefect["ErrorID"] = -1;
            }
        }


        /// <summary>
        /// RefreshReferenceInfo Method
        /// Save the Reference selected in the combo box in CurrentDefect.
        /// </summary>
        private void RefreshReferenceInfo()
        {
            try
            {
                this.CurrentDefect["Reference"] = cmbbx_Reference.Text?.ToString() ?? String.Empty;
            }
            catch
            {
                this.CurrentDefect["Reference"] = String.Empty;
            }
        }


        /// <summary>
        /// BuildDefectCode Method
        /// Build the defect code based on the Step code and the Error code
        /// </summary>
        private void BuildDefectCode()
        {
            String stepCode = String.Empty;
            String errorCode = String.Empty;

            // Looking for the step Name in the Manufacturing step table
            foreach (DataRow step in this._manSteps.Rows)
            {
                try
                {
                    if ((int)step["StepID"] == int.Parse((string)(this.CurrentDefect["ManufacturingStepID"] ?? "-1")))
                    {
                        stepCode = (string)(step["StepCode"] ?? String.Empty);
                        break;
                    }
                }
                catch { }
            }

            DataView dv = new DataView(this._errTypes);
            dv.RowFilter = "ManufacturingStepId = " + (string)(this.CurrentDefect["ManufacturingStepID"] ?? "-1"); // query example = "id = 10"

            DataTable errTypesFiltered = dv.ToTable();
            // Looking for the error type in the Error Type table
            foreach (DataRow err in errTypesFiltered.Rows)
            {
                try
                {
                    if ((int)err["ErrorID"] == int.Parse((string)(this.CurrentDefect["ErrorID"] ?? "-1")))
                    {
                        errorCode = (string)(err["ErrorCode"] ?? String.Empty);
                        break;
                    }
                }
                catch { }
            }

            // Defect code formula
            this.CurrentDefect["DefectCode"] = stepCode + errorCode;
        }


        /// <summary>
        /// CheckData Method
        /// Validate the data entered by the user. This enables or not the "Add Defect" button
        /// </summary>
        /// <returns>
        /// true if all the data is valid, false if one piece of data is not valid
        /// </returns>
        private bool CheckData()
        {
            string stepID, errID, reference;

            #region Manufacturing Step
            try
            {
                stepID = (string)this.CurrentDefect["ManufacturingStepID"];

                if (stepID == "-1")
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            #endregion

            #region Error Type
            try
            {
                errID = (string)this.CurrentDefect["ErrorID"];

                if (errID == "-1")
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            #endregion

            #region Reference
            try
            {
                reference = (string)this.CurrentDefect["Reference"];

                if (reference == string.Empty)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            #endregion

            return true;
        }


        /// <summary>
        /// LoadData Method
        /// Load the data from an existing Defect into the form
        /// </summary>
        /// <param name="defectView"></param>
        private void LoadData(DataRow defectView)
        {

            #region Manufacturing Step

            this.cmbbx_Step.Text = (string)defectView[Resources.String.DefectViewerCol2];

            #endregion


            #region Error Type

            this.cmbbx_ErrorType.Text = (string)defectView[Resources.String.DefectViewerCol3];

            #endregion


            #region Reference

            this.cmbbx_Reference.Text = (string)defectView[Resources.String.DefectViewerCol5];

            #endregion


            #region Comment

            this.rtxtbox_Comment.Text = (string)defectView[Resources.String.DefectViewerCol6];

            #endregion


            this.btn_AddDefect.Enabled = CheckData();

        }
        #endregion
    }
}
