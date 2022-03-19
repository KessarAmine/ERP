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

    public class DechargeController : Controller
    {
        private KBFsteelContext _context;
        public DechargeController(KBFsteelContext context)
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
        public async Task<IActionResult> GetDecharge(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkDecharge
                .Where(c => c.DateDecharge.Date >= dateDebut.Date && c.DateDecharge.Date <= dateFin.Date)
                .Select(i => new {
                    i.DateDecharge,
                    i.NumDecharge,
                    i.ServiceReceveur,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDechargeDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDecharge = id;
            var StkAffectations = _context.StkDechargeArticles
                .Where(c => c.NumDecharge == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.Qte,
                    i.NumDecharge,
                    i.Observation,
                    i.DateDecharge
                });
            
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostDecharge(string values)
        {
            var model = new StkDecharge();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDecharge(model, valuesDict);
            var StkDecharge = _context.StkDecharge
                .OrderBy(o => o.NumDecharge)
                .Select(i => new
                {
                    i.NumDecharge
                }).ToList();
            if (StkDecharge.Count == 0)
                model.NumDecharge = 1;
            else
            {
                var m = StkDecharge.Last();
                model.NumDecharge = Convert.ToInt32(m.NumDecharge) + 1;
            }
            if (model.DateDecharge.Equals(""))
                model.DateDecharge = DateTime.Now.Date;

            var result = _context.StkDecharge.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumDecharge);
        }
        [HttpPost]
        public async Task<IActionResult> PostDechargeDetails(string values)
        {
            var model = new StkDechargeArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDechargeArticles(model, valuesDict);
            var StkDecharge = _context.StkDecharge
                .Where(o => o.NumDecharge == XpertHelper.NumDecharge)
                .Select(i => new
                {
                    i.DateDecharge
                }).ToList();
            var StkDechargeArticles = _context.StkDechargeArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkDechargeArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkDechargeArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.DateDecharge = StkDecharge.Last().DateDecharge;
            model.NumDecharge = XpertHelper.NumDecharge;
            //ADD TO MOVEMENTS
            var NumDecharge = _context.StkDecharge
            .AsNoTracking()
            .OrderBy(o => o.NumDecharge)
            .Where(c => c.NumDecharge == model.NumDecharge)
            .Select(i => new
            {
                i.DateDecharge
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
                            // There is valorisation methode
                            //Adding sorite to movement
                            StkMovements movement = new StkMovements();
                            movement.CodePdr = model.CodeArticle;
                            movement.DateMovment = NumDecharge.Last().DateDecharge;
                            movement.Qte = model.Qte;
                            movement.TypeMovement = 5;
                            movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                            movement.IdDetail = model.Id;
                            ComputeValorisation(movement, 1);
                            var resultmovement = _context.StkMovements.Add(movement);
                        }
                    }
                }
            }
            else
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
                //Chek if there is enough
                if (StkMovements.Last().StockTotalSythese - model.Qte < 0 )
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
                    movement.CodePdr = model.CodeArticle;
                    movement.DateMovment = NumDecharge.Last().DateDecharge;
                    movement.Qte = model.Qte;
                    movement.TypeMovement = 5;
                    movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                    movement.IdDetail = model.Id;
                    ComputeValorisation(movement, 2);
                    var resultmovement = _context.StkMovements.Add(movement);
                }
            }
            var result = _context.StkDechargeArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutDecharge(int key, string values)
        {
            var model = await _context.StkDecharge.FirstOrDefaultAsync(item => item.NumDecharge == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDecharge(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDechargeDetails(int key, string values)
        {
            var model = await _context.StkDechargeArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var oldQte = model.Qte;
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDechargeArticles(model, valuesDict);
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 5);
            if(modelMovement != null)
            {
                modelMovement.Qte = model.Qte;
                if ((modelMovement.StockTotalSythese + oldQte) - model.Qte < 0)
                {
                    return StatusCode(409, "Cette Quantité : " + model.Qte + " n'est pas disponnible, il reste : " + modelMovement.StockTotalSythese + oldQte);
                }
                modelMovement.StockTotalSythese = (modelMovement.StockTotalSythese - oldQte) + model.Qte;
                modelMovement.ValeurStockTotal = (modelMovement.ValeurStockTotal - (oldQte * modelMovement.PrixUnitaire)) + (model.Qte * modelMovement.PrixUnitaire);
                modelMovement.ValeurValorisation = Math.Round((double)(modelMovement.ValeurStockTotal / modelMovement.StockTotalSythese), 2);
                _context.StkMovements.Update(modelMovement);
            }
            else
            {
                return StatusCode(409, "movement inrrouvable vérifiez votre base de données");
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task<IActionResult> DeleteDecharge(int key)
        {
            var model = await _context.StkDecharge.FirstOrDefaultAsync(item => item.NumDecharge == key);
            var details = _context.StkDechargeArticles.Where(item => item.NumDecharge == key).ToList();
            if (details.Count > 0)
                return StatusCode(409, "Non autorisé : vueillez suprimmer les détails avant");
            _context.StkDecharge.Remove(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteDechargeDetails(int key)
        {
            var model = await _context.StkDechargeArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkDechargeArticles.Remove(model);
            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 5);
            if(modelMovement != null)
            {
                _context.StkMovements.Remove(modelMovement);
            }
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
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
                model.StockTotalSythese = (model.StockTotalSythese * -1) + StkStockInitial.Last().Qte;
                model.ValeurStockTotal = Math.Round((double)(model.ValeurStockTotal * -1) + (StkStockInitial.Last().Qte * StkStockInitial.Last().PrixUnitare), 2);
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
                // in Sortie PU becomes Valeur de Valorisation
                model.PrixUnitaire = (double)StkMovements.Last().ValeurValorisation;
                model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
                model.StockTotalSythese = (model.StockTotalSythese * -1) + StkMovements.Last().StockTotalSythese;
                model.ValeurStockTotal = Math.Round((double)((model.ValeurStockTotal * -1) + StkMovements.Last().ValeurStockTotal) - model.Montant, 2);
                model.ValeurValorisation = Math.Round((double)StkMovements.Last().ValeurValorisation, 2);
            }
        }

        //=================================================PopulateModels===================================
        private void PopulateModelDecharge(StkDecharge model, IDictionary values)
        {
            string DateDecharge = nameof(StkDecharge.DateDecharge);
            string ServiceReceveur = nameof(StkDecharge.ServiceReceveur);
            string CodeIntervenant = nameof(StkDecharge.CodeIntervenant);
            if (values.Contains(DateDecharge))
            {
                model.DateDecharge = Convert.ToDateTime(values[DateDecharge]);
            }
            if (values.Contains(ServiceReceveur))
            {
                model.ServiceReceveur = Convert.ToInt32(values[ServiceReceveur]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
        }
        private void PopulateModelDechargeArticles(StkDechargeArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkDechargeArticles.CodeArticle);
            string Qte = nameof(StkDechargeArticles.Qte);
            string Observation = nameof(StkDechargeArticles.Observation); 
            string DateDecharge = nameof(StkDechargeArticles.DateDecharge); 
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
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }
            if (values.Contains(DateDecharge))
            {
                model.DateDecharge = Convert.ToDateTime(values[DateDecharge]);
            }
        }
    }
}
