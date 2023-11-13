using System.Data;

namespace SPCReportingTool.Forms
{
    partial class SelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionForm));
            dataGV_Selection = new DataGridView();
            lbl_Select = new Label();
            btn_Select = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGV_Selection).BeginInit();
            SuspendLayout();
            // 
            // dataGV_Selection
            // 
            resources.ApplyResources(dataGV_Selection, "dataGV_Selection");
            dataGV_Selection.AllowUserToAddRows = false;
            dataGV_Selection.AllowUserToDeleteRows = false;
            dataGV_Selection.AllowUserToOrderColumns = true;
            dataGV_Selection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Selection.MultiSelect = false;
            dataGV_Selection.Name = "dataGV_Selection";
            dataGV_Selection.ReadOnly = true;
            dataGV_Selection.RowTemplate.Height = 25;
            // 
            // lbl_Select
            // 
            resources.ApplyResources(lbl_Select, "lbl_Select");
            lbl_Select.Name = "lbl_Select";
            // 
            // btn_Select
            // 
            resources.ApplyResources(btn_Select, "btn_Select");
            btn_Select.Name = "btn_Select";
            btn_Select.UseVisualStyleBackColor = true;
            btn_Select.Click += btn_Select_Click;
            // 
            // SelectionForm
            // 
            AcceptButton = btn_Select;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Select);
            Controls.Add(lbl_Select);
            Controls.Add(dataGV_Selection);
            Name = "SelectionForm";
            ((System.ComponentModel.ISupportInitialize)dataGV_Selection).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGV_Selection;
        private Label lbl_Select;
        private Button btn_Select;
    }
}