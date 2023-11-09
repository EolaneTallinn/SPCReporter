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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefectForm));
            cmbbx_Step = new ComboBox();
            cmbbx_ErrorType = new ComboBox();
            cmbbx_Reference = new ComboBox();
            lbl_Step = new Label();
            lbl_ErrorType = new Label();
            lbl_Reference = new Label();
            btn_AddDefect = new Button();
            btn_Cancel = new Button();
            rtxtbox_Comment = new RichTextBox();
            lbl_Comment = new Label();
            SuspendLayout();
            // 
            // cmbbx_Step
            // 
            resources.ApplyResources(cmbbx_Step, "cmbbx_Step");
            cmbbx_Step.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbx_Step.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbbx_Step.FormattingEnabled = true;
            cmbbx_Step.Name = "cmbbx_Step";
            cmbbx_Step.SelectedIndexChanged += cmbbx_Step_SelectedIndexChanged;
            // 
            // cmbbx_ErrorType
            // 
            resources.ApplyResources(cmbbx_ErrorType, "cmbbx_ErrorType");
            cmbbx_ErrorType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbx_ErrorType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbbx_ErrorType.FormattingEnabled = true;
            cmbbx_ErrorType.Name = "cmbbx_ErrorType";
            cmbbx_ErrorType.SelectedIndexChanged += cmbbx_ErrorType_SelectedIndexChanged;
            // 
            // cmbbx_Reference
            // 
            resources.ApplyResources(cmbbx_Reference, "cmbbx_Reference");
            cmbbx_Reference.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbbx_Reference.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbbx_Reference.FormattingEnabled = true;
            cmbbx_Reference.Name = "cmbbx_Reference";
            cmbbx_Reference.SelectedIndexChanged += cmbbx_Reference_SelectedIndexChanged;
            cmbbx_Reference.LostFocus += cmbbx_Reference_LostFocus;
            // 
            // lbl_Step
            // 
            resources.ApplyResources(lbl_Step, "lbl_Step");
            lbl_Step.Name = "lbl_Step";
            // 
            // lbl_ErrorType
            // 
            resources.ApplyResources(lbl_ErrorType, "lbl_ErrorType");
            lbl_ErrorType.Name = "lbl_ErrorType";
            // 
            // lbl_Reference
            // 
            resources.ApplyResources(lbl_Reference, "lbl_Reference");
            lbl_Reference.Name = "lbl_Reference";
            // 
            // btn_AddDefect
            // 
            resources.ApplyResources(btn_AddDefect, "btn_AddDefect");
            btn_AddDefect.Name = "btn_AddDefect";
            btn_AddDefect.UseVisualStyleBackColor = true;
            btn_AddDefect.Click += btn_AddDefect_Click;
            // 
            // btn_Cancel
            // 
            resources.ApplyResources(btn_Cancel, "btn_Cancel");
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // rtxtbox_Comment
            // 
            resources.ApplyResources(rtxtbox_Comment, "rtxtbox_Comment");
            rtxtbox_Comment.Name = "rtxtbox_Comment";
            // 
            // lbl_Comment
            // 
            resources.ApplyResources(lbl_Comment, "lbl_Comment");
            lbl_Comment.Name = "lbl_Comment";
            // 
            // DefectForm
            // 
            AcceptButton = btn_AddDefect;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btn_Cancel;
            Controls.Add(lbl_Comment);
            Controls.Add(rtxtbox_Comment);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_AddDefect);
            Controls.Add(lbl_Reference);
            Controls.Add(lbl_ErrorType);
            Controls.Add(lbl_Step);
            Controls.Add(cmbbx_Reference);
            Controls.Add(cmbbx_ErrorType);
            Controls.Add(cmbbx_Step);
            Name = "DefectForm";
            ResumeLayout(false);
            PerformLayout();
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