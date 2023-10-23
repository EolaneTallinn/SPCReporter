namespace SPCReportingTool.Forms
{
    partial class StartMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_NewReport = new System.Windows.Forms.Button();
            this.btn_EditReport = new System.Windows.Forms.Button();
            this.btn_ChangeLanguage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_NewReport
            // 
            this.btn_NewReport.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_NewReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_NewReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_NewReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_NewReport.Location = new System.Drawing.Point(12, 41);
            this.btn_NewReport.Name = "btn_NewReport";
            this.btn_NewReport.Size = new System.Drawing.Size(184, 171);
            this.btn_NewReport.TabIndex = 0;
            this.btn_NewReport.Text = "New Report";
            this.btn_NewReport.UseVisualStyleBackColor = false;
            this.btn_NewReport.Click += new System.EventHandler(this.btn_NewReport_Click);
            // 
            // btn_EditReport
            // 
            this.btn_EditReport.BackColor = System.Drawing.Color.Khaki;
            this.btn_EditReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_EditReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_EditReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_EditReport.Location = new System.Drawing.Point(207, 41);
            this.btn_EditReport.Name = "btn_EditReport";
            this.btn_EditReport.Size = new System.Drawing.Size(184, 171);
            this.btn_EditReport.TabIndex = 1;
            this.btn_EditReport.Text = "View Reports";
            this.btn_EditReport.UseVisualStyleBackColor = false;
            this.btn_EditReport.Click += new System.EventHandler(this.btn_EditReport_Click);
            // 
            // btn_ChangeLanguage
            // 
            this.btn_ChangeLanguage.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_ChangeLanguage.Location = new System.Drawing.Point(12, 12);
            this.btn_ChangeLanguage.Name = "btn_ChangeLanguage";
            this.btn_ChangeLanguage.Size = new System.Drawing.Size(379, 23);
            this.btn_ChangeLanguage.TabIndex = 2;
            this.btn_ChangeLanguage.Text = "Switch to Russian";
            this.btn_ChangeLanguage.UseVisualStyleBackColor = false;
            this.btn_ChangeLanguage.Click += new System.EventHandler(this.btn_ChangeLanguage_Click);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(403, 224);
            this.Controls.Add(this.btn_ChangeLanguage);
            this.Controls.Add(this.btn_EditReport);
            this.Controls.Add(this.btn_NewReport);
            this.Name = "StartMenu";
            this.Text = "StartMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_NewReport;
        private Button btn_EditReport;
        private Button btn_ChangeLanguage;
    }
}