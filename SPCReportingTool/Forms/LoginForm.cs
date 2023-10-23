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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string inputPassword = txtbx_Password.Text;
            string password = "I4m$PCEdit0r";

            if(inputPassword == password)
            {
                var selectionForm = new HeaderForm();
                selectionForm.Show();

                this.Close();
            }
            else
            {
                lbl_ErrMessage.Visible = true;
            }
        }
    }
}
