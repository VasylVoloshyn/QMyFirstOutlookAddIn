using Outlook = Microsoft.Office.Interop.Outlook;

namespace QMyFirstOutlookAddIn
{
    public partial class ThisAddIn
    {

        public QLogging Logger { get; set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Logger = new QLogging();
            Logger.StartLog();

            ((Outlook.ApplicationEvents_11_Event)Application).Quit += ThisAddIn_Quit;
        }

        private void ThisAddIn_Quit()
        {
            Logger.EndLog();
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            
                return Globals.Factory.GetRibbonFactory().CreateRibbonManager(
                    new Microsoft.Office.Tools.Ribbon.IRibbonExtension[] { new QMyFirstOutlookRibbon() });
            
        }

       
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);            
        }
        
        #endregion
    }
}
