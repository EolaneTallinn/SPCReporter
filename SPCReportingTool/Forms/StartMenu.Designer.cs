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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            btn_NewReport = new Button();
            btn_ViewReports = new Button();
            btn_ChangeLanguage = new Button();
            SuspendLayout();
            // 
            // btn_NewReport
            // 
            resources.ApplyResources(btn_NewReport, "btn_NewReport");
            btn_NewReport.BackColor = Color.PaleGreen;
            btn_NewReport.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btn_NewReport.ForeColor = SystemColors.ControlText;
            btn_NewReport.Name = "btn_NewReport";
            btn_NewReport.UseVisualStyleBackColor = false;
            btn_NewReport.Click += btn_NewReport_Click;
            // 
            // btn_ViewReports
            // 
            resources.ApplyResources(btn_ViewReports, "btn_ViewReports");
            btn_ViewReports.BackColor = Color.Khaki;
            btn_ViewReports.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btn_ViewReports.ForeColor = SystemColors.ControlText;
            btn_ViewReports.Name = "btn_ViewReports";
            btn_ViewReports.UseVisualStyleBackColor = false;
            btn_ViewReports.Click += btn_ViewReports_Click;
            // 
            // btn_ChangeLanguage
            // 
            resources.ApplyResources(btn_ChangeLanguage, "btn_ChangeLanguage");
            btn_ChangeLanguage.BackColor = Color.PaleTurquoise;
            btn_ChangeLanguage.Name = "btn_ChangeLanguage";
            btn_ChangeLanguage.UseVisualStyleBackColor = false;
            btn_ChangeLanguage.Click += btn_ChangeLanguage_Click;
            // 
            // StartMenu
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(btn_ChangeLanguage);
            Controls.Add(btn_ViewReports);
            Controls.Add(btn_NewReport);
            Name = "StartMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_NewReport;
        private Button btn_ViewReports;
        private Button btn_ChangeLanguage;
    }
}