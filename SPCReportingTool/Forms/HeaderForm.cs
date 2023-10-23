using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SPCReportingTool.Classes;

namespace SPCReportingTool.Forms
{
    public partial class HeaderForm : Form
    {
        public HeaderForm()
        {
            InitializeComponent();

            this.userList = DatabaseManager.GetDatatermUsers();

            this.InitDefectsTables();

            inspTypes = DatabaseManager.GetInspectionTypes();
            DataTable inspTypesDataSource = DatabaseManager.AddNewEmptyDataRow(inspTypes);
            this.cmbbx_InspectionType.DataSource = inspTypesDataSource;
            this.cmbbx_InspectionType.DisplayMember = inspTypesDataSource.Columns["Name"].ToString();
            this.cmbbx_InspectionType.ValueMember = inspTypesDataSource.Columns["InspectionID"].ToString();


            this.manSteps = DatabaseManager.GetManufacturingSteps();

        }

        internal DateTime startDate, endDate;

        private DataTable userList;
        internal int userID = 0;
        internal string userName = String.Empty;

        private DataTable inspTypes;
        internal int inspectionID = 0;

        internal string productCode = String.Empty;
        internal string productionOrder = String.Empty;
        internal int productionOrderQty = 0;

        internal int qtyChecked = 0;
        internal int qtyDefective = 0;


        internal DataTable defects;
        private DataTable defectsViewer;


        private DataTable manSteps;
        private DataTable errTypes;


        private void InitDefectsTables()
        {
            this.defects = new DataTable();
            this.defects.Columns.Add("ManufacturingStepID");
            this.defects.Columns.Add("ErrorID");
            this.defects.Columns.Add("ErrorCode");
            this.defects.Columns.Add("Reference");
            this.defects.Columns.Add("Comment");

            this.defectsViewer = new DataTable();
            this.defectsViewer.Columns.Add("Index");
            this.defectsViewer.Columns.Add("Manufacturing Step");
            this.defectsViewer.Columns.Add("Error Type");
            this.defectsViewer.Columns.Add("Error Code");
            this.defectsViewer.Columns.Add("Reference");
            this.defectsViewer.Columns.Add("Comment");

            this.dataGV_Defects.DataSource = this.defectsViewer;
            this.dataGV_Defects.ReadOnly = true;
            for (int i = 0; i < dataGV_Defects.Columns.Count; i++)
            {
                if (i < dataGV_Defects.Columns.Count - 1)
                {
                    dataGV_Defects.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                }
                else
                {
                    dataGV_Defects.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            if (this.inspectionID == 0)
            {
                this.btn_AddDefect.Enabled = false;
            }
            this.btn_DeleteDefect.Enabled = false;
        }

        private void btn_AddDefect_Click(object sender, EventArgs e)
        {
            if (inspectionID != 0)
            {
                var defectForm = new DefectForm(this.defects, this.inspectionID);

                defectForm.StartPosition = FormStartPosition.CenterParent;

                var result = defectForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        defects.Rows.Add(defectForm.newDefect);

                        DataRow newDefectView = defectsViewer.NewRow();
                        RefreshDefectInfo(defectForm.newDefect, newDefectView);

                        defectsViewer.Rows.Add(newDefectView);

                        this.btn_DeleteDefect.Enabled = true;
                    }
                    catch
                    {

                    }
                }
            }
            this.btn_SendData.Enabled = CheckData();
        }

        private void txtbx_QtyChecked_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbx_QtyChecked_LostFocus(object sender, EventArgs e)
        {
            bool validate = RefreshQtyCheckedInfo();
            if (validate)
            {
                SetStartDate();

                this.btn_SendData.Enabled = CheckData();
            }
        }

        private void txtbx_InspectorID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbx_InspectorID_LostFocus(object sender, EventArgs e)
        {
            bool validate = RefreshUserInfo();
            if (validate)
            {
                SetStartDate();

                this.txtbx_InspectorID.Enabled = false;
            }
            this.btn_SendData.Enabled = CheckData();
        }

        private void cmbbx_InspectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool validate = RefreshInspectionInfo();
            if (validate)
            {
                SetStartDate();

                this.cmbbx_InspectionType.Enabled = false;
                this.errTypes = DatabaseManager.GetErrorTypes(inspectionID);
                this.btn_AddDefect.Enabled = true;
                this.btn_SendData.Enabled = CheckData();
            }
        }

