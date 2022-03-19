using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class JourneeProduction
    {
        public JourneeProduction()
        {
            CadenceProductionJournee = new HashSet<CadenceProductionJournee>();
        }

        public int NumRapport { get; set; }
        public DateTime Date { get; set; }
        public int Poste { get; set; }
        public int NumBon { get; set; }
        public int OperateurPcp { get; set; }
        public int ChefPoste { get; set; }
        public int IngProcess { get; set; }
        public string DimProduitFini { get; set; }
        public string DimProduitConforme { get; set; }
        public string DimBillete { get; set; }
        public string LongBillete { get; set; }
        public int? NbrCisaille { get; set; }
        public int? NbrExpulsee { get; set; }
        public int? NbrRealisee { get; set; }
        public int? NbrDefourne { get; set; }
        public int? NumRapportPreparation { get; set; }
        public int? NbrFardeaux { get; set; }
        public string Note { get; set; }
        public double? ParGrpInter2Dcl { get; set; }
        public double? ParGrpInter3Dcl { get; set; }
        public double? ParGrpInter4Dcl { get; set; }
        public double? ParGrpInter5Dcl { get; set; }
        public double? ParGrpFin67Dcl { get; set; }
        public double? ParGrpFin8Dcl { get; set; }
        public double? ParGrpFin9Dcl { get; set; }
        public double? ParGrpFin10Dcl { get; set; }
        public double? ParGrpFin11Dcl { get; set; }
        public double? ParGrpFin12Dcl { get; set; }
        public double? ParGrpFin13Dcl { get; set; }
        public double? ParGrpInter2Mvr { get; set; }
        public double? ParGrpInter3Mvr { get; set; }
        public double? ParGrpInter4Mvr { get; set; }
        public double? ParGrpInter5Mvr { get; set; }
        public double? ParGrpFin67Mvr { get; set; }
        public double? ParGrpFin8Mvr { get; set; }
        public double? ParGrpFin9Mvr { get; set; }
        public double? ParGrpFin10Mvr { get; set; }
        public double? ParGrpFin11Mvr { get; set; }
        public double? ParGrpFin12Mvr { get; set; }
        public double? ParGrpFin13Mvr { get; set; }
        public double? ParGrpInter2Vl { get; set; }
        public double? ParGrpInter3Vl { get; set; }
        public double? ParGrpInter4Vl { get; set; }
        public double? ParGrpInter5Vl { get; set; }
        public double? ParGrpFin67Vl { get; set; }
        public double? ParGrpFin8Vl { get; set; }
        public double? ParGrpFin9Vl { get; set; }
        public double? ParGrpFin10Vl { get; set; }
        public double? ParGrpFin11Vl { get; set; }
        public double? ParGrpFin12Vl { get; set; }
        public double? ParGrpFin13Vl { get; set; }
        public double? ParGrpInter2A { get; set; }
        public double? ParGrpInter3A { get; set; }
        public double? ParGrpInter4A { get; set; }
        public double? ParGrpInter5A { get; set; }
        public double? ParGrpFin67A { get; set; }
        public double? ParGrpFin8A { get; set; }
        public double? ParGrpFin9A { get; set; }
        public double? ParGrpFin10A { get; set; }
        public double? ParGrpFin11A { get; set; }
        public double? ParGrpFin12A { get; set; }
        public double? ParGrpFin13A { get; set; }
        public double? ParVmcv { get; set; }
        public double? ParLpb { get; set; }
        public double? ParLbn { get; set; }
        public double? ParLbf { get; set; }
        public string ParCm { get; set; }
        public double? ParVmce5 { get; set; }
        public double? ParLt { get; set; }
        public double? ParLq { get; set; }
        public double? ParRpm1 { get; set; }
        public double? ParRmp2 { get; set; }
        public double? ParRmp3 { get; set; }
        public double? ParDcl { get; set; }
        public double? ParP1a { get; set; }
        public double? ParP2a { get; set; }
        public double? ParP3a { get; set; }
        public double? ParP4a { get; set; }
        public double? ParP5a { get; set; }

        public virtual ICollection<CadenceProductionJournee> CadenceProductionJournee { get; set; }
    }
}
