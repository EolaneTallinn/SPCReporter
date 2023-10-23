using SPCReportingTool.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPCReportingTool.Forms
{
    public partial class DefectForm : Form
    {
        public DefectForm(DataTable defects, int inspectionID)
        {
            InitializeComponent();

            this.newDefect = defects.NewRow();

            this.btn_AddDefect.Enabled = CheckData();

            this.manSteps = DatabaseManager.GetManufacturingSteps();
            DataTable manStepsDataSource = DatabaseManager.AddNewEmptyDataRow(this.manSteps);
            this.cmbbx_Step.DataSource = manStepsDataSource;
            this.cmbbx_Step.DisplayMember = manStepsDataSource.Columns["Name"].ToString();
            this.cmbbx_Step.ValueMember = manStepsDataSource.Columns["StepID"].ToString();

            this.errTypes = DatabaseManager.GetErrorTypes(inspectionID);
            DataTable errTypesDataSource = DatabaseManager.AddNewEmptyDataRow(this.errTypes);
            this.cmbbx_ErrorType.DataSource = errTypesDataSource;
            this.cmbbx_ErrorType.DisplayMember = errTypesDataSource.Columns["Name"].ToString();
            this.cmbbx_ErrorType.ValueMember = errTypesDataSource.Columns["ErrorID"].ToString();

            this.references = DatabaseManager.GetInspectionTypes();
            DataTable referencesDataSource = DatabaseManager.AddNewEmptyDataRow(this.references);
            this.cmbbx_Reference.DataSource = referencesDataSource;
            this.cmbbx_Reference.DisplayMember = referencesDataSource.Columns["Name"].ToString();
            this.cmbbx_Reference.ValueMember = referencesDataSource.Columns["InspectionID"].ToString();
        }

        internal DataRow newDefect;

        DataTable manSteps;
        DataTable errTypes;
        DataTable references;

        private void cmbbx_Step_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshManufacturingStepInfo();
            this.btn_AddDefect.Enabled = CheckData();
        }

        private void cmbbx_ErrorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshErrorTypeInfo();
            this.btn_AddDefect.Enabled = CheckData();
        }

        private void cmbbx_Reference_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshReferenceInfo();
            this.btn_AddDefect.Enabled = CheckData();
        }

        private void btn_AddDefect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            newDefect["Comment"] = rtxtbox_Comment.Text;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void RefreshManufacturingStepInfo()
        {
            try
            {
                newDefect["ManufacturingStepID"] = int.Parse(cmbbx_Step.SelectedValue.ToString());
                BuildErrorCode();
            }
            catch
            {
                newDefect["ManufacturingStepID"] = -1;
            }
        }


        private void RefreshErrorTypeInfo()
        {
            try
            {
                newDefect["ErrorID"] = int.Parse(cmbbx_ErrorType.SelectedValue.ToString());
                BuildErrorCode();
                
            }
            catch
            {
                newDefect["ErrorID"] = -1;
            }
        }


        private void RefreshReferenceInfo()
        {
            try
            {
                newDefect["Reference"] = int.Parse(cmbbx_Reference.SelectedValue.ToString());
            }
            catch
            {
                newDefect["Reference"] = String.Empty;
            }
        }


        private void BuildErrorCode()
        {
            String stepName = String.Empty;
            String error = String.Empty;

            foreach (DataRow step in manSteps.Rows)
            {
                try
                {
                    if ((int)step["StepID"] == int.Parse((string)newDefect["ManufacturingStepID"]))
                    {
                        stepName = (string)step["Name"];
                        break;
                    }
                }
                catch { }
            }

            foreach (DataRow err in errTypes.Rows)
            {
                try
                {
                    if ((int)err["ErrorID"] == int.Parse((string)newDefect["ErrorID"]))
                    {
                        error = (string)err["Name"];
                        break;
                    }
                }
                catch { }
            }
            newDefect["ErrorCode"] = stepName + error;
        }
        private bool CheckData()
        {
            string stepID, errID, reference;

            try
            {
                stepID = (string)this.newDefect["ManufacturingStepID"];
            }
            catch
            {
                return false;
            }

            try
            {
                errID = (string)this.newDefect["ErrorID"];
            }
            catch
            {
                return false;
            }

            try
            {
                reference = (string)this.newDefect["Reference"];
            }
            catch
            {
                return false;
            }


            if (stepID == "-1")
            {
                return false;
            }
            if (errID == "-1")
            {
                return false;
            }
            if (reference == string.Empty)
            {
                return false;
            }

            return true;
        }
    }
}
