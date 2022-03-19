using System;
using System.IO;
using System.Linq;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraReports.UI;
using DevKbfSteel.Entities;

namespace DevKbfSteel.Reports
{
    public partial class RaportOrdreTravail
    {
        private KBFsteelContext _context;
        public RaportOrdreTravail()
        {
            InitializeComponent();
            _context = new KBFsteelContext();
        }
        private void RaportOrdreTravail_DataSourceDemanded(object sender, EventArgs e)
        {
            var ordres = _context.OrdreTravail
            .Where(o => o.NumOt == Convert.ToInt32(this.Num_Ot.Value.ToString()))
            .Select(i => new
            {
                i.CodeDemandeur
            }).ToList();
            var Responsable = _context.Structure
            .Where(o => o.CodeStructure == ordres.Last().CodeDemandeur).Select(i => new
            {
                i.Responsable
            }).ToList();
            var Visa = _context.GrhNumericVisas
            .Where(o => o.Responsable == Responsable.Last().Responsable).Select(i => new
            {
                i.VisaPath
            }).ToList();
            //UpdatePicture
            this.SignatureBox.ImageSource = ImageSource.FromFile(Visa.Last().VisaPath);
        }
    }
}