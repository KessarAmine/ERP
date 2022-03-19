using System;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class SuiviMovementNew
    {
        public SuiviMovementNew()
        {
            InitializeComponent();
        }

        private void SuiviMovementNew_DataSourceDemanded(object sender, EventArgs e)
        {
            if (this.TypeReport.Value.ToString().Equals("0"))
            {
                this.EntreesHead.Visible = true;
                this.EntreesColumns.Visible = true;
                this.EntreesData.Visible = true;
                this.EntreesSum.Visible = true;

                this.SortiesHead.Visible = true;
                this.SortiesCollumns.Visible = true;
                this.SoritesData.Visible = true;
                this.SortiesSum.Visible = true;

            }
            if (this.TypeReport.Value.ToString().Equals("1"))
            {
                this.EntreesHead.Visible = true;
                this.EntreesColumns.Visible = true;
                this.EntreesData.Visible = true;
                this.EntreesSum.Visible = true;

                this.SortiesHead.Visible = false;
                this.SortiesCollumns.Visible = false;
                this.SoritesData.Visible = false;
                this.SortiesSum.Visible = false;
            }
            if (this.TypeReport.Value.ToString().Equals("2"))
            {
                this.EntreesHead.Visible = false;
                this.EntreesColumns.Visible = false;
                this.EntreesData.Visible = false;
                this.EntreesSum.Visible = false;

                this.SortiesHead.Visible = true;
                this.SortiesCollumns.Visible = true;
                this.SoritesData.Visible = true;
                this.SortiesSum.Visible = true;
            }

        }
    }
}
