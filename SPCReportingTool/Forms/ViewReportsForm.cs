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
    public partial class ViewReportsForm : Form
    {
        public ViewReportsForm()
        {
            InitializeComponent();

            this.reports = DatabaseManager.GetReports();
            this.dataGV_Reports.DataSource = reports;
            AutoSizeDataGV(this.dataGV_Reports, 0);

            this.selectedRowIndex = 0;
            this.reportID = (int)reports.Rows[this.selectedRowIndex]["ReportID"];
            this.defects = DatabaseManager.GetDefectsFromReport(this.reportID);
            this.dataGV_Defects.DataSource = defects;
            AutoSizeDataGV(this.dataGV_Defects, 1);
        }

        DataTable reports;
        DataTable defects;

        int selectedRowIndex;

        int reportID;

        private static void AutoSizeDataGV(DataGridView dgv, int mode)
        {
            switch (mode)
            {
                case 0:
                    foreach (DataGridViewColumn dgvc in dgv.Columns)
                    {
                        dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    break;

                case 1:
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (i < dgv.Columns.Count - 1)
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        }
                        else
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                    break;
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            var selectionForm = new LoginForm();
            selectionForm.Show();
        }

        private void dataGV_Reports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGV_Reports_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                this.selectedRowIndex = dataGV_Reports.CurrentCell.RowIndex;
            }
            catch
            {
                this.selectedRowIndex = 0;
            }

            this.reportID = (int)reports.Rows[this.selectedRowIndex]["ReportID"];
            this.defects = DatabaseManager.GetDefectsFromReport(this.reportID);
            this.dataGV_Defects.DataSource = defects;
            AutoSizeDataGV(this.dataGV_Defects, 1);
        }
    }
}
