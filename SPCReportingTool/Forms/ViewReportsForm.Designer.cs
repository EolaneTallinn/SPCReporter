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
            btn_Edit = new Button();
            dataGV_Reports = new DataGridView();
            dataGV_Defects = new DataGridView();
            splitContainer1 = new SplitContainer();
            txtbx_ProductionOrder = new TextBox();
            lbl_ProductionOrder = new Label();
            lbl_ProductCode = new Label();
            lbl_InspectionType = new Label();
            rbtn_InspectorName = new RadioButton();
            rbtn_InspectorID = new RadioButton();
            btn_Search = new Button();
            txtbx_Inspector = new TextBox();
            cmbbx_DateSelection = new ComboBox();
            cmbbx_InspectionType = new ComboBox();
            txtbx_ProductCode = new TextBox();
            dateTime_To = new DateTimePicker();
            dateTime_From = new DateTimePicker();
            btn_Delete = new Button();
            txtbx_ReportID = new TextBox();
            lbl_ReportID = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGV_Reports).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGV_Defects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Edit
            // 
            btn_Edit.Location = new Point(12, 632);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new Size(75, 23);
            btn_Edit.TabIndex = 2;
            btn_Edit.Text = "Edit";
            btn_Edit.UseVisualStyleBackColor = true;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // dataGV_Reports
            // 
            dataGV_Reports.AllowUserToAddRows = false;
            dataGV_Reports.AllowUserToDeleteRows = false;
            dataGV_Reports.AllowUserToOrderColumns = true;
            dataGV_Reports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Reports.Location = new Point(0, 0);
            dataGV_Reports.MultiSelect = false;
            dataGV_Reports.Name = "dataGV_Reports";
            dataGV_Reports.ReadOnly = true;
            dataGV_Reports.RowTemplate.Height = 25;
            dataGV_Reports.Size = new Size(1204, 304);
            dataGV_Reports.TabIndex = 3;
            dataGV_Reports.CellContentClick += dataGV_Reports_CellContentClick;
            dataGV_Reports.CurrentCellChanged += dataGV_Reports_CurrentCellChanged;
            // 
            // dataGV_Defects
            // 
            dataGV_Defects.AllowUserToAddRows = false;
            dataGV_Defects.AllowUserToDeleteRows = false;
            dataGV_Defects.AllowUserToOrderColumns = true;
            dataGV_Defects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Defects.Location = new Point(0, 2);
            dataGV_Defects.MultiSelect = false;
            dataGV_Defects.Name = "dataGV_Defects";
            dataGV_Defects.ReadOnly = true;
            dataGV_Defects.RowTemplate.Height = 25;
            dataGV_Defects.Size = new Size(724, 298);
            dataGV_Defects.TabIndex = 4;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGV_Reports);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lbl_ReportID);
            splitContainer1.Panel2.Controls.Add(txtbx_ReportID);
            splitContainer1.Panel2.Controls.Add(txtbx_ProductionOrder);
            splitContainer1.Panel2.Controls.Add(lbl_ProductionOrder);
            splitContainer1.Panel2.Controls.Add(lbl_ProductCode);
            splitContainer1.Panel2.Controls.Add(lbl_InspectionType);
            splitContainer1.Panel2.Controls.Add(rbtn_InspectorName);
            splitContainer1.Panel2.Controls.Add(rbtn_InspectorID);
            splitContainer1.Panel2.Controls.Add(txtbx_Inspector);
            splitContainer1.Panel2.Controls.Add(cmbbx_DateSelection);
            splitContainer1.Panel2.Controls.Add(cmbbx_InspectionType);
            splitContainer1.Panel2.Controls.Add(txtbx_ProductCode);
            splitContainer1.Panel2.Controls.Add(dateTime_To);
            splitContainer1.Panel2.Controls.Add(dateTime_From);
            splitContainer1.Panel2.Controls.Add(dataGV_Defects);
            splitContainer1.Size = new Size(1204, 614);
            splitContainer1.SplitterDistance = 307;
            splitContainer1.TabIndex = 5;
            // 
            // txtbx_ProductionOrder
            // 
            txtbx_ProductionOrder.Location = new Point(979, 256);
            txtbx_ProductionOrder.Name = "txtbx_ProductionOrder";
            txtbx_ProductionOrder.Size = new Size(143, 23);
            txtbx_ProductionOrder.TabIndex = 18;
            // 
            // lbl_ProductionOrder
            // 
            lbl_ProductionOrder.AutoSize = true;
            lbl_ProductionOrder.Location = new Point(874, 259);
            lbl_ProductionOrder.Name = "lbl_ProductionOrder";
            lbl_ProductionOrder.Size = new Size(99, 15);
            lbl_ProductionOrder.TabIndex = 17;
            lbl_ProductionOrder.Text = "Production Order";
            // 
            // lbl_ProductCode
            // 
            lbl_ProductCode.AutoSize = true;
            lbl_ProductCode.Location = new Point(893, 218);
            lbl_ProductCode.Name = "lbl_ProductCode";
            lbl_ProductCode.Size = new Size(80, 15);
            lbl_ProductCode.TabIndex = 16;
            lbl_ProductCode.Text = "Product Code";
            // 
            // lbl_InspectionType
            // 
            lbl_InspectionType.AutoSize = true;
            lbl_InspectionType.Location = new Point(884, 178);
            lbl_InspectionType.Name = "lbl_InspectionType";
            lbl_InspectionType.Size = new Size(89, 15);
            lbl_InspectionType.TabIndex = 15;
            lbl_InspectionType.Text = "Inspection Type";
            // 
            // rbtn_InspectorName
            // 
            rbtn_InspectorName.AutoSize = true;
            rbtn_InspectorName.Location = new Point(864, 136);
            rbtn_InspectorName.Name = "rbtn_InspectorName";
            rbtn_InspectorName.Size = new Size(109, 19);
            rbtn_InspectorName.TabIndex = 14;
            rbtn_InspectorName.TabStop = true;
            rbtn_InspectorName.Text = "Inspector Name";
            rbtn_InspectorName.UseVisualStyleBackColor = true;
            // 
            // rbtn_InspectorID
            // 
            rbtn_InspectorID.AutoSize = true;
            rbtn_InspectorID.Location = new Point(767, 136);
            rbtn_InspectorID.Name = "rbtn_InspectorID";
            rbtn_InspectorID.Size = new Size(88, 19);
            rbtn_InspectorID.TabIndex = 13;
            rbtn_InspectorID.TabStop = true;
            rbtn_InspectorID.Text = "Inspector ID";
            rbtn_InspectorID.UseVisualStyleBackColor = true;
            // 
            // btn_Search
            // 
            btn_Search.Location = new Point(991, 632);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(75, 23);
            btn_Search.TabIndex = 12;
            btn_Search.Text = "Search";
            btn_Search.UseVisualStyleBackColor = true;
            // 
            // txtbx_Inspector
            // 
            txtbx_Inspector.Location = new Point(979, 136);
            txtbx_Inspector.Name = "txtbx_Inspector";
            txtbx_Inspector.Size = new Size(143, 23);
            txtbx_Inspector.TabIndex = 11;
            // 
            // cmbbx_DateSelection
            // 
            cmbbx_DateSelection.FormattingEnabled = true;
            cmbbx_DateSelection.Location = new Point(767, 21);
            cmbbx_DateSelection.Name = "cmbbx_DateSelection";
            cmbbx_DateSelection.Size = new Size(138, 23);
            cmbbx_DateSelection.TabIndex = 10;
            // 
            // cmbbx_InspectionType
            // 
            cmbbx_InspectionType.FormattingEnabled = true;
            cmbbx_InspectionType.Location = new Point(979, 175);
            cmbbx_InspectionType.Name = "cmbbx_InspectionType";
            cmbbx_InspectionType.Size = new Size(143, 23);
            cmbbx_InspectionType.TabIndex = 9;
            // 
            // txtbx_ProductCode
            // 
            txtbx_ProductCode.Location = new Point(979, 215);
            txtbx_ProductCode.Name = "txtbx_ProductCode";
            txtbx_ProductCode.Size = new Size(143, 23);
            txtbx_ProductCode.TabIndex = 8;
            // 
            // dateTime_To
            // 
            dateTime_To.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTime_To.Format = DateTimePickerFormat.Custom;
            dateTime_To.Location = new Point(979, 50);
            dateTime_To.Name = "dateTime_To";
            dateTime_To.Size = new Size(143, 23);
            dateTime_To.TabIndex = 6;
            // 
            // dateTime_From
            // 
            dateTime_From.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTime_From.Format = DateTimePickerFormat.Custom;
            dateTime_From.Location = new Point(979, 21);
            dateTime_From.Name = "dateTime_From";
            dateTime_From.Size = new Size(143, 23);
            dateTime_From.TabIndex = 5;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(137, 632);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(75, 23);
            btn_Delete.TabIndex = 7;
            btn_Delete.Text = "Delete";
            btn_Delete.UseVisualStyleBackColor = true;
            // 
            // txtbx_ReportID
            // 
            txtbx_ReportID.Location = new Point(979, 96);
            txtbx_ReportID.Name = "txtbx_ReportID";
            txtbx_ReportID.Size = new Size(143, 23);
            txtbx_ReportID.TabIndex = 19;
            // 
            // lbl_ReportID
            // 
            lbl_ReportID.AutoSize = true;
            lbl_ReportID.Location = new Point(917, 99);
            lbl_ReportID.Name = "lbl_ReportID";
            lbl_ReportID.Size = new Size(56, 15);
            lbl_ReportID.TabIndex = 20;
            lbl_ReportID.Text = "Report ID";
            // 
            // ViewReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 667);
            Controls.Add(btn_Delete);
            Controls.Add(splitContainer1);
            Controls.Add(btn_Edit);
            Controls.Add(btn_Search);
            Name = "ViewReportsForm";
            Text = "View Reports";
            ((System.ComponentModel.ISupportInitialize)dataGV_Reports).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGV_Defects).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btn_Edit;
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
        private TextBox txtbx_Inspector;
        private Button btn_Delete;
        private Label lbl_ProductionOrder;
        private Label lbl_ProductCode;
        private Label lbl_InspectionType;
        private TextBox txtbx_ProductionOrder;
        private Label lbl_ReportID;
        private TextBox txtbx_ReportID;
    }
}