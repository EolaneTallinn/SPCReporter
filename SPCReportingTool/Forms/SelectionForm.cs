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
    /// <summary>
    /// SelectionForm Class
    /// Form which present data as a table from which the user can select a row
    /// It supposed to be called as a dialog box
    /// </summary>
    public partial class SelectionForm : Form
    {
        #region Constructors
        /// <summary>
        /// SelectionForm Constructor
        /// Initialize all the form's elements
        /// Set the datasource for the Grid View and the data variable
        /// Set the size of the columns for the Griv View
        /// </summary>
        /// <param name="dt"></param>
        public SelectionForm(DataTable dt)
        {
            InitializeComponent();

            this.dataGV_Selection.DataSource = dt;
            this._data = dt;
            this.Selection = null;

            AutoSizeDataGV(this.dataGV_Selection, AutoSizeModes.Evenly);

            this.btn_Select.Select();
        }

        /// <summary>
        /// SelectionForm Constructor
        /// Initialize all the form's elements, set the specified title of the window
        /// Set the datasource for the Grid View and the data variable
        /// Set the size of the columns for the Griv View
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="title"></param>
        public SelectionForm(DataTable dt, string title)
        {
            InitializeComponent();

            this.Text = title;

            this.dataGV_Selection.DataSource = dt;
            this._data = dt;
            this.Selection = null;

            AutoSizeDataGV(this.dataGV_Selection, AutoSizeModes.Evenly);

            this.btn_Select.Select();
        }
        #endregion


        #region Properties
        // Row selected by the user. Set when the user clicks on the "Select" button
        public DataRow? Selection { get; set; }
        #endregion


        #region Variables
        private DataTable _data;
        #endregion


        #region EventHandlers
        /// <summary>
        /// btn_Select_Click Event Handler
        /// Triggered when the "Select" button is clicked
        /// Read the index of the row which is currently selected in the Grid View
        /// Set the Selection to this row in the datasource
        /// Set the DialogResult state to OK and close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int index = this.dataGV_Selection.CurrentRow.Index;
                this.Selection = this._data.Rows[index];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                var errorWin = new ErrorForm(Resources.String.NoRowSelectedErr);
                errorWin.ShowDialog();
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// AutoSizeDataGV Method
        /// Compute the size of each column of a Grid View depending on the mode
        /// The available modes are described in the Globals class
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="mode"></param>
        private static void AutoSizeDataGV(DataGridView dgv, AutoSizeModes mode)
        {
            switch (mode)
            {
                //For having auto sized columns and the first one filling the remaining place
                case AutoSizeModes.FirstFill:
                    for (int i = dgv.Columns.Count - 1; i >= 0; i--)
                    {
                        if (i > 0)
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                        }
                        else
                        {
                            dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                    break;

                //For having auto sized columns and the last one filling the remaining place
                case AutoSizeModes.LastFill:
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

                //For having auto sized columns in the available place.
                case AutoSizeModes.Evenly:
                    foreach (DataGridViewColumn dgvc in dgv.Columns)
                    {
                        dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    break;
            }

        }
        #endregion
    }
}
