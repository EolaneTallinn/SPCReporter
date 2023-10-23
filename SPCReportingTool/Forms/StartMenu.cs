namespace SPCReportingTool.Forms
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_NewReport_Click(object sender, EventArgs e)
        {
            var headerForm = new HeaderForm();
            headerForm.Show();
            //this.close();
        }

        private void btn_EditReport_Click(object sender, EventArgs e)
        {
            var loginForm = new ViewReportsForm();
            loginForm.Show();
            //this.close();
        }

        private void btn_ChangeLanguage_Click(object sender, EventArgs e)
        {

        }
    }
}