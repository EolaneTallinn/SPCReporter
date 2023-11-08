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
    /// ErrorForm Class
    /// Form to signal an error to the user
    /// It supposed to be used as a dialog box, but no input required from the user, only acknowlegment
    /// The error message is customizable
    /// </summary>
    public partial class ErrorForm : Form
    {
        #region Constructors
        /// <summary>
        /// ErrorForm Constructor
        /// Initialize the form components and write the custom message
        /// </summary>
        /// <param name="error"></param>
        public ErrorForm(string error)
        {
            InitializeComponent();
            this.lbl_Error.Text = error;
        }
        #endregion


        #region Properties
        #endregion


        #region Variables
        #endregion


        #region EventHandlers
        /// <summary>
        /// btn_Ack_Click Event Handler
        /// Triggered when the "OK" button is clicked
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        #region Methods
        #endregion
    }
}
