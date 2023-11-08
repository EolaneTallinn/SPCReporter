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
    /// ConfirmationForm Class
    /// Form which ask the confirmation of the user when some actions are performed.
    /// This is supposed to be used as a dialog box called by another form.
    /// <remark>
    /// The confirmation message is customizable
    /// </remark>
    /// </summary>
    public partial class ConfirmationForm : Form
    {
        #region Constructors
        /// <summary>
        /// ConfrimationForm constructor
        /// Initialize the form components and setup the confirmation message
        /// </summary>
        /// <param name="confirmMessage"></param>
        public ConfirmationForm(string confirmMessage)
        {
            InitializeComponent();
            this.lbl_ConfirmMsg.Text = confirmMessage;
        }
        #endregion


        #region Properties
        #endregion


        #region Variables
        #endregion


        #region EventHandlers
        /// <summary>
        /// btn_Confirm_Click event handler
        /// Triggered when the "Confirm" button is clicked
        /// It will put the DialogResult to OK state and will close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {

            }
        }


        /// <summary>
        /// btn_Cancel_Click event handler
        /// Triggered when the "Cancel" button is clicked
        /// It will put the DialogResult to Cancel state and will close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch
            {

            }
        }
        #endregion


        #region Methods
        #endregion
    }
}
