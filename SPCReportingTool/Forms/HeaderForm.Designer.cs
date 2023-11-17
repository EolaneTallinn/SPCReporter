using SPCReportingTool.Classes;
using System.Data;
using System.Windows.Forms;

namespace SPCReportingTool.Forms
{
    partial class HeaderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeaderForm));
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            lbl_ReportIdValue = new Label();
            lbl_ReportID = new Label();
            lbl_BatchQtyInput = new Label();
            lbl_ProdOrderInput = new Label();
            txtbx_BatchQty = new TextBox();
            txtbx_ProdOrder = new TextBox();
            dateTime_EndDate = new DateTimePicker();
            dateTime_StartDate = new DateTimePicker();
            lbl_EndDateInput = new Label();
            lbl_StartDateInput = new Label();
            btn_CheckProdOrder = new Button();
            cmbbx_InspectionType = new ComboBox();
            lbl_QtyCheckedInput = new Label();
            lbl_ProductCodeInput = new Label();
            lbl_InspectionTypeInput = new Label();
            lbl_InspectorIDInput = new Label();
            txtbx_QtyChecked = new TextBox();
            txtbx_ProductCode = new TextBox();
            txtbx_InspectorID = new TextBox();
            lbl_QtyDefectiveValue = new Label();
            lbl_QtyCheckedValue = new Label();
            lbl_ProdOrderValue = new Label();
            lbl_ProductCodeValue = new Label();
            lbl_InspectionTypeValue = new Label();
            lbl_InspectorNameValue = new Label();
            lbl_InspectorIDValue = new Label();
            lbl_StartDateValue = new Label();
            lbl_QtyDefective = new Label();
            lbl_QtyChecked = new Label();
            lbl_ProdOrder = new Label();
            lbl_ProductCode = new Label();
            lbl_InspectionType = new Label();
            lbl_InspectorName = new Label();
            lbl_InspectorID = new Label();
            lbl_StartDate = new Label();
            btn_Delete = new Button();
            dataGV_Defects = new DataGridView();
            btn_NoDefect = new Button();
            lbl_DefectCount = new Label();
            btn_DeleteDefect = new Button();
            btn_AddDefect = new Button();
            btn_SendData = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGV_Defects).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(splitContainer1.Panel1, "splitContainer1.Panel1");
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
            splitContainer1.Panel2.Controls.Add(btn_Delete);
            splitContainer1.Panel2.Controls.Add(dataGV_Defects);
            splitContainer1.Panel2.Controls.Add(btn_NoDefect);
            splitContainer1.Panel2.Controls.Add(lbl_DefectCount);
            splitContainer1.Panel2.Controls.Add(btn_DeleteDefect);
            splitContainer1.Panel2.Controls.Add(btn_AddDefect);
            splitContainer1.Panel2.Controls.Add(btn_SendData);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(splitContainer2.Panel1, "splitContainer2.Panel1");
            splitContainer2.Panel1.Controls.Add(lbl_ReportIdValue);
            splitContainer2.Panel1.Controls.Add(lbl_ReportID);
            splitContainer2.Panel1.Controls.Add(lbl_BatchQtyInput);
            splitContainer2.Panel1.Controls.Add(lbl_ProdOrderInput);
            splitContainer2.Panel1.Controls.Add(txtbx_BatchQty);
            splitContainer2.Panel1.Controls.Add(txtbx_ProdOrder);
            splitContainer2.Panel1.Controls.Add(dateTime_EndDate);
            splitContainer2.Panel1.Controls.Add(dateTime_StartDate);
            splitContainer2.Panel1.Controls.Add(lbl_EndDateInput);
            splitContainer2.Panel1.Controls.Add(lbl_StartDateInput);
            splitContainer2.Panel1.Controls.Add(btn_CheckProdOrder);
            splitContainer2.Panel1.Controls.Add(cmbbx_InspectionType);
            splitContainer2.Panel1.Controls.Add(lbl_QtyCheckedInput);
            splitContainer2.Panel1.Controls.Add(lbl_ProductCodeInput);
            splitContainer2.Panel1.Controls.Add(lbl_InspectionTypeInput);
            splitContainer2.Panel1.Controls.Add(lbl_InspectorIDInput);
            splitContainer2.Panel1.Controls.Add(txtbx_QtyChecked);
            splitContainer2.Panel1.Controls.Add(txtbx_ProductCode);
            splitContainer2.Panel1.Controls.Add(txtbx_InspectorID);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(splitContainer2.Panel2, "splitContainer2.Panel2");
            splitContainer2.Panel2.Controls.Add(lbl_QtyDefectiveValue);
            splitContainer2.Panel2.Controls.Add(lbl_QtyCheckedValue);
            splitContainer2.Panel2.Controls.Add(lbl_ProdOrderValue);
            splitContainer2.Panel2.Controls.Add(lbl_ProductCodeValue);
            splitContainer2.Panel2.Controls.Add(lbl_InspectionTypeValue);
            splitContainer2.Panel2.Controls.Add(lbl_InspectorNameValue);
            splitContainer2.Panel2.Controls.Add(lbl_InspectorIDValue);
            splitContainer2.Panel2.Controls.Add(lbl_StartDateValue);
            splitContainer2.Panel2.Controls.Add(lbl_QtyDefective);
            splitContainer2.Panel2.Controls.Add(lbl_QtyChecked);
            splitContainer2.Panel2.Controls.Add(lbl_ProdOrder);
            splitContainer2.Panel2.Controls.Add(lbl_ProductCode);
            splitContainer2.Panel2.Controls.Add(lbl_InspectionType);
            splitContainer2.Panel2.Controls.Add(lbl_InspectorName);
            splitContainer2.Panel2.Controls.Add(lbl_InspectorID);
            splitContainer2.Panel2.Controls.Add(lbl_StartDate);
            // 
            // lbl_ReportIdValue
            // 
            resources.ApplyResources(lbl_ReportIdValue, "lbl_ReportIdValue");
            lbl_ReportIdValue.Name = "lbl_ReportIdValue";
            // 
            // lbl_ReportID
            // 
            resources.ApplyResources(lbl_ReportID, "lbl_ReportID");
            lbl_ReportID.Name = "lbl_ReportID";
            // 
            // lbl_BatchQtyInput
            // 
            resources.ApplyResources(lbl_BatchQtyInput, "lbl_BatchQtyInput");
            lbl_BatchQtyInput.Name = "lbl_BatchQtyInput";
            // 
            // lbl_ProdOrderInput
            // 
            resources.ApplyResources(lbl_ProdOrderInput, "lbl_ProdOrderInput");
            lbl_ProdOrderInput.Name = "lbl_ProdOrderInput";
            // 
            // txtbx_BatchQty
            // 
            resources.ApplyResources(txtbx_BatchQty, "txtbx_BatchQty");
            txtbx_BatchQty.Name = "txtbx_BatchQty";
            txtbx_BatchQty.LostFocus += txtbx_BatchQty_LostFocus;
            // 
            // txtbx_ProdOrder
            // 
            resources.ApplyResources(txtbx_ProdOrder, "txtbx_ProdOrder");
            txtbx_ProdOrder.Name = "txtbx_ProdOrder";
            txtbx_ProdOrder.LostFocus += txtbx_ProdOrder_LostFocus;
            // 
            // dateTime_EndDate
            // 
            resources.ApplyResources(dateTime_EndDate, "dateTime_EndDate");
            dateTime_EndDate.Format = DateTimePickerFormat.Custom;
            dateTime_EndDate.Name = "dateTime_EndDate";
            dateTime_EndDate.ValueChanged += dateTime_EndDate_ValueChanged;
            // 
            // dateTime_StartDate
            // 
            resources.ApplyResources(dateTime_StartDate, "dateTime_StartDate");
            dateTime_StartDate.Format = DateTimePickerFormat.Custom;
            dateTime_StartDate.Name = "dateTime_StartDate";
            dateTime_StartDate.Value = new DateTime(2023, 10, 18, 14, 30, 29, 316);
            dateTime_StartDate.ValueChanged += dateTime_StartDate_ValueChanged;
            // 
            // lbl_EndDateInput
            // 
            resources.ApplyResources(lbl_EndDateInput, "lbl_EndDateInput");
            lbl_EndDateInput.Name = "lbl_EndDateInput";
            // 
            // lbl_StartDateInput
            // 
            resources.ApplyResources(lbl_StartDateInput, "lbl_StartDateInput");
            lbl_StartDateInput.Name = "lbl_StartDateInput";
            // 
            // btn_CheckProdOrder
            // 
            resources.ApplyResources(btn_CheckProdOrder, "btn_CheckProdOrder");
            btn_CheckProdOrder.Name = "btn_CheckProdOrder";
            btn_CheckProdOrder.UseVisualStyleBackColor = true;
            btn_CheckProdOrder.Click += btn_CheckProdOrder_Click;
            // 
            // cmbbx_InspectionType
            // 
            resources.ApplyResources(cmbbx_InspectionType, "cmbbx_InspectionType");
            cmbbx_InspectionType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbx_InspectionType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbbx_InspectionType.FormattingEnabled = true;
            cmbbx_InspectionType.Name = "cmbbx_InspectionType";
            cmbbx_InspectionType.SelectedIndexChanged += cmbbx_InspectionType_SelectedIndexChanged;
            // 
            // lbl_QtyCheckedInput
            // 
            resources.ApplyResources(lbl_QtyCheckedInput, "lbl_QtyCheckedInput");
            lbl_QtyCheckedInput.Name = "lbl_QtyCheckedInput";
            // 
            // lbl_ProductCodeInput
            // 
            resources.ApplyResources(lbl_ProductCodeInput, "lbl_ProductCodeInput");
            lbl_ProductCodeInput.Name = "lbl_ProductCodeInput";
            // 
            // lbl_InspectionTypeInput
            // 
            resources.ApplyResources(lbl_InspectionTypeInput, "lbl_InspectionTypeInput");
            lbl_InspectionTypeInput.Name = "lbl_InspectionTypeInput";
            // 
            // lbl_InspectorIDInput
            // 
            resources.ApplyResources(lbl_InspectorIDInput, "lbl_InspectorIDInput");
            lbl_InspectorIDInput.Name = "lbl_InspectorIDInput";
            // 
            // txtbx_QtyChecked
            // 
            resources.ApplyResources(txtbx_QtyChecked, "txtbx_QtyChecked");
            txtbx_QtyChecked.Name = "txtbx_QtyChecked";
            txtbx_QtyChecked.LostFocus += txtbx_QtyChecked_LostFocus;
            txtbx_QtyChecked.KeyUp += txtbx_QtyChecked_KeyUp;
            // 
            // txtbx_ProductCode
            // 
            resources.ApplyResources(txtbx_ProductCode, "txtbx_ProductCode");
            txtbx_ProductCode.Name = "txtbx_ProductCode";
            txtbx_ProductCode.TextChanged += txtbx_ProductCode_TextChanged;
            txtbx_ProductCode.GotFocus += txtbx_ProductCode_GotFocus;
            txtbx_ProductCode.LostFocus += txtbx_ProductCode_LostFocus;
            // 
            // txtbx_InspectorID
            // 
            resources.ApplyResources(txtbx_InspectorID, "txtbx_InspectorID");
            txtbx_InspectorID.Name = "txtbx_InspectorID";
            txtbx_InspectorID.KeyUp += txtbx_InspectorID_KeyUp;
            txtbx_InspectorID.LostFocus += txtbx_InspectorID_LostFocus;
            // 
            // lbl_QtyDefectiveValue
            // 
            resources.ApplyResources(lbl_QtyDefectiveValue, "lbl_QtyDefectiveValue");
            lbl_QtyDefectiveValue.ForeColor = Color.Red;
            lbl_QtyDefectiveValue.Name = "lbl_QtyDefectiveValue";
            // 
            // lbl_QtyCheckedValue
            // 
            resources.ApplyResources(lbl_QtyCheckedValue, "lbl_QtyCheckedValue");
            lbl_QtyCheckedValue.ForeColor = Color.Red;
            lbl_QtyCheckedValue.Name = "lbl_QtyCheckedValue";
            // 
            // lbl_ProdOrderValue
            // 
            resources.ApplyResources(lbl_ProdOrderValue, "lbl_ProdOrderValue");
            lbl_ProdOrderValue.ForeColor = Color.Red;
            lbl_ProdOrderValue.Name = "lbl_ProdOrderValue";
            // 
            // lbl_ProductCodeValue
            // 
            resources.ApplyResources(lbl_ProductCodeValue, "lbl_ProductCodeValue");
            lbl_ProductCodeValue.ForeColor = Color.Red;
            lbl_ProductCodeValue.Name = "lbl_ProductCodeValue";
            // 
            // lbl_InspectionTypeValue
            // 
            resources.ApplyResources(lbl_InspectionTypeValue, "lbl_InspectionTypeValue");
            lbl_InspectionTypeValue.ForeColor = Color.Red;
            lbl_InspectionTypeValue.Name = "lbl_InspectionTypeValue";
            // 
            // lbl_InspectorNameValue
            // 
            resources.ApplyResources(lbl_InspectorNameValue, "lbl_InspectorNameValue");
            lbl_InspectorNameValue.ForeColor = Color.Red;
            lbl_InspectorNameValue.Name = "lbl_InspectorNameValue";
            // 
            // lbl_InspectorIDValue
            // 
            resources.ApplyResources(lbl_InspectorIDValue, "lbl_InspectorIDValue");
            lbl_InspectorIDValue.ForeColor = Color.Red;
            lbl_InspectorIDValue.Name = "lbl_InspectorIDValue";
            // 
            // lbl_StartDateValue
            // 
            resources.ApplyResources(lbl_StartDateValue, "lbl_StartDateValue");
            lbl_StartDateValue.ForeColor = Color.Red;
            lbl_StartDateValue.Name = "lbl_StartDateValue";
            // 
            // lbl_QtyDefective
            // 
            resources.ApplyResources(lbl_QtyDefective, "lbl_QtyDefective");
            lbl_QtyDefective.ForeColor = Color.Red;
            lbl_QtyDefective.Name = "lbl_QtyDefective";
            // 
            // lbl_QtyChecked
            // 
            resources.ApplyResources(lbl_QtyChecked, "lbl_QtyChecked");
            lbl_QtyChecked.ForeColor = Color.Red;
            lbl_QtyChecked.Name = "lbl_QtyChecked";
            // 
            // lbl_ProdOrder
            // 
            resources.ApplyResources(lbl_ProdOrder, "lbl_ProdOrder");
            lbl_ProdOrder.ForeColor = Color.Red;
            lbl_ProdOrder.Name = "lbl_ProdOrder";
            // 
            // lbl_ProductCode
            // 
            resources.ApplyResources(lbl_ProductCode, "lbl_ProductCode");
            lbl_ProductCode.ForeColor = Color.Red;
            lbl_ProductCode.Name = "lbl_ProductCode";
            // 
            // lbl_InspectionType
            // 
            resources.ApplyResources(lbl_InspectionType, "lbl_InspectionType");
            lbl_InspectionType.ForeColor = Color.Red;
            lbl_InspectionType.Name = "lbl_InspectionType";
            // 
            // lbl_InspectorName
            // 
            resources.ApplyResources(lbl_InspectorName, "lbl_InspectorName");
            lbl_InspectorName.ForeColor = Color.Red;
            lbl_InspectorName.Name = "lbl_InspectorName";
            // 
            // lbl_InspectorID
            // 
            resources.ApplyResources(lbl_InspectorID, "lbl_InspectorID");
            lbl_InspectorID.ForeColor = Color.Red;
            lbl_InspectorID.Name = "lbl_InspectorID";
            // 
            // lbl_StartDate
            // 
            resources.ApplyResources(lbl_StartDate, "lbl_StartDate");
            lbl_StartDate.ForeColor = Color.Red;
            lbl_StartDate.Name = "lbl_StartDate";
            // 
            // btn_Delete
            // 
            resources.ApplyResources(btn_Delete, "btn_Delete");
            btn_Delete.ForeColor = Color.Red;
            btn_Delete.Name = "btn_Delete";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // dataGV_Defects
            // 
            resources.ApplyResources(dataGV_Defects, "dataGV_Defects");
            dataGV_Defects.AllowUserToAddRows = false;
            dataGV_Defects.AllowUserToDeleteRows = false;
            dataGV_Defects.AllowUserToOrderColumns = true;
            dataGV_Defects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Defects.MultiSelect = false;
            dataGV_Defects.Name = "dataGV_Defects";
            dataGV_Defects.ReadOnly = true;
            dataGV_Defects.RowTemplate.Height = 25;
            dataGV_Defects.CellContentClick += dataGV_Defects_CellContentClick;
            dataGV_Defects.CellDoubleClick += dataGV_Defects_CellDoubleClick;
            // 
            // btn_NoDefect
            // 
            resources.ApplyResources(btn_NoDefect, "btn_NoDefect");
            btn_NoDefect.BackColor = Color.SpringGreen;
            btn_NoDefect.Name = "btn_NoDefect";
            btn_NoDefect.UseVisualStyleBackColor = false;
            btn_NoDefect.Click += btn_NoDefect_Click;
            // 
            // lbl_DefectCount
            // 
            resources.ApplyResources(lbl_DefectCount, "lbl_DefectCount");
            lbl_DefectCount.Name = "lbl_DefectCount";
            // 
            // btn_DeleteDefect
            // 
            resources.ApplyResources(btn_DeleteDefect, "btn_DeleteDefect");
            btn_DeleteDefect.BackColor = Color.MediumTurquoise;
            btn_DeleteDefect.Name = "btn_DeleteDefect";
            btn_DeleteDefect.UseVisualStyleBackColor = false;
            btn_DeleteDefect.Click += btn_DeleteDefect_Click;
            // 
            // btn_AddDefect
            // 
            resources.ApplyResources(btn_AddDefect, "btn_AddDefect");
            btn_AddDefect.BackColor = Color.Tomato;
            btn_AddDefect.Name = "btn_AddDefect";
            btn_AddDefect.UseVisualStyleBackColor = false;
            btn_AddDefect.Click += btn_AddDefect_Click;
            // 
            // btn_SendData
            // 
            resources.ApplyResources(btn_SendData, "btn_SendData");
            btn_SendData.Name = "btn_SendData";
            btn_SendData.UseVisualStyleBackColor = true;
            btn_SendData.Click += btn_SendData_Click;
            // 
            // HeaderForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "HeaderForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGV_Defects).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ComboBox cmbbx_InspectionType;
        private Label lbl_QtyCheckedInput;
        private Label lbl_ProductCodeInput;
        private Label lbl_InspectionTypeInput;
        private Label lbl_InspectorIDInput;
        private TextBox txtbx_QtyChecked;
        private TextBox txtbx_ProductCode;
        private TextBox txtbx_InspectorID;
        private Button btn_CheckProdOrder;
        private Label lbl_QtyDefectiveValue;
        private Label lbl_QtyCheckedValue;
        private Label lbl_ProdOrderValue;
        private Label lbl_ProductCodeValue;
        private Label lbl_InspectionTypeValue;
        private Label lbl_InspectorNameValue;
        private Label lbl_InspectorIDValue;
        private Label lbl_StartDateValue;
        private Label lbl_QtyDefective;
        private Label lbl_QtyChecked;
        private Label lbl_ProdOrder;
        private Label lbl_ProductCode;
        private Label lbl_InspectionType;
        private Label lbl_InspectorName;
        private Label lbl_InspectorID;
        private Label lbl_StartDate;
        private Label lbl_DefectCount;
        private Button btn_DeleteDefect;
        private Button btn_AddDefect;
        private Button btn_SendData;
        private DateTimePicker dateTime_EndDate;
        private DateTimePicker dateTime_StartDate;
        private Label lbl_EndDateInput;
        private Label lbl_StartDateInput;
        private Button btn_NoDefect;
        private DataGridView dataGV_Defects;
        private Label lbl_BatchQtyInput;
        private Label lbl_ProdOrderInput;
        private TextBox txtbx_BatchQty;
        private TextBox txtbx_ProdOrder;
        private Button btn_Delete;
        private Label lbl_ReportIdValue;
        private Label lbl_ReportID;
    }
}