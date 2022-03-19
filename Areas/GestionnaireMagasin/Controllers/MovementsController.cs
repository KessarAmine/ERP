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

    public class MovementsController : Controller
    {
        private KBFsteelContext _context;
        public MovementsController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkBonSortie = _context.StkMovements
                .Where(c => c.DateMovment.Date >= dateDebut.Date && c.DateMovment.Date <= dateFin.Date)
                .Select(i => new {
                    i.IdMovement,
                    i.IdDetail,
                    i.CodePdr,
                    i.DateMovment,
                    i.Montant,
                    i.PrixUnitaire,
                    i.Qte,
                    i.StockTotalSythese,
                    i.TypeMovement,
                    i.TypeValorisation,
                    i.ValeurStockTotal,
                    i.ArticleNonGere,
                    i.ValeurValorisation
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonSortie, loadOptions));
        }
        [HttpGet]
        public object GetSuiviMovements(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            List<SuiviMovementsModel> SuiviMovementsModelList = new List<SuiviMovementsModel>();
            var StkMovements = _context.StkMovements
                .AsNoTracking()
                .Where(c => c.DateMovment.Date >= dateDebut.Date && c.DateMovment.Date <= dateFin.Date)
                .Select(i => new {
                    i.IdMovement,
                    i.IdDetail,
                    i.CodePdr,
                    i.DateMovment,
                    i.Montant,
                    i.PrixUnitaire,
                    i.Qte,
                    i.StockTotalSythese,
                    i.TypeMovement,
                    i.TypeValorisation,
                    i.ValeurStockTotal,
                    i.ArticleNonGere,
                    i.ValeurValorisation
                }).ToList();
            foreach (var movement in StkMovements)
            {
                SuiviMovementsModel suiviMovementsModel = new SuiviMovementsModel();
                suiviMovementsModel.ArticleNonGere = movement.ArticleNonGere;
                suiviMovementsModel.CodePdr = movement.CodePdr;
                var article = _context.StkPdr.AsNoTracking().Where(c => c.CodePdr == movement.CodePdr).FirstOrDefault();
                if (article != null)
                    suiviMovementsModel.CompteComptable = article.CompteComptable;
                suiviMovementsModel.DateMovment = movement.DateMovment;
                suiviMovementsModel.IdDetail = movement.IdDetail;
                suiviMovementsModel.IdMovement = movement.IdMovement;
                suiviMovementsModel.Montant = movement.Montant;
                suiviMovementsModel.PrixUnitaire = movement.PrixUnitaire;
                suiviMovementsModel.Qte = movement.Qte;
                suiviMovementsModel.StockTotalSythese = movement.StockTotalSythese;
                suiviMovementsModel.TypeMovement = movement.TypeMovement;
                suiviMovementsModel.TypeValorisation = movement.TypeValorisation;
                suiviMovementsModel.ValeurStockTotal = movement.ValeurStockTotal;
                suiviMovementsModel.ValeurValorisation = movement.ValeurValorisation;
                if (String.IsNullOrEmpty(suiviMovementsModel.ArticleNonGere))
                {
                    var CodeUnite = _context.StkPdr
                        .AsNoTracking()
                        .Where(c => c.CodePdr == movement.CodePdr)
                        .Select(i => new {
                            i.CodeUniteMesurePdr
                        }).ToList();
                    if (CodeUnite.Count() > 0)
                    {
                        var Unite = _context.StkUniteMesurePdr
                            .AsNoTracking()
                            .Where(c => c.CodeUniteMesurePdr == CodeUnite.Last().CodeUniteMesurePdr)
                            .Select(i => new {
                                i.DesignationUniteMesurePdr
                            }).ToList();
                        if (Unite.Count() > 0)
                            suiviMovementsModel.UniteMesure = Unite.Last().DesignationUniteMesurePdr;
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Entree)
                    {
                        var NumBon = _context.StkBonEntreeArticles
                        .AsNoTracking()
                        .Where(c => c.Id == movement.IdDetail)
                        .Select(i => new {
                            i.NumBonEntree
                        }).ToList().Last();
                        suiviMovementsModel.NumBon = NumBon.NumBonEntree;
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Sortie)
                    {
                        var NumBon = _context.StkBonSortieArticles
                            .AsNoTracking()
                            .Where(c => c.Id == movement.IdDetail)
                            .Select(i => new {
                                i.NumBonSortie
                            }).ToList().Last();
                        suiviMovementsModel.NumBon = NumBon.NumBonSortie;
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Affectation)
                    {
                        var NumBon = _context.StkAffectationsArticles
                            .AsNoTracking()
                            .Where(c => c.Id == movement.IdDetail)
                            .Select(i => new {
                                i.NumBonAffectation
                            }).ToList().Last();
                        suiviMovementsModel.NumBon = NumBon.NumBonAffectation;
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Decharge)
                    {
                        var NumBon = _context.StkDechargeArticles
                            .AsNoTracking()
                            .Where(c => c.Id == movement.IdDetail)
                            .Select(i => new {
                                i.NumDecharge
                            }).ToList().Last();
                        suiviMovementsModel.NumBon = NumBon.NumDecharge;
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Reintegration)
                    {
                        var NumBon = _context.StkReintegrationArticles
                            .AsNoTracking()
                            .Where(c => c.Id == movement.IdDetail)
                            .Select(i => new {
                                i.NumBonReintegration
                            }).ToList().Last();
                        suiviMovementsModel.NumBon = NumBon.NumBonReintegration;
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Restitution)
                    {
                        var NumBon = _context.StkRestitutionArticles
                            .AsNoTracking()
                            .Where(c => c.Id == movement.IdDetail)
                            .Select(i => new {
                                i.NumRestitution
                            }).ToList().Last();
                        suiviMovementsModel.NumBon = NumBon.NumRestitution;
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Retour)
                    {
                        var NumBon = _context.StkBonRetourArticles
                            .AsNoTracking()
                            .Where(c => c.Id == movement.IdDetail)
                            .Select(i => new {
                                i.NumBonRetour
                            }).ToList().Last();
                        suiviMovementsModel.NumBon = NumBon.NumBonRetour;
                    }
                }
                else
                {
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Entree)
                    {
                        var CodeUnite = _context.StkBonEntreeArticles
                            .AsNoTracking()
                            .Where(c => c.ArticleNonGere == movement.ArticleNonGere)
                            .Select(i => new {
                                i.NumBonEntree,
                                i.UniteMesureArticleNonGere
                            }).ToList();
                        if (CodeUnite.Count() > 0)
                        {
                            suiviMovementsModel.NumBon = CodeUnite.Last().NumBonEntree;
                            var Unite = _context.StkUniteMesurePdr
                                .AsNoTracking()
                                .Where(c => c.CodeUniteMesurePdr == CodeUnite.Last().UniteMesureArticleNonGere)
                                .Select(i => new {
                                    i.DesignationUniteMesurePdr
                                }).ToList();
                            if (Unite.Count() > 0)
                            {
                                suiviMovementsModel.UniteMesure = Unite.Last().DesignationUniteMesurePdr;
                            }
                        }
                    }
                    if (suiviMovementsModel.TypeMovement == XpertHelperGestionnaireMagasin.typeMovment_Sortie)
                    {
                        var CodeUnite = _context.StkBonSortieArticles
                            .AsNoTracking()
                            .Where(c => c.ArticleNonGere == movement.ArticleNonGere)
                            .Select(i => new {
                                i.NumBonSortie,
                                i.UniteMesureArticleNonGere
                            }).ToList();
                        if (CodeUnite.Count() > 0)
                        {
                            suiviMovementsModel.NumBon = CodeUnite.Last().NumBonSortie;
                            var Unite = _context.StkUniteMesurePdr
                                .AsNoTracking()
                                .Where(c => c.CodeUniteMesurePdr == CodeUnite.Last().UniteMesureArticleNonGere)
                                .Select(i => new {
                                    i.DesignationUniteMesurePdr
                                }).ToList();
                            if (Unite.Count() > 0)
                            {
                                suiviMovementsModel.UniteMesure = Unite.Last().DesignationUniteMesurePdr;
                            }
                        }
                    }
                }
                var Emplacement = _context.StkEmplacement
                    .AsNoTracking()
                    .Where(c => c.CodePdr == movement.CodePdr)
                    .Select(i => new {
                        i.CodeGisement,
                        i.CodeLieu
                    }).ToList();
                if (Emplacement.Count() > 0)
                {
                    var empl = Emplacement.Last();
                    var Gisement = _context.StkGismentPdr
                    .AsNoTracking()
                    .Where(c => c.CodeGisment == empl.CodeGisement)
                    .Select(i => new {
                        i.DesignationGisment
                    }).ToList();
                    if (Gisement.Count > 0)
                        suiviMovementsModel.Gisement = Gisement.Last().DesignationGisment;
                }
                SuiviMovementsModelList.Add(suiviMovementsModel);
            }
            return DataSourceLoader.Load(SuiviMovementsModelList, loadOptions);
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> TypeMovementLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkTypeMovement
                         orderby i.CodeMovement
                         select new
                         {
                             Value = i.CodeMovement,
                             Text = i.DesignationMovement
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeValorisationLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkTypeValorisation
                         orderby i.CodeValorisation
                         select new
                         {
                             Value = i.CodeValorisation,
                             Text = i.DesignationValorisation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DesignationPdrLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkPdr
                         orderby i.CodePdr
                         select new
                         {
                             Value = i.CodePdr,
                             Text = i.DesignationPdr
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
    }
}