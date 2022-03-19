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
using System.IO;
namespace DevKbfSteel.Areas.GestionnaireMagasin.Controllers
{
    [Area(nameof(Areas.GestionnaireMagasin))]

    public class SortiesController : Controller
    {
        private KBFsteelContext _context;
        private int SortieTableEmpty = 0;
        public SortiesController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> GetFromDemandeFourniture(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperGestionnaireMagasin.NumDemandeFournitureMagasin = id;
            var StkBonSortie = _context.StkBonSortie
                .Where(c => c.NumDemandeFourniture == id)
                .Select(i => new {
                    i.NumBonSortie,
                    i.CodeIntervenant,
                    i.CodeServiceEmetteur,
                    i.DateSortie,
                    i.NumDemandeFourniture,
                    i.TypeSortie
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonSortie, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkBonSortie = _context.StkBonSortie
                .Where(c => c.DateSortie.Date >= dateDebut.Date && c.DateSortie.Date <= dateFin.Date)
                .Select(i => new {
                    i.SourceSortie,
                    i.NumBonSortie,
                    i.CodeIntervenant,
                    i.CodeServiceEmetteur,
                    i.DateSortie,
                    i.NumDemandeFourniture,
                    i.TypeSortie,
                    i.CentreFrais,
                    i.CodeEmetteur
                });
            if (StkBonSortie.Count() == 0)
            {
                SortieTableEmpty = 1;
            }
            return Json(await DataSourceLoader.LoadAsync(StkBonSortie, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetNumBon( DataSourceLoadOptions loadOptions)
        {
            var StkBonSortie = _context.StkBonSortie
                .Select(i => new {
                    i.NumBonSortie,
                    i.CodeIntervenant,
                    i.CodeServiceEmetteur,
                    i.DateSortie,
                    i.NumDemandeFourniture,
                    i.TypeSortie,
                    i.CentreFrais,
                    i.CodeEmetteur
                });
            if (StkBonSortie.Count() == 0)
            {
                SortieTableEmpty = 1;
            }
            return Json(await DataSourceLoader.LoadAsync(StkBonSortie, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperGestionnaireMagasin.NumBonSortieMagasin = id;
            var StkStockInitial = _context.StkBonSortieArticles
                .Where(c => c.NumBonSortie == id)
                .Select(i => new {
                    i.CodeArticle,
                    i.DateSortie,
                    i.Id,
                    i.Montant,
                    i.CodePreneur,
                    i.PrixUnitaire,
                    i.LieuDemandé,
                    i.ArticleNonGere,
                    i.Qte,
                    i.UniteMesureArticleNonGere
                });
            return Json(await DataSourceLoader.LoadAsync(StkStockInitial, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new StkBonSortie();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonSortie(model, valuesDict);
            if (String.IsNullOrEmpty(model.CentreFrais.ToString()))
            {
                return StatusCode(409, "Le Centre de frais est obligatoire");
            }
            if (String.IsNullOrEmpty(model.SourceSortie.ToString()))
            {
                model.SourceSortie = 10;
            }
            var StkReceptionBillette = _context.StkBonSortie
                .OrderBy(o => o.NumBonSortie)
                .Select(i => new
                {
                    i.NumBonSortie
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.NumBonSortie = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.NumBonSortie = Convert.ToInt32(m.NumBonSortie) + 1;
            }
            if (model.DateSortie.Equals(""))
                model.DateSortie = DateTime.Now;
            //if (SortieTableEmpty == 1)
            //   model.DateSortie = model.DateSortie.AddHours(1.0);
            model.CodeServiceEmetteur = XpertHelperGestionnaireMagasin.CodeMagasin;
            model.NumDemandeFourniture = XpertHelperGestionnaireMagasin.NumDemandeFournitureMagasin;
            var result = _context.StkBonSortie.Add(model);

            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.Operation = "Post/BS:Id=" + model.NumBonSortie;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);


            await _context.SaveChangesAsync();
            return Json(result.Entity.NumBonSortie);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetail(string values)
        {
            var model = new StkBonSortieArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonSortieArticles(model, valuesDict);
            model.DateSortie = model.DateSortie.Value.AddHours(12);
            model.NumBonSortie = XpertHelperGestionnaireMagasin.NumBonSortieMagasin;
            //chcek if emplacement Qte dispo
            var bonsortie = _context.StkBonSortie.AsNoTracking().Where(c => c.NumBonSortie == model.NumBonSortie).FirstOrDefault();
            var empl = _context.StkEmplacement.Where(c => c.CodePdr == model.CodeArticle && c.CodeLieu == bonsortie.SourceSortie).FirstOrDefault();
            if (empl == null)
                return StatusCode(409, "cette article n'est pas dans cette emplacement");
            if (empl.Qte - model.Qte < 0)
                return StatusCode(409, "la quantité disponible (" + empl.Qte + ") dans cette emplacement n'est pas suffisante");
            empl.Qte -= model.Qte;
            _context.StkEmplacement.Update(empl);
            //check preneur
            if (String.IsNullOrEmpty(model.CodePreneur.ToString()))
            {
                var Prenuers = _context.StkBonSortieArticles
                .AsNoTracking()
                .Where(c => c.NumBonSortie == model.NumBonSortie)
                .AsNoTracking()
                .Select(i => new
                {
                    i.CodePreneur
                }).ToList();
                if (Prenuers.Count() > 0)
                {
                    model.CodePreneur = Prenuers.First().CodePreneur;
                }
            }
            if (model.Qte <= 0)
            {
                return StatusCode(409, "Veuillez entrer une QTE supérieur à 0");
            }
            else
            {
                var StkReceptionBillette = _context.StkBonSortieArticles
                    .OrderBy(o => o.Id)
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();
                var StkBonSortie = _context.StkBonSortie
                    .OrderBy(o => o.NumBonSortie)
                    .Where(c => c.NumBonSortie == model.NumBonSortie)
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.DateSortie
                    }).Last();
                if (StkReceptionBillette.Count == 0)
                    model.Id = 1;
                else
                {
                    var m = StkReceptionBillette.Last();
                    model.Id = Convert.ToInt32(m.Id) + 1;
                }
                model.DateSortie = StkBonSortie.DateSortie;
                var DateBonSortie = _context.StkBonSortie
                .AsNoTracking()
                .OrderBy(o => o.NumBonSortie)
                .Where(c => c.NumBonSortie == model.NumBonSortie)
                .Select(i => new
                {
                    i.DateSortie
                }).ToList();
                if (model.CodeArticle.Equals(null))
                {
                    var StkBonEntreeArticles = _context.StkBonEntreeArticles
                    .Where(c => c.ArticleNonGere == model.ArticleNonGere)
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.PrixUnitaire,
                        i.QteRecu
                    }).ToList();
                    if (StkBonEntreeArticles.Equals(null) || StkBonEntreeArticles == null || StkBonEntreeArticles.Count() == 0)
                    {
                        IDictionary<string, double> WordsProbabilities = new Dictionary<string, double>();
                        string target1 = model.ArticleNonGere;
                        var articlesNonGere = _context.StkBonEntreeArticles
                        .AsNoTracking()
                        .Select(i => new
                        {
                            i.ArticleNonGere,
                            i.QteRecu
                        }).ToList();
                        List<string> sentences = new List<string>();
                        foreach (var item in articlesNonGere)
                        {
                            if(item.ArticleNonGere != null)
                                sentences.Add(item.ArticleNonGere);
                        }
                        var target1Splited = target1.Split(' ');
                        foreach (var i in target1Splited)
                        {
                            char[] chi = new char[i.Length];
                            for (int x = 0; x < i.Length; x++)
                            {
                                chi[x] = i[x];
                            }
                            double qt = 0.0;
                            int NbrSplit = 0;
                            foreach (var j in sentences)
                            {
                                var jSplited = j.Split(' ');
                                foreach (var splitedJ in jSplited)
                                {
                                    int Nbr = 0;
                                    char[] chj = new char[splitedJ.Length];
                                    for (int y = 0; y < splitedJ.Length; y++)
                                    {
                                        chj[y] = splitedJ[y];
                                    }
                                    int maxL = 0;
                                    if (chj.Length >= chi.Length)
                                    {
                                        maxL = chi.Length;
                                    }
                                    else
                                    {
                                        maxL = chj.Length;
                                    }
                                    for (int inc = 0; inc < maxL; inc++)
                                    {
                                        if (char.ToLower(chj[inc]).Equals(char.ToLower(chi[inc])))
                                        {
                                            Nbr++;
                                        }
                                    }
                                    double quatio = Math.Round((double)Nbr / i.Length, 2);
                                    qt += quatio;
                                    NbrSplit += Nbr;
                                }
                                bool keyExists = WordsProbabilities.ContainsKey(j);
                                if (keyExists)
                                {
                                    WordsProbabilities[j] += qt;
                                }
                                else
                                {
                                    WordsProbabilities.Add(j, qt);
                                }
                                NbrSplit = 0;
                                qt = 0;
                            }
                        }
                        var maxValue = WordsProbabilities.Values.Max();
                        var keyOfMaxValue = WordsProbabilities.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                        if (maxValue > 0.30)
                        {
                            return StatusCode(409, "Cette article non géré ne correspand à aucune entrée d'article non gérée, voulez vous dire :"+ keyOfMaxValue);
                        }
                        else
                        {
                            return StatusCode(409, "Cette article non géré ne correspand à aucune entrée d'article non gérée");
                        }
                    }
                    else
                    {
                        if (StkBonEntreeArticles.Last().QteRecu < model.Qte)
                        {
                            return StatusCode(409, "La Qte saisie ne doit pas dépasser la QTE reçu de cette artcile non géré ( "+ StkBonEntreeArticles.Last().QteRecu+" )");
                        }
                        else
                        {
                            model.PrixUnitaire = StkBonEntreeArticles.Last().PrixUnitaire;
                            model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
                            var Move = _context.StkMovements
                                .Where(c => c.ArticleNonGere == model.ArticleNonGere)
                                .Select(i => new
                                {
                                    i.StockTotalSythese,
                                    i.ValeurStockTotal,
                                    i.ValeurValorisation
                                }).ToList();
                            if (Move.Count() > 0)
                            {
                                StkMovements movement = new StkMovements();
                                movement.ArticleNonGere = model.ArticleNonGere;
                                movement.DateMovment = DateBonSortie.Last().DateSortie;
                                movement.Qte = model.Qte;
                                movement.PrixUnitaire = model.PrixUnitaire;
                                movement.Montant = model.Montant;
                                movement.TypeMovement = 3;// 2 pour les sorties
                                movement.IdDetail = model.Id;
                                if(Move.Last().StockTotalSythese - model.Qte < 0)
                                {
                                    return StatusCode(409, "La Qte saisie ne doit pas dépasser la QTE reçu de cette artcile non géré ( " + Move.Last().StockTotalSythese + " )");
                                }
                                movement.StockTotalSythese = Move.Last().StockTotalSythese - model.Qte;
                                movement.ValeurStockTotal = Move.Last().ValeurStockTotal - model.Montant;
                                movement.ValeurValorisation = Move.Last().ValeurValorisation;
                                var resultmovement = _context.StkMovements.Add(movement);
                            }
                            else
                            {
                                return StatusCode(409, "Vérifiez les movements de cette article NonGéré");
                            }
                        }
                    }
                }
                else
                {
                    var EntreesUniteMesure = _context.StkBonEntreeArticles
                        .Where(c => c.ArticleNonGere == model.ArticleNonGere)
                        .Select(i => new
                        {
                            i.UniteMesureArticleNonGere
                        }).ToList().Last();
                    model.UniteMesureArticleNonGere = EntreesUniteMesure.UniteMesureArticleNonGere;
                    // we work the movement 
                    //Calcul Valorisation
                    //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
                    var StkMovements = _context.StkMovements
                     .AsNoTracking()
                    .OrderBy(o => o.DateMovment)
                    .Where(c => c.CodePdr == model.CodeArticle  && c.DateMovment <= model.DateSortie)
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
                            return StatusCode(409, "La Pdr : " + model.CodeArticle + " n'as pas de stock initial (elle n'exite pas dans le Sotck)");
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
                                    // There is valorisation methode
                                    model.PrixUnitaire = StkStockInitial.Last().PrixUnitare;
                                    model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
                                    //Adding sorite to movement
                                    StkMovements movement = new StkMovements();
                                    movement.CodePdr = model.CodeArticle;
                                    movement.DateMovment = DateBonSortie.Last().DateSortie;
                                    movement.PrixUnitaire = model.PrixUnitaire;
                                    movement.Qte = model.Qte;
                                    movement.Montant = model.Montant;
                                    movement.TypeMovement = 3;// 3 pour les SORITES
                                    movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                                    movement.IdDetail = model.Id;
                                    ComputeValorisation(movement, 1);// Stock Initial
                                    //model.PrixUnitaire = movement.PrixUnitaire;
                                    //model.Montant = movement.Montant;
                                }
                            }
                        }
                    }
                    else
                    {
                        //Chek if there is enough
                        if ((StkMovements.Last().StockTotalSythese - model.Qte) < 0)
                        {
                            return StatusCode(409, "La Quantité saise  : " + model.Qte + " aura un effet négatif sur la QTE du stock (" + (StkMovements.Last().StockTotalSythese -model.Qte) + ")");
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
                            model.PrixUnitaire = StkMovements.Last().ValeurValorisation;
                            model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
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
                            movement.DateMovment = DateBonSortie.Last().DateSortie;
                            movement.PrixUnitaire = model.PrixUnitaire;
                            movement.Qte = model.Qte;
                            movement.Montant = model.Montant;
                            movement.TypeMovement = 3;// 3 pour les SORITES
                            movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                            movement.IdDetail = model.Id;
                            ComputeValorisation(movement, 2);// There is mouvements
                            //model.PrixUnitaire = movement.PrixUnitaire;
                            //model.Montant = movement.Montant;
                        }
                    }
                    //If movement computed succeully we add this article in StkBonSortieArticles

                    //Tracking
                    TrackingOperations OpTrack = new TrackingOperations();
                    var TrackingOperations = _context.TrackingOperations
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();
                    if (TrackingOperations.Count == 0)
                        OpTrack.Id = 1;
                    else
                    {
                        var mTrackingOperations = TrackingOperations.Last();
                        OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
                    }
                    OpTrack.IpAdress = OperationsTracker.GetIP2();
                    OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
                    OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
                    OpTrack.Operation = "Post/BSN°" + model.NumBonSortie + "/Detail:Id=" + model.Id;
                    OpTrack.DateOperation = DateTime.Now;
                    var resultOp = _context.TrackingOperations.Add(OpTrack);
                }
            }
            var result = _context.StkBonSortieArticles.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.StkBonSortie.FirstOrDefaultAsync(item => item.NumBonSortie == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonSortie(model, valuesDict);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Put/BS:Id=" + model.NumBonSortie;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetail(int key, string values)
        {
            var model = await _context.StkBonSortieArticles.FirstOrDefaultAsync(item => item.Id == key);
            var oldQte = model.Qte;
            var oldMontant = model.Montant;
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonSortieArticles(model, valuesDict);
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 3);
            modelMovement.PrixUnitaire = model.PrixUnitaire;
            modelMovement.Qte = model.Qte;
            modelMovement.Montant = model.Montant;
            if ((modelMovement.StockTotalSythese - oldQte) + model.Qte < 0)
            {
                return StatusCode(409, "Cette Quantité : " + model.Qte + " n'est pas disponnible, il reste : " + modelMovement.StockTotalSythese);
            }
            modelMovement.StockTotalSythese = (modelMovement.StockTotalSythese - oldQte) + model.Qte;
            modelMovement.ValeurStockTotal = (modelMovement.ValeurStockTotal - oldMontant) + model.Montant;
            modelMovement.ValeurValorisation = Math.Round((double)(modelMovement.ValeurStockTotal / modelMovement.StockTotalSythese), 2);
            _context.StkMovements.Update(modelMovement);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Put/BSN°" + model.NumBonSortie + "/Detail:Id=" + model.Id;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.StkBonSortie.FirstOrDefaultAsync(item => item.NumBonSortie == key);
            _context.StkBonSortie.Remove(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Delete/BS:Id=" + model.NumBonSortie;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetail(int key)
        {
            var model = await _context.StkBonSortieArticles.FirstOrDefaultAsync(item => item.Id == key);
            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 3);
            _context.StkMovements.Remove(modelMovement);
            _context.StkBonSortieArticles.Remove(model);
            //Tracking
            TrackingOperations OpTrack = new TrackingOperations();
            var TrackingOperations = _context.TrackingOperations
            .AsNoTracking()
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (TrackingOperations.Count == 0)
                OpTrack.Id = 1;
            else
            {
                var mTrackingOperations = TrackingOperations.Last();
                OpTrack.Id = Convert.ToInt32(mTrackingOperations.Id) + 1;
            }
            OpTrack.IpAdress = OperationsTracker.GetIP2();
            OpTrack.MaccAdress = OperationsTracker.GetMacByIP(OpTrack.IpAdress);
            OpTrack.IpAdress = OperationsTracker.GetIP(OpTrack.IpAdress);
            OpTrack.Operation = "Delete/BSN°" + model.NumBonSortie + "/Detail:Id=" + model.Id;
            OpTrack.DateOperation = DateTime.Now;
            var resultOp = _context.TrackingOperations.Add(OpTrack);

            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> TypeSortieLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupTypeBonSorie
                         orderby i.CodeTypeSortie
                         select new
                         {
                             Value = i.CodeTypeSortie,
                             Text = i.DesignationTypeSortie
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> CodePreneurLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Nom
                         //where i.Disponnible != 3 && i.Disponnible != null
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> CentreFraisLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkCentreFrais
                         orderby i.CodeCentreFrais
                         select new
                         {
                             Value = i.CodeCentreFrais,
                             Text = i.DesignationCentreFrais
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> IntervenantLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Nom
                         where i.Departement == XpertHelperGestionnaireMagasin.CodeMagasin && i.Disponnible != 3 && i.Disponnible != null
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
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
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment> model.DateMovment)
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
                    i.StockTotalSythese,
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                }).ToList();
                // in Sortie PU becomes Valeur de Valorisation
                model.PrixUnitaire = (double)StkMovements.Last().ValeurValorisation;
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
                .OrderBy(o => o.IdMovement)
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
        private void PopulateModelStkBonSortie(StkBonSortie model, IDictionary values)
        {
            string CodeIntervenant = nameof(StkBonSortie.CodeIntervenant);
            string CodeServiceEmetteur = nameof(StkBonSortie.CodeServiceEmetteur);
            string DateSortie = nameof(StkBonSortie.DateSortie);
            string TypeSortie = nameof(StkBonSortie.TypeSortie);
            string CentreFrais = nameof(StkBonSortie.CentreFrais);
            string CodeEmetteur = nameof(StkBonSortie.CodeEmetteur);
            string SourceSortie = nameof(StkBonSortie.SourceSortie);
            if (values.Contains(SourceSortie))
            {
                model.SourceSortie = Convert.ToInt32(values[SourceSortie]);
            }
            if (values.Contains(DateSortie))
            {
                model.DateSortie = Convert.ToDateTime(values[DateSortie]);
            }
            if (values.Contains(TypeSortie))
            {
                model.TypeSortie = Convert.ToInt32(values[TypeSortie]);
            }
            if (values.Contains(CodeEmetteur))
            {
                model.CodeEmetteur = Convert.ToInt32(values[CodeEmetteur]);
            }
            if (values.Contains(CodeServiceEmetteur))
            {
                model.CodeServiceEmetteur = Convert.ToInt32(values[CodeServiceEmetteur]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
            if (values.Contains(CentreFrais))
            {
                model.CentreFrais = Convert.ToInt32(values[CentreFrais]);
            }
        }
        private void PopulateModelStkBonSortieArticles(StkBonSortieArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkBonSortieArticles.CodeArticle);
            string PrixUnitaire = nameof(StkBonSortieArticles.PrixUnitaire);
            string CodePreneur = nameof(StkBonSortieArticles.CodePreneur);
            string LieuDemandé = nameof(StkBonSortieArticles.LieuDemandé);
            string DateSortie = nameof(StkBonSortieArticles.DateSortie);
            string Qte = nameof(StkBonSortieArticles.Qte);
            string ArticleNonGere = nameof(StkBonSortieArticles.ArticleNonGere);
            if (values.Contains(DateSortie))
            {
                model.DateSortie = Convert.ToDateTime(values[DateSortie]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToDouble(values[Qte]);
            }
            if (values.Contains(PrixUnitaire))
            {
                model.PrixUnitaire = Convert.ToInt32(values[PrixUnitaire]);
            }
            if (values.Contains(CodePreneur))
            {
                model.CodePreneur = Convert.ToInt32(values[CodePreneur]);
            }
            if (values.Contains(LieuDemandé))
            {
                model.LieuDemandé = Convert.ToString(values[LieuDemandé]);
            }
            if (values.Contains(ArticleNonGere))
            {
                model.ArticleNonGere = Convert.ToString(values[ArticleNonGere]);
            }
            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
        }
    }
}
