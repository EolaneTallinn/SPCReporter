namespace SPCReportingTool.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            btn_Login = new Button();
            lbl_Password = new Label();
            txtbx_Password = new TextBox();
            lbl_ErrMessage = new Label();
            SuspendLayout();
            // 
            // btn_Login
            // 
            resources.ApplyResources(btn_Login, "btn_Login");
            btn_Login.Name = "btn_Login";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // lbl_Password
            // 
            resources.ApplyResources(lbl_Password, "lbl_Password");
            lbl_Password.Name = "lbl_Password";
            // 
            // txtbx_Password
            // 
            resources.ApplyResources(txtbx_Password, "txtbx_Password");
            txtbx_Password.Name = "txtbx_Password";
            txtbx_Password.UseSystemPasswordChar = true;
            // 
            // lbl_ErrMessage
            // 
            resources.ApplyResources(lbl_ErrMessage, "lbl_ErrMessage");
            lbl_ErrMessage.ForeColor = Color.Red;
            lbl_ErrMessage.Name = "lbl_ErrMessage";
            // 
            // LoginForm
            // 
            AcceptButton = btn_Login;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl_ErrMessage);
            Controls.Add(txtbx_Password);
            Controls.Add(lbl_Password);
            Controls.Add(btn_Login);
            Name = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private Label lbl_Password;
        private TextBox txtbx_Password;
        private Label lbl_ErrMessage;
    }
}