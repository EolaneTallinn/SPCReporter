using SPCReportingTool.Classes;
using System.Data;

namespace SPCReportingTool.Forms
{
    partial class DefectForm
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
            this.cmbbx_Step = new System.Windows.Forms.ComboBox();
            this.cmbbx_ErrorType = new System.Windows.Forms.ComboBox();
            this.cmbbx_Reference = new System.Windows.Forms.ComboBox();
            this.lbl_Step = new System.Windows.Forms.Label();
            this.lbl_ErrorType = new System.Windows.Forms.Label();
            this.lbl_Reference = new System.Windows.Forms.Label();
            this.btn_AddDefect = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rtxtbox_Comment = new System.Windows.Forms.RichTextBox();
            this.lbl_Comment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbbx_Step
            // 
            this.cmbbx_Step.FormattingEnabled = true;
            this.cmbbx_Step.Location = new System.Drawing.Point(132, 27);
            this.cmbbx_Step.Name = "cmbbx_Step";
            this.cmbbx_Step.Size = new System.Drawing.Size(184, 23);
            this.cmbbx_Step.TabIndex = 0;
            this.cmbbx_Step.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Step_SelectedIndexChanged);
            // 
            // cmbbx_ErrorType
            // 
            this.cmbbx_ErrorType.FormattingEnabled = true;
            this.cmbbx_ErrorType.Location = new System.Drawing.Point(132, 78);
            this.cmbbx_ErrorType.Name = "cmbbx_ErrorType";
            this.cmbbx_ErrorType.Size = new System.Drawing.Size(184, 23);
            this.cmbbx_ErrorType.TabIndex = 1;
            this.cmbbx_ErrorType.SelectedIndexChanged += new System.EventHandler(this.cmbbx_ErrorType_SelectedIndexChanged);
            // 
            // cmbbx_Reference
            // 
            this.cmbbx_Reference.FormattingEnabled = true;
            this.cmbbx_Reference.Location = new System.Drawing.Point(132, 130);
            this.cmbbx_Reference.Name = "cmbbx_Reference";
            this.cmbbx_Reference.Size = new System.Drawing.Size(184, 23);
            this.cmbbx_Reference.TabIndex = 2;
            this.cmbbx_Reference.SelectedIndexChanged += new System.EventHandler(this.cmbbx_Reference_SelectedIndexChanged);
            // 
            // lbl_Step
            // 
            this.lbl_Step.AutoSize = true;
            this.lbl_Step.Location = new System.Drawing.Point(14, 30);
            this.lbl_Step.Name = "lbl_Step";
            this.lbl_Step.Size = new System.Drawing.Size(112, 15);
            this.lbl_Step.TabIndex = 3;
            this.lbl_Step.Text = "Manufacturing Step";
            // 
            // lbl_ErrorType
            // 
            this.lbl_ErrorType.AutoSize = true;
            this.lbl_ErrorType.Location = new System.Drawing.Point(67, 81);
            this.lbl_ErrorType.Name = "lbl_ErrorType";
            this.lbl_ErrorType.Size = new System.Drawing.Size(59, 15);
            this.lbl_ErrorType.TabIndex = 4;
            this.lbl_ErrorType.Text = "Error Type";
            // 
            // lbl_Reference
            // 
            this.lbl_Reference.AutoSize = true;
            this.lbl_Reference.Location = new System.Drawing.Point(67, 133);
            this.lbl_Reference.Name = "lbl_Reference";
            this.lbl_Reference.Size = new System.Drawing.Size(59, 15);
            this.lbl_Reference.TabIndex = 5;
            this.lbl_Reference.Text = "Reference";
            // 
            // btn_AddDefect
            // 
            this.btn_AddDefect.Location = new System.Drawing.Point(283, 282);
            this.btn_AddDefect.Name = "btn_AddDefect";
            this.btn_AddDefect.Size = new System.Drawing.Size(75, 23);
            this.btn_AddDefect.TabIndex = 6;
            this.btn_AddDefect.Text = "Add Defect";
            this.btn_AddDefect.UseVisualStyleBackColor = true;
            this.btn_AddDefect.Click += new System.EventHandler(this.btn_AddDefect_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(202, 282);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rtxtbox_Comment
            // 
            this.rtxtbox_Comment.Location = new System.Drawing.Point(12, 189);
            this.rtxtbox_Comment.Name = "rtxtbox_Comment";
            this.rtxtbox_Comment.Size = new System.Drawing.Size(346, 80);
            this.rtxtbox_Comment.TabIndex = 8;
            this.rtxtbox_Comment.Text = "";
            // 
            // lbl_Comment
            // 
            this.lbl_Comment.AutoSize = true;
            this.lbl_Comment.Location = new System.Drawing.Point(14, 171);
            this.lbl_Comment.Name = "lbl_Comment";
            this.lbl_Comment.Size = new System.Drawing.Size(61, 15);
            this.lbl_Comment.TabIndex = 9;
            this.lbl_Comment.Text = "Comment";
            // 
            // DefectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 314);
            this.Controls.Add(this.lbl_Comment);
            this.Controls.Add(this.rtxtbox_Comment);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_AddDefect);
            this.Controls.Add(this.lbl_Reference);
            this.Controls.Add(this.lbl_ErrorType);
            this.Controls.Add(this.lbl_Step);
            this.Controls.Add(this.cmbbx_Reference);
            this.Controls.Add(this.cmbbx_ErrorType);
            this.Controls.Add(this.cmbbx_Step);
            this.Name = "DefectForm";
            this.Text = "Defect Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbbx_Step;
        private ComboBox cmbbx_ErrorType;
        private ComboBox cmbbx_Reference;
        private Label lbl_Step;
        private Label lbl_ErrorType;
        private Label lbl_Reference;
        private Button btn_AddDefect;
        private Button btn_Cancel;
        private RichTextBox rtxtbox_Comment;
        private Label lbl_Comment;
    }
}