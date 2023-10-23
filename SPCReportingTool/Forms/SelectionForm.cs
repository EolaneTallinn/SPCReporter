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
    public partial class SelectionForm : Form
    {
        public SelectionForm(DataTable dt)
        {
            InitializeComponent();

            this.dataGV_Selection.DataSource = dt;
            this.data = dt;
            this.selection = null;

            AutoSizeDataGV(this.dataGV_Selection, 0);
        }

        private DataTable data;
        public DataRow selection;

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

        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGV_Selection.CurrentRow.Index;
                selection = data.Rows[index];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {

            }
        }
    }
}
