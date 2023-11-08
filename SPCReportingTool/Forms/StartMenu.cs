using SPCReportingTool.Classes;

namespace SPCReportingTool.Forms
{
    /// <summary>
    /// StartMenu Class
    /// Form which is the starting point of the application.
    /// From this form, you can open either the new report form or open the View form.
    /// In the future, it will also be possible to change the language of the app from this form
    /// </summary>
    public partial class StartMenu : Form
    {
        #region Constructors
        /// <summary>
        /// StartMenu Constructor
        /// Initialize all the form's components
        /// Set the start position in the center of the screen
        /// </summary>
        public StartMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion


        #region Properties
        #endregion


        #region Variables
        #endregion


        #region EventHandlers
        /// <summary>
        /// btn_NewReport_Click Event Handler
        /// Triggered when the "New Report" button is cliked
        /// Open a new Header Form for report creation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_NewReport_Click(object sender, EventArgs e)
        {
            var headerForm = new HeaderForm();
            headerForm.Show();
        }

        /// <summary>
        /// btn_ViewReports_Click Event Handler
        /// Triggered when the "View Reports" button is cliked
        /// Open a new Viewing Form for report review
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ViewReports_Click(object sender, EventArgs e)
        {
            var loginForm = new ViewReportsForm();
            loginForm.Show();
        }

        /// <summary>
        /// btn_ChangeLanguage_Click Event Handler
        /// Triggered when the "New Report" button is cliked
        /// /!\ NOT IMPLEMENTED YET /!\
        /// Will change the language from English to Russian
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ChangeLanguage_Click(object sender, EventArgs e)
        {
            if (Globals.englishMode)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
                Globals.englishMode = false;
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                Globals.englishMode = true;
            }

            this.Controls.Clear();
            InitializeComponent();
        }
        #endregion


        #region Methods
        #endregion
    }
}