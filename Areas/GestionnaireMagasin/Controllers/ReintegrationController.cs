using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
using Microsoft.AspNetCore.Authorization;
using DevKbfSteel.Helpers;
using DevKbfSteel.Models;
using DevKbfSteel.Areas.GestionnaireMagasin.Models;

namespace DevKbfSteel.Areas.GestionnaireMagasin.Controllers
{
    [Area(nameof(Areas.GestionnaireMagasin))]

    public class ReintegrationController : Controller
    {
        private KBFsteelContext _context;
        public ReintegrationController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public object GetDechargee(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            List<RecapBillettesModel> RecapBillettesModelList = new List<RecapBillettesModel>();
            int NbrFdx = 0;
            int NbrPieces = 0;
            int NbrRot = 0;
            double Tonnage= 0.0;
            var StkReceptionBillette = _context.StkReceptionBillette
                .Where(c => c.DateReception.Date >= dateDebut.Date && c.DateReception.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumReception,
                    i.BilleteRecue,
                    i.Navire,
                    i.DateReception
                }).ToList();
            foreach (var itemStkReceptionBillette in StkReceptionBillette)
            {
                RecapBillettesModel RecapBillettesModel = new RecapBillettesModel();
                RecapBillettesModel.Date = itemStkReceptionBillette.DateReception;
                RecapBillettesModel.Navire = itemStkReceptionBillette.Navire;
                var StkRapportTransfertBillette = _context.StkRapportTransfertBillette
                .Where(c => c.DateTransfert.Date >= itemStkReceptionBillette.DateReception.Date && c.DateTransfert.Date <= itemStkReceptionBillette.DateReception.Date)
                .Select(i => new
                {
                    i.NumRapportTransfert
                }).ToList();
                if(StkRapportTransfertBillette.Count() > 0)
                {
                    var StkRapportTransfertBillettesDetails = _context.StkRapportTransfertBillettesDetails
                    .Where(c => c.NumRapportTransfert == StkRapportTransfertBillette.Last().NumRapportTransfert)
                    .Select(i => new {
                        i.Id
                    });
                    NbrRot = StkRapportTransfertBillettesDetails.Count();
                }

                RecapBillettesModel.NbrRotations = NbrRot;

                var StkReceptionBilletteDetails = _context.StkReceptionBilletteDetails
                .Where(c => c.NumReception == itemStkReceptionBillette.NumReception)
                .Select(i => new
                {
                    i.NbrFdx,
                    i.NbrPieces,
                    i.NetPoidTh
                }).ToList();
                foreach (var itemStkReceptionBilletteDetails in StkReceptionBilletteDetails)
                {
                    NbrFdx = NbrFdx + itemStkReceptionBilletteDetails.NbrFdx;
                    NbrPieces = NbrPieces + itemStkReceptionBilletteDetails.NbrPieces;
                    Tonnage = Tonnage + itemStkReceptionBilletteDetails.NetPoidTh;
                }

                RecapBillettesModel.NbrPieces = NbrPieces;
                RecapBillettesModel.NbrFdx = NbrFdx;
                RecapBillettesModel.Tonnage = Tonnage;
                RecapBillettesModelList.Add(RecapBillettesModel);
                NbrFdx = 0;
                NbrPieces = 0;
                NbrRot = 0;
                Tonnage = 0.0;
            }
            return DataSourceLoader.Load(RecapBillettesModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public async Task<IActionResult> GetReintegration(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkReintegration
                .Where(c => c.DateReingegration.Date >= dateDebut.Date && c.DateReingegration.Date <= dateFin.Date)
                .Select(i => new {
                    i.DateReingegration,
                    i.NumBonReintegration,
                    i.ServiceEmetteur,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetReintegrationDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperGestionnaireMagasin.NumReintegration = id;
            var StkAffectations = _context.StkReintegrationArticles
                .Where(c => c.NumBonReintegration == id)
                .Select(i => new {
                    i.Id,
                    i.DateReingegration,
                    i.CodeArticle,
                    i.Qte,
                    i.CodeIntervenant,
                    i.LieuDemande
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostReintegration(string values)
        {
            var model = new StkReintegration();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegration(model, valuesDict);
            var StkReintegration = _context.StkReintegration
                .OrderBy(o => o.NumBonReintegration)
                .Select(i => new
                {
                    i.NumBonReintegration
                }).ToList();

            if (StkReintegration.Count == 0)
                model.NumBonReintegration = 1;
            else
            {
                var m = StkReintegration.Last();
                model.NumBonReintegration = Convert.ToInt32(m.NumBonReintegration) + 1;
            }
            model.DateReingegration = DateTime.Now.Date;

            var result = _context.StkReintegration.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonReintegration);
        }
        [HttpPost]
        public async Task<IActionResult> PostReintegrationDetails(string values)
        {
            var model = new StkReintegrationArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegrationArticles(model, valuesDict);
            var StkReintegration = _context.StkReintegration
                .AsNoTracking()
                .Where(o => o.NumBonReintegration == XpertHelperGestionnaireMagasin.NumReintegration)
                .Select(i => new
                {
                    i.DateReingegration
                }).ToList();
            var StkReintegrationArticles = _context.StkReintegrationArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReintegrationArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReintegrationArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            if (StkReintegration.Count() > 0)
            {

                model.DateReingegration = StkReintegration.Last().DateReingegration;
                model.NumBonReintegration = XpertHelperGestionnaireMagasin.NumReintegration;
                //ADD This to movements
                var DateReingegration = _context.StkReintegration
                .AsNoTracking()
                .OrderBy(o => o.NumBonReintegration)
                .Where(c => c.NumBonReintegration == model.NumBonReintegration)
                .Select(i => new
                {
                    i.DateReingegration
                }).ToList();
                //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
                var StkMovements = _context.StkMovements
                .AsNoTracking()
                .OrderBy(o => o.IdMovement)
                .Where(c => c.CodePdr == model.CodeArticle)
                .Select(i => new
                {
                    i.IdMovement,
                    i.StockTotalSythese,
                    i.ValeurValorisation
                }).ToList();
                if (StkMovements.Count == 0)
                {
                    var StkStockInitial = _context.StkStockInitial
                    .AsNoTracking()
                    .OrderBy(o => o.Id)
                    .Where(c => c.CodePdr == model.CodeArticle)
                    .Select(i => new
                    {
                        i.Id,
                        i.Qte,
                        i.PrixUnitare
                    }).ToList();
                    //If there is no stockInitial Erreur else we compute normally
                    if (StkStockInitial.Count == 0)
                    {
                        return StatusCode(409, "La Pdr : " + model.CodeArticle + " n'as pas de stock initial");
                    }
                    else
                    {
                        // We check if there is enough quantite
                        if (StkStockInitial.Last().Qte < model.Qte)
                        {
                            return StatusCode(409, "La Qte : " + model.Qte + " surpass la quantité disponible");
                        }
                        else
                        {
                            // There is enough quantite
                            // We check if this article doesnt have Valorisation Methode
                            var pdrValorisation = _context.StkPdr
                            .AsNoTracking()
                            .OrderBy(o => o.CodePdr)
                            .Where(c => c.CodePdr == model.CodeArticle)
                            .Select(i => new
                            {
                                i.TypeValorisation
                            }).ToList();
                            // Each PDR must have TypeValorisation
                            if (pdrValorisation.Count == 0 || pdrValorisation.Last().TypeValorisation == null)
                            {
                                return StatusCode(409, "La Pdr : " + model.CodeArticle + " n'as pas de type de valorisation");
                            }
                            else
                            {
                                model.PrixUnitaire = StkStockInitial.Last().PrixUnitare;
                                model.Montant = Math.Round((double)(model.PrixUnitaire * model.Qte), 2);
                                //Adding  to movement
                                StkMovements movement = new StkMovements();
                                movement.PrixUnitaire = (double)model.PrixUnitaire;
                                movement.Montant = (double)model.Montant;
                                movement.CodePdr = model.CodeArticle;
                                movement.DateMovment = DateReingegration.Last().DateReingegration;
                                movement.Qte = model.Qte;
                                movement.TypeMovement = 6;// 6 pour les Réintegration
                                movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                                movement.IdDetail = model.Id;
                                ComputeValorisation(movement, 1);// There is no mouvements
                                var resultmovement = _context.StkMovements.Add(movement);
                            }
                        }
                    }
                }
                else
                {
                    var pdrValorisation = _context.StkPdr
                    .AsNoTracking()
                    .OrderBy(o => o.CodePdr)
                    .Where(c => c.CodePdr == model.CodeArticle)
                    .Select(i => new
                    {
                        i.TypeValorisation
                    }).ToList();
                    // Each PDR must have TypeValorisation
                    if (pdrValorisation.Count == 0)
                    {
                        return StatusCode(409, "La Pdr : " + model.CodeArticle + " n'as plus de type de valorisation");
                    }
                    else
                    {

                        model.PrixUnitaire = StkMovements.Last().ValeurValorisation;
                        model.Montant = Math.Round((double)(model.PrixUnitaire * model.Qte), 2);
                        // There is TypeValorisation and there is stockInitial we compute
                        var MethodeValorisation = _context.StkTypeValorisation
                                .AsNoTracking()
                                .OrderBy(o => o.CodeValorisation)
                                .Where(c => c.CodeValorisation == pdrValorisation.Last().TypeValorisation)
                                .Select(i => new
                                {
                                    i.DesignationValorisation
                                }).ToList();
                        // There is valorisation methode
                        // Adding sorite to movement
                        StkMovements movement = new StkMovements();
                        movement.PrixUnitaire = (double)model.PrixUnitaire;
                        movement.Montant = (double)model.Montant;
                        movement.CodePdr = model.CodeArticle;
                        movement.DateMovment = DateReingegration.Last().DateReingegration;
                        movement.Qte = model.Qte;
                        movement.TypeMovement = 6;// 6 pour les Réintegration
                        movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                        movement.IdDetail = model.Id;
                        ComputeValorisation(movement, 2);// There is mouvements
                        var resultmovement = _context.StkMovements.Add(movement);
                    }
                }
            }
            else
            {
                return StatusCode(409, "La Réintegration N° saise  : " + model.NumBonReintegration + " est introuvable");
            }
            var result = _context.StkReintegrationArticles.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutReintegration(int key, string values)
        {
            var model = await _context.StkReintegration.FirstOrDefaultAsync(item => item.NumBonReintegration == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegration(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutReintegrationDetails(int key, string values)
        {
            var model = await _context.StkReintegrationArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var oldQte = model.Qte;
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegrationArticles(model, valuesDict);
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 6);
            modelMovement.Qte = model.Qte;
            if ((modelMovement.StockTotalSythese - oldQte) + model.Qte < 0)
            {
                return StatusCode(409, "Cette Quantité : " + model.Qte + " n'est pas disponnible, il reste : " + modelMovement.StockTotalSythese);
            }
            modelMovement.StockTotalSythese = (modelMovement.StockTotalSythese - oldQte) + model.Qte;
            modelMovement.ValeurStockTotal = (modelMovement.ValeurStockTotal - (oldQte * modelMovement.PrixUnitaire)) + (model.Qte * modelMovement.PrixUnitaire);
            modelMovement.ValeurValorisation = Math.Round((double)(modelMovement.ValeurStockTotal / modelMovement.StockTotalSythese), 2);
            _context.StkMovements.Update(modelMovement);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteReintegration(int key)
        {
            var model = await _context.StkReintegration.FirstOrDefaultAsync(item => item.NumBonReintegration == key);
            _context.StkReintegration.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteReintegrationDetails(int key)
        {
            var model = await _context.StkReintegrationArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkReintegrationArticles.Remove(model);
            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 6);
            _context.StkMovements.Remove(modelMovement);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> EmployeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
        private void PopulateModelReintegration(StkReintegration model, IDictionary values)
        {
            string DateReingegration = nameof(StkReintegration.DateReingegration);
            string ServiceEmetteur = nameof(StkReintegration.ServiceEmetteur);
            string CodeIntervenant = nameof(StkReintegration.CodeIntervenant);
            if (values.Contains(DateReingegration))
            {
                model.DateReingegration = Convert.ToDateTime(values[DateReingegration]);
            }
            if (values.Contains(ServiceEmetteur))
            {
                model.ServiceEmetteur = Convert.ToInt32(values[ServiceEmetteur]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
        }
        private void PopulateModelReintegrationArticles(StkReintegrationArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkReintegrationArticles.CodeArticle);
            string Qte = nameof(StkReintegrationArticles.Qte);
            string CodeIntervenant = nameof(StkReintegrationArticles.CodeIntervenant); 
            string LieuDemande = nameof(StkReintegrationArticles.LieuDemande); 
            string DateReingegration = nameof(StkReintegrationArticles.DateReingegration); 
            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(CodeIntervenant))
            {
                var CodePdrvar = values[CodeIntervenant];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeIntervenant = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(DateReingegration))
            {
                model.DateReingegration = Convert.ToDateTime(values[DateReingegration]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(LieuDemande))
            {
                model.LieuDemande = Convert.ToString(values[LieuDemande]);
            }
        }
        public void ComputeValorisation(StkMovements model, int Case)
        {
            model.StockTotalSythese = model.Qte;
            model.ValeurStockTotal = model.Montant;
            //if case = 1 we compute from stockInitial 
            if (Case == 1)
            {
                var StkStockInitial = _context.StkStockInitial
                    .OrderBy(o => o.Id)
                    .Where(c => c.CodePdr == model.CodePdr)
                    .Select(i => new
                    {
                        i.Id,
                        i.Qte,
                        i.PrixUnitare
                    }).ToList();

                model.StockTotalSythese += StkStockInitial.Last().Qte;
                model.ValeurStockTotal += Math.Round((double)(StkStockInitial.Last().PrixUnitare * StkStockInitial.Last().Qte), 2);
            }
            //If case = 2 we get last movement
            if (Case == 2)
            {
                var StkMovements = _context.StkMovements
                .OrderBy(o => o.IdMovement)
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment.Date <= model.DateMovment.Date)
                .Select(i => new
                {
                    i.IdMovement,
                    i.StockTotalSythese,
                    i.ValeurStockTotal
                }).ToList();
                model.StockTotalSythese += StkMovements.Last().StockTotalSythese;
                model.ValeurStockTotal += Math.Round((double)(StkMovements.Last().ValeurStockTotal), 2);
            }
            model.ValeurValorisation = Math.Round((double)(model.ValeurStockTotal / model.StockTotalSythese), 2);
        }

    }
}