        private void txtbx_ProductCode_TextChanged(object sender, EventArgs e)
        {
            if (txtbx_ProductCode.Text == String.Empty)
            {
                this.btn_CheckProdOrder.Enabled = false;
            }
            else
            {
                this.btn_CheckProdOrder.Enabled = true;
            }
        }

        private void txtbx_ProductCode_LostFocus(object sender, EventArgs e)
        {
            bool validate = RefreshProductInfo();
            if (validate)
            {
                SetStartDate();

                this.txtbx_ProductCode.Enabled = false;
                this.btn_SendData.Enabled = CheckData();
            }
        }

        private void btn_CheckProdOrder_Click(object sender, EventArgs e)
        {
            if (productCode == String.Empty)
            {
                var errorWin = new ErrorForm("Please fill in the product code before looking for orders");
                errorWin.Show();
            }
            else
            {
                DataTable productionOrders = DatabaseManager.GetProductionOrders(productCode);

                if (productionOrders != null)
                {
                    if (productionOrders.Rows.Count > 0)
                    {
                        var selectionForm = new SelectionForm(productionOrders);

                        selectionForm.StartPosition = FormStartPosition.CenterParent;

                        var result = selectionForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            try
                            {
                                this.productionOrder = (string)selectionForm.selection["Order"];
                                this.productionOrderQty = (int)(Decimal)selectionForm.selection["Target Qty"];
                                this.btn_CheckProdOrder.Enabled = false;
                                RefreshProdOrderInfo();
                            }
                            catch
                            {

                            }
                        }

                    }
                    else
                    {
                        var errorWin = new ErrorForm("No orders found for the product " + productCode);
                        errorWin.Show();
                    }
                }
                else
                {
                    var errorWin = new ErrorForm("No orders found for the product " + productCode);
                    errorWin.Show();
                }
            }
            this.btn_SendData.Enabled = CheckData();
        }

        private void dateTime_StartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }



        private void SetStartDate()
        {
            if (lbl_StartDateValue.Text == String.Empty)
            {
                this.startDate = DateTime.Now;
                lbl_StartDateValue.Text = this.startDate.ToString("g");

                dateTime_StartDate.Value = this.startDate;

                lbl_StartDate.Font = new Font(lbl_ProductCode.Font.Name, lbl_ProductCode.Font.Size, FontStyle.Regular);
                lbl_StartDate.ForeColor = System.Drawing.Color.Black;
                lbl_StartDateValue.ForeColor = System.Drawing.Color.Green;

                dateTime_StartDate.Visible = true;
                lbl_StartDateInput.Visible = true;
            }
        }

        private bool RefreshUserInfo()
        {
            this.userName = String.Empty;

            try
            {
                this.userID = int.Parse(txtbx_InspectorID.Text);
            }
            catch
            {
                this.userID = 0;
                return false;
            }

            foreach (DataRow user in userList.Rows)
            {
                try
                {
                    if (int.Parse((string)user["UserID"]) == this.userID)
                    {
                        this.userName = (string)user["UserName"];
                        break;
                    }
                }
                catch { }
            }

            lbl_InspectorIDValue.Text = userID.ToString();
            lbl_InspectorNameValue.Text = userName;

            //Dictionary<string, object> currentUser = userList.FirstOrDefault(user => (int)user["UserID"] == this.userID);
            //this.userName = (string)currentUser["UserName"];

            if (userName == String.Empty)
            {
                lbl_InspectorName.Font = new Font(lbl_InspectorName.Font.Name, lbl_InspectorID.Font.Size, FontStyle.Bold);
                lbl_InspectorName.ForeColor = System.Drawing.Color.Red;

                lbl_InspectorID.Font = new Font(lbl_InspectorID.Font.Name, lbl_InspectorID.Font.Size, FontStyle.Bold);
                lbl_InspectorID.ForeColor = System.Drawing.Color.Red;
                lbl_InspectorIDValue.ForeColor = System.Drawing.Color.Red;

                return false;
            }
            else
            {

                lbl_InspectorName.Font = new Font(lbl_InspectorName.Font.Name, lbl_InspectorID.Font.Size, FontStyle.Regular);
                lbl_InspectorName.ForeColor = System.Drawing.Color.Black;
                lbl_InspectorNameValue.ForeColor = System.Drawing.Color.Green;

                lbl_InspectorID.Font = new Font(lbl_InspectorID.Font.Name, lbl_InspectorID.Font.Size, FontStyle.Regular);
                lbl_InspectorID.ForeColor = System.Drawing.Color.Black;
                lbl_InspectorIDValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        private bool RefreshInspectionInfo()
        {
            try
            {
                inspectionID = int.Parse(cmbbx_InspectionType.SelectedValue.ToString());
            }
            catch
            {
                inspectionID = 0;
                return false;
            }

            string inspectionType = String.Empty;
            foreach (DataRow inspection in inspTypes.Rows)
            {
                try
                {
                    if ((int)inspection["InspectionID"] == this.inspectionID)
                    {
                        inspectionType = (string)inspection["Name"];
                        break;
                    }
                }
                catch { }
            }

            lbl_InspectionTypeValue.Text = inspectionType;

            if (inspectionID == 0 || lbl_InspectionTypeValue.Text == String.Empty)
            {
                lbl_InspectionType.Font = new Font(lbl_InspectionType.Font.Name, lbl_InspectionType.Font.Size, FontStyle.Bold);
                lbl_InspectionType.ForeColor = System.Drawing.Color.Red;
                lbl_InspectionTypeValue.ForeColor = System.Drawing.Color.Red;

                return false;
            }
            else
            {
                lbl_InspectionType.Font = new Font(lbl_InspectionType.Font.Name, lbl_InspectionType.Font.Size, FontStyle.Regular);
                lbl_InspectionType.ForeColor = System.Drawing.Color.Black;
                lbl_InspectionTypeValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        private bool RefreshProductInfo()
        {
            productCode = txtbx_ProductCode.Text;

            lbl_ProductCodeValue.Text = txtbx_ProductCode.Text;
            if (txtbx_ProductCode.Text == String.Empty)
            {
                lbl_ProductCode.Font = new Font(lbl_ProductCode.Font.Name, lbl_ProductCode.Font.Size, FontStyle.Bold);
                lbl_ProductCode.ForeColor = System.Drawing.Color.Red;
                lbl_ProductCodeValue.ForeColor = System.Drawing.Color.Red;

                return false;
            }
            else
            {
                lbl_ProductCode.Font = new Font(lbl_ProductCode.Font.Name, lbl_ProductCode.Font.Size, FontStyle.Regular);
                lbl_ProductCode.ForeColor = System.Drawing.Color.Black;
                lbl_ProductCodeValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        private bool RefreshProdOrderInfo()
        {
            lbl_ProdOrderValue.Text = this.productionOrder;
            if (this.productionOrder == String.Empty)
            {
                lbl_ProdOrder.Font = new Font(lbl_ProdOrder.Font.Name, lbl_ProdOrder.Font.Size, FontStyle.Bold);
                lbl_ProdOrder.ForeColor = System.Drawing.Color.Red;
                lbl_ProdOrderValue.ForeColor = System.Drawing.Color.Red;

                return false;

            }
            else
            {
                lbl_ProdOrder.Font = new Font(lbl_ProdOrder.Font.Name, lbl_ProdOrder.Font.Size, FontStyle.Regular);
                lbl_ProdOrder.ForeColor = System.Drawing.Color.Black;
                lbl_ProdOrderValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }


        private bool RefreshQtyCheckedInfo()
        {
            try
            {
                qtyChecked = int.Parse(txtbx_QtyChecked.Text);
            }
            catch
            {
                qtyChecked = 0;
                return false;
            }

            lbl_QtyCheckedValue.Text = qtyChecked.ToString();
            if (qtyChecked == 0)
            {
                lbl_QtyChecked.Font = new Font(lbl_QtyChecked.Font.Name, lbl_QtyChecked.Font.Size, FontStyle.Bold);
                lbl_QtyChecked.ForeColor = System.Drawing.Color.Red;
                lbl_QtyCheckedValue.ForeColor = System.Drawing.Color.Red;

                return false;

            }
            else
            {
                lbl_QtyChecked.Font = new Font(lbl_QtyChecked.Font.Name, lbl_QtyChecked.Font.Size, FontStyle.Regular);
                lbl_QtyChecked.ForeColor = System.Drawing.Color.Black;
                lbl_QtyCheckedValue.ForeColor = System.Drawing.Color.Green;

                return true;
            }
        }

        private void btn_NoDefect_Click(object sender, EventArgs e)
        {
            if (this.defects.Rows.Count > 0)
            {
                this.InitDefectsTables();
            }

            lbl_DefectCount.Text = "0 defect(s) registered";

            SetStartDate();

            RefreshQtyDefectiveInfo();
            this.btn_SendData.Enabled = CheckData();
        }

        private bool RefreshQtyDefectiveInfo()
        {
            try
            {
                qtyDefective = defects.Rows.Count;
            }
            catch
            {
                qtyDefective = 0;
            }

            lbl_QtyDefectiveValue.Text = qtyDefective.ToString();

            if (lbl_QtyDefective.ForeColor == System.Drawing.Color.Red)
            {
                lbl_QtyDefective.Font = new Font(lbl_QtyDefective.Font.Name, lbl_QtyDefective.Font.Size, FontStyle.Regular);
                lbl_QtyDefective.ForeColor = System.Drawing.Color.Black;
                lbl_QtyDefectiveValue.ForeColor = System.Drawing.Color.Green;
            }

            return true;
        }

        private void btn_SendData_Click(object sender, EventArgs e)
        {
            bool send = CheckData();

            if (send)
            {
                this.endDate = DateTime.Now;
                SendData();
            }
        }

        private void RefreshDefectInfo(DataRow newDefect, DataRow newDefectView)
        {
            lbl_DefectCount.Text = defects.Rows.Count.ToString() + " defect(s) registered";
            newDefectView["Index"] = defects.Rows.Count.ToString();

            foreach (DataRow step in manSteps.Rows)
            {
                try
                {
                    if ((int)step["StepID"] == int.Parse((string)newDefect["ManufacturingStepID"]))
                    {
                        newDefectView["Manufacturing Step"] = step["Name"];
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
                        newDefectView["Error Type"] = err["Name"];
                        break;
                    }
                }
                catch { }
            }

            newDefectView["Error Code"] = newDefect["ErrorCode"];
            newDefectView["Reference"] = newDefect["Reference"];
            newDefectView["Comment"] = newDefect["Comment"];


            RefreshQtyDefectiveInfo();

        }

        private bool CheckData()
        {
            if (this.userID == 0)
            {
                return false;
            }
            if (this.userName == string.Empty)
            {
                return false;
            }
            if (this.inspectionID == 0)
            {
                return false;
            }
            if (this.productCode == string.Empty)
            {
                return false;
            }
            if (this.productionOrder == string.Empty)
            {
                return false;
            }
            if (this.qtyChecked == 0)
            {
                return false;
            }
            if (this.lbl_QtyDefectiveValue.Text == string.Empty)
            {
                return false;
            }
            return true;
        }



        private void SendData()
        {
            var confirmationForm = new ConfirmationForm();

            confirmationForm.StartPosition = FormStartPosition.CenterScreen;

            var result = confirmationForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    int reportId = DatabaseManager.InsertNewReport(this);

                    foreach (DataRow defect in this.defects.Rows)
                    {
                        DatabaseManager.InsertNewDefect(reportId, defect);
                    }
                    this.Close();
                }
                catch
                {
                    var errForm = new ErrorForm("Error during report insertion");
                    errForm.ShowDialog();
                }
            }


        }

        private void btn_DeleteDefect_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGV_Defects.CurrentRow.Index;

                this.defects.Rows[index].Delete();
                this.defects.AcceptChanges();

                this.defectsViewer.Rows[index].Delete();
                this.defectsViewer.AcceptChanges();

                if (defects.Rows.Count == 0)
                {
                    this.btn_DeleteDefect.Enabled = false;
                }

                lbl_DefectCount.Text = defects.Rows.Count.ToString() + " defect(s) registered";
                RefreshQtyDefectiveInfo();
            }
            catch
            {

            }
        }
    }
}
