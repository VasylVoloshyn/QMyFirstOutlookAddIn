namespace QMyFirstOutlookAddIn
{
    partial class QMyFirstOutlookRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public QMyFirstOutlookRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QMyNewTab = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.QMyButton = this.Factory.CreateRibbonButton();
            this.QMyNewTab.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QMyNewTab
            // 
            this.QMyNewTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.QMyNewTab.Groups.Add(this.group1);
            this.QMyNewTab.Label = "My First Tab";
            this.QMyNewTab.Name = "QMyNewTab";
            // 
            // group1
            // 
            this.group1.Items.Add(this.QMyButton);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // QMyButton
            // 
            this.QMyButton.Label = "My First Button";
            this.QMyButton.Name = "QMyButton";
            this.QMyButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.QMyButton_Click);
            // 
            // QMyFirstOutlookRibbon
            // 
            this.Name = "QMyFirstOutlookRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.QMyNewTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.QMyFirstOutlookRibbon_Load);
            this.QMyNewTab.ResumeLayout(false);
            this.QMyNewTab.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab QMyNewTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton QMyButton;
    }

    partial class ThisRibbonCollection
    {
        internal QMyFirstOutlookRibbon QMyFirstOutlookRibbon
        {
            get { return this.GetRibbon<QMyFirstOutlookRibbon>(); }
        }
    }
}
