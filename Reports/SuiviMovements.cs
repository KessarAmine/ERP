using System;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class SuiviMovements
    {
        public SuiviMovements()
        {
            InitializeComponent();
        }

        private void SuiviMovements_DataSourceDemanded(object sender, EventArgs e)
        {
            if (this.TypeReport.Value.ToString().Equals("0"))
            {
                this.EntreesHead.Visible = true;
                this.EntreeColumns.Visible = true;
                this.EntreeData.Visible = true;

                this.SortiesHead.Visible = true;
                this.SortiesColumns.Visible = true;
                this.SortiesData.Visible = true;

            }
            if (this.TypeReport.Value.ToString().Equals("1"))
            {
                this.EntreesHead.Visible = true;
                this.EntreeColumns.Visible = true;
                this.EntreeData.Visible = true;

                this.SortiesHead.Visible = false;
                this.SortiesColumns.Visible = false;
                this.SortiesData.Visible = false;
            }
            if (this.TypeReport.Value.ToString().Equals("2"))
            {
                this.EntreesHead.Visible = false;
                this.EntreeColumns.Visible = false;
                this.EntreeData.Visible = false;

                this.SortiesHead.Visible = true;
                this.SortiesColumns.Visible = true;
                this.SortiesData.Visible = true;
            }
            if (this.Complexite.Value.ToString().Equals("0"))
            {
                this.EntreeDetailColumns.Visible = false;
                this.EntressDetailsData.Visible = false;

                this.SortiesDetailsColumns.Visible = false;
                this.SortiesDetailsData.Visible = false;

            }
            if (this.Complexite.Value.ToString().Equals("1"))
            {
                if (this.TypeReport.Value.ToString().Equals("0"))
                {
                    this.EntreeDetailColumns.Visible = true;
                    this.EntressDetailsData.Visible = true;

                    this.SortiesDetailsColumns.Visible = true;
                    this.SortiesDetailsData.Visible = true;
                }
                if (this.TypeReport.Value.ToString().Equals("1"))
                {
                    this.EntreeDetailColumns.Visible = true;
                    this.EntressDetailsData.Visible = true;
                    this.SortiesDetailsColumns.Visible = false;
                    this.SortiesDetailsData.Visible = false;
                }
                if (this.TypeReport.Value.ToString().Equals("2"))
                {
                    this.EntreeDetailColumns.Visible = false;
                    this.EntressDetailsData.Visible = false;
                    this.SortiesDetailsColumns.Visible = true;
                    this.SortiesDetailsData.Visible = true;
                }
            }

        }
    }
}
