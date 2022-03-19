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
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkStockInitial = _context.StkBonEntree
                .Where(c => c.DateEntree.Date >= dateDebut.Date && c.DateEntree.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumBon,
                    i.DateEntree,
                    i.CodeFournisseur,
                    i.DateDa,
                    i.Nda,
                    i.TypeAchat,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkStockInitial, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumBonEntreeMagasin = id;
            var StkStockInitial = _context.StkBonEntreeArticles
                .Where(c => c.NumBonEntree == id)
                .Select(i => new {
                    i.CodePdr,
                    i.Id,
                    i.Montant,
                    i.NumBonEntree,
                    i.PrixUnitaire,
                    i.QteRecu
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
            model.DateEntree = DateTime.Now.Date;

            var result = _context.StkBonEntree.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumBon);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetail(string values)
        {
            var model = new StkBonEntreeArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonEntreeArticles(model, valuesDict);
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
            model.NumBonEntree = XpertHelper.NumBonEntreeMagasin;
            model.Montant = Math.Round(model.QteRecu * model.PrixUnitaire,2);

            // we work the movement 
            var DateBonEntree = _context.StkBonEntree
            .AsNoTracking()
            .OrderBy(o => o.NumBon)
            .Where(c => c.NumBon == model.NumBonEntree)
            .Select(i => new
            {
                i.DateEntree
            }).ToList();
            //Calcul Valorisation
            //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
            var StkMovements = _context.StkMovements
             .AsNoTracking()
            .OrderBy(o => o.IdMovement)
            .Where(c => c.CodePdr == model.CodePdr)
            .Select(i => new
            {
                i.IdMovement
            }).ToList();
            if(StkMovements.Count == 0){
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
                    return StatusCode(409, "La Pdr : "+ model.CodePdr+ " n'as pas de stock initial");
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
                            movement.CodePdr = model.CodePdr;
                            movement.DateMovment = DateBonEntree.Last().DateEntree;
                            movement.PrixUnitaire = model.PrixUnitaire;
                            movement.Qte = model.QteRecu;
                            movement.Montant = model.Montant;
                            movement.TypeMovement = 2;// 2 pour les entrees
                            movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                            movement.IdDetail = model.Id;
                            ComputeCMUP(movement,1);//Case = 1 car on est dans le cas ou en calcul apres un stock intiial premeir mouvement
                            var resultmovement = _context.StkMovements.Add(movement);
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
                if (pdrValorisation.Count == 0)
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
                        movement.CodePdr = model.CodePdr;
                        movement.DateMovment = DateBonEntree.Last().DateEntree;
                        movement.PrixUnitaire = model.PrixUnitaire;
                        movement.Qte = model.QteRecu;
                        movement.Montant = model.Montant;
                        movement.TypeMovement = 2;// 2 pour les entrees
                        movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                        movement.IdDetail = model.Id;
                        ComputeCMUP(movement, 2);//Case = 2 car on est dans le cas ou EN as deja un mouvement
                        var resultmovement = _context.StkMovements.Add(movement);
                    }
                    else
                    {
                        return StatusCode(409, "Ce type de valorisation : " + MethodeValorisation.Last().DesignationValorisation + " n'est pas prit en charge");
                    }
                }
            }
            //If movement computed succeully we add this article in bonEntreeDetail
            var result = _context.StkBonEntreeArticles.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.StkBonEntree.FirstOrDefaultAsync(item => item.NumBon == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkBonEntree(model, valuesDict);
            await _context.SaveChangesAsync();
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
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 2);
            modelMovement.PrixUnitaire = model.PrixUnitaire;
            modelMovement.Qte = model.QteRecu;
            modelMovement.Montant = model.Montant;
            if ((modelMovement.StockTotalSythese - oldQte) + model.QteRecu < 0)
            {
                return StatusCode(409, "Cette Quantité : " + model.QteRecu + " n'est pas disponnible, il reste : " + modelMovement.StockTotalSythese);
            }
            modelMovement.StockTotalSythese =(modelMovement.StockTotalSythese - oldQte)+ model.QteRecu;
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
            var model = await _context.StkBonEntree.FirstOrDefaultAsync(item => item.NumBon == key);
            _context.StkBonEntree.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetail(int key)
        {
            var model = await _context.StkBonEntreeArticles.FirstOrDefaultAsync(item => item.Id == key);
            var modelMovement = await _context.StkMovements.FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 2);
            _context.StkMovements.Remove(modelMovement);
            _context.StkBonEntreeArticles.Remove(model);
            await _context.SaveChangesAsync();
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
                model.ValeurStockTotal += StkStockInitial.Last().Qte * StkStockInitial.Last().PrixUnitare;
            }
            //If case = 2 we get last movement
            if (Case == 2)
            {
                var StkMovements = _context.StkMovements
                .OrderBy(o => o.IdMovement)
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment.Date < model.DateMovment.Date)
                .Select(i => new
                {
                    i.IdMovement,
                    i.StockTotalSythese,
                    i.ValeurStockTotal
                }).ToList();
                model.StockTotalSythese += StkMovements.Last().StockTotalSythese;
                model.ValeurStockTotal += StkMovements.Last().ValeurStockTotal;
            }
            model.ValeurValorisation = Math.Round((double)(model.ValeurStockTotal / model.StockTotalSythese), 2);
        }
        private void PopulateModelStkBonEntree(StkBonEntree model, IDictionary values)
        {
            string CodeFournisseur = nameof(StkBonEntree.CodeFournisseur);
            string DateDa = nameof(StkBonEntree.DateDa);
            string DateEntree = nameof(StkBonEntree.DateEntree);
            string Nda = nameof(StkBonEntree.Nda);
            string TypeAchat = nameof(StkBonEntree.TypeAchat);
            string CodeIntervenant = nameof(StkBonEntree.CodeIntervenant);
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
            if (values.Contains(TypeAchat))
            {
                model.TypeAchat = Convert.ToInt32(values[TypeAchat]);
            }
            if (values.Contains(CodeFournisseur))
            {
                var CodePdrvar = values[CodeFournisseur].ToString().Trim('"');
                var SplitThefirst = CodePdrvar.Split("FR");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0].Split("\"");
                var elee = CodePdrSplited[0];
                model.CodeFournisseur = Convert.ToString("FR"+ elee);
            }
        }
        private void PopulateModelStkBonEntreeArticles(StkBonEntreeArticles model, IDictionary values)
        {
            string CodePdr = nameof(StkBonEntreeArticles.CodePdr);
            string PrixUnitaire = nameof(StkBonEntreeArticles.PrixUnitaire);
            string QteRecu = nameof(StkBonEntreeArticles.QteRecu);
            if (values.Contains(QteRecu))
            {
                model.QteRecu = Convert.ToInt32(values[QteRecu]);
            }
            if (values.Contains(PrixUnitaire))
            {
                model.PrixUnitaire = Convert.ToInt32(values[PrixUnitaire]);
            }
            if (values.Contains(CodePdr))
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
