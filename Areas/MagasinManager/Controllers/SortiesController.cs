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
using DevKbfSteel.Areas.MagasinManager.Models;

namespace DevKbfSteel.Areas.MagasinManager.Controllers
{
    [Area(nameof(Areas.MagasinManager))]

    public class SortiesController : Controller
    {
        private KBFsteelContext _context;
        public SortiesController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> GetFromDemandeFourniture(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDemandeFournitureMagasin = id;
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
                    i.NumBonSortie,
                    i.CodeIntervenant,
                    i.CodeServiceEmetteur,
                    i.DateSortie,
                    i.NumDemandeFourniture,
                    i.TypeSortie,
                    i.CentreFrais
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonSortie, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumBonSortieMagasin = id;
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
                    i.Qte
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
            model.DateSortie = DateTime.Now.Date;
            model.CodeServiceEmetteur = XpertHelper.CodeMagasin;
            model.NumDemandeFourniture = XpertHelper.NumDemandeFournitureMagasin;
            var result = _context.StkBonSortie.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumBonSortie);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetail(string values)
        {
            var model = new StkBonSortieArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonSortieArticles(model, valuesDict);
            var StkReceptionBillette = _context.StkBonSortieArticles
                .OrderBy(o => o.Id)
                .AsNoTracking()
                .Select(i => new
                {
                    i.Id
                }).ToList();                    
            var StkBonSortie = _context.StkBonSortie
                .OrderBy(o => o.NumBonSortie)
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
            model.NumBonSortie = XpertHelper.NumBonSortieMagasin;
            var DateBonSortie = _context.StkBonSortie
            .AsNoTracking()
            .OrderBy(o => o.NumBonSortie)
            .Where(c => c.NumBonSortie == model.NumBonSortie)
            .Select(i => new
            {
                i.DateSortie
            }).ToList();
            // we work the movement 
            //Calcul Valorisation
            //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
            var StkMovements = _context.StkMovements
             .AsNoTracking()
            .OrderBy(o => o.IdMovement)
            .Where(c => c.CodePdr == model.CodeArticle)
            .Select(i => new
            {
                i.IdMovement,
                i.StockTotalSythese
            }).ToList();
            if(StkMovements.Count == 0){
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
                    return StatusCode(409, "La Pdr : "+ model.CodeArticle + " n'as pas de stock initial");
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
                            var MovementsList = _context.StkMovements
                            .AsNoTracking()
                            .OrderBy(o => o.IdMovement)
                            .Select(i => new
                            {
                                i.IdMovement
                            }).ToList();
                            if (MovementsList.Count == 0)
                                movement.IdMovement = 1;
                            else
                            {
                                var m = MovementsList.Last();
                                movement.IdMovement = Convert.ToInt32(m.IdMovement) + 1;
                            }
                            movement.CodePdr = model.CodeArticle;
                            movement.DateMovment = DateBonSortie.Last().DateSortie;
                            movement.PrixUnitaire = model.PrixUnitaire;
                            movement.Qte = model.Qte;
                            movement.Montant = model.Montant;
                            movement.TypeMovement = 3;// 3 pour les SORITES
                            movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                            movement.IdDetail = model.Id;
                            ComputeValorisation(movement, 1);// Stock Initial
                            var resultmovement = _context.StkMovements.Add(movement);
                            model.PrixUnitaire = movement.PrixUnitaire;
                            model.Montant = movement.Montant;
                        }
                    }
                }
            }
            else
            {
                //Chek if there is enough
                if(model.Qte >= StkMovements.Last().StockTotalSythese){
                    return StatusCode(409, "La Quantité saise  : " + model.Qte + " est (supérieur/égale) à la quantité disponnible ("+ StkMovements.Last().StockTotalSythese+")");
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
                    var MovementsList = _context.StkMovements
                    .AsNoTracking()
                    .OrderBy(o => o.IdMovement)
                    .Select(i => new
                    {
                        i.IdMovement
                    }).ToList();
                    if (MovementsList.Count == 0)
                        movement.IdMovement = 1;
                    else
                    {
                        var m = MovementsList.Last();
                        movement.IdMovement = Convert.ToInt32(m.IdMovement) + 1;
                    }
                    movement.CodePdr = model.CodeArticle;
                    movement.DateMovment = DateBonSortie.Last().DateSortie;
                    movement.PrixUnitaire = model.PrixUnitaire;
                    movement.Qte = model.Qte;
                    movement.Montant = model.Montant;
                    movement.TypeMovement = 3;// 3 pour les SORITES
                    movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                    movement.IdDetail = model.Id;
                    ComputeValorisation(movement, 2);// There is mouvements
                    var resultmovement = _context.StkMovements.Add(movement);
                    model.PrixUnitaire = movement.PrixUnitaire;
                    model.Montant = movement.Montant;
                }
            }
            //If movement computed succeully we add this article in StkBonSortieArticles
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
            if((modelMovement.StockTotalSythese - oldQte) + model.Qte < 0)
            {
                return StatusCode(409, "Cette Quantité : " + model.Qte + " n'est pas disponnible, il reste : "+ modelMovement.StockTotalSythese);
            }
            modelMovement.StockTotalSythese =(modelMovement.StockTotalSythese - oldQte)+ model.Qte;
            modelMovement.ValeurStockTotal = (modelMovement.ValeurStockTotal - oldMontant) + model.Montant;
            modelMovement.ValeurValorisation = Math.Round((double)(modelMovement.ValeurStockTotal / modelMovement.StockTotalSythese), 2);
            _context.StkMovements.Update(modelMovement);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.StkBonSortie.FirstOrDefaultAsync(item => item.NumBonSortie == key);
            _context.StkBonSortie.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetail(int key)
        {
            var model = await _context.StkBonSortieArticles.FirstOrDefaultAsync(item => item.Id == key);
            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 3);
            _context.StkMovements.Remove(modelMovement);
            _context.StkBonSortieArticles.Remove(model);
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
                         orderby i.Id
                         where i.Disponnible != 3 && i.Disponnible != null
                         select new
                         {
                             Value = i.Id,
                             Text = i.Prenom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> IntervenantLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         where i.Departement == XpertHelper.CodeMagasin && i.Disponnible != 3 && i.Disponnible != null
                         select new
                         {
                             Value = i.Id,
                             Text = i.Prenom
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
                model.StockTotalSythese = (model.StockTotalSythese *-1) + StkStockInitial.Last().Qte;
                model.ValeurStockTotal = Math.Round((double)(model.ValeurStockTotal * -1) + (StkStockInitial.Last().PrixUnitare*StkStockInitial.Last().Qte),2);
                model.ValeurValorisation = Math.Round(StkStockInitial.Last().PrixUnitare, 2);
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
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                }).ToList();
                // in Sortie PU beomes Valeur de Valorisation
                model.PrixUnitaire = (double)StkMovements.Last().ValeurValorisation;
                model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
                model.StockTotalSythese = (model.StockTotalSythese * -1) + StkMovements.Last().StockTotalSythese;
                model.ValeurStockTotal = Math.Round((double)((model.ValeurStockTotal * -1) + StkMovements.Last().ValeurStockTotal) - model.Montant,2) ;
                model.ValeurValorisation = Math.Round((double)StkMovements.Last().ValeurValorisation, 2);
            }
        }
        private void PopulateModelStkBonSortie(StkBonSortie model, IDictionary values)
        {
            string CodeIntervenant = nameof(StkBonSortie.CodeIntervenant);
            string CodeServiceEmetteur = nameof(StkBonSortie.CodeServiceEmetteur);
            string DateSortie = nameof(StkBonSortie.DateSortie);
            string TypeSortie = nameof(StkBonSortie.TypeSortie);
            string CentreFrais = nameof(StkBonSortie.CentreFrais);
            if (values.Contains(DateSortie))
            {
                model.DateSortie = Convert.ToDateTime(values[DateSortie]);
            }
            if (values.Contains(TypeSortie))
            {
                model.TypeSortie = Convert.ToInt32(values[TypeSortie]);
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
            if (values.Contains(DateSortie))
            {
                model.DateSortie = Convert.ToDateTime(values[DateSortie]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
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
            if (values.Contains(CodeArticle))
            {
                model.CodeArticle = Convert.ToInt32(values[CodeArticle]);
            }
        }
    }
}
