using System;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class SuiviMovementsServices
    {
        public SuiviMovementsServices()
        {
            InitializeComponent();
        }

        private void SuiviMovementsServices_DataSourceDemanded(object sender, EventArgs e)
        {
            if (this.NatureArticles.Value.ToString().Equals("0"))
            {
                this.Gere.Visible = true;
                this.NonGere.Visible = false;
                this.General.Visible = false;
            }
            if (this.NatureArticles.Value.ToString().Equals("1"))
            {
                this.Gere.Visible = false;
                this.NonGere.Visible = true;
                this.General.Visible = false;
            }
            if (this.NatureArticles.Value.ToString().Equals("2"))
            {
                this.Gere.Visible = false;
                this.NonGere.Visible = false;
                this.General.Visible = true;
            }
        }
    }
}
