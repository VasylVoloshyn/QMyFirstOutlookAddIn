using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;

namespace QMyFirstOutlookAddIn
{
    public partial class QMyFirstOutlookRibbon
    {        
        private QCalcPrimeNumber calculate = new QCalcPrimeNumber();
        private QlogInfo logInfo = new QlogInfo();
        
        private async void QMyFirstOutlookRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            await calculate.CalculatePrimeNumberAsync(Rand.rand().ToInt32());
        }

        private void QMyButton_Click(object sender, RibbonControlEventArgs e)
        {
            logInfo = calculate.LogInfo;

            var item = e.Control.Context as Inspector;
            var mailItem = item.CurrentItem as MailItem;

            if (mailItem != null)
            {
                if (mailItem.EntryID == null)
                {
                    string CurrentMail = mailItem.Body.ToString();
                    Globals.ThisAddIn.Logger.LogData(logInfo);
                    mailItem.Body = "Prime Number = " + logInfo.PrimeNumber.ToString() + " " + CurrentMail;
                }
            }
        }
    }
}
