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
    /// LoginForm Class
    /// Form which is asking for a password
    /// This password is then encrypted with MD5 and will be compared to the value stored in the SPCReport Database
    /// The form is supposed to be called as a dialog box
    /// </summary>
    public partial class LoginForm : Form
    {
        #region Constructors
        /// <summary>
        /// LoginForm Constructor
        /// Initialize the form's elements and select the password text box so that the user can directly type in
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            this.txtbx_Password.Select();
        }
        #endregion


        #region Properties
        #endregion


        #region Variables
        #endregion


        #region EventHandlers
        /// <summary>
        /// btn_Login_Click Event Handler
        /// Triggered when the "Login" button is clicked
        /// Read the password entered by the user, get the MD5 hash of this password and send it to the Database for login validation
        /// If the password is correct the DialogResult state is OK and the form is closed
        /// If the password is not correct, the error message is displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string inputPassword = this.txtbx_Password.Text;
            string md5Hash = CreateMD5(inputPassword);

            int loginRequestResult = DatabaseManager.RequestLogin(md5Hash);

            if (loginRequestResult == 1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.lbl_ErrMessage.Visible = true;
            }
        }
        #endregion


        #region Methods
        /// <summary>
        /// CreateMD5 Method
        /// Compute the MD5 hash from a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// Computed MD5 hash
        /// </returns>
        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

                // Convert the byte array to hexadecimal string prior to .NET 5
                // StringBuilder sb = new System.Text.StringBuilder();
                // for (int i = 0; i < hashBytes.Length; i++)
                // {
                //     sb.Append(hashBytes[i].ToString("X2"));
                // }
                // return sb.ToString();
            }
        }
        #endregion
    }
}
