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

    public class RestitutionController : Controller
    {
        private KBFsteelContext _context;
        public RestitutionController(KBFsteelContext context)
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
        public async Task<IActionResult> GetRestitution(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperMagasinSuperviseur.NumDecharge = id;
            var StkRestitution = _context.StkRestitution
                .Where(c => c.NumDecharge == id)
                .Select(i => new {
                    i.DateRestitution,
                    i.NumDecharge,
                    i.NumRestitution,
                    i.ServiceEmetteur,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkRestitution, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetRestitutionDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelperMagasinSuperviseur.NumRestitution = id;
            var StkAffectations = _context.StkRestitutionArticles
                .Where(c => c.NumRestitution == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.Qte,
                    i.NumRestitution,
                    i.Observation,
                    i.DateRestitution
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostRestitution(string values)
        {
            var model = new StkRestitution();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitution(model, valuesDict);
            var StkRestitution = _context.StkRestitution
                .OrderBy(o => o.NumRestitution)
                .Select(i => new
                {
                    i.NumRestitution
                }).ToList();

            if (StkRestitution.Count == 0)
                model.NumRestitution = 1;
            else
            {
                var m = StkRestitution.Last();
                model.NumRestitution = Convert.ToInt32(m.NumRestitution) + 1;
            }
            model.NumDecharge = XpertHelperMagasinSuperviseur.NumDecharge;
            var result = _context.StkRestitution.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumRestitution);
        }
        [HttpPost]
        public async Task<IActionResult> PostRestitutionDetails(string values)
        {
            StkMovements movement = new StkMovements();
            var model = new StkRestitutionArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitutionArticles(model, valuesDict);
            var StkRestitution = _context.StkRestitution
                .Where(c => c.NumDecharge == XpertHelperMagasinSuperviseur.NumDecharge)
                .Select(i => new {
                    i.DateRestitution
                }).ToList().Last();
            var StkRestitutionArticles = _context.StkRestitutionArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkRestitutionArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkRestitutionArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.DateRestitution = StkRestitution.DateRestitution;
            model.NumRestitution = XpertHelperMagasinSuperviseur.NumRestitution;
            //ADD TO MOVEMENTS
            var DateRestitution = _context.StkRestitution
            .AsNoTracking()
            .OrderBy(o => o.NumRestitution)
            .Where(c => c.NumRestitution == model.NumRestitution)
            .Select(i => new
            {
                i.DateRestitution
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
                        model.PrixUnitaire = StkStockInitial.Last().PrixUnitare;
                        model.Montant = Math.Round((double)(model.PrixUnitaire * model.Qte), 2);
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
                            //Adding  to movement
                            movement.PrixUnitaire = (double)model.PrixUnitaire;
                            movement.Montant = (double)model.Montant;
                            movement.CodePdr = model.CodeArticle;
                            movement.DateMovment = DateRestitution.Last().DateRestitution;
                            movement.Qte = model.Qte;
                            movement.TypeMovement = 7;
                            movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                            movement.IdDetail = model.Id;
                            ComputeCMUP(movement, 1);
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
                    movement.PrixUnitaire = (double)model.PrixUnitaire;
                    movement.Montant = (double)model.Montant;
                    movement.CodePdr = model.CodeArticle;
                    movement.DateMovment = DateRestitution.Last().DateRestitution;
                    movement.Qte = model.Qte;
                    movement.TypeMovement = 7;
                    movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                    movement.IdDetail = model.Id;
                    ComputeCMUP(movement, 2);//Case = 2 car on est dans le cas ou EN as deja un mouvement
                }
            }

            var resultmovement = _context.StkMovements.Add(movement);
            var result = _context.StkRestitutionArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutRestitution(int key, string values)
        {
            var model = await _context.StkRestitution.FirstOrDefaultAsync(item => item.NumRestitution == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitution(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutRestitutionDetails(int key, string values)
        {
            var model = await _context.StkRestitutionArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var oldQte = model.Qte;
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitutionArticles(model, valuesDict);
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 7);
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
        public async Task<IActionResult> DeleteRestitution(int key)
        {
            var model = await _context.StkRestitution.FirstOrDefaultAsync(item => item.NumRestitution == key);
            var details = _context.StkRestitutionArticles.Where(item => item.NumRestitution == key).ToList();
            if (details.Count > 0)
                return StatusCode(409, "Non autorisé : vueillez suprimmer les détails avant");
            _context.StkRestitution.Remove(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteRestitutionDetails(int key)
        {
            var model = await _context.StkRestitutionArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkRestitutionArticles.Remove(model);
            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 7);
            if(modelMovement != null)
                _context.StkMovements.Remove(modelMovement);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
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

        //=================================================PopulateModels===================================
        private void PopulateModelRestitution(StkRestitution model, IDictionary values)
        {
            string DateRestitution = nameof(StkRestitution.DateRestitution);
            string ServiceEmetteur = nameof(StkRestitution.ServiceEmetteur);
            string CodeIntervenant = nameof(StkRestitution.CodeIntervenant);
            if (values.Contains(DateRestitution))
            {
                model.DateRestitution = Convert.ToDateTime(values[DateRestitution]);
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
        private void PopulateModelRestitutionArticles(StkRestitutionArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkRestitutionArticles.CodeArticle);
            string Qte = nameof(StkRestitutionArticles.Qte);
            string Observation = nameof(StkRestitutionArticles.Observation); 
            string DateRestitution = nameof(StkRestitutionArticles.DateRestitution); 
            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(DateRestitution))
            {
                model.DateRestitution = Convert.ToDateTime(values[DateRestitution]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }
        }
    }
}
