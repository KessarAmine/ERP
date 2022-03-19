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

    public class EntreesController : Controller
    {
        private KBFsteelContext _context;
        public EntreesController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public object GetStockInitial(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            List<RecapBillettesModel> RecapBillettesModelList = new List<RecapBillettesModel>();
            int NbrFdx = 0;
            int NbrPieces = 0;
            int NbrRot = 0;
            double Tonnage = 0.0;
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
                if (StkRapportTransfertBillette.Count() > 0)
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
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            //updatehourEntree();
            var StkStockInitial = _context.StkBonEntree
                .Where(c => c.DateEntree.Date >= dateDebut.Date && c.DateEntree.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumBon,
                    i.DateEntree,
                    i.CodeFournisseur,
                    i.DateDa,
                    i.Nda,
                    i.TypeAchat,
                    i.CodeIntervenant,
                    i.TypeDevise,
                    i.NumSource,
                    i.TauxChange,
                    i.TypeSource,
                    i.FournisseurNonGere
                });
            return Json(await DataSourceLoader.LoadAsync(StkStockInitial, loadOptions));
        }
        public void updatehourEntree()
        {
            var entrees = _context.StkBonEntree.ToList();
            foreach (var entree in entrees)
            {
                entree.DateEntree = entree.DateEntree.AddHours(-18.0);
                _context.StkBonEntree.Update(entree);
                _context.SaveChanges();
                var details = _context.StkBonEntreeArticles.Where(c => c.NumBonEntree == entree.NumBon);
                foreach (var detail in details)
                {
                    var movement = _context.StkMovements.Where(c => c.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Entree
                                                                && c.IdDetail == detail.Id).FirstOrDefault();
                    movement.DateMovment = entree.DateEntree;
                    _context.StkMovements.Update(movement);
                    _context.SaveChanges();
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperMagasinSuperviseur.NumBonEntreeMagasin = id;
            checkOxygeneAllSuperviseur();
            var StkStockInitial = _context.StkBonEntreeArticles
                .Where(c => c.NumBonEntree == id)
                .Select(i => new {
                    i.CodePdr,
                    i.Id,
                    i.Montant,
                    i.NumBonEntree,
                    i.PrixUnitaire,
                    i.CoutUnitaire,
                    i.CodeFrais,
                    i.ValeurFrais,
                    i.NumFacture,
                    i.MontantDevise,
                    i.ArticleNonGere,
                    i.CodeInvesstisment,
                    i.QteRecu,
                    i.UniteMesureArticleNonGere
                });
            return Json(await DataSourceLoader.LoadAsync(StkStockInitial, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new StkBonEntree();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonEntree(model, valuesDict);
            if (String.IsNullOrEmpty(model.CodeFournisseur) && String.IsNullOrEmpty(model.FournisseurNonGere))
            {
                return StatusCode(409, "Veuillez entrer un fournisseur");
            }
            if (!String.IsNullOrEmpty(model.CodeFournisseur) && !String.IsNullOrEmpty(model.FournisseurNonGere))
            {
                return StatusCode(409, "Veuillez entrer un seul type de fournisseur");
            }
            var StkReceptionBillette = _context.StkBonEntree
                .OrderBy(o => o.NumBon)
                .Select(i => new
                {
                    i.NumBon
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.NumBon = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.NumBon = Convert.ToInt32(m.NumBon) + 1;
            }
            if (model.DateEntree.Equals(""))
                model.DateEntree = DateTime.Now;
            var result = _context.StkBonEntree.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumBon);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetail(string values)
        {
            StkMovements movement = new StkMovements();
            var model = new StkBonEntreeArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonEntreeArticles(model, valuesDict);
            if(model.CodeInvesstisment != true && model.CodeInvesstisment != false)
            {
                model.CodeInvesstisment = false;
            }
            if (model.QteRecu <= 0)
            {
                return StatusCode(409, "Veuillez entrer une QTE supérieur à 0");
            }
            else
            {
                var StkReceptionBillette = _context.StkBonEntreeArticles
                    .OrderBy(o => o.Id)
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();


                if (StkReceptionBillette.Count == 0)
                    model.Id = 1;
                else
                {
                    var m = StkReceptionBillette.Last();
                    model.Id = Convert.ToInt32(m.Id) + 1;
                }
                model.NumBonEntree = XpertHelperMagasinSuperviseur.NumBonEntreeMagasin;
                var DateBonEntree = _context.StkBonEntree
                .AsNoTracking()
                .OrderBy(o => o.NumBon)
                .Where(c => c.NumBon == model.NumBonEntree)
                .Select(i => new
                {
                    i.DateEntree,
                    i.TauxChange,
                    i.TypeDevise
                }).ToList();
                if (DateBonEntree.Last().TypeDevise != null && DateBonEntree.Last().TypeDevise != 0)
                {
                    model.PrixUnitaire = (double)(model.PrixUnitaire * DateBonEntree.Last().TauxChange);
                }
                //Set AllEmptyOrNull CoutUnitaire in DB to PrixUnitaire
                var StkBonEntreeArticles = _context.StkBonEntreeArticles
                .Where(c => String.IsNullOrEmpty(c.CoutUnitaire.ToString())).ToList();
                foreach (var itemStkBonEntreeArticles in StkBonEntreeArticles)
                {
                    itemStkBonEntreeArticles.CoutUnitaire = itemStkBonEntreeArticles.PrixUnitaire;
                }
                model.Montant = Math.Round((double)(model.QteRecu * model.PrixUnitaire), 4);

                double SommeFraisGeneral = 0;
                double sommeEntree = 0;
                //Calculate CoutUnitaire
                if (!model.CodeFrais.Equals(null))
                {
                    //The article has its own frais
                    if (!model.MontantDevise.Equals(null))
                    {
                        model.ValeurFrais = Math.Round((double)(model.ValeurFrais * model.MontantDevise), 4);
                    }
                    model.CoutUnitaire = model.PrixUnitaire + Math.Round((double)(model.ValeurFrais / model.QteRecu), 4);
                    model.Montant = (double)model.CoutUnitaire * model.QteRecu;
                }
                else
                {
                    StkBonEntreeArticles = _context.StkBonEntreeArticles.Where(c=>c.NumBonEntree == model.NumBonEntree).ToList();
                    // the article may have general frais
                    var StkEntreeFraisApproches = _context.StkEntreeFraisApproches.AsNoTracking()
                    .Where(c => c.NumBonEntree == model.NumBonEntree).ToList();
                    //Check if we have Frais
                    if (StkEntreeFraisApproches.Count() > 0)
                    {
                        //Sum of the fees
                        foreach (var itemStkEntreeFraisApproches in StkEntreeFraisApproches)
                        {
                            SommeFraisGeneral += itemStkEntreeFraisApproches.ValeurFrais;
                        }
                        //sum of all entrees articles
                        foreach (var itemStkBonEntreeArticles in StkBonEntreeArticles)
                        {
                            sommeEntree += itemStkBonEntreeArticles.Montant;
                        }
                        // calculate cout

                        if (StkBonEntreeArticles.Count == 0)
                        {
                            model.CoutUnitaire = Math.Round((model.PrixUnitaire * SommeFraisGeneral * model.QteRecu) / (model.PrixUnitaire * model.QteRecu), 4);
                            model.Montant += (double)model.CoutUnitaire;
                        }
                        else
                        {
                            model.CoutUnitaire = Math.Round((model.PrixUnitaire * SommeFraisGeneral * model.QteRecu) / sommeEntree, 4);
                            model.Montant += (double)model.CoutUnitaire;
                        }
                    }
                    else
                    {
                        model.CoutUnitaire = model.PrixUnitaire;
                    }
                }
                var EntreesArticles = _context.StkBonEntreeArticles
                .Select(i => new
                {
                    i.CodeFrais
                }).ToList();
                if (model.CodePdr.Equals(null) || model.CodePdr == 0)
                {
                    movement.ArticleNonGere = model.ArticleNonGere;
                    movement.DateMovment = DateBonEntree.Last().DateEntree;
                    movement.PrixUnitaire = (double)model.CoutUnitaire;
                    movement.Qte = model.QteRecu;
                    movement.Montant = model.Montant;
                    movement.TypeMovement = 2;// 2 pour les entrees
                    movement.IdDetail = model.Id;
                    movement.StockTotalSythese = model.QteRecu;
                    movement.ValeurStockTotal = model.Montant;
                    movement.ValeurValorisation = movement.PrixUnitaire;
                    var resultmovement = _context.StkMovements.Add(movement);
                }
                else
                {
                    // we work the movement 
                    //Calcul Valorisation
                    //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
                    var StkMovements = _context.StkMovements
                     .AsNoTracking()
                    .OrderBy(o => o.DateMovment)
                    .Where(c => c.CodePdr == model.CodePdr && c.DateMovment.Date <= DateBonEntree.Last().DateEntree.Date)
                    .Select(i => new
                    {
                        i.IdMovement
                    }).ToList();
                    if (StkMovements.Count == 0)
                    {
                        var StkStockInitial = _context.StkStockInitial
                        .AsNoTracking()
                        .OrderBy(o => o.Id)
                        .Where(c => c.CodePdr == model.CodePdr)
                        .Select(i => new
                        {
                            i.Id
                        }).ToList();
                        //If there is no stockInitial Erreur else we compute normally
                        if (StkStockInitial.Count == 0)
                        {
                            var NewpdrValorisation = _context.StkPdr
                                .AsNoTracking()
                               .OrderBy(o => o.CodePdr)
                               .Where(c => c.CodePdr == model.CodePdr)
                               .Select(i => new
                               {
                                   i.TypeValorisation
                               }).ToList();
                            // Each PDR must have TypeValorisation
                            if (NewpdrValorisation.Count == 0 || NewpdrValorisation.Last().TypeValorisation == null)
                            {
                                return StatusCode(409, "La Pdr : " + model.CodePdr + " n'as pas de type de valorisation");
                            }
                            movement.CodePdr = (int)model.CodePdr;
                            movement.DateMovment = DateBonEntree.Last().DateEntree;
                            movement.PrixUnitaire = (double)model.CoutUnitaire;
                            movement.Montant = model.Montant;
                            movement.Qte = model.QteRecu;
                            movement.TypeMovement = 2;// 2 pour les entrees
                            movement.TypeValorisation = (int)NewpdrValorisation.Last().TypeValorisation;
                            movement.IdDetail = model.Id;
                            movement.StockTotalSythese = movement.Qte;
                            movement.ValeurValorisation = (double)model.CoutUnitaire;
                            movement.ValeurStockTotal = Math.Round(movement.Montant, 4);
                            var resultmovement = _context.StkMovements.Add(movement);
                            _context.SaveChanges();
                            //we saved the changes now we upate all movements that were afeter this movement QTE and CMUP
                            var after = _context.StkMovements
                            .AsNoTracking()
                            .OrderBy(o => o.DateMovment)
                            .Where(c => c.CodePdr == model.CodePdr && c.DateMovment > movement.DateMovment)
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
                                StkMovements previousUpdatedMvt = movement;
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
                        else
                        {
                            var pdrValorisation = _context.StkPdr
                             .AsNoTracking()
                            .OrderBy(o => o.CodePdr)
                            .Where(c => c.CodePdr == model.CodePdr)
                            .Select(i => new
                            {
                                i.TypeValorisation
                            }).ToList();
                            // Each PDR must have TypeValorisation
                            if (pdrValorisation.Count == 0 || pdrValorisation.Last().TypeValorisation == null)
                            {
                                return StatusCode(409, "La Pdr : " + model.CodePdr + " n'as pas de type de valorisation");
                            }
                            else
                            {
                                // There is TypeValorisation and there is stockInitial we compute
                                var MethodeValorisation = _context.StkTypeValorisation
                                    .AsNoTracking()
                                    .OrderBy(o => o.CodeValorisation)
                                    .Where(c => c.CodeValorisation == pdrValorisation.Last().TypeValorisation)
                                    .Select(i => new
                                    {
                                        i.DesignationValorisation
                                    }).ToList();
                                //IF CMUP
                                if (MethodeValorisation.Last().DesignationValorisation.Equals("CMUP"))
                                {
                                    var MovementsList = _context.StkMovements
                                    .AsNoTracking()
                                    .OrderBy(o => o.IdMovement)
                                    .Select(i => new
                                    {
                                        i.IdMovement
                                    }).ToList();
                                    if (!model.CodePdr.Equals(null))
                                        movement.CodePdr = (int)model.CodePdr;
                                    movement.DateMovment = DateBonEntree.Last().DateEntree;
                                    movement.PrixUnitaire = (double)model.CoutUnitaire;
                                    movement.Montant = model.Montant;
                                    movement.Qte = model.QteRecu;
                                    movement.TypeMovement = 2;// 2 pour les entrees
                                    movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                                    movement.IdDetail = model.Id;
                                    ComputeCMUP(movement, 1);//Case = 1 car on est dans le cas ou en calcul apres un stock intiial premeir mouvement
                                    checkSpot(model);
                                }
                                else
                                {
                                    return StatusCode(409, "Ce type de valorisation : " + MethodeValorisation.Last().DesignationValorisation + " n'est pas prit en charge");
                                }
                            }
                        }
                    }
                    else
                    {
                        var pdrValorisation = _context.StkPdr
                        .AsNoTracking()
                        .OrderBy(o => o.CodePdr)
                        .Where(c => c.CodePdr == model.CodePdr)
                        .Select(i => new
                        {
                            i.TypeValorisation
                        }).ToList();
                        // Each PDR must have TypeValorisation
                        if (pdrValorisation.Count == 0 || pdrValorisation.Last().TypeValorisation == null)
                        {
                            return StatusCode(409, "La Pdr : " + model.CodePdr + " n'as plus de type de valorisation");
                        }
                        else
                        {
                            // There is TypeValorisation and there is stockInitial we compute
                            var MethodeValorisation = _context.StkTypeValorisation
                                    .AsNoTracking()
                                    .OrderBy(o => o.CodeValorisation)
                                    .Where(c => c.CodeValorisation == pdrValorisation.Last().TypeValorisation)
                                    .Select(i => new
                                    {
                                        i.DesignationValorisation
                                    }).ToList();
                            //IF CMUP
                            if (MethodeValorisation.Last().DesignationValorisation.Equals("CMUP"))
                            {
                                var MovementsList = _context.StkMovements
                                .AsNoTracking()
                                .OrderBy(o => o.IdMovement)
                                .Select(i => new
                                {
                                    i.IdMovement
                                }).ToList();
                                if (!model.CodePdr.Equals(null))
                                    movement.CodePdr = (int)model.CodePdr; 
                                movement.DateMovment = DateBonEntree.Last().DateEntree;
                                movement.PrixUnitaire = (double)model.CoutUnitaire;
                                movement.Qte = model.QteRecu;
                                movement.Montant = model.Montant;
                                movement.TypeMovement = 2;// 2 pour les entrees
                                movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                                movement.IdDetail = model.Id;
                                ComputeCMUP(movement, 2);//Case = 2 car on est dans le cas ou EN as deja un mouvement
                                checkSpot(model);
                            }
                            else
                            {
                                return StatusCode(409, "Ce type de valorisation : " + MethodeValorisation.Last().DesignationValorisation + " n'est pas prit en charge");
                            }
                        }
                    }
                }
            }
            var result = _context.StkBonEntreeArticles.Add(model);
            await _context.SaveChangesAsync();
            await UpdateBeFraisSommeAsync(model.NumBonEntree);
            return Json(result.Entity.Id);
        }
        public void checkOxygeneAllSuperviseur()
        {
            // get all oxygene Entree > 40 && no frais unique in them
            // cehck if there is no frais global in them
            // add new frais with the detail NumBon Transport 2000 DA
            // update coutUnitaire of entreeArticle and montant
            // Update MovementValues current and after
            var OxygeneEntreesDetails = _context.StkBonEntreeArticles
                .AsNoTracking()
                .Where(c => c.CodePdr == XpertHelper.CodeOxygene && c.QteRecu> 40 && String.IsNullOrEmpty(c.ValeurFrais.ToString()))
                .Select(i=> new
                {
                    i.Id,
                    i.CodeFrais,
                    i.CoutUnitaire,
                    i.PrixUnitaire,
                    i.QteRecu,
                    i.Montant,
                    i.NumBonEntree
                }).ToList();
            if(OxygeneEntreesDetails.Count > 0)
            {
                foreach (var itemOxygeneEntreesDetails in OxygeneEntreesDetails)
                {
                    var EntreeFraisGlobal = _context.StkEntreeFraisApproches
                            .AsNoTracking()
                            .Where(c => c.NumBonEntree == itemOxygeneEntreesDetails.NumBonEntree && c.CodeFrais == 1)//there is no frais of transport
                            .Select(i => new
                            {
                                i.CodeFrais,
                                i.ValeurFrais,
                                i.MontantDevise
                            }).ToList();
                    if(EntreeFraisGlobal.Count == 0)
                    {
                        // addnewFrais
                        var frais = _context.StkEntreeFraisApproches.AsNoTracking().ToList();
                        StkEntreeFraisApproches newFrais = new StkEntreeFraisApproches();
                        if(frais.Count == 0)
                        {
                            newFrais.Id = 1;
                        }
                        else
                        {
                            newFrais.Id = frais.Last().Id + 1;
                        }
                        newFrais.CodeArticle = XpertHelper.CodeOxygene;
                        newFrais.CodeFrais = 1;//transport
                        newFrais.ValeurFrais = 2000;//2000 TRANSPORTS
                        newFrais.NumBonEntree = itemOxygeneEntreesDetails.NumBonEntree;
                        _context.StkEntreeFraisApproches.Add(newFrais);
                        _context.SaveChanges();
                        //Update EntreeArticle
                        var EntreeDetailToUpdate = _context.StkBonEntreeArticles.Where(c => c.Id == itemOxygeneEntreesDetails.Id).FirstOrDefault();
                        EntreeDetailToUpdate.CoutUnitaire = Math.Round(EntreeDetailToUpdate.PrixUnitaire + (newFrais.ValeurFrais / EntreeDetailToUpdate.QteRecu),4);
                        EntreeDetailToUpdate.Montant = Math.Round((double)(EntreeDetailToUpdate.QteRecu * EntreeDetailToUpdate.CoutUnitaire), 4);
                        _context.StkBonEntreeArticles.Update(EntreeDetailToUpdate);
                        _context.SaveChanges();
                        //UpdateMovement
                        var dateEntree = _context.StkBonEntree.AsNoTracking().OrderBy(o=> o.DateEntree).Where(c => c.NumBon == itemOxygeneEntreesDetails.NumBonEntree).Select(i => new { i.DateEntree }).Last();
                        var previousMvt = _context.StkMovements.AsNoTracking().OrderBy(o => o.DateMovment).Where(c => c.DateMovment < dateEntree.DateEntree).Select(i=>new { i.ValeurStockTotal }).Last();
                        var movementToUpdate = _context.StkMovements.Where(c => c.TypeMovement == XpertHelperMagasinSuperviseur.typeMovment_Entree && c.IdDetail == itemOxygeneEntreesDetails.Id).FirstOrDefault();
                        movementToUpdate.PrixUnitaire = (double)EntreeDetailToUpdate.CoutUnitaire;
                        movementToUpdate.Montant = Math.Round(movementToUpdate.Qte * movementToUpdate.PrixUnitaire, 4);
                        movementToUpdate.ValeurStockTotal = previousMvt.ValeurStockTotal + movementToUpdate.Montant;
                        movementToUpdate.ValeurValorisation = Math.Round(movementToUpdate.ValeurStockTotal / movementToUpdate.StockTotalSythese, 4);
                        _context.StkMovements.Update(movementToUpdate);
                        _context.SaveChanges();
                        //update Movements After movementToUpdate
                        updateAfterMovement(movementToUpdate);
                    }
                }
            }
        }
        public void updateAfterMovement(StkMovements model)
        {
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
                StkMovements previousUpdatedMvt = model;
                foreach (var itemafter in after)
                {
                    var current = _context.StkMovements.Where(c => c.IdMovement == itemafter.IdMovement).FirstOrDefault();
                    switch (current.TypeMovement)
                    {
                        case 2://entree
                        case 6://reintegration
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese + current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal + current.Montant;
                            current.ValeurValorisation = Math.Round(current.ValeurStockTotal / current.StockTotalSythese, 2);
                            break;
                        case 3://sortie
                        case 8://retour
                            current.PrixUnitaire = previousUpdatedMvt.ValeurValorisation;
                            current.Montant = current.PrixUnitaire * current.Qte;
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese - current.Qte;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal - current.Montant;
                            if (current.ValeurStockTotal < 1)
                                current.ValeurStockTotal = 0;
                            current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                            break;
                        default:
                            current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese;
                            current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal;
                            current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                            break;
                    }
                    _context.StkMovements.Update(current);
                    _context.SaveChanges();
                    previousUpdatedMvt = current;
                }
            }
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.StkBonEntree.FirstOrDefaultAsync(item => item.NumBon == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var OldChange = model.TauxChange;
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonEntree(model, valuesDict);
            if (model.CodeFournisseur != null && !String.IsNullOrEmpty(model.FournisseurNonGere))
            {
                return StatusCode(409, "Veuillez entrer un seul type de fournisseur");
            }
            var newChange = model.TauxChange;
            if (model.TypeDevise != null)
            {
                if (!OldChange.Equals(newChange))
                {
                    var ArticlesList = _context.StkBonEntreeArticles.Where(item => item.NumBonEntree == key).Select(i => new {
                        i.CodePdr,
                        i.Id,
                        i.Montant,
                        i.NumBonEntree,
                        i.PrixUnitaire,
                        i.QteRecu
                    }).ToList();
                    foreach (var itemArticlesList in ArticlesList)
                    {
                        var itemmodel = await _context.StkBonEntreeArticles.FirstOrDefaultAsync(item => item.Id == itemArticlesList.Id);
                        if (model.TauxChange == 0)
                        {
                            itemmodel.PrixUnitaire = (double)(itemmodel.PrixUnitaire / OldChange);
                        }
                        else
                        {
                            itemmodel.PrixUnitaire = (double)(itemmodel.PrixUnitaire * model.TauxChange);
                        }
                        itemmodel.Montant = itemmodel.PrixUnitaire * itemmodel.QteRecu;
                    }
                }
            }
            await _context.SaveChangesAsync();
            await UpdateBeFraisSommeAsync(model.NumBon);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetail(int key, string values)
        {
            var model = await _context.StkBonEntreeArticles.FirstOrDefaultAsync(item => item.Id == key);
            var oldQte = model.QteRecu;
            var oldMontant = model.Montant;
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonEntreeArticles(model, valuesDict);
            var DateBonEntree = _context.StkBonEntree
            .AsNoTracking()
            .OrderBy(o => o.NumBon)
            .Where(c => c.NumBon == model.NumBonEntree)
            .Select(i => new
            {
                i.DateEntree,
                i.TauxChange,
                i.TypeDevise
            }).ToList();
            if (DateBonEntree.Last().TypeDevise != null && DateBonEntree.Last().TypeDevise != 0)
            {
                model.PrixUnitaire = (double)(model.PrixUnitaire * DateBonEntree.Last().TauxChange);
            }
            model.Montant = model.PrixUnitaire * model.QteRecu;
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 2);
            modelMovement.PrixUnitaire = model.PrixUnitaire;
            modelMovement.Qte = model.QteRecu;
            modelMovement.Montant = model.Montant;
            if (!modelMovement.CodePdr.Equals(null) && modelMovement.CodePdr != 0)
            {
                //Application des contraintes de stock que sur les articles Gérés
                if ((modelMovement.StockTotalSythese - oldQte) + model.QteRecu < 0)
                {
                    return StatusCode(409, "Cette Quantité : " + model.QteRecu + " n'est pas disponnible, il reste : " + modelMovement.StockTotalSythese);
                }
                modelMovement.StockTotalSythese = (modelMovement.StockTotalSythese - oldQte) + model.QteRecu;
                modelMovement.ValeurStockTotal = (modelMovement.ValeurStockTotal - oldMontant) + model.Montant;
                modelMovement.ValeurValorisation = Math.Round((double)(modelMovement.ValeurStockTotal / modelMovement.StockTotalSythese), 4);
            }
            _context.StkMovements.Update(modelMovement);
            await _context.SaveChangesAsync();
            await UpdateBeFraisSommeAsync(model.NumBonEntree);
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var model = await _context.StkBonEntree.FirstOrDefaultAsync(item => item.NumBon == key);
            if (model == null)
                return StatusCode(409, "BE N°" + key + " est introuvable, Vérifiez la basse de données");
            var details = _context.StkBonEntreeArticles.Where(item => item.NumBonEntree == key).ToList();
            if (details.Count > 0)
                return StatusCode(409, "Non autorisé : vueillez suprimmer les détails avant");
            var ArticlesList = _context.StkBonEntreeArticles.Where(item => item.NumBonEntree == key).Select(i => new {
                i.CodePdr,
                i.Id,
                i.Montant,
                i.NumBonEntree,
                i.PrixUnitaire,
                i.QteRecu
            }).ToList();
            foreach (var itemArticlesList in ArticlesList)
            {
                await DeleteDetail(itemArticlesList.Id);
            }
            await UpdateBeFraisSommeAsync(model.NumBon);
            _context.StkBonEntree.Remove(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteDetail(int key)
        {
            var model = await _context.StkBonEntreeArticles.FirstOrDefaultAsync(item => item.Id == key);

            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 2);
            
            var emplacements = _context.StkEmplacement.Where(item => item.CodePdr == model.CodePdr).ToList();
            var Entree = await _context.StkBonEntree.FirstOrDefaultAsync(item => item.NumBon == model.NumBonEntree);
            StkEmplacement magasinP = emplacements.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);//Principal
            magasinP.Qte -= model.QteRecu;
            _context.StkEmplacement.Update(magasinP);

            _context.StkMovements.Remove(modelMovement);
            _context.StkBonEntreeArticles.Remove(model);
            await _context.SaveChangesAsync();
            await UpdateBeFraisSommeAsync(model.NumBonEntree);
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> TypeDeviseLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupDevise
                         orderby i.CodeDevise
                         select new
                         {
                             Value = i.CodeDevise,
                             Text = i.DesignationDevise
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeSourceLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupSourceBonEntree
                         orderby i.CodeSource
                         select new
                         {
                             Value = i.CodeSource,
                             Text = i.DesignationSource
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeAchatLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkTypeAchat
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.DesignationTypeAchat
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
        private void checkSpot(StkBonEntreeArticles model)
        {
            var emplacement = _context.StkEmplacement
                .AsNoTracking()
                .Where(c => c.CodePdr == model.CodePdr).ToList();
            if (emplacement.Count == 0)
            {
                //case new article en Entree
                StkEmplacement newEmplacement = new StkEmplacement();
                newEmplacement.CodeLieu = XpertHelper.CodeMagasin;
                newEmplacement.CodePdr = model.CodePdr;
                var mvt = _context.StkMovements
                .OrderBy(o => o.DateMovment)
                .AsNoTracking()
                .Where(c => c.CodePdr == model.CodePdr).ToList();
                if (mvt.Count > 0)
                {
                    //we first assign total of stock to it
                    newEmplacement.Qte = mvt.Last().StockTotalSythese;
                    //we get sum of qte in other lieux then we substruct it to get the result
                    double sommeOtherPlaces = 0;
                    foreach (var itememplacement in emplacement)
                    {
                        if (itememplacement.CodeLieu != XpertHelper.CodeMagasin)
                        {
                            sommeOtherPlaces += (double)itememplacement.Qte;
                        }
                    }
                    newEmplacement.Qte -= sommeOtherPlaces;
                }
                else
                {
                    var stkInit = _context.StkStockInitial.Where(c => c.CodePdr == model.CodePdr).ToList();
                    if (stkInit.Count > 0)
                    {
                        newEmplacement.Qte = stkInit.Last().Qte;
                    }
                }
                _context.StkEmplacement.Add(newEmplacement);
            }
            else
            {
                //case there is an emplacements in
                StkEmplacement magasinP = emplacement.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);//Principal
                if (magasinP != null)
                {
                    magasinP.Qte += model.QteRecu;
                    _context.StkEmplacement.Update(magasinP);
                }
            }
            _context.SaveChanges();
        }
        public void ComputeCMUP(StkMovements model, int Case)
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
                model.ValeurStockTotal += Math.Round((double)(StkStockInitial.Last().PrixUnitare * StkStockInitial.Last().Qte), 4);
                model.ValeurValorisation = Math.Round((double)(model.ValeurStockTotal / model.StockTotalSythese), 4);
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
                    StkMovements previousUpdatedMvt = model;
                    foreach (var itemafter in after)
                    {
                        var current = _context.StkMovements.Where(c => c.IdMovement == itemafter.IdMovement).FirstOrDefault();
                        switch (current.TypeMovement)
                        {
                            case 2://entree
                            case 6://reintegration
                                current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese + current.Qte;
                                current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal + current.Montant;
                                current.ValeurValorisation = Math.Round(current.ValeurStockTotal / current.StockTotalSythese, 2);
                                break;
                            case 3://sortie
                            case 8://retour
                                current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese - current.Qte;
                                current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal - current.Montant;
                                current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                                break;
                            default:
                                current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese;
                                current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal;
                                current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                                break;
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
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment.Date <= model.DateMovment.Date)
                .Select(i => new
                {
                    i.IdMovement,
                    i.StockTotalSythese,
                    i.ValeurStockTotal
                }).ToList();
                model.StockTotalSythese += StkMovements.Last().StockTotalSythese;
                model.ValeurStockTotal += Math.Round((double)(StkMovements.Last().ValeurStockTotal), 4);
                model.ValeurValorisation = Math.Round((double)(model.ValeurStockTotal / model.StockTotalSythese), 4);
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
                    StkMovements previousUpdatedMvt = model;
                    foreach (var itemafter in after)
                    {
                        var current = _context.StkMovements.Where(c => c.IdMovement == itemafter.IdMovement).FirstOrDefault();
                        switch (current.TypeMovement)
                        {
                            case 2://entree
                            case 6://reintegration
                                current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese + current.Qte;
                                current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal + current.Montant;
                                current.ValeurValorisation = Math.Round(current.ValeurStockTotal / current.StockTotalSythese, 2);
                                break;
                            case 3://sortie
                            case 8://retour
                                current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese - current.Qte;
                                current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal - current.Montant;
                                current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                                break;
                            default:
                                current.StockTotalSythese = previousUpdatedMvt.StockTotalSythese;
                                current.ValeurStockTotal = previousUpdatedMvt.ValeurStockTotal;
                                current.ValeurValorisation = previousUpdatedMvt.ValeurValorisation;
                                break;
                        }
                        _context.StkMovements.Update(current);
                        _context.SaveChanges();
                        previousUpdatedMvt = current;
                    }
                }
            }
        }
        public double ComputeFrais(int NumBonEntree)
        {
            var SommeFrais = 0.0;
            var ArticlesList = _context.StkBonEntreeArticles.AsNoTracking().Where(item => item.NumBonEntree == NumBonEntree).Select(i => new {
                i.ValeurFrais,
                i.MontantDevise
            }).ToList();
            var Frais = _context.StkEntreeFraisApproches.AsNoTracking().Where(item => item.NumBonEntree == NumBonEntree).Select(i => new {
                i.ValeurFrais,
                i.MontantDevise
            }).ToList();
            foreach (var itemFrais in Frais)
            {
                if (itemFrais.MontantDevise != null)
                {
                    var dev = itemFrais.ValeurFrais * itemFrais.MontantDevise;
                    SommeFrais += (double)dev;
                }
                else
                {
                    SommeFrais += itemFrais.ValeurFrais;
                }
            }
            foreach (var itemArticlesList in ArticlesList)
            {
                if (itemArticlesList.ValeurFrais != null)
                {
                    if (itemArticlesList.MontantDevise != null)
                    {
                        var dev = itemArticlesList.ValeurFrais * itemArticlesList.MontantDevise;
                        SommeFrais += (double)dev;
                    }
                    else
                    {
                        SommeFrais += (double)itemArticlesList.ValeurFrais;
                    }
                }
            }
            return SommeFrais;
        }
        public double ComputeSomme(int NumBonEntree, double SommeFrais)
        {
            var Somme = 0.0;
            var ArticlesList = _context.StkBonEntreeArticles.AsNoTracking().Where(item => item.NumBonEntree == NumBonEntree).Select(i => new {
                i.Montant
            }).ToList();
            foreach (var itemArticlesList in ArticlesList)
            {
                Somme += (double)itemArticlesList.Montant;
            }
            Somme += SommeFrais;
            return Somme;
        }
        public async Task UpdateBeFraisSommeAsync(int NumBonEntree)
        {
            var sommeFrais = ComputeFrais(NumBonEntree);
            var somme = ComputeSomme(NumBonEntree, sommeFrais);
            var BE = await _context.StkBonEntree.FirstOrDefaultAsync(item => item.NumBon == NumBonEntree);
            BE.Somme = somme;
            BE.SommeFraisApproches = sommeFrais;
            _context.StkBonEntree.Update(BE);
            await _context.SaveChangesAsync();
        }
        private void PopulateModelStkBonEntree(StkBonEntree model, IDictionary values)
        {
            string CodeFournisseur = nameof(StkBonEntree.CodeFournisseur);
            string DateDa = nameof(StkBonEntree.DateDa);
            string DateEntree = nameof(StkBonEntree.DateEntree);
            string Nda = nameof(StkBonEntree.Nda);
            string TypeAchat = nameof(StkBonEntree.TypeAchat);
            string CodeIntervenant = nameof(StkBonEntree.CodeIntervenant);
            string TypeDevise = nameof(StkBonEntree.TypeDevise);
            string TypeSource = nameof(StkBonEntree.TypeSource);
            string TauxChange = nameof(StkBonEntree.TauxChange);
            string NumSource = nameof(StkBonEntree.NumSource);
            string FournisseurNonGere = nameof(StkBonEntree.FournisseurNonGere);
            if (values.Contains(DateEntree))
            {
                model.DateEntree = Convert.ToDateTime(values[DateEntree]);
            }
            if (values.Contains(DateDa))
            {
                model.DateDa = Convert.ToDateTime(values[DateDa]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
            if (values.Contains(Nda))
            {
                model.Nda = Convert.ToInt32(values[Nda]);
            }
            if (values.Contains(TauxChange))
            {
                model.TauxChange = Convert.ToDouble(values[TauxChange]);
            }
            if (values.Contains(NumSource))
            {
                model.NumSource = Convert.ToInt32(values[NumSource]);
            }
            if (values.Contains(TypeAchat))
            {
                model.TypeAchat = Convert.ToInt32(values[TypeAchat]);
            }
            if (values.Contains(TypeDevise))
            {
                model.TypeDevise = Convert.ToInt32(values[TypeDevise]);
            }
            if (values.Contains(TypeSource))
            {
                model.TypeSource = Convert.ToInt32(values[TypeSource]);
            }
            if (values.Contains(CodeFournisseur))
            {
                if (values[CodeFournisseur] != null)//in case we choose one and we press X
                {
                    var CodePdrvar = values[CodeFournisseur].ToString().Trim('"');
                    var SplitThefirst = CodePdrvar.Split("FR");
                    var SplitThesecond = SplitThefirst[1].Split("]");
                    var CodePdrSplited = SplitThesecond[0].Split("\"");
                    var elee = CodePdrSplited[0];
                    model.CodeFournisseur = Convert.ToString("FR" + elee);
                }
            }
            if (values.Contains(FournisseurNonGere))
            {
                model.FournisseurNonGere = Convert.ToString(values[FournisseurNonGere]);
            }
        }
        private void PopulateModelStkBonEntreeArticles(StkBonEntreeArticles model, IDictionary values)
        {
            string CodePdr = nameof(StkBonEntreeArticles.CodePdr);
            string PrixUnitaire = nameof(StkBonEntreeArticles.PrixUnitaire);
            string QteRecu = nameof(StkBonEntreeArticles.QteRecu);
            string CodeFrais = nameof(StkBonEntreeArticles.CodeFrais);
            string MontantDevise = nameof(StkBonEntreeArticles.MontantDevise);
            string NumFacture = nameof(StkBonEntreeArticles.NumFacture);
            string ValeurFrais = nameof(StkBonEntreeArticles.ValeurFrais);
            string ArticleNonGere = nameof(StkBonEntreeArticles.ArticleNonGere);
            string UniteMesureArticleNonGere = nameof(StkBonEntreeArticles.UniteMesureArticleNonGere);
            string CodeInvesstisment = nameof(StkBonEntreeArticles.CodeInvesstisment);
            if (values.Contains(CodeFrais))
            {
                var CodePdrvar = values[CodeFrais];
                var Idemployestrings = CodePdrvar.ToString().Trim();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeFrais = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(CodeInvesstisment))
            {
                model.CodeInvesstisment = Convert.ToBoolean(values[CodeInvesstisment]);
            }
            if (values.Contains(MontantDevise))
            {
                model.MontantDevise = Convert.ToDouble(values[MontantDevise]);
            }
            if (values.Contains(NumFacture))
            {
                model.NumFacture = Convert.ToInt32(values[NumFacture]);
            }
            if (values.Contains(UniteMesureArticleNonGere))
            {
                model.UniteMesureArticleNonGere = Convert.ToInt32(values[UniteMesureArticleNonGere]);
            }
            if (values.Contains(ValeurFrais))
            {
                model.ValeurFrais = Convert.ToDouble(values[ValeurFrais]);
            }
            if (values.Contains(QteRecu))
            {
                model.QteRecu = Convert.ToDouble(values[QteRecu]);
            }
            if (values.Contains(PrixUnitaire))
            {
                model.PrixUnitaire = Convert.ToDouble(values[PrixUnitaire]);
            }
            if (values.Contains(ArticleNonGere))
            {
                model.ArticleNonGere = Convert.ToString(values[ArticleNonGere]);
            }
            if (values.Contains(CodePdr) && !String.IsNullOrEmpty(Convert.ToString(values[CodePdr])))
            {
                var CodePdrvar = values[CodePdr];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodePdr = Convert.ToInt32(CodePdrSplited);
            }
        }
    }
}
