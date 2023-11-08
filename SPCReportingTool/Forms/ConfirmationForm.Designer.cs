namespace SPCReportingTool.Forms
{
    partial class ConfirmationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationForm));
            lbl_ConfirmMsg = new Label();
            btn_Confirm = new Button();
            btn_Cancel = new Button();
            SuspendLayout();
            // 
            // lbl_ConfirmMsg
            // 
            resources.ApplyResources(lbl_ConfirmMsg, "lbl_ConfirmMsg");
            lbl_ConfirmMsg.Name = "lbl_ConfirmMsg";
            // 
            // btn_Confirm
            // 
            resources.ApplyResources(btn_Confirm, "btn_Confirm");
            btn_Confirm.Name = "btn_Confirm";
            btn_Confirm.UseVisualStyleBackColor = true;
            btn_Confirm.Click += btn_Confirm_Click;
            // 
            // btn_Cancel
            // 
            resources.ApplyResources(btn_Cancel, "btn_Cancel");
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // ConfirmationForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Confirm);
            Controls.Add(lbl_ConfirmMsg);
            Name = "ConfirmationForm";
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_ConfirmMsg;
        private Button btn_Confirm;
        private Button btn_Cancel;
    }
}