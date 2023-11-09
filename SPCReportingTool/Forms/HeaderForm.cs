using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPCReportingTool.Classes;

namespace SPCReportingTool.Forms
{
    /// <summary>
    /// HeaderForm Class
    /// Form where the header information for the SPC report are entered
    /// It is not supposed to be called as a dialog box, because several header form could be used at the same time
    /// </summary>
    public partial class HeaderForm : Form
    {
        #region Constructors
        /// <summary>
        /// HeaderForm Constructor 1
        /// Initialize all the form components with empty values.
        /// All the comboboxes will have their datasource assigned
        /// The purpose of this is to create a new report
        /// </summary>
        public HeaderForm()
        {
            InitializeComponent();

            this._editMode = false;

            this._userList = DatabaseManager.GetDatatermUsers();

            this._inspTypes = DatabaseManager.GetInspectionTypes();
            DataTable inspTypesDataSource = DatabaseManager.AddNewEmptyDataRow(this._inspTypes);
            this.cmbbx_InspectionType.DataSource = inspTypesDataSource;
            this.cmbbx_InspectionType.DisplayMember = inspTypesDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
            this.cmbbx_InspectionType.ValueMember = inspTypesDataSource.Columns["InspectionID"]?.ToString();

            this._manSteps = DatabaseManager.GetManufacturingSteps();

            this._errTypes = DatabaseManager.GetErrorTypes();


            this.ReportId = -1;

            this.InitDefectsTables();

        }


        /// <summary>
        /// HeaderForm Constructor 2
        /// Initialize all the form components with values from an existing report. The elements related to report editing will be visible and enabled
        /// All the comboboxes will have their datasource assigned.
        /// The purpose of this is to edit an existing report
        /// </summary>
        /// <param name="report"></param>
        public HeaderForm(DataRow report)
        {
            InitializeComponent();

            this._editMode = true;

            this._userList = DatabaseManager.GetDatatermUsers();

            this._inspTypes = DatabaseManager.GetInspectionTypes();
            DataTable inspTypesDataSource = DatabaseManager.AddNewEmptyDataRow(this._inspTypes);
            this.cmbbx_InspectionType.DataSource = inspTypesDataSource;
            this.cmbbx_InspectionType.DisplayMember = inspTypesDataSource.Columns[Resources.String.DBNameColumn]?.ToString();
            this.cmbbx_InspectionType.ValueMember = inspTypesDataSource.Columns["InspectionID"]?.ToString();

            this._manSteps = DatabaseManager.GetManufacturingSteps();

            this._errTypes = DatabaseManager.GetErrorTypes();


            this.LoadData(report);

            this.ShowEditMode();
        }
        #endregion


        #region Properties
        //Viewing Form from which the Header form has been called (in case of editing). This form will be refreshed upon confirmation of changes
        internal ViewReportsForm? ReportView { get; set; }

        //ID of the current report
        internal int ReportId { get; set; }

        //Start and End timestamps for the current report
        internal DateTime StartDate { get; set; } = DateTime.MinValue;
        internal DateTime EndDate { get; set; } = DateTime.MinValue;

        //Informations about who is filling the report. Corresponds to the user ID and name in the dataterm database (ESD gates)
        internal int UserID { get; set; } = 0;
        internal string UserName { get; set; } = String.Empty;

        //ID of the inspection type of the current report
        internal int InspectionID { get; set; } = 0;

        //Product information for the current report. Production Order is taken from the OnePlan upon creation of the report. Then it can be edited to any value
        internal string ProductCode { get; set; } = String.Empty;
        internal string ProductionOrder { get; set; } = String.Empty;
        internal int ProductionOrderQty { get; set; } = 0;

        //Quantity information for the current report
        internal int QtyChecked { get; set; } = 0;
        internal int QtyDefective { get; set; } = 0;

        //List of defects registered in the current report
        internal DataTable Defects { get; set; } = new DataTable();
        #endregion


        #region Variables
        private bool _editMode;

        private DataTable _userList = new();

        private DataTable _inspTypes = new();
        private DataTable _manSteps = new();
        private DataTable _errTypes = new();

        //A defect viewer list is needed to display the information with names and not ID. The defect list contains only IDs for Step and Error type
        private DataTable _defectsViewer = new();
        #endregion


        #region EventHandlers
        /// <summary>
        /// txtbx_InspectorID_LostFocus Event Handler
        /// Triggered when the text box for Inspector ID lose focus
        /// Refresh inspector info, lock the field and update the start date in creation mode, and validate the data of the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_InspectorID_LostFocus(object sender, EventArgs e)
        {
            bool validate = RefreshUserInfo();
            if (validate && !_editMode)
            {
                SetStartDate();

                this.txtbx_InspectorID.Enabled = false;
            }
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// txtbx_InspectorID_KeyUp Event Handler
        /// Triggered when the user presses (and release) any key when writing in the text box for Inspector ID
        /// If Enter is pressed: refresh inspector info, lock the field and update the start date in creation mode, and validate the data of the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_InspectorID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enter key pressed

                e.Handled = true;
                bool validate = RefreshUserInfo();
                if (validate && !_editMode)
                {
                    SetStartDate();

                    this.txtbx_InspectorID.Enabled = false;
                }
                this.btn_SendData.Enabled = CheckData();
            }
        }


        /// <summary>
        /// cmbbx_InspectionType_SelectedIndexChanged Event Handler
        /// Triggered when an item is selected in the combo box for Inspection Type
        /// Refresh inspection info, lock the field and update the start date in creation mode, get, the error types corresponding to this inspection type, and validate the data of the report.
        /// Only after selecting the inspection type here, the "Add defect" button will be available. Because the list of error type is needed to add a defect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbbx_InspectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool validate = RefreshInspectionInfo();
            if (validate)
            {
                if (!_editMode)
                {
                    SetStartDate();

                    this.cmbbx_InspectionType.Enabled = false;
                }
            }
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// txtbx_ProductCode_TextChanged Event Handler
        /// Triggered when the text is changed in the text box for Product code
        /// Activate the "Check Production Order" button if the content of the text box is not empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_ProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtbx_ProductCode.Text == String.Empty)
            {
                this.btn_CheckProdOrder.Enabled = false;
            }
            else
            {
                this.btn_CheckProdOrder.Enabled = true;
            }
        }


        /// <summary>
        /// txtbx_ProductCode_LostFocus Event Handler
        /// Triggered when the text box for Product Code lose focus
        /// Refresh Product info, lock the field and update the start date in creation mode, and validate the data of the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_ProductCode_LostFocus(object sender, EventArgs e)
        {
            bool validate = RefreshProductInfo();
            if (validate && !_editMode)
            {
                SetStartDate();

                this.txtbx_ProductCode.Enabled = false;
            }
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// btn_CheckProdOrder_Click Event Handler
        /// Triggered when the "Check Production Order" is clicked
        /// Look for production orders for the specified product in the OnePlan Database and will display them in a SelectionForm
        /// Then it will get the selected item from the SelectionForm and refresh the production order info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CheckProdOrder_Click(object sender, EventArgs e)
        {
            if (ProductCode == String.Empty)
            {
                var errorWin = new ErrorForm(Resources.String.NoProductSelectedErr);
                errorWin.ShowDialog();
            }
            else
            {
                //Getting data from the OnePlan Database
                DataTable productionOrders = DatabaseManager.GetProductionOrders(ProductCode);

                if (productionOrders != null)
                {
                    if (productionOrders.Rows.Count > 0)
                    {
                        //Display the Production Order selection form
                        var selectionForm = new SelectionForm(productionOrders);
                        selectionForm.StartPosition = FormStartPosition.CenterParent;
                        var result = selectionForm.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            try
                            {
                                //Retrieving info from the selected item
                                this.txtbx_ProdOrder.Text = (selectionForm.Selection?["Order"] ?? String.Empty).ToString();
                                this.txtbx_BatchQty.Text = ((int)(Decimal)(selectionForm.Selection?["Target Qty"] ?? "0")).ToString();
                                this.btn_CheckProdOrder.Enabled = false;
                                RefreshProdOrderInfo();
                            }
                            catch
                            {

                            }
                        }

                    }
                    else
                    {
                        var errorWin = new ErrorForm(Resources.String.NoOrderErr + ProductCode);
                        errorWin.ShowDialog();
                    }
                }
                else
                {
                    var errorWin = new ErrorForm(Resources.String.NoOrderErr + ProductCode);
                    errorWin.ShowDialog();
                }
            }
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// txtbx_QtyChecked_LostFocus Event Handler
        /// Triggered when the text box for Quantity Checked lose focus
        /// Refresh Quantity Checked info, update the start date in creation mode, and validate the data of the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_QtyChecked_LostFocus(object sender, EventArgs e)
        {
            bool validate = RefreshQtyCheckedInfo();
            if (validate && !_editMode)
            {
                SetStartDate();
            }
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// btn_AddDefect_Click Event Handler
        /// Triggered when the "Add Defect" is clicked
        /// Show a Defect Form as a dialog box where the defect info can be enetered
        /// Then it will get the defect info, add it to the defect list and create a new defect view based on the defect info.
        /// Recalculate the Quantity Defective info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddDefect_Click(object sender, EventArgs e)
        {
            //Show the Defect Form as dialog box
            var defectForm = new DefectForm(this.Defects, this.InspectionID);
            defectForm.StartPosition = FormStartPosition.CenterParent;
            var result = defectForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    //Adding the new defect to the defect list
                    Defects.Rows.Add(defectForm.CurrentDefect);

                    //Creating the new defect view
                    DataRow newDefectView = _defectsViewer.NewRow();
                    RefreshDefectInfo(defectForm.CurrentDefect, newDefectView);
                    _defectsViewer.Rows.Add(newDefectView);

                    this.btn_DeleteDefect.Enabled = true;
                }
                catch
                {

                }
            }

            SetStartDate();
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// btn_DeleteDefect_Click Event Handler
        /// Triggered when the "Delete Defect" is clicked
        /// Remove the selected defect from the defect and defect viewer lists
        /// Recalculate the Quantity Defective info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DeleteDefect_Click(object sender, EventArgs e)
        {
            try
            {
                //Retrieving the index of the selected defect
                int index = dataGV_Defects.CurrentRow.Index;

                //Deleting from defect list
                this.Defects.Rows[index].Delete();
                this.Defects.AcceptChanges();

                //Deleting from defect viewer list
                this._defectsViewer.Rows[index].Delete();
                this._defectsViewer.AcceptChanges();


                if (this.Defects.Rows.Count == 0)
                {
                    this.btn_DeleteDefect.Enabled = false;
                }

                this.lbl_DefectCount.Text = this.Defects.Rows.Count.ToString() + Resources.String.DefectCountLbl;
                RefreshQtyDefectiveInfo();
            }
            catch
            {
                var errorWin = new ErrorForm(Resources.String.NoDefectSelectedErr);
                errorWin.ShowDialog();
            }
        }


        /// <summary>
        /// dataGV_Defects_CellContentClick Event Handler
        /// Triggered when the user click on a cell of this Grid View
        /// If the user clicked on the Edit Button Column, then it will edit the selected defect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGV_Defects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                EditDefect(e.RowIndex);
                this.btn_SendData.Enabled = CheckData();
            }
        }


        /// <summary>
        /// dataGV_Defects_CellDoubleClick Event Handler
        /// Triggered when the user doubleclick on a cell of this Grid View
        /// Edit the selected defect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGV_Defects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditDefect(e.RowIndex);
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// btn_NoDefect_Click Event Handler
        /// Triggered when the "No Defect" button is clicked
        /// Put the number of defect to 0 and delete all defect after confirmation if there are existing defects
        /// It is also a way to make the user confirm that there is no defect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NoDefect_Click(object sender, EventArgs e)
        {
            if (this.Defects.Rows.Count > 0)
            {
                var confirmationForm = new ConfirmationForm(Resources.String.RemoveAllDefectConf);
                confirmationForm.StartPosition = FormStartPosition.CenterScreen;
                var result = confirmationForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    InitDefectsTables();

                    this.lbl_DefectCount.Text = Resources.String.NoDefectLbl;
                }
            }

            SetStartDate();

            RefreshQtyDefectiveInfo();
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// dateTime_StartDate_ValueChanged Event Handler
        /// Triggered when the Start Date Datetime picker is updated
        /// Refresh the start date info and validate the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTime_StartDate_ValueChanged(object sender, EventArgs e)
        {
            this.StartDate = dateTime_StartDate.Value;
            this.lbl_StartDateValue.Text = this.StartDate.ToString("g");

            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// dateTime_EndDate_ValueChanged Event Handler
        /// Triggered when the End Date Datetime picker is updated
        /// Refresh the end date info and validate the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTime_EndDate_ValueChanged(object sender, EventArgs e)
        {
            this.EndDate = dateTime_EndDate.Value;

            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// txtbx_ProdOrder_LostFocus Event Handler
        /// Triggered when the text box for Production Order lose focus
        /// Refresh Production Order info, and validate the data of the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_ProdOrder_LostFocus(object sender, EventArgs e)
        {
            RefreshProdOrderInfo();
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// txtbx_BatchQty_LostFocus Event Handler
        /// Triggered when the text box for Batch Quantity lose focus
        /// Refresh Baych Quantity info, and validate the data of the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtbx_BatchQty_LostFocus(object sender, EventArgs e)
        {
            RefreshProdOrderInfo();
            this.btn_SendData.Enabled = CheckData();
        }


        /// <summary>
        /// btn_SendData_Click Event Handler
        /// Triggered when the "Send Data" button is clicked
        /// Set the end date in creation mode and start the process of sending data to the Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SendData_Click(object sender, EventArgs e)
        {
            bool send = CheckData();

            if (send)
            {
                if (!_editMode)
                {
                    this.EndDate = DateTime.Now;
                }

                SendData();
            }
        }


        /// <summary>
        /// btn_Delete_Click Event Handler
        /// Triggered when the "Delete" button is clicked
        /// Ask for confirmation and delete the report which is being edited if the action is confirmed. Refresh the report view form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var confirmationForm = new ConfirmationForm(Resources.String.DeleteReportConf);
            confirmationForm.StartPosition = FormStartPosition.CenterScreen;
            var result = confirmationForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    DatabaseManager.DeleteReport(this.ReportId);
                    this.ReportView?.RefreshReports();
                    this.Close();
                }
                catch
                {
                    var errForm = new ErrorForm(Resources.String.DeleteReportErr);
                    errForm.ShowDialog();
                }
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// InitDefectsTables Method
        /// Instanciate and setup the Defects and Defect Viewer tables with the needed columns
        /// Set the _defectViewer table as the datasource of the Grid View for defects and set the size of each colmn
        /// Add the Edit button column for the Grid View of the defects
        /// </summary>
        private void InitDefectsTables()
        {
            //Setting up Defects table
            this.Defects = new DataTable();
            this.Defects.Columns.Add("ManufacturingStepID");
            this.Defects.Columns.Add("ErrorID");
            this.Defects.Columns.Add("DefectCode");
            this.Defects.Columns.Add("Reference");
            this.Defects.Columns.Add("Comment");

            //Setting up Defect Viewer table
            this._defectsViewer = new DataTable();
            this._defectsViewer.Columns.Add(Resources.String.DefectViewerCol1);
            this._defectsViewer.Columns.Add(Resources.String.DefectViewerCol2);
            this._defectsViewer.Columns.Add(Resources.String.DefectViewerCol3);
            this._defectsViewer.Columns.Add(Resources.String.DefectViewerCol4);
            this._defectsViewer.Columns.Add(Resources.String.DefectViewerCol5);
            this._defectsViewer.Columns.Add(Resources.String.DefectViewerCol6);

            //Setting up Defect Grid View
            this.dataGV_Defects.DataSource = this._defectsViewer;
            this.dataGV_Defects.ReadOnly = true;

            //Setting size of the columns in Defect Grid View
            for (int i = 0; i < dataGV_Defects.Columns.Count; i++)
            {
                if (i < this.dataGV_Defects.Columns.Count - 1)
                {
                    this.dataGV_Defects.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                }
                else
                {
                    this.dataGV_Defects.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            //Adding Edit button column to Defect Grid View
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn()
            {
                Name = Resources.String.EditButton,
                Text = Resources.String.EditButton,
                UseColumnTextForButtonValue = true
            };
            if (this.dataGV_Defects.Columns[Resources.String.EditButton] == null)
            {
                this.dataGV_Defects.Columns.Insert(0, editColumn);
            }

            //Disable Delete Defect buttons
            this.btn_DeleteDefect.Enabled = false;

        }


        /// <summary>
        /// SetStartDate Method
        /// Set the current time as the start date if it is not defined yet
        /// Write this start date in the report summary on the right side of the form (Green -> OK, Red -> NOK)
        /// </summary>
        private void SetStartDate()
        {
            if (this.lbl_StartDateValue.Text == String.Empty)
            {
                //Retrieving current timestamp
                this.StartDate = DateTime.Now;
                this.lbl_StartDateValue.Text = this.StartDate.ToString("g");

                //Setting summary label text
                this.dateTime_StartDate.Value = this.StartDate;

                //Setting summary label style
                this.lbl_StartDate.Font = new Font(this.lbl_ProductCode.Font.Name, this.lbl_ProductCode.Font.Size, FontStyle.Regular);
                this.lbl_StartDate.ForeColor = System.Drawing.Color.Black;
                this.lbl_StartDateValue.ForeColor = System.Drawing.Color.Green;

                this.dateTime_StartDate.Visible = true;
                this.lbl_StartDateInput.Visible = true;
            }
        }


        /// <summary>
        /// RefreshUserInfo Method
        /// Read the User ID entered by the user
        /// Find the corresponding user name in the Dataterm Database
        /// Write the user ID and name in the report summary on the right side of the form (Green -> OK, Red -> NOK)
        /// </summary>
        /// <returns>
        /// true if the data is valid, flase if not
        /// </returns>
        private bool RefreshUserInfo()
        {

            try
            {
                //Reading User input
                this.UserID = int.Parse(this.txtbx_InspectorID.Text);
            }
            catch
            {
                this.UserID = 0;
                return false;
            }

            this.UserName = String.Empty;
            //Searching the User name in the Dataterm Database
            foreach (DataRow user in this._userList.Rows)
            {
                try
                {
                    if (int.Parse((string)user["UserID"]) == this.UserID)
                    {
                        this.UserName = (string)user["UserName"];
                        break;
                    }
                }
                catch { }
            }

            //Setting summary labels text
            this.lbl_InspectorIDValue.Text = this.UserID.ToString();
            this.lbl_InspectorNameValue.Text = this.UserName;

            //Setting summary labels style
            if (this.UserName == String.Empty)
            {
                this.lbl_InspectorName.Font = new Font(this.lbl_InspectorName.Font.Name, this.lbl_InspectorID.Font.Size, FontStyle.Bold);
                this.lbl_InspectorName.ForeColor = System.Drawing.Color.Red;

                this.lbl_InspectorID.Font = new Font(this.lbl_InspectorID.Font.Name, this.lbl_InspectorID.Font.Size, FontStyle.Bold);
                this.lbl_InspectorID.ForeColor = System.Drawing.Color.Red;
                this.lbl_InspectorIDValue.ForeColor = System.Drawing.Color.Red;

                return false;
            }
            else
            {

                this.lbl_InspectorName.Font = new Font(this.lbl_InspectorName.Font.Name, this.lbl_InspectorID.Font.Size, FontStyle.Regular);
                this.lbl_InspectorName.ForeColor = System.Drawing.Color.Black;
                this.lbl_InspectorNameValue.ForeColor = System.Drawing.Color.Green;

                this.lbl_InspectorID.Font = new Font(this.lbl_InspectorID.Font.Name, this.lbl_InspectorID.Font.Size, FontStyle.Regular);
                this.lbl_InspectorID.ForeColor = System.Drawing.Color.Black;
                this.lbl_InspectorIDValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        /// <summary>
        /// RefreshInspectionInfo Method
        /// Get the Inspection ID of the Inspection Type selected by the user
        /// Find the corresponding Inspection type name in the SPCReport Database
        /// Write the Inspection type in the report summary on the right side of the form (Green -> OK, Red -> NOK)
        /// </summary>
        /// <returns>
        /// true if the data is valid, flase if not
        /// </returns>
        private bool RefreshInspectionInfo()
        {
            try
            {
                //Reading User input
                this.InspectionID = int.Parse(this.cmbbx_InspectionType.SelectedValue?.ToString() ?? "0");
            }
            catch
            {
                this.InspectionID = 0;
                return false;
            }

            string inspectionType = String.Empty;
            //Searching the Inspection Type Name in the SPCReport Database
            foreach (DataRow inspection in this._inspTypes.Rows)
            {
                try
                {
                    if ((int)inspection["InspectionID"] == this.InspectionID)
                    {
                        inspectionType = (string)inspection[Resources.String.DBNameColumn];
                        break;
                    }
                }
                catch { }
            }

            //Setting summary labels text
            this.lbl_InspectionTypeValue.Text = inspectionType;

            //Setting summary labels style
            if (this.InspectionID == 0 || this.lbl_InspectionTypeValue.Text == String.Empty)
            {
                this.lbl_InspectionType.Font = new Font(this.lbl_InspectionType.Font.Name, this.lbl_InspectionType.Font.Size, FontStyle.Bold);
                this.lbl_InspectionType.ForeColor = System.Drawing.Color.Red;
                this.lbl_InspectionTypeValue.ForeColor = System.Drawing.Color.Red;

                return false;
            }
            else
            {
                this.lbl_InspectionType.Font = new Font(this.lbl_InspectionType.Font.Name, this.lbl_InspectionType.Font.Size, FontStyle.Regular);
                this.lbl_InspectionType.ForeColor = System.Drawing.Color.Black;
                this.lbl_InspectionTypeValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        /// <summary>
        /// RefreshProductInfo Method
        /// Read the Product Code entered by the user
        /// Write the Product Code in the report summary on the right side of the form (Green -> OK, Red -> NOK)
        /// </summary>
        /// <returns>
        /// true if the data is valid, flase if not
        /// </returns>
        private bool RefreshProductInfo()
        {
            //Read User input
            this.ProductCode = this.txtbx_ProductCode.Text;

            //Setting summary labels text
            this.lbl_ProductCodeValue.Text = this.txtbx_ProductCode.Text;

            //Setting summary labels style
            if (this.txtbx_ProductCode.Text == String.Empty)
            {
                this.lbl_ProductCode.Font = new Font(this.lbl_ProductCode.Font.Name, this.lbl_ProductCode.Font.Size, FontStyle.Bold);
                this.lbl_ProductCode.ForeColor = System.Drawing.Color.Red;
                this.lbl_ProductCodeValue.ForeColor = System.Drawing.Color.Red;

                return false;
            }
            else
            {
                this.lbl_ProductCode.Font = new Font(this.lbl_ProductCode.Font.Name, this.lbl_ProductCode.Font.Size, FontStyle.Regular);
                this.lbl_ProductCode.ForeColor = System.Drawing.Color.Black;
                this.lbl_ProductCodeValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        /// <summary>
        /// RefreshProdOrderInfo Method
        /// Get the Production Order info selected by the user
        /// Write the Production Order in the report summary on the right side of the form (Green -> OK, Red -> NOK)
        /// </summary>
        /// <returns>
        /// true if the data is valid, flase if not
        /// </returns>
        private bool RefreshProdOrderInfo()
        {
            //Get user selection
            this.ProductionOrder = this.txtbx_ProdOrder.Text;
            this.ProductionOrderQty = int.Parse(this.txtbx_BatchQty.Text);

            //Setting summary labels text
            this.lbl_ProdOrderValue.Text = this.ProductionOrder;

            //Setting summary labels style
            if (this.ProductionOrder == String.Empty)
            {
                this.lbl_ProdOrder.Font = new Font(this.lbl_ProdOrder.Font.Name, this.lbl_ProdOrder.Font.Size, FontStyle.Bold);
                this.lbl_ProdOrder.ForeColor = System.Drawing.Color.Red;
                this.lbl_ProdOrderValue.ForeColor = System.Drawing.Color.Red;

                return false;

            }
            else
            {
                this.lbl_ProdOrder.Font = new Font(this.lbl_ProdOrder.Font.Name, this.lbl_ProdOrder.Font.Size, FontStyle.Regular);
                this.lbl_ProdOrder.ForeColor = System.Drawing.Color.Black;
                this.lbl_ProdOrderValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        /// <summary>
        /// RefreshQtyCheckedInfo Method
        /// Read the Quantity Checked entered by the user
        /// Write the Quantity Checked in the report summary on the right side of the form (Green -> OK, Red -> NOK)
        /// </summary>
        /// <returns>
        /// true if the data is valid, flase if not
        /// </returns>
        private bool RefreshQtyCheckedInfo()
        {
            try
            {
                //Reading User input
                this.QtyChecked = int.Parse(this.txtbx_QtyChecked.Text);
            }
            catch
            {
                this.QtyChecked = 0;
                return false;
            }

            //Setting summary labels text
            this.lbl_QtyCheckedValue.Text = this.QtyChecked.ToString();

            //Setting summary labels style
            if (QtyChecked == 0)
            {
                this.lbl_QtyChecked.Font = new Font(this.lbl_QtyChecked.Font.Name, this.lbl_QtyChecked.Font.Size, FontStyle.Bold);
                this.lbl_QtyChecked.ForeColor = System.Drawing.Color.Red;
                this.lbl_QtyCheckedValue.ForeColor = System.Drawing.Color.Red;

                return false;

            }
            else
            {
                this.lbl_QtyChecked.Font = new Font(this.lbl_QtyChecked.Font.Name, this.lbl_QtyChecked.Font.Size, FontStyle.Regular);
                this.lbl_QtyChecked.ForeColor = System.Drawing.Color.Black;
                this.lbl_QtyCheckedValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        /// <summary>
        /// RefreshDefectInfo Method
        /// Fill the information in a new defect view according to a newly register defect.
        /// Look into the SPCReports Database to get the step and error name from the step and error ID specified in the defect information
        /// Defect Code, reference and Comment are the same in the defect and defect view
        /// </summary>
        /// <param name="newDefect"></param>
        /// <param name="newDefectView"></param>
        private void RefreshDefectInfo(DataRow newDefect, DataRow newDefectView)
        {
            //Update defect count label
            this.lbl_DefectCount.Text = this.Defects.Rows.Count.ToString() + Resources.String.DefectCountLbl;

            //This index is just an aid for the operator. It will not be added to the SPCReports Database
            newDefectView[Resources.String.DefectViewerCol1] = this.Defects.Rows.Count.ToString();

            //Looking for the Step Name
            foreach (DataRow step in this._manSteps.Rows)
            {
                try
                {
                    if ((int)step["StepID"] == int.Parse((string)newDefect["ManufacturingStepID"]))
                    {
                        newDefectView[Resources.String.DefectViewerCol2] = step[Resources.String.DBNameColumn];
                        break;
                    }
                }
                catch { }
            }

            DataView dv = new DataView(this._errTypes);
            dv.RowFilter = "ManufacturingStepId = " + (string)newDefect["ManufacturingStepID"]; // query example = "id = 10"

            DataTable errTypesFiltered = dv.ToTable();
            //Looking for the Error type
            foreach (DataRow err in errTypesFiltered.Rows)
            {
                try
                {
                    if ((int)err["ErrorID"] == int.Parse((string)newDefect["ErrorID"]))
                    {
                        newDefectView[Resources.String.DefectViewerCol3] = err[Resources.String.DBNameColumn];
                        break;
                    }
                }
                catch { }
            }

            newDefectView[Resources.String.DefectViewerCol4] = newDefect["DefectCode"];
            newDefectView[Resources.String.DefectViewerCol5] = newDefect["Reference"];
            newDefectView[Resources.String.DefectViewerCol6] = newDefect["Comment"];


            RefreshQtyDefectiveInfo();

        }


        /// <summary>
        /// RefreshQtyDefectiveInfo Method
        /// Calculate the number of defects based on the defects registred by the user
        /// Write the Quantity Defective in the report summary on the right side of the form (Green -> OK, Red -> NOK)
        /// </summary>
        /// <returns>
        /// true if the data is valid, flase if not
        /// </returns>
        private bool RefreshQtyDefectiveInfo()
        {
            try
            {
                //Reading User input
                this.QtyDefective = this.Defects.Rows.Count;
            }
            catch
            {
                this.QtyDefective = 0;
            }

            //Setting summary labels text
            this.lbl_QtyDefectiveValue.Text = this.QtyDefective.ToString();

            //Setting summary labels style
            if (this.lbl_QtyDefective.ForeColor == System.Drawing.Color.Red)
            {
                this.lbl_QtyDefective.Font = new Font(this.lbl_QtyDefective.Font.Name, this.lbl_QtyDefective.Font.Size, FontStyle.Regular);
                this.lbl_QtyDefective.ForeColor = System.Drawing.Color.Black;
                this.lbl_QtyDefectiveValue.ForeColor = System.Drawing.Color.Green;
            }

            return true;
        }


        /// <summary>
        /// EditDefect Method
        /// Open the defect form with the information of the selected defect for editing purposes.
        /// Refresh the defect and defect view lists with the edited information.
        /// </summary>
        /// <param name="index"></param>
        private void EditDefect(int index)
        {
            //Retrieving the selected defect
            DataRow selectedDefect = this.Defects.Rows[index];
            DataRow selectedDefectView = this._defectsViewer.Rows[index];

            //Open the defect form as a dialog box and with the editing mode
            var defectForm = new DefectForm(selectedDefect, selectedDefectView, this.InspectionID);
            defectForm.StartPosition = FormStartPosition.CenterParent;
            var result = defectForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Refresh defect and defect view lists
                RefreshDefectInfo(selectedDefect, selectedDefectView);
            }
        }


        /// <summary>
        /// CheckData Method
        /// Check if the data entered by the user is valid and if the report can be sent to the Database
        /// </summary>
        /// <returns>
        /// true if the data is valid, flase if not
        /// </returns>
        private bool CheckData()
        {
            #region Inspector
            if (this.UserID == 0)
            {
                return false;
            }
            if (this.UserName == string.Empty)
            {
                return false;
            }
            #endregion

            #region Inspection Type
            if (this.InspectionID == 0)
            {
                return false;
            }
            #endregion

            #region Product
            if (this.ProductCode == string.Empty)
            {
                return false;
            }
            #endregion

            #region Production Order
            if (this.ProductionOrder == string.Empty)
            {
                return false;
            }
            if (this.ProductionOrderQty == 0)
            {
                return false;
            }
            #endregion

            #region Quantity Checked
            if (this.QtyChecked == 0)
            {
                return false;
            }
            #endregion

            #region Quantity Defective
            if (this.lbl_QtyDefectiveValue.Text == string.Empty)
            {
                return false;
            }
            #endregion

            return true;
        }


        /// <summary>
        /// SendData Method
        /// Send the report data (Header + Defects) to the SPCReport database after confirmation from the user.
        /// In creation mode, it will create a new report entry and new defect entries in the database
        /// In edit mode, it will delete all the defect registered for the edited report ID, update the report information and recreate the edited defects. This is needed because we do not read the defect ID from the database when editing.
        /// </summary>
        private void SendData()
        {
            //Call the confimation form as a dialog box
            var confirmationForm = new ConfirmationForm(Resources.String.SendDataConf);
            confirmationForm.StartPosition = FormStartPosition.CenterScreen;
            var result = confirmationForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Creation mode
                if (!this._editMode)
                {
                    try
                    {
                        //Create a new report entry and get the new report ID
                        int reportId = DatabaseManager.InsertNewReport(this);

                        //Create each defect under the new report ID
                        foreach (DataRow defect in this.Defects.Rows)
                        {
                            DatabaseManager.InsertNewDefect(reportId, defect);
                        }
                        this.Close();
                    }
                    catch
                    {
                        var errForm = new ErrorForm(Resources.String.SendDataErr);
                        errForm.ShowDialog();
                    }
                }
                //Edit mode
                else
                {
                    try
                    {
                        //Delete all the defects
                        DatabaseManager.DeleteAllDefects(this.ReportId);

                        //Update report info
                        DatabaseManager.UpdateReport(this);

                        //Recreate the edited defects
                        foreach (DataRow defect in this.Defects.Rows)
                        {
                            DatabaseManager.InsertNewDefect(this.ReportId, defect);
                        }

                        //Update the report view form which called the Header form for edition
                        this.ReportView?.RefreshReports();
                    }
                    catch
                    {
                        var errForm = new ErrorForm(Resources.String.SendDataErr);
                        errForm.ShowDialog();
                    }
                }

            }


        }


        /// <summary>
        /// LoadData Method
        /// Prefill the fields of the form with the data from an existing form.
        /// When loading the data, the checks and refreshs are done as the user was entering the data.
        /// </summary>
        /// <param name="report"></param>
        private void LoadData(DataRow report)
        {

            this.ReportId = (int)report[Resources.String.DBReportIDReportView];

            #region Start Date
            this.StartDate = (DateTime)report[Resources.String.DBStartDateReportView];
            lbl_StartDateValue.Text = this.StartDate.ToString("g");

            dateTime_StartDate.Value = this.StartDate;

            lbl_StartDate.Font = new Font(lbl_ProductCode.Font.Name, lbl_ProductCode.Font.Size, FontStyle.Regular);
            lbl_StartDate.ForeColor = System.Drawing.Color.Black;
            lbl_StartDateValue.ForeColor = System.Drawing.Color.Green;

            dateTime_StartDate.Visible = true;
            dateTime_StartDate.Enabled = true;
            lbl_StartDateInput.Visible = true;
            #endregion


            #region End Date
            this.EndDate = (DateTime)report[Resources.String.DBEndDateReportView];

            dateTime_EndDate.Value = this.EndDate;

            dateTime_EndDate.Visible = true;
            dateTime_EndDate.Enabled = true;
            lbl_EndDateInput.Visible = true;
            #endregion


            #region Inspector
            this.txtbx_InspectorID.Text = ((int)report[Resources.String.DBInspectorIDReportView]).ToString();
            RefreshUserInfo();
            #endregion


            #region InspectionType
            this.cmbbx_InspectionType.Text = (string)report[Resources.String.DBInspectionTypeReportView];
            RefreshInspectionInfo();
            #endregion


            #region ProductCode
            this.txtbx_ProductCode.Text = (string)report[Resources.String.DBProductReportView];
            RefreshProductInfo();
            #endregion


            #region ProductionOrder
            this.txtbx_ProdOrder.Text = (string)report[Resources.String.DBProdOrderReportView];

            try
            {
                this.txtbx_BatchQty.Text = ((int)report[Resources.String.DBBatchQtyReportView]).ToString();
            }
            catch
            {
                this.txtbx_BatchQty.Text = "0";
            }
            RefreshProdOrderInfo();
            #endregion


            #region QuantityChecked
            this.txtbx_QtyChecked.Text = ((int)report[Resources.String.DBQtyCheckedReportView]).ToString();
            RefreshQtyCheckedInfo();
            #endregion


            #region Defects
            InitDefectsTables();

            DataTable tempDefects = DatabaseManager.GetDefectsFromReport(this.ReportId);
            foreach (DataRow defect in tempDefects.Rows)
            {
                DataRow newDefect = this.Defects.NewRow();
                DataRow newDefectView = this._defectsViewer.NewRow();

                this.btn_DeleteDefect.Enabled = true;

                #region Manufacturing Step
                foreach (DataRow step in this._manSteps.Rows)
                {
                    try
                    {
                        if ((string)step[Resources.String.DBNameColumn] == (string)defect[Resources.String.DBStepDefectView])
                        {
                            newDefect["ManufacturingStepID"] = step["StepID"];
                            break;
                        }
                    }
                    catch { }
                }
                #endregion


                #region Error Type
                foreach (DataRow err in this._errTypes.Rows)
                {
                    try
                    {
                        if ((string)err[Resources.String.DBNameColumn] == (string)defect[Resources.String.DBErrorDefectView])
                        {
                            newDefect["ErrorID"] = err["ErrorID"];
                            break;
                        }
                    }
                    catch { }
                }
                #endregion


                #region Defect Code
                newDefect["DefectCode"] = defect[Resources.String.DBDefectCodeDefectView];
                #endregion


                #region Reference
                newDefect["Reference"] = defect[Resources.String.DBReferenceDefectView];
                #endregion


                #region Comment
                newDefect["Comment"] = defect[Resources.String.DBCommentDefectView];
                #endregion


                this.Defects.Rows.Add(newDefect);
                RefreshDefectInfo(newDefect, newDefectView);
                this._defectsViewer.Rows.Add(newDefectView);
            }

            RefreshQtyDefectiveInfo();

            this.btn_SendData.Enabled = CheckData();
            #endregion
        }


        /// <summary>
        /// ShowEditMode Method
        /// Enable and make visible the visual elements of the form which are available only in edition mode - Report ID in the form title, Production Order Text box, Batch Qty Text box, Delete button
        /// Disable and hide the check production order button. 
        /// </summary>
        private void ShowEditMode()
        {
            //this.lbl_ReportID.Visible = true;
            //this.lbl_ReportIdValue.Visible = true;

            this.Text = Resources.String.HeaderEditTitle + this.ReportId.ToString();

            this.btn_CheckProdOrder.Enabled = false;
            this.btn_CheckProdOrder.Visible = false;

            this.txtbx_ProdOrder.Visible = true;
            this.txtbx_ProdOrder.Enabled = true;
            this.lbl_ProdOrderInput.Visible = true;

            this.txtbx_BatchQty.Visible = true;
            this.txtbx_BatchQty.Enabled = true;
            this.lbl_BatchQtyInput.Visible = true;

            this.btn_Delete.Visible = true;
            this.btn_Delete.Enabled = true;

            this.btn_SendData.Text = Resources.String.ApplyChangesBtn;
        }
        #endregion
    }
}
