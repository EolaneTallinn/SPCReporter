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
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.txtbx_Password = new System.Windows.Forms.TextBox();
            this.lbl_ErrMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(158, 56);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 0;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(12, 9);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(143, 15);
            this.lbl_Password.TabIndex = 1;
            this.lbl_Password.Text = "Please Enter the Password";
            // 
            // txtbx_Password
            // 
            this.txtbx_Password.Location = new System.Drawing.Point(12, 27);
            this.txtbx_Password.Name = "txtbx_Password";
            this.txtbx_Password.Size = new System.Drawing.Size(221, 23);
            this.txtbx_Password.TabIndex = 2;
            this.txtbx_Password.UseSystemPasswordChar = true;
            // 
            // lbl_ErrMessage
            // 
            this.lbl_ErrMessage.AutoSize = true;
            this.lbl_ErrMessage.ForeColor = System.Drawing.Color.Red;
            this.lbl_ErrMessage.Location = new System.Drawing.Point(12, 60);
            this.lbl_ErrMessage.Name = "lbl_ErrMessage";
            this.lbl_ErrMessage.Size = new System.Drawing.Size(140, 15);
            this.lbl_ErrMessage.TabIndex = 3;
            this.lbl_ErrMessage.Text = "The password is incorrect";
            this.lbl_ErrMessage.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 89);
            this.Controls.Add(this.lbl_ErrMessage);
            this.Controls.Add(this.txtbx_Password);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.btn_Login);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Login;
        private Label lbl_Password;
        private TextBox txtbx_Password;
        private Label lbl_ErrMessage;
    }
}