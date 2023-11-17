namespace SPCReportingTool.Forms
{
    partial class ViewReportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewReportsForm));
            splitContainer1 = new SplitContainer();
            dataGV_Reports = new DataGridView();
            chсkbx_DateFilter = new CheckBox();
            cmbbx_Inspector = new ComboBox();
            groupBox_Inspector = new GroupBox();
            rbtn_InspectorID = new RadioButton();
            rbtn_InspectorName = new RadioButton();
            lbl_ReportID = new Label();
            txtbx_ReportID = new TextBox();
            txtbx_ProductionOrder = new TextBox();
            lbl_ProductionOrder = new Label();
            lbl_ProductCode = new Label();
            lbl_InspectionType = new Label();
            cmbbx_DateSelection = new ComboBox();
            cmbbx_InspectionType = new ComboBox();
            txtbx_ProductCode = new TextBox();
            dateTime_To = new DateTimePicker();
            dateTime_From = new DateTimePicker();
            dataGV_Defects = new DataGridView();
            btn_EditMode = new Button();
            btn_Search = new Button();
            btn_Refresh = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGV_Reports).BeginInit();
            groupBox_Inspector.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(dataGV_Reports);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
            splitContainer1.Panel2.Controls.Add(chсkbx_DateFilter);
            splitContainer1.Panel2.Controls.Add(cmbbx_Inspector);
            splitContainer1.Panel2.Controls.Add(groupBox_Inspector);
            splitContainer1.Panel2.Controls.Add(lbl_ReportID);
            splitContainer1.Panel2.Controls.Add(txtbx_ReportID);
            splitContainer1.Panel2.Controls.Add(txtbx_ProductionOrder);
            splitContainer1.Panel2.Controls.Add(lbl_ProductionOrder);
            splitContainer1.Panel2.Controls.Add(lbl_ProductCode);
            splitContainer1.Panel2.Controls.Add(lbl_InspectionType);
            splitContainer1.Panel2.Controls.Add(cmbbx_DateSelection);
            splitContainer1.Panel2.Controls.Add(cmbbx_InspectionType);
            splitContainer1.Panel2.Controls.Add(txtbx_ProductCode);
            splitContainer1.Panel2.Controls.Add(dateTime_To);
            splitContainer1.Panel2.Controls.Add(dateTime_From);
            splitContainer1.Panel2.Controls.Add(dataGV_Defects);
            // 
            // dataGV_Reports
            // 
            resources.ApplyResources(dataGV_Reports, "dataGV_Reports");
            dataGV_Reports.AllowUserToAddRows = false;
            dataGV_Reports.AllowUserToDeleteRows = false;
            dataGV_Reports.AllowUserToOrderColumns = true;
            dataGV_Reports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Reports.MultiSelect = false;
            dataGV_Reports.Name = "dataGV_Reports";
            dataGV_Reports.ReadOnly = true;
            dataGV_Reports.RowTemplate.Height = 25;
            dataGV_Reports.CurrentCellChanged += dataGV_Reports_CurrentCellChanged;
            // 
            // chсkbx_DateFilter
            // 
            resources.ApplyResources(chсkbx_DateFilter, "chсkbx_DateFilter");
            chсkbx_DateFilter.Name = "chсkbx_DateFilter";
            chсkbx_DateFilter.UseVisualStyleBackColor = true;
            chсkbx_DateFilter.CheckedChanged += chсkbx_DateFilter_CheckedChanged;
            // 
            // cmbbx_Inspector
            // 
            resources.ApplyResources(cmbbx_Inspector, "cmbbx_Inspector");
            cmbbx_Inspector.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbx_Inspector.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbbx_Inspector.FormattingEnabled = true;
            cmbbx_Inspector.Name = "cmbbx_Inspector";
            // 
            // groupBox_Inspector
            // 
            resources.ApplyResources(groupBox_Inspector, "groupBox_Inspector");
            groupBox_Inspector.Controls.Add(rbtn_InspectorID);
            groupBox_Inspector.Controls.Add(rbtn_InspectorName);
            groupBox_Inspector.Name = "groupBox_Inspector";
            groupBox_Inspector.TabStop = false;
            // 
            // rbtn_InspectorID
            // 
            resources.ApplyResources(rbtn_InspectorID, "rbtn_InspectorID");
            rbtn_InspectorID.Name = "rbtn_InspectorID";
            rbtn_InspectorID.TabStop = true;
            rbtn_InspectorID.UseVisualStyleBackColor = true;
            rbtn_InspectorID.CheckedChanged += rbtn_InspectorID_CheckedChanged;
            // 
            // rbtn_InspectorName
            // 
            resources.ApplyResources(rbtn_InspectorName, "rbtn_InspectorName");
            rbtn_InspectorName.Name = "rbtn_InspectorName";
            rbtn_InspectorName.TabStop = true;
            rbtn_InspectorName.UseVisualStyleBackColor = true;
            rbtn_InspectorName.CheckedChanged += rbtn_InspectorName_CheckedChanged;
            // 
            // lbl_ReportID
            // 
            resources.ApplyResources(lbl_ReportID, "lbl_ReportID");
            lbl_ReportID.Name = "lbl_ReportID";
            // 
            // txtbx_ReportID
            // 
            resources.ApplyResources(txtbx_ReportID, "txtbx_ReportID");
            txtbx_ReportID.Name = "txtbx_ReportID";
            // 
            // txtbx_ProductionOrder
            // 
            resources.ApplyResources(txtbx_ProductionOrder, "txtbx_ProductionOrder");
            txtbx_ProductionOrder.Name = "txtbx_ProductionOrder";
            // 
            // lbl_ProductionOrder
            // 
            resources.ApplyResources(lbl_ProductionOrder, "lbl_ProductionOrder");
            lbl_ProductionOrder.Name = "lbl_ProductionOrder";
            // 
            // lbl_ProductCode
            // 
            resources.ApplyResources(lbl_ProductCode, "lbl_ProductCode");
            lbl_ProductCode.Name = "lbl_ProductCode";
            // 
            // lbl_InspectionType
            // 
            resources.ApplyResources(lbl_InspectionType, "lbl_InspectionType");
            lbl_InspectionType.Name = "lbl_InspectionType";
            // 
            // cmbbx_DateSelection
            // 
            resources.ApplyResources(cmbbx_DateSelection, "cmbbx_DateSelection");
            cmbbx_DateSelection.FormattingEnabled = true;
            cmbbx_DateSelection.Name = "cmbbx_DateSelection";
            cmbbx_DateSelection.SelectedIndexChanged += cmbbx_DateSelection_SelectedIndexChanged;
            // 
            // cmbbx_InspectionType
            // 
            resources.ApplyResources(cmbbx_InspectionType, "cmbbx_InspectionType");
            cmbbx_InspectionType.FormattingEnabled = true;
            cmbbx_InspectionType.Name = "cmbbx_InspectionType";
            // 
            // txtbx_ProductCode
            // 
            resources.ApplyResources(txtbx_ProductCode, "txtbx_ProductCode");
            txtbx_ProductCode.Name = "txtbx_ProductCode";
            // 
            // dateTime_To
            // 
            resources.ApplyResources(dateTime_To, "dateTime_To");
            dateTime_To.Format = DateTimePickerFormat.Custom;
            dateTime_To.Name = "dateTime_To";
            // 
            // dateTime_From
            // 
            resources.ApplyResources(dateTime_From, "dateTime_From");
            dateTime_From.Format = DateTimePickerFormat.Custom;
            dateTime_From.Name = "dateTime_From";
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
            // 
            // btn_EditMode
            // 
            resources.ApplyResources(btn_EditMode, "btn_EditMode");
            btn_EditMode.Name = "btn_EditMode";
            btn_EditMode.UseVisualStyleBackColor = true;
            btn_EditMode.Click += btn_EditMode_Click;
            // 
            // btn_Search
            // 
            resources.ApplyResources(btn_Search, "btn_Search");
            btn_Search.Name = "btn_Search";
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += btn_Search_Click;
            // 
            // btn_Refresh
            // 
            resources.ApplyResources(btn_Refresh, "btn_Refresh");
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // ViewReportsForm
            // 
            AcceptButton = btn_Search;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Refresh);
            Controls.Add(splitContainer1);
            Controls.Add(btn_EditMode);
            Controls.Add(btn_Search);
            Name = "ViewReportsForm";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGV_Reports).EndInit();
            groupBox_Inspector.ResumeLayout(false);
            groupBox_Inspector.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGV_Defects).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_EditMode;
        private DataGridView dataGV_Reports;
        private DataGridView dataGV_Defects;
        private SplitContainer splitContainer1;
        private ComboBox cmbbx_DateSelection;
        private ComboBox cmbbx_InspectionType;
        private TextBox txtbx_ProductCode;
        private DateTimePicker dateTime_To;
        private DateTimePicker dateTime_From;
        private RadioButton rbtn_InspectorName;
        private RadioButton rbtn_InspectorID;
        private Button btn_Search;
        private Label lbl_ProductionOrder;
        private Label lbl_ProductCode;
        private Label lbl_InspectionType;
        private TextBox txtbx_ProductionOrder;
        private Label lbl_ReportID;
        private TextBox txtbx_ReportID;
        private GroupBox groupBox_Inspector;
        private ComboBox cmbbx_Inspector;
        private CheckBox chсkbx_DateFilter;
        private Button btn_Refresh;
    }
}