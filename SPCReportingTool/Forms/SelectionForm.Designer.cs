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
            dataGV_Selection = new DataGridView();
            lbl_Select = new Label();
            btn_Select = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGV_Selection).BeginInit();
            SuspendLayout();
            // 
            // dataGV_Selection
            // 
            dataGV_Selection.AllowUserToAddRows = false;
            dataGV_Selection.AllowUserToDeleteRows = false;
            dataGV_Selection.AllowUserToOrderColumns = true;
            dataGV_Selection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGV_Selection.Location = new Point(12, 33);
            dataGV_Selection.MultiSelect = false;
            dataGV_Selection.Name = "dataGV_Selection";
            dataGV_Selection.ReadOnly = true;
            dataGV_Selection.RowTemplate.Height = 25;
            dataGV_Selection.Size = new Size(776, 376);
            dataGV_Selection.TabIndex = 0;
            // 
            // lbl_Select
            // 
            lbl_Select.AutoSize = true;
            lbl_Select.Location = new Point(12, 9);
            lbl_Select.Name = "lbl_Select";
            lbl_Select.Size = new Size(68, 15);
            lbl_Select.TabIndex = 1;
            lbl_Select.Text = "Select item:";
            // 
            // btn_Select
            // 
            btn_Select.Location = new Point(713, 415);
            btn_Select.Name = "btn_Select";
            btn_Select.Size = new Size(75, 23);
            btn_Select.TabIndex = 2;
            btn_Select.Text = "Select";
            btn_Select.UseVisualStyleBackColor = true;
            btn_Select.Click += btn_Select_Click;
            // 
            // SelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_Select);
            Controls.Add(lbl_Select);
            Controls.Add(dataGV_Selection);
            Name = "SelectionForm";
            Text = "SelectionForm";
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