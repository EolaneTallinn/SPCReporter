namespace SPCReportingTool.Forms
{
    partial class ErrorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            lbl_Error = new Label();
            btn_Ack = new Button();
            SuspendLayout();
            // 
            // lbl_Error
            // 
            resources.ApplyResources(lbl_Error, "lbl_Error");
            lbl_Error.ForeColor = Color.Red;
            lbl_Error.Name = "lbl_Error";
            // 
            // btn_Ack
            // 
            resources.ApplyResources(btn_Ack, "btn_Ack");
            btn_Ack.Name = "btn_Ack";
            btn_Ack.UseVisualStyleBackColor = true;
            btn_Ack.Click += btn_Ack_Click;
            // 
            // ErrorForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Ack);
            Controls.Add(lbl_Error);
            Name = "ErrorForm";
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_Error;
        private Button btn_Ack;
    }
}