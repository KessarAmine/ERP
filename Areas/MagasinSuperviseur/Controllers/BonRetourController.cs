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
using DevKbfSteel.Areas.MagasinSuperviseur.Models;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Controllers
{
    [Area(nameof(Areas.MagasinSuperviseur))]

    public class BonRetourController : Controller
    {
        private KBFsteelContext _context;
        public BonRetourController(KBFsteelContext context)
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
        public async Task<IActionResult> GetBonRetour(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.SrkBonRetour
                .Where(c => c.DateRetour.Date >= dateDebut.Date && c.DateRetour.Date <= dateFin.Date)
                .Select(i => new {
                    i.CodeFournisseur,
                    i.DateRetour,
                    i.NumBonEntree,
                    i.NumBonRetour,
                    i.CodeIntervenant,
                    i.DateLivrason
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetBonRetourDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperMagasinSuperviseur.NumBonRetour = id;
            var StkAffectations = _context.StkBonRetourArticles
                .Where(c => c.NumBonRetour == id)
                .Select(i => new {
                    i.Id,
                    i.DateRetour,
                    i.CodeArticle,
                    i.Qte,
                    i.PrixUnitaire,
                    i.Montant,
                    i.MotifRetour
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostBonRetour(string values)
        {
            var model = new SrkBonRetour();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetour(model, valuesDict);
            var SrkBonRetour = _context.SrkBonRetour
                .OrderBy(o => o.NumBonRetour)
                .Select(i => new
                {
                    i.NumBonRetour
                }).ToList();

            if (SrkBonRetour.Count == 0)
                model.NumBonRetour = 1;
            else
            {
                var m = SrkBonRetour.Last();
                model.NumBonRetour = Convert.ToInt32(m.NumBonRetour) + 1;
            }
            //model.DateRetour = DateTime.Now.Date;
            var StkBonEntree = _context.StkBonEntree
            .Where(o => o.NumBon == model.NumBonEntree)
            .Select(i => new
            {
                i.DateEntree
            }).ToList();
            if (StkBonEntree.Count() <= 0)
            {
                return StatusCode(409, "La BE N° : " + model.NumBonEntree + " est introuvable");
            }
            var result = _context.SrkBonRetour.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonRetour);
        }
        [HttpPost]
        public async Task<IActionResult> PostBonRetourDetails(string values)
        {
            var model = new StkBonRetourArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetourArticles(model, valuesDict);
            var StkBonRetourArticles = _context.StkBonRetourArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();
            var SrkBonRetour = _context.SrkBonRetour
                .AsNoTracking()
                .Where(o => o.NumBonRetour == XpertHelperMagasinSuperviseur.NumBonRetour)
                .Select(i => new
                {
                    i.DateRetour
                }).ToList();

            if (StkBonRetourArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkBonRetourArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            if (SrkBonRetour.Count() > 0)
            {

                model.DateRetour = SrkBonRetour.Last().DateRetour;
                model.NumBonRetour = XpertHelperMagasinSuperviseur.NumBonRetour;
                //AFF THIS TO MOVEMENTS
                var DateRetour = _context.SrkBonRetour
                .AsNoTracking()
                .OrderBy(o => o.NumBonRetour)
                .Where(c => c.NumBonRetour == model.NumBonRetour)
                .Select(i => new
                {
                    i.DateRetour
                }).ToList();
                //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
                var StkMovements = _context.StkMovements
                .AsNoTracking()
                .OrderBy(o => o.DateMovment)
                .Where(c => c.CodePdr == model.CodeArticle && c.DateMovment <= model.DateRetour)
                .Select(i => new
                {
                    i.IdMovement,
                    i.PrixUnitaire,
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
                                movement.CodePdr = model.CodeArticle;
                                movement.DateMovment = DateRetour.Last().DateRetour;
                                movement.Qte = model.Qte;
                                movement.TypeMovement = 8;
                                movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                                movement.IdDetail = model.Id;
                                ComputeValorisation(movement, 1);// There is no mouvements
                            }
                        }
                    }
                }
                else
                {
                    //Chek if there is enough
                    if (StkMovements.Last().StockTotalSythese - model.Qte < 0)
                    {
                        return StatusCode(409, "La Quantité saise  : " + model.Qte + " est (supérieur/égale) à la quantité disponnible (" + StkMovements.Last().StockTotalSythese + ")");
                    }
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
                        model.PrixUnitaire = StkMovements.Last().PrixUnitaire;
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
                        movement.CodePdr = model.CodeArticle;
                        movement.DateMovment = DateRetour.Last().DateRetour;
                        movement.Qte = model.Qte;
                        movement.TypeMovement = 8;
                        movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                        movement.IdDetail = model.Id;
                        ComputeValorisation(movement, 2);// There is mouvements
                    }
                }
            }
            else
            {
                return StatusCode(409, "Le Retour N° : " + model.NumBonRetour + " est introuvable");
            }
            var result = _context.StkBonRetourArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutBonRetour(int key, string values)
        {
            var model = await _context.SrkBonRetour.FirstOrDefaultAsync(item => item.NumBonRetour == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetour(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutBonRetourDetails(int key, string values)
        {
            var model = await _context.StkBonRetourArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var oldQte = model.Qte;
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetourArticles(model, valuesDict);
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 8);
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
        public async Task<IActionResult> DeleteBonRetour(int key)
        {
            var model = await _context.SrkBonRetour.FirstOrDefaultAsync(item => item.NumBonRetour == key);
            var details = _context.StkBonRetourArticles.Where(item => item.NumBonRetour == key).ToList();
            if (details.Count > 0)
                return StatusCode(409, "Non autorisé : vueillez suprimmer les détails avant");
            _context.SrkBonRetour.Remove(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteBonRetourDetails(int key)
        {
            var model = await _context.StkBonRetourArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkBonRetourArticles.Remove(model);
            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 8);
            _context.StkMovements.Remove(modelMovement);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================

        //=================================================PopulateModels===================================
        private void PopulateModelBonRetour(SrkBonRetour model, IDictionary values)
        {
            string CodeFournisseur = nameof(SrkBonRetour.CodeFournisseur);
            string DateRetour = nameof(SrkBonRetour.DateRetour);
            string NumBonEntree = nameof(SrkBonRetour.NumBonEntree);
            string CodeIntervenant = nameof(SrkBonRetour.CodeIntervenant);
            string DateLivrason = nameof(SrkBonRetour.DateLivrason);
            if (values.Contains(DateLivrason))
            {
                model.DateLivrason = Convert.ToDateTime(values[DateLivrason]);
            }
            if (values.Contains(DateRetour))
            {
                model.DateRetour = Convert.ToDateTime(values[DateRetour]);
            }
            if (values.Contains(CodeFournisseur))
            {
                model.CodeFournisseur = Convert.ToString(values[CodeFournisseur]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
            if (values.Contains(NumBonEntree))
            {
                model.NumBonEntree = Convert.ToInt32(values[NumBonEntree]);
            }
        }
        private void PopulateModelBonRetourArticles(StkBonRetourArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkBonRetourArticles.CodeArticle);
            string Qte = nameof(StkBonRetourArticles.Qte);
            string MotifRetour = nameof(StkBonRetourArticles.MotifRetour); 
            string PrixUnitaire = nameof(StkBonRetourArticles.PrixUnitaire);
            string DateRetour = nameof(StkBonRetourArticles.DateRetour);
            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToDouble(values[Qte]);
            }
            if (values.Contains(DateRetour))
            {
                model.DateRetour = Convert.ToDateTime(values[DateRetour]);
            }
            if (values.Contains(MotifRetour))
            {
                model.MotifRetour = Convert.ToString(values[MotifRetour]);
            }
            if (values.Contains(PrixUnitaire))
            {
                model.PrixUnitaire = Convert.ToDouble(values[PrixUnitaire]);
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
                // in Sortie PU becomes Valeur de Valorisation
                model.PrixUnitaire = (double)StkStockInitial.Last().PrixUnitare;
                model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
                model.StockTotalSythese = StkStockInitial.Last().Qte - model.StockTotalSythese;
                model.ValeurValorisation = Math.Round(StkStockInitial.Last().PrixUnitare, 2);
                model.ValeurStockTotal = model.ValeurValorisation * model.StockTotalSythese;
                var resultmovement = _context.StkMovements.Add(model);
                _context.SaveChanges();
                //we saved the changes now we upate all movements that were afeter this movement QTE and CMUP
                var after = _context.StkMovements
                .AsNoTracking()
                .OrderBy(o => o.DateMovment)
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment > model.DateMovment)
                .Select(i => new
                {
                    i.IdMovement,
                    i.Qte,
                    i.StockTotalSythese,
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                }).ToList();
                if (after.Count > 0)
                {
                    // update model
                    // get mvts after model 
                    // update current model
                    // at first previous mvt is our model
                    // update our current
                    // set previous to current
                    StkMovements previousUpdatedMvt = model;
                    foreach (var itemafter in after)
                    {
                        // 56 + 60 = 118 => 118 - 32 = ...
                        // 56 - 32 = 26 => 26 + 60 = 86
                        // previous model(sortie, 32 , 26)
                        // current (entree, 60,118)
                        // updatedcurrent (entree, 60 ,86)
                        // set previous to current
                        var current = _context.StkMovements.Where(c => c.IdMovement == itemafter.IdMovement).FirstOrDefault();
                        if (current.TypeMovement == 2 || current.TypeMovement == 6 || current.TypeMovement == 7)//entree || reintegration || restitution
                        {
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese + current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal + current.Montant;
                            current.ValeurValorisation = Math.Round(current.ValeurStockTotal / current.StockTotalSythese, 2);
                        }
                        if (current.TypeMovement == 3 || current.TypeMovement == 4 || current.TypeMovement == 5)// sortie || affectation || decharge
                        {
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese - current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal - current.Montant;
                            current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                        }
                        if (current.TypeMovement == 8)// retour
                        {
                            current.PrixUnitaire = previousUpdatedMvt.PrixUnitaire;
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese - current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal - current.Montant;
                            current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                        }
                        _context.StkMovements.Update(current);
                        _context.SaveChanges();
                        previousUpdatedMvt = current;
                    }
                }
            }
            //If case = 2 we get last movement
            if (Case == 2)
            {
                var StkMovements = _context.StkMovements
                .OrderBy(o => o.DateMovment)
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment <= model.DateMovment)
                .Select(i => new
                {
                    i.IdMovement,
                    i.PrixUnitaire,
                    i.StockTotalSythese,
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                }).ToList();
                // in Sortie PU becomes Valeur de Valorisation
                model.PrixUnitaire = (double)StkMovements.Last().PrixUnitaire;
                model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
                model.ValeurValorisation = Math.Round((double)StkMovements.Last().ValeurValorisation, 2);
                model.StockTotalSythese = StkMovements.Last().StockTotalSythese - model.StockTotalSythese;
                model.ValeurStockTotal = model.StockTotalSythese * model.ValeurValorisation;
                //UPDATES HERE
                var resultmovement = _context.StkMovements.Add(model);
                _context.SaveChanges();
                //we saved the changes now we upate all movements that were afeter this movement QTE and CMUP
                var after = _context.StkMovements
                .AsNoTracking()
                .OrderBy(o => o.DateMovment)
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment > model.DateMovment)
                .Select(i => new
                {
                    i.IdMovement,
                    i.Qte,
                    i.StockTotalSythese,
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                }).ToList();
                if (after.Count > 0)
                {
                    // update model
                    // get mvts after model 
                    // update current model
                    // at first previous mvt is our model
                    // update our current
                    // set previous to current
                    StkMovements previousUpdatedMvt = model;
                    foreach (var itemafter in after)
                    {
                        // 56 + 60 = 118 => 118 - 32 = ...
                        // 56 - 32 = 26 => 26 + 60 = 86
                        // previous model(sortie, 32 , 26)
                        // current (entree, 60,118)
                        // updatedcurrent (entree, 60 ,86)
                        // set previous to current
                        var current = _context.StkMovements.Where(c => c.IdMovement == itemafter.IdMovement).FirstOrDefault();
                        if (current.TypeMovement == 2 || current.TypeMovement == 6 || current.TypeMovement == 7)//entree || reintegration || restitution
                        {
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese + current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal + current.Montant;
                            current.ValeurValorisation = Math.Round(current.ValeurStockTotal / current.StockTotalSythese, 2);
                        }
                        if (current.TypeMovement == 3 || current.TypeMovement == 4 || current.TypeMovement == 5)// sortie || affectation || decharge
                        {
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese - current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal - current.Montant;
                            current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                        }
                        if (current.TypeMovement == 8)// retour
                        {
                            current.PrixUnitaire = previousUpdatedMvt.PrixUnitaire;
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese - current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal - current.Montant;
                            current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                        }
                        _context.StkMovements.Update(current);
                        _context.SaveChanges();
                        previousUpdatedMvt = current;
                    }
                }
            }
        }
    }
}
