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
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
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
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGV_Defects);
            splitContainer1.Panel2.Controls.Add(btn_NoDefect);
            splitContainer1.Panel2.Controls.Add(lbl_DefectCount);
            splitContainer1.Panel2.Controls.Add(btn_DeleteDefect);
            splitContainer1.Panel2.Controls.Add(btn_AddDefect);
            splitContainer1.Panel2.Controls.Add(btn_SendData);
            splitContainer1.Size = new Size(850, 548);
            splitContainer1.SplitterDistance = 244;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
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
            splitContainer2.Size = new Size(850, 244);
            splitContainer2.SplitterDistance = 538;
            splitContainer2.TabIndex = 0;
            // 
            // dateTime_EndDate
            // 
            dateTime_EndDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTime_EndDate.Enabled = false;
            dateTime_EndDate.Format = DateTimePickerFormat.Custom;
            dateTime_EndDate.Location = new Point(380, 83);
            dateTime_EndDate.Name = "dateTime_EndDate";
            dateTime_EndDate.Size = new Size(133, 23);
            dateTime_EndDate.TabIndex = 14;
            dateTime_EndDate.Value = new DateTime(2023, 10, 18, 14, 30, 29, 310);
            dateTime_EndDate.Visible = false;
            dateTime_EndDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTime_StartDate
            // 
            dateTime_StartDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTime_StartDate.Enabled = false;
            dateTime_StartDate.Format = DateTimePickerFormat.Custom;
            dateTime_StartDate.Location = new Point(380, 39);
            dateTime_StartDate.Name = "dateTime_StartDate";
            dateTime_StartDate.Size = new Size(133, 23);
            dateTime_StartDate.TabIndex = 13;
            dateTime_StartDate.Value = new DateTime(2023, 10, 18, 14, 30, 29, 316);
            dateTime_StartDate.Visible = false;
            dateTime_StartDate.ValueChanged += dateTime_StartDate_ValueChanged;
            // 
            // lbl_EndDateInput
            // 
            lbl_EndDateInput.AutoSize = true;
            lbl_EndDateInput.Location = new Point(320, 89);
            lbl_EndDateInput.Name = "lbl_EndDateInput";
            lbl_EndDateInput.Size = new Size(54, 15);
            lbl_EndDateInput.TabIndex = 12;
            lbl_EndDateInput.Text = "End Date";
            lbl_EndDateInput.Visible = false;
            // 
            // lbl_StartDateInput
            // 
            lbl_StartDateInput.AutoSize = true;
            lbl_StartDateInput.Location = new Point(316, 42);
            lbl_StartDateInput.Name = "lbl_StartDateInput";
            lbl_StartDateInput.Size = new Size(58, 15);
            lbl_StartDateInput.TabIndex = 11;
            lbl_StartDateInput.Text = "Start Date";
            lbl_StartDateInput.Visible = false;
            // 
            // btn_CheckProdOrder
            // 
            btn_CheckProdOrder.Enabled = false;
            btn_CheckProdOrder.Location = new Point(148, 153);
            btn_CheckProdOrder.Name = "btn_CheckProdOrder";
            btn_CheckProdOrder.Size = new Size(177, 23);
            btn_CheckProdOrder.TabIndex = 8;
            btn_CheckProdOrder.Text = "Check For Production Order";
            btn_CheckProdOrder.UseVisualStyleBackColor = true;
            btn_CheckProdOrder.Click += btn_CheckProdOrder_Click;
            // 
            // cmbbx_InspectionType
            // 
            cmbbx_InspectionType.FormattingEnabled = true;
            cmbbx_InspectionType.Location = new Point(148, 83);
            cmbbx_InspectionType.Name = "cmbbx_InspectionType";
            cmbbx_InspectionType.Size = new Size(134, 23);
            cmbbx_InspectionType.TabIndex = 7;
            cmbbx_InspectionType.SelectedIndexChanged += cmbbx_InspectionType_SelectedIndexChanged;
            // 
            // lbl_QtyCheckedInput
            // 
            lbl_QtyCheckedInput.AutoSize = true;
            lbl_QtyCheckedInput.Location = new Point(40, 197);
            lbl_QtyCheckedInput.Name = "lbl_QtyCheckedInput";
            lbl_QtyCheckedInput.Size = new Size(102, 15);
            lbl_QtyCheckedInput.TabIndex = 6;
            lbl_QtyCheckedInput.Text = "Quantity Checked";
            // 
            // lbl_ProductCodeInput
            // 
            lbl_ProductCodeInput.AutoSize = true;
            lbl_ProductCodeInput.Location = new Point(62, 127);
            lbl_ProductCodeInput.Name = "lbl_ProductCodeInput";
            lbl_ProductCodeInput.Size = new Size(80, 15);
            lbl_ProductCodeInput.TabIndex = 5;
            lbl_ProductCodeInput.Text = "Product Code";
            // 
            // lbl_InspectionTypeInput
            // 
            lbl_InspectionTypeInput.AutoSize = true;
            lbl_InspectionTypeInput.Location = new Point(53, 86);
            lbl_InspectionTypeInput.Name = "lbl_InspectionTypeInput";
            lbl_InspectionTypeInput.Size = new Size(89, 15);
            lbl_InspectionTypeInput.TabIndex = 4;
            lbl_InspectionTypeInput.Text = "Inspection Type";
            // 
            // lbl_InspectorIDInput
            // 
            lbl_InspectorIDInput.AutoSize = true;
            lbl_InspectorIDInput.Location = new Point(72, 42);
            lbl_InspectorIDInput.Name = "lbl_InspectorIDInput";
            lbl_InspectorIDInput.Size = new Size(70, 15);
            lbl_InspectorIDInput.TabIndex = 3;
            lbl_InspectorIDInput.Text = "Inspector ID";
            // 
            // txtbx_QtyChecked
            // 
            txtbx_QtyChecked.Location = new Point(148, 194);
            txtbx_QtyChecked.Name = "txtbx_QtyChecked";
            txtbx_QtyChecked.Size = new Size(134, 23);
            txtbx_QtyChecked.TabIndex = 2;
            txtbx_QtyChecked.TextChanged += txtbx_QtyChecked_TextChanged;
            txtbx_QtyChecked.LostFocus += txtbx_QtyChecked_LostFocus;
            // 
            // txtbx_ProductCode
            // 
            txtbx_ProductCode.Location = new Point(148, 124);
            txtbx_ProductCode.Name = "txtbx_ProductCode";
            txtbx_ProductCode.Size = new Size(134, 23);
            txtbx_ProductCode.TabIndex = 1;
            txtbx_ProductCode.TextChanged += txtbx_ProductCode_TextChanged;
            txtbx_ProductCode.LostFocus += txtbx_ProductCode_LostFocus;
            // 
            // txtbx_InspectorID
            // 
            txtbx_InspectorID.Location = new Point(148, 39);
            txtbx_InspectorID.Name = "txtbx_InspectorID";
            txtbx_InspectorID.Size = new Size(134, 23);
            txtbx_InspectorID.TabIndex = 0;
            txtbx_InspectorID.TextChanged += txtbx_InspectorID_TextChanged;
            txtbx_InspectorID.LostFocus += txtbx_InspectorID_LostFocus;
            // 
            // lbl_QtyDefectiveValue
            // 
            lbl_QtyDefectiveValue.AutoSize = true;
            lbl_QtyDefectiveValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_QtyDefectiveValue.ForeColor = Color.Red;
            lbl_QtyDefectiveValue.Location = new Point(144, 217);
            lbl_QtyDefectiveValue.Name = "lbl_QtyDefectiveValue";
            lbl_QtyDefectiveValue.Size = new Size(0, 15);
            lbl_QtyDefectiveValue.TabIndex = 15;
            // 
            // lbl_QtyCheckedValue
            // 
            lbl_QtyCheckedValue.AutoSize = true;
            lbl_QtyCheckedValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_QtyCheckedValue.ForeColor = Color.Red;
            lbl_QtyCheckedValue.Location = new Point(144, 189);
            lbl_QtyCheckedValue.Name = "lbl_QtyCheckedValue";
            lbl_QtyCheckedValue.Size = new Size(0, 15);
            lbl_QtyCheckedValue.TabIndex = 14;
            // 
            // lbl_ProdOrderValue
            // 
            lbl_ProdOrderValue.AutoSize = true;
            lbl_ProdOrderValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ProdOrderValue.ForeColor = Color.Red;
            lbl_ProdOrderValue.Location = new Point(144, 161);
            lbl_ProdOrderValue.Name = "lbl_ProdOrderValue";
            lbl_ProdOrderValue.Size = new Size(0, 15);
            lbl_ProdOrderValue.TabIndex = 13;
            // 
            // lbl_ProductCodeValue
            // 
            lbl_ProductCodeValue.AutoSize = true;
            lbl_ProductCodeValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ProductCodeValue.ForeColor = Color.Red;
            lbl_ProductCodeValue.Location = new Point(144, 132);
            lbl_ProductCodeValue.Name = "lbl_ProductCodeValue";
            lbl_ProductCodeValue.Size = new Size(0, 15);
            lbl_ProductCodeValue.TabIndex = 12;
            // 
            // lbl_InspectionTypeValue
            // 
            lbl_InspectionTypeValue.AutoSize = true;
            lbl_InspectionTypeValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InspectionTypeValue.ForeColor = Color.Red;
            lbl_InspectionTypeValue.Location = new Point(144, 105);
            lbl_InspectionTypeValue.Name = "lbl_InspectionTypeValue";
            lbl_InspectionTypeValue.Size = new Size(0, 15);
            lbl_InspectionTypeValue.TabIndex = 11;
            // 
            // lbl_InspectorNameValue
            // 
            lbl_InspectorNameValue.AutoSize = true;
            lbl_InspectorNameValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InspectorNameValue.ForeColor = Color.Red;
            lbl_InspectorNameValue.Location = new Point(144, 77);
            lbl_InspectorNameValue.Name = "lbl_InspectorNameValue";
            lbl_InspectorNameValue.Size = new Size(0, 15);
            lbl_InspectorNameValue.TabIndex = 10;
            // 
            // lbl_InspectorIDValue
            // 
            lbl_InspectorIDValue.AutoSize = true;
            lbl_InspectorIDValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InspectorIDValue.ForeColor = Color.Red;
            lbl_InspectorIDValue.Location = new Point(144, 49);
            lbl_InspectorIDValue.Name = "lbl_InspectorIDValue";
            lbl_InspectorIDValue.Size = new Size(0, 15);
            lbl_InspectorIDValue.TabIndex = 9;
            // 
            // lbl_StartDateValue
            // 
            lbl_StartDateValue.AutoSize = true;
            lbl_StartDateValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StartDateValue.ForeColor = Color.Red;
            lbl_StartDateValue.Location = new Point(144, 22);
            lbl_StartDateValue.Name = "lbl_StartDateValue";
            lbl_StartDateValue.Size = new Size(0, 15);
            lbl_StartDateValue.TabIndex = 8;
            // 
            // lbl_QtyDefective
            // 
            lbl_QtyDefective.AutoSize = true;
            lbl_QtyDefective.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_QtyDefective.ForeColor = Color.Red;
            lbl_QtyDefective.Location = new Point(23, 217);
            lbl_QtyDefective.Name = "lbl_QtyDefective";
            lbl_QtyDefective.Size = new Size(117, 15);
            lbl_QtyDefective.TabIndex = 7;
            lbl_QtyDefective.Text = "Quantity Defective:";
            // 
            // lbl_QtyChecked
            // 
            lbl_QtyChecked.AutoSize = true;
            lbl_QtyChecked.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_QtyChecked.ForeColor = Color.Red;
            lbl_QtyChecked.Location = new Point(23, 189);
            lbl_QtyChecked.Name = "lbl_QtyChecked";
            lbl_QtyChecked.Size = new Size(109, 15);
            lbl_QtyChecked.TabIndex = 6;
            lbl_QtyChecked.Text = "Quantity Checked:";
            // 
            // lbl_ProdOrder
            // 
            lbl_ProdOrder.AutoSize = true;
            lbl_ProdOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ProdOrder.ForeColor = Color.Red;
            lbl_ProdOrder.Location = new Point(23, 161);
            lbl_ProdOrder.Name = "lbl_ProdOrder";
            lbl_ProdOrder.Size = new Size(107, 15);
            lbl_ProdOrder.TabIndex = 5;
            lbl_ProdOrder.Text = "Production Order:";
            // 
            // lbl_ProductCode
            // 
            lbl_ProductCode.AutoSize = true;
            lbl_ProductCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ProductCode.ForeColor = Color.Red;
            lbl_ProductCode.Location = new Point(23, 133);
            lbl_ProductCode.Name = "lbl_ProductCode";
            lbl_ProductCode.Size = new Size(85, 15);
            lbl_ProductCode.TabIndex = 4;
            lbl_ProductCode.Text = "Product Code:";
            // 
            // lbl_InspectionType
            // 
            lbl_InspectionType.AutoSize = true;
            lbl_InspectionType.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InspectionType.ForeColor = Color.Red;
            lbl_InspectionType.Location = new Point(23, 105);
            lbl_InspectionType.Name = "lbl_InspectionType";
            lbl_InspectionType.Size = new Size(97, 15);
            lbl_InspectionType.TabIndex = 3;
            lbl_InspectionType.Text = "Inspection Type:";
            // 
            // lbl_InspectorName
            // 
            lbl_InspectorName.AutoSize = true;
            lbl_InspectorName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InspectorName.ForeColor = Color.Red;
            lbl_InspectorName.Location = new Point(23, 77);
            lbl_InspectorName.Name = "lbl_InspectorName";
            lbl_InspectorName.Size = new Size(99, 15);
            lbl_InspectorName.TabIndex = 2;
            lbl_InspectorName.Text = "Inspector Name:";
            // 
            // lbl_InspectorID
            // 
            lbl_InspectorID.AutoSize = true;
            lbl_InspectorID.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_InspectorID.ForeColor = Color.Red;
            lbl_InspectorID.Location = new Point(23, 49);
            lbl_InspectorID.Name = "lbl_InspectorID";
            lbl_InspectorID.Size = new Size(79, 15);
            lbl_InspectorID.TabIndex = 1;
            lbl_InspectorID.Text = "Inspector ID:";
            // 
            // lbl_StartDate
            // 
            lbl_StartDate.AutoSize = true;
            lbl_StartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StartDate.ForeColor = Color.Red;
            lbl_StartDate.Location = new Point(23, 22);
            lbl_StartDate.Name = "lbl_StartDate";
            lbl_StartDate.Size = new Size(65, 15);
            lbl_StartDate.TabIndex = 0;
            lbl_StartDate.Text = "StartDate:";
            // 
            // dataGV_Defects
            // 
            dataGV_Defects.AllowUserToAddRows = false;
            dataGV_Defects.AllowUserToDeleteRows = false;
            dataGV_Defects.AllowUserToOrderColumns = true;
            dataGV_Defects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Defects.Location = new Point(12, 34);
            dataGV_Defects.MultiSelect = false;
            dataGV_Defects.Name = "dataGV_Defects";
            dataGV_Defects.ReadOnly = true;
            dataGV_Defects.RowTemplate.Height = 25;
            dataGV_Defects.Size = new Size(826, 225);
            dataGV_Defects.TabIndex = 6;
            // 
            // btn_NoDefect
            // 
            btn_NoDefect.BackColor = Color.SpringGreen;
            btn_NoDefect.Location = new Point(12, 5);
            btn_NoDefect.Name = "btn_NoDefect";
            btn_NoDefect.Size = new Size(75, 23);
            btn_NoDefect.TabIndex = 5;
            btn_NoDefect.Text = "No defect";
            btn_NoDefect.UseVisualStyleBackColor = false;
            btn_NoDefect.Click += btn_NoDefect_Click;
            // 
            // lbl_DefectCount
            // 
            lbl_DefectCount.AutoSize = true;
            lbl_DefectCount.Location = new Point(721, 13);
            lbl_DefectCount.Name = "lbl_DefectCount";
            lbl_DefectCount.Size = new Size(117, 15);
            lbl_DefectCount.TabIndex = 4;
            lbl_DefectCount.Text = "0 defect(s) registered";
            // 
            // btn_DeleteDefect
            // 
            btn_DeleteDefect.BackColor = Color.MediumTurquoise;
            btn_DeleteDefect.Enabled = false;
            btn_DeleteDefect.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_DeleteDefect.Location = new Point(189, 5);
            btn_DeleteDefect.Name = "btn_DeleteDefect";
            btn_DeleteDefect.Size = new Size(35, 23);
            btn_DeleteDefect.TabIndex = 3;
            btn_DeleteDefect.Text = "-";
            btn_DeleteDefect.UseVisualStyleBackColor = false;
            btn_DeleteDefect.Click += btn_DeleteDefect_Click;
            // 
            // btn_AddDefect
            // 
            btn_AddDefect.BackColor = Color.Tomato;
            btn_AddDefect.Enabled = false;
            btn_AddDefect.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btn_AddDefect.Location = new Point(148, 5);
            btn_AddDefect.Name = "btn_AddDefect";
            btn_AddDefect.Size = new Size(35, 23);
            btn_AddDefect.TabIndex = 2;
            btn_AddDefect.Text = "+";
            btn_AddDefect.UseVisualStyleBackColor = false;
            btn_AddDefect.Click += btn_AddDefect_Click;
            // 
            // btn_SendData
            // 
            btn_SendData.Location = new Point(763, 265);
            btn_SendData.Name = "btn_SendData";
            btn_SendData.Size = new Size(75, 23);
            btn_SendData.TabIndex = 1;
            btn_SendData.Text = "Send";
            btn_SendData.UseVisualStyleBackColor = true;
            btn_SendData.Click += btn_SendData_Click;
            // 
            // HeaderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 548);
            Controls.Add(splitContainer1);
            Name = "HeaderForm";
            Text = "Report Header";
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
    }
}