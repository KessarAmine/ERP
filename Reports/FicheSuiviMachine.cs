using System;
using DevExpress.XtraReports.UI;

namespace DevKbfSteel.Reports
{
    public partial class FicheSuiviMachine
    {
        public FicheSuiviMachine()
        {
            DevExpress.DataAccess.Sql.SqlDataSource.AllowCustomSqlQueries = true;
            DevExpress.DataAccess.Sql.SqlDataSource.DisableCustomQueryValidation = true;
            InitializeComponent();
        }

        private void FicheSuiviMachine_DataSourceDemanded(object sender, EventArgs e)
        {
            if (this.TypeReport.Value.ToString().Equals("0"))
            {
                if (this.ServiceCurrent.Value.ToString().Equals("0"))
                {
                    this.Global.Visible = true;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = false;
                }
                if (this.ServiceCurrent.Value.ToString().Equals("1"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = true;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = false;
                }
                if (this.ServiceCurrent.Value.ToString().Equals("2"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = true;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = false;
                }
            }
            if (this.TypeReport.Value.ToString().Equals("1"))
            {
                if (this.ServiceCurrent.Value.ToString().Equals("0"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = true;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = false;
                }
                if (this.ServiceCurrent.Value.ToString().Equals("1"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = true;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = false;
                }
                if (this.ServiceCurrent.Value.ToString().Equals("2"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = true;
                    this.CorretifElectrique.Visible = false;
                }
            }
            if (this.TypeReport.Value.ToString().Equals("2"))
            {
                if (this.ServiceCurrent.Value.ToString().Equals("0"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = true;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = false;
                }
                if (this.ServiceCurrent.Value.ToString().Equals("1"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = true;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = false;
                }
                if (this.ServiceCurrent.Value.ToString().Equals("2"))
                {
                    this.Global.Visible = false;
                    this.Preventif.Visible = false;
                    this.Correctif.Visible = false;

                    this.GlobalMecanique.Visible = false;
                    this.PreventifMecanique.Visible = false;
                    this.CorrectifMecanique.Visible = false;

                    this.GlobalElectrique.Visible = false;
                    this.PreventifElectrique.Visible = false;
                    this.CorretifElectrique.Visible = true;
                }
            }
        }
    }
}
