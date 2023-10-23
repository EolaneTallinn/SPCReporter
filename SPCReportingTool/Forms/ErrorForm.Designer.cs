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
        private void InitializeComponent(string error)
        {
            this.lbl_Error = new System.Windows.Forms.Label();
            this.btn_Ack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.Location = new System.Drawing.Point(99, 30);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(81, 15);
            this.lbl_Error.TabIndex = 0;
            this.lbl_Error.Text = error;
            // 
            // btn_Ack
            // 
            this.btn_Ack.Location = new System.Drawing.Point(201, 67);
            this.btn_Ack.Name = "btn_Ack";
            this.btn_Ack.Size = new System.Drawing.Size(75, 23);
            this.btn_Ack.TabIndex = 1;
            this.btn_Ack.Text = "Ok";
            this.btn_Ack.UseVisualStyleBackColor = true;
            this.btn_Ack.Click += new System.EventHandler(this.btn_Ack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 102);
            this.Controls.Add(this.btn_Ack);
            this.Controls.Add(this.lbl_Error);
            this.Name = "ErrorForm";
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_Error;
        private Button btn_Ack;
    }
}