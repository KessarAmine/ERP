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
using DevKbfSteel.Areas.MagasinSuperviseur.Controllers;
using System.Text;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class StkAffectationsController : Controller
    {
        private KBFsteelContext _context;
        public StkAffectationsController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBonAffectation(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkAffectations
                .OrderBy(o => o.DateAffectation)
                .Where(c => c.DateAffectation.Date >= dateDebut.Date && c.DateAffectation.Date <= dateFin.Date)
                .Select(i => new {
                    i.DateAffectation,
                    i.DateEntree,
                    i.NumBonAffectation,
                    i.NumBonEntree,
                    i.SericeEmetteur,
                    i.ServiceReceveur,
                    i.CodeIntervenant
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetBonAffectationBonEntreeSuperviseur(int NumBonEntree, DataSourceLoadOptions loadOptions)
        {
            XpertHelperMagasinSuperviseur.NumBonEntreeMagasin = NumBonEntree;
            var StkAffectations = _context.StkAffectations
                .Where(c => c.NumBonEntree == NumBonEntree)
                .Select(i => new {
                    i.DateAffectation,
                    i.DateEntree,
                    i.NumBonAffectation,
                    i.NumBonEntree,
                    i.SericeEmetteur,
                    i.ServiceReceveur,
                    i.CodeIntervenant
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetBonAffectationBonEntreeGestionnaire(int NumBonEntree, DataSourceLoadOptions loadOptions)
        {
            XpertHelperGestionnaireMagasin.NumBonEntreeMagasin = NumBonEntree;
            var StkAffectations = _context.StkAffectations
                .Where(c => c.NumBonEntree == NumBonEntree)
                .Select(i => new {
                    i.DateAffectation,
                    i.DateEntree,
                    i.NumBonAffectation,
                    i.NumBonEntree,
                    i.SericeEmetteur,
                    i.ServiceReceveur,
                    i.CodeIntervenant
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetBonAffectationArticlesSuperviseur(int numBonAffectation, DataSourceLoadOptions loadOptions)
        {
            XpertHelperMagasinSuperviseur.NumBonAffectationMagasin = numBonAffectation;
            //checkAllAffectationsSuperviseur();
            var StkAffectationsArticles = _context.StkAffectationsArticles
                .Where(c => c.NumBonAffectation == numBonAffectation)
                .Select(i => new {
                    i.CodePdr,
                    i.Id,
                    i.NumBonAffectation,
                    i.Qte
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkAffectationsArticles, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetBonAffectationArticlesGestionnaire(int numBonAffectation, DataSourceLoadOptions loadOptions)
        {
            XpertHelperGestionnaireMagasin.NumBonAffectationMagasin = numBonAffectation;
            var StkAffectationsArticles = _context.StkAffectationsArticles
                .Where(c => c.NumBonAffectation == numBonAffectation)
                .Select(i => new {
                    i.CodePdr,
                    i.Id,
                    i.NumBonAffectation,
                    i.Qte
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(StkAffectationsArticles, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostBonAffectationGestionnaire(string values)
        {
            var model = new StkAffectations();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkAffectations(model, valuesDict);
            model.SericeEmetteur = XpertHelper.CodeMagasin;
            var StkBonEntree = _context.StkBonEntree
            .Where(o => o.NumBon == model.NumBonEntree)
            .Select(i => new
            {
                i.DateEntree
            }).ToList();
            if (StkBonEntree.Count() > 0)
            {
                var lastStkBonEntree = StkBonEntree.Last();
                model.DateEntree = lastStkBonEntree.DateEntree;
            }
            else
            {
                return StatusCode(409, "La BE N° : " + model.NumBonEntree + " est introuvable");
            }
            //model.DateAffectation = DateTime.Now.Date;
            XpertHelperGestionnaireMagasin.NumBonAffectationMagasin = model.NumBonAffectation;
            var result = _context.StkAffectations.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonAffectation);
        }
        [HttpPost]
        public async Task<IActionResult> PostBonAffectationSuperviseur(string values)
        {
            var model = new StkAffectations();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkAffectations(model, valuesDict);
            var StkBonEntree = _context.StkBonEntree
            .Where(o => o.NumBon == model.NumBonEntree)
            .Select(i => new
            {
                i.DateEntree
            }).ToList();
            if (StkBonEntree.Count() > 0)
            {
                var lastStkBonEntree = StkBonEntree.Last();
                model.DateEntree = lastStkBonEntree.DateEntree;
            }
            else
            {
                return StatusCode(409, "La BE N° : " + model.NumBonEntree + " est introuvable");
            }
            model.SericeEmetteur = XpertHelper.CodeMagasin;
            //model.DateAffectation = DateTime.Now.Date;
            XpertHelperMagasinSuperviseur.NumBonAffectationMagasin = model.NumBonAffectation;
            var result = _context.StkAffectations.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonAffectation);
        }
        [HttpPost]
        public async Task<ActionResult> PostBonAffectationArticlesGestionnaire(string values)
        {
            int isZero = 0;
            var model = new StkAffectationsArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkAffectationsArticles(model, valuesDict);
            var Affectations = _context.StkAffectationsArticles
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();
            if(Affectations.Count() == 0)
            {
                model.Id = 1;
            }
            else
            {
                var LastAffectation = Affectations.Last().Id;
                model.Id = LastAffectation + 1;
            }
            if (model.Qte <= 0)
            {
                return StatusCode(409, "Veuillez entrer une QTE supérieur à 0");
            }
            else
            {
                model.NumBonAffectation = (int)XpertHelperGestionnaireMagasin.NumBonAffectationMagasin;
                //ADD This to movements
                var DateAffectation = _context.StkAffectations
                .AsNoTracking()
                .OrderBy(o => o.NumBonAffectation)
                .Where(c => c.NumBonAffectation == model.NumBonAffectation)
                .Select(i => new
                {
                    i.DateAffectation
                }).ToList();
                //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
                var StkMovements = _context.StkMovements
                .AsNoTracking()
                .OrderBy(o => o.DateMovment)
                .Where(c => c.CodePdr == model.CodePdr)
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
                    .Where(c => c.CodePdr == model.CodePdr)
                    .Select(i => new
                    {
                        i.Id,
                        i.Qte,
                        i.PrixUnitare
                    }).ToList();
                    //If there is no stockInitial Erreur else we compute normally
                    if (StkStockInitial.Count == 0)
                    {
                        return StatusCode(409, "La Pdr : " + model.CodePdr + " n'as pas de stock initial");
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
                                // There is valorisation methode
                                model.PrixUnitaire = StkStockInitial.Last().PrixUnitare;
                                model.Montant = Math.Round((double)(model.Qte * model.PrixUnitaire), 2);
                                //Adding sorite to movement
                                StkMovements movement = new StkMovements();
                                movement.CodePdr = model.CodePdr;
                                movement.DateMovment = DateAffectation.Last().DateAffectation;
                                movement.PrixUnitaire = (double)model.PrixUnitaire;
                                movement.Qte = model.Qte;
                                movement.Montant = (double)model.Montant;
                                movement.TypeMovement = 4;
                                movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                                movement.IdDetail = model.Id;
                                //reparing dataBase setting the emplacement of all articles in magasin P
                                repareSpots();
                                ComputeValorisationGestionnaire(movement, 1);
                                //changer emplacement ChnageSpot()
                                changeSpot(model);
                            }
                        }
                    }
                }
                else
                {
                    if ((StkMovements.Last().StockTotalSythese - model.Qte) == 0)
                    {
                        isZero = 1;
                    }
                    //Chek if there is enough
                    if ((StkMovements.Last().StockTotalSythese - model.Qte) < 0)
                    {
                        return StatusCode(409, "La Quantité saise  : " + model.Qte + " aura un effet négatif sur la QTE du stock (" + (StkMovements.Last().StockTotalSythese) + ")");
                    }
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
                        model.PrixUnitaire = StkMovements.Last().ValeurValorisation;
                        model.Montant = Math.Round((double)(model.PrixUnitaire*model.Qte), 2);
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
                        movement.CodePdr = model.CodePdr;
                        movement.DateMovment = DateAffectation.Last().DateAffectation;
                        movement.Qte = model.Qte;
                        movement.PrixUnitaire = (double)model.PrixUnitaire;
                        movement.Montant = (double)model.Montant;
                        movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                        movement.IdDetail = model.Id;
                        movement.TypeMovement = 4;
                        repareSpots();
                        ComputeValorisationGestionnaire(movement, 2);// There is mouvements
                        changeSpot(model);
                    }
                }
            }
            var result = _context.StkAffectationsArticles.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<ActionResult> PostBonAffectationArticlesSuperviseur(string values)
        {
            int isZero = 0;
            var model = new StkAffectationsArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkAffectationsArticles(model, valuesDict);
            var Affectations = _context.StkAffectationsArticles
                    .AsNoTracking()
                    .Select(i => new
                    {
                        i.Id
                    }).ToList();
            if(Affectations.Count() == 0)
            {
                model.Id = 1;
            }
            else
            {
                var LastAffectation = Affectations.Last().Id;
                model.Id = LastAffectation + 1;
            }
            if (model.Qte <= 0)
            {
                return StatusCode(409, "Veuillez entrer une QTE supérieur à 0");
            }
            else
            {
                model.NumBonAffectation = (int)XpertHelperMagasinSuperviseur.NumBonAffectationMagasin;
                //ADD This to movements
                var DateAffectation = _context.StkAffectations
                .AsNoTracking()
                .OrderBy(o => o.NumBonAffectation)
                .Where(c => c.NumBonAffectation == model.NumBonAffectation)
                .Select(i => new
                {
                    i.DateAffectation
                }).ToList();
                //First we check if this pdr has movement if no mouvement we get from StockInitial else we get from last mouvement
                var StkMovements = _context.StkMovements
                .AsNoTracking()
                .OrderBy(o => o.DateMovment)
                .Where(c => c.CodePdr == model.CodePdr)
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
                    .Where(c => c.CodePdr == model.CodePdr)
                    .Select(i => new
                    {
                        i.Id,
                        i.Qte,
                        i.PrixUnitare
                    }).ToList();
                    //If there is no stockInitial Erreur else we compute normally
                    if (StkStockInitial.Count == 0)
                    {
                        return StatusCode(409, "La Pdr : " + model.CodePdr + " n'as pas de stock initial");
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
                                // There is valorisation methode
                                model.PrixUnitaire = StkStockInitial.Last().PrixUnitare;
                                model.Montant = Math.Round((double)(model.Qte * model.PrixUnitaire), 2);
                                //Adding sorite to movement
                                StkMovements movement = new StkMovements();
                                movement.CodePdr = model.CodePdr;
                                movement.DateMovment = DateAffectation.Last().DateAffectation;
                                movement.PrixUnitaire = (double)model.PrixUnitaire;
                                movement.Qte = model.Qte;
                                movement.Montant = (double)model.Montant;
                                movement.TypeMovement = 4;
                                movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                                movement.IdDetail = model.Id;
                                repareSpots();
                                ComputeValorisationSuperviseur(movement, 1);
                                changeSpot(model);
                            }
                        }
                    }
                }
                else
                {
                    if ((StkMovements.Last().StockTotalSythese - model.Qte) == 0)
                    {
                        isZero = 1;
                    }
                    //Chek if there is enough
                    if ((StkMovements.Last().StockTotalSythese - model.Qte) < 0)
                    {
                        return StatusCode(409, "La Quantité saise  : " + model.Qte + " aura un effet négatif sur la QTE du stock (" + (StkMovements.Last().StockTotalSythese) + ")");
                    }
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
                        model.PrixUnitaire = StkMovements.Last().ValeurValorisation;
                        model.Montant = Math.Round((double)(model.PrixUnitaire*model.Qte), 2);
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
                        movement.CodePdr = model.CodePdr;
                        movement.DateMovment = DateAffectation.Last().DateAffectation;
                        movement.Qte = model.Qte;
                        movement.PrixUnitaire = (double)model.PrixUnitaire;
                        movement.Montant = (double)model.Montant;
                        movement.TypeValorisation = (int)pdrValorisation.Last().TypeValorisation;
                        movement.IdDetail = model.Id;
                        movement.TypeMovement = 4;
                        repareSpots();
                        ComputeValorisationSuperviseur(movement, 2);// There is mouvements
                        changeSpot(model);
                    }
                }
            }
            var result = _context.StkAffectationsArticles.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> PutBonAffectation(int key, string values)
        {
            var model = await _context.StkAffectations.FirstOrDefaultAsync(item => item.NumBonAffectation == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkAffectations(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutBonAffectationArticles(int key, string values)
        {
            var model = await _context.StkAffectationsArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var oldQte = model.Qte;
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelStkAffectationsArticles(model, valuesDict);
            var modelMovement = await _context.StkMovements
                .FirstOrDefaultAsync(item => item.IdDetail == key && item.TypeMovement == 4);
            modelMovement.Qte = model.Qte;
            if ((modelMovement.StockTotalSythese - oldQte) + model.Qte < 0)
            {
                return StatusCode(409, "Cette Quantité : " + model.Qte + " n'est pas disponnible, il reste : " + modelMovement.StockTotalSythese);
            }
            modelMovement.StockTotalSythese = (modelMovement.StockTotalSythese - oldQte) + model.Qte;
            modelMovement.ValeurStockTotal = (modelMovement.ValeurStockTotal - (oldQte * modelMovement.PrixUnitaire)) + (model.Qte* modelMovement.PrixUnitaire);
            modelMovement.ValeurValorisation = Math.Round((double)(modelMovement.ValeurStockTotal / modelMovement.StockTotalSythese), 2);
            _context.StkMovements.Update(modelMovement);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBonAffectationArticles(int key)
        {
            var model = await _context.StkAffectationsArticles.FirstOrDefaultAsync(item => item.Id == key);
            var modelMovement =  _context.StkMovements.FirstOrDefault(item => item.IdDetail == key && item.TypeMovement == 4);
            if (modelMovement == null)
            {
                return StatusCode(409, "Le mouvement est introuvable");
            }
            var emplacements =  _context.StkEmplacement.Where(item => item.CodePdr == model.CodePdr).ToList();
            if (emplacements.Count > 0)
            {
                var BonAffectation =  _context.StkAffectations.FirstOrDefault(item => item.NumBonAffectation == model.NumBonAffectation);
                StkEmplacement magasinP = emplacements.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);//Principal
                if (magasinP != null)
                {
                    magasinP.Qte += model.Qte;
                    _context.StkEmplacement.Update(magasinP);

                }
                if (BonAffectation != null)
                {

                    StkEmplacement magasinD = emplacements.SingleOrDefault(c => c.CodeLieu == BonAffectation.ServiceReceveur);//Destination
                    if (magasinD != null)
                    {
                        magasinD.Qte -= model.Qte;
                        _context.StkEmplacement.Update(magasinD);
                    }
                }
            }
            if (modelMovement !=null)
                _context.StkMovements.Remove(modelMovement);
            _context.StkAffectationsArticles.Remove(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteBonAffectation(int key)
        {
            var model = await _context.StkAffectations.FirstOrDefaultAsync(item => item.NumBonAffectation == key);
            _context.StkAffectations.Remove(model);
            await _context.SaveChangesAsync();
        }
        //.....
        public void checkAllAffectationsGestionnaire()
        {
            // we get all articles
            var allArticles = _context.StkPdr.AsNoTracking().Select(i=> new { i.CodePdr }).ToList();
            // we get all movements orderBy DateMovements for each article
            foreach (var article in allArticles)
            {
                var allMovements = _context.StkMovements.AsNoTracking().OrderBy(o=> o.DateMovment).Where(c => c.CodePdr == article.CodePdr).ToList();
                // iterate throught it
                StkMovements previous = allMovements.FirstOrDefault();
                StkMovements current;
                foreach (var movement in allMovements)
                {
                    
                    current = movement;
                    // if we get movement == affectation
                    if(current.TypeMovement == XpertHelperMagasinSuperviseur.typeMovment_Affectation)
                    {
                        // we delete currnent movement
                        // save id detail
                        var idDetail = current.IdMovement;
                        var movementToDelete = _context.StkMovements.Where(c => c.IdMovement == current.IdMovement).FirstOrDefault();
                        _context.StkMovements.Remove(movementToDelete);
                        _context.SaveChanges();
                        // we compute new Movement save it
                        StkMovements newMovement = new StkMovements();
                        newMovement.IdDetail = idDetail;
                        newMovement.ArticleNonGere = current.ArticleNonGere;
                        newMovement.CodePdr = current.CodePdr;
                        newMovement.DateMovment = current.DateMovment;
                        newMovement.Montant = current.Montant;
                        newMovement.PrixUnitaire = current.PrixUnitaire;
                        newMovement.Qte = current.Qte;
                        newMovement.TypeMovement = current.TypeMovement;
                        newMovement.TypeValorisation = current.TypeValorisation;
                        //if first movement is affectation we save stock initial as valorisation
                        if(current == previous)
                        {
                            var initial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == article.CodePdr).FirstOrDefault();
                            newMovement.StockTotalSythese = initial.Qte;
                            newMovement.ValeurStockTotal = Math.Round(initial.Qte* initial.PrixUnitare,4);
                            newMovement.ValeurValorisation = initial.PrixUnitare;
                        }
                        else
                        {
                            newMovement.StockTotalSythese = previous.StockTotalSythese;
                            newMovement.ValeurStockTotal = previous.ValeurStockTotal;
                            newMovement.ValeurValorisation = previous.ValeurValorisation;
                        }
                        _context.StkMovements.Add(newMovement);
                        _context.SaveChanges();
                        // we update emplacement qte corrsepanding to affectation receveur and save it
                        // we get Receveur from Affectation 
                        var numBonAffectation = _context.StkAffectationsArticles.AsNoTracking().Where(c => c.Id == idDetail).Select(i => new { i.NumBonAffectation,i.Qte }).FirstOrDefault();
                        var receveur = _context.StkAffectations.AsNoTracking().Where(c => c.NumBonAffectation == numBonAffectation.NumBonAffectation).Select(i => new { i.ServiceReceveur }).FirstOrDefault();
                        // check if there is qte of this pdr in this receveur
                        var empl = _context.StkEmplacement.AsNoTracking().Where(c => c.CodePdr == article.CodePdr).FirstOrDefault();
                        if(empl == null)
                        {
                            //add new emplacement
                            StkEmplacement newEmplacement = new StkEmplacement();
                            newEmplacement.CodeLieu = receveur.ServiceReceveur;
                            newEmplacement.CodePdr = article.CodePdr;
                            newEmplacement.Qte = numBonAffectation.Qte;
                            _context.StkEmplacement.Add(newEmplacement);
                            _context.SaveChanges();
                        }
                        else
                        {
                            //update exesting emplacement
                            empl.Qte += numBonAffectation.Qte;
                            _context.StkEmplacement.Update(empl);
                            _context.SaveChanges();
                        }
                        //update MagasinP Qte
                        checkSpotMagasinPGestionnairer(article.CodePdr);
                    }
                    previous = current;
                }
            }
        }
        public void checkAllAffectationsSuperviseur()
        {
            // we get all articles
            var allArticles = _context.StkPdr.AsNoTracking().Select(i=> new { i.CodePdr }).ToList();
            // we get all movements orderBy DateMovements for each article
            foreach (var article in allArticles)
            {
                var allMovements = _context.StkMovements.AsNoTracking().OrderBy(o=> o.DateMovment).Where(c => c.CodePdr == article.CodePdr).ToList();
                // iterate throught it
                StkMovements previous = allMovements.FirstOrDefault();
                StkMovements current;
                foreach (var movement in allMovements)
                {
                    
                    current = movement;
                    // if we get movement == affectation
                    if(current.TypeMovement == XpertHelperMagasinSuperviseur.typeMovment_Affectation)
                    {
                        // we delete currnent movement
                        // save id detail
                        var idDetail = current.IdDetail;
                        var movementToDelete = _context.StkMovements.Where(c => c.IdMovement == current.IdMovement).FirstOrDefault();
                        _context.StkMovements.Remove(movementToDelete);
                        _context.SaveChanges();
                        // we compute new Movement save it
                        StkMovements newMovement = new StkMovements();
                        newMovement.IdDetail = idDetail;
                        newMovement.ArticleNonGere = current.ArticleNonGere;
                        newMovement.CodePdr = current.CodePdr;
                        newMovement.DateMovment = current.DateMovment;
                        newMovement.Montant = current.Montant;
                        newMovement.PrixUnitaire = current.PrixUnitaire;
                        newMovement.Qte = current.Qte;
                        newMovement.TypeMovement = current.TypeMovement;
                        newMovement.TypeValorisation = current.TypeValorisation;
                        //if first movement is affectation we save stock initial as valorisation
                        if(current == previous)
                        {
                            var initial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == article.CodePdr).FirstOrDefault();
                            newMovement.StockTotalSythese = initial.Qte;
                            newMovement.ValeurStockTotal = Math.Round(initial.Qte* initial.PrixUnitare,4);
                            newMovement.ValeurValorisation = initial.PrixUnitare;
                        }
                        else
                        {
                            newMovement.StockTotalSythese = previous.StockTotalSythese;
                            newMovement.ValeurStockTotal = previous.ValeurStockTotal;
                            newMovement.ValeurValorisation = previous.ValeurValorisation;
                        }
                        _context.StkMovements.Add(newMovement);
                        _context.SaveChanges();
                        // we update emplacement qte corrsepanding to affectation receveur and save it
                        // we get Receveur from Affectation 
                        var numBonAffectation = _context.StkAffectationsArticles.AsNoTracking().Where(c => c.Id == idDetail).Select(i => new { i.NumBonAffectation,i.Qte }).FirstOrDefault();
                        var receveur = _context.StkAffectations.AsNoTracking().Where(c => c.NumBonAffectation == numBonAffectation.NumBonAffectation).Select(i => new { i.ServiceReceveur }).FirstOrDefault();
                        // check if there is qte of this pdr in this receveur
                        var empl = _context.StkEmplacement.AsNoTracking().Where(c => c.CodePdr == receveur.ServiceReceveur).FirstOrDefault();
                        if (empl == null)
                        {
                            //add new emplacement
                            StkEmplacement newEmplacement = new StkEmplacement();
                            newEmplacement.CodeLieu = receveur.ServiceReceveur;
                            newEmplacement.CodePdr = article.CodePdr;
                            newEmplacement.Qte = numBonAffectation.Qte;
                            _context.StkEmplacement.Add(newEmplacement);
                            _context.SaveChanges();
                        }
                        else
                        {
                            //update exesting emplacement
                            empl.Qte += numBonAffectation.Qte;
                            _context.StkEmplacement.Update(empl);
                            _context.SaveChanges();
                        }
                    }
                    previous = current;
                }
                //update MagasinP Qte
                //checkSpotMagasinPSuperviseur(article.CodePdr);
            }
        }
        private void checkSpotMagasinPGestionnairer(int CodePdr)
        {
            var emplacement = _context.StkEmplacement
                .AsNoTracking()
                .Where(c => c.CodePdr == CodePdr).ToList();
            if (emplacement.Count > 0)
            {
                StkEmplacement MagasinP = emplacement.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);
                if (MagasinP != null)
                {
                    var mvt = _context.StkMovements
                    .OrderBy(o => o.DateMovment)
                    .AsNoTracking()
                    .Where(c => c.CodePdr == CodePdr).ToList();
                    if (mvt.Count > 0)
                    {
                        MagasinP.Qte = mvt.Last().StockTotalSythese;
                        //we get sum of qte in other lieux then we substruct it to get the result
                        double sommeOtherPlaces = 0;
                        foreach (var itememplacement in emplacement)
                        {
                            if (itememplacement.CodeLieu != XpertHelper.CodeMagasin)
                            {
                                sommeOtherPlaces += (double)itememplacement.Qte;
                            }
                        }
                        MagasinP.Qte -= sommeOtherPlaces;
                    }
                    else
                    {
                        var stkInit = _context.StkStockInitial.Where(c => c.CodePdr == CodePdr).ToList();
                        if (stkInit.Count > 0)
                        {
                            MagasinP.Qte = stkInit.Last().Qte;
                        }
                    }
                    _context.StkEmplacement.Update(MagasinP);
                    _context.SaveChanges();
                }
            }
        }
        private void checkSpotMagasinPSuperviseur(int CodePdr)
        {
            var emplacement = _context.StkEmplacement
                .AsNoTracking()
                .Where(c => c.CodePdr == CodePdr).ToList();
            if (emplacement.Count > 0)
            {
                StkEmplacement MagasinP = emplacement.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);
                if (MagasinP != null)
                {
                    var mvt = _context.StkMovements
                    .OrderBy(o => o.DateMovment)
                    .AsNoTracking()
                    .Where(c => c.CodePdr == CodePdr).ToList();
                    if (mvt.Count > 0)
                    {
                        MagasinP.Qte = mvt.Last().StockTotalSythese;
                        //we get sum of qte in other lieux then we substruct it to get the result
                        double sommeOtherPlaces = 0;
                        foreach (var itememplacement in emplacement)
                        {
                            if (itememplacement.CodeLieu != XpertHelper.CodeMagasin)
                            {
                                sommeOtherPlaces += (double)itememplacement.Qte;
                            }
                        }
                        MagasinP.Qte -= sommeOtherPlaces;
                    }
                    else
                    {
                        var stkInit = _context.StkStockInitial.Where(c => c.CodePdr == CodePdr).ToList();
                        if (stkInit.Count > 0)
                        {
                            MagasinP.Qte = stkInit.Last().Qte;
                        }
                    }
                    _context.StkEmplacement.Update(MagasinP);
                    _context.SaveChanges();
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> ServiceReceveurLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Structure
                         orderby i.CodeStructure
                         select new
                         {
                             Value = i.CodeStructure,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> UniteMesureLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkUniteMesurePdr
                         orderby i.CodeUniteMesurePdr
                         select new
                         {
                             Value = i.CodeUniteMesurePdr,
                             Text = i.DesignationUniteMesurePdr
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
        public void ComputeValorisationGestionnaire(StkMovements model, int Case)
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
                model.StockTotalSythese = model.StockTotalSythese;
                model.ValeurValorisation = Math.Round(StkStockInitial.Last().PrixUnitare, 2);
                model.ValeurStockTotal = Math.Round(model.ValeurValorisation * model.StockTotalSythese, 2);
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
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                }).ToList();
                // in Sortie PU becomes Valeur de Valorisation
                model.PrixUnitaire = (double)StkMovements.Last().ValeurValorisation;
                model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 2);
                model.ValeurValorisation = Math.Round((double)StkMovements.Last().ValeurValorisation, 2);
                model.StockTotalSythese = StkMovements.Last().StockTotalSythese - model.StockTotalSythese;
                model.ValeurStockTotal = Math.Round(model.ValeurValorisation * model.StockTotalSythese, 2);
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
        public void ComputeValorisationSuperviseur(StkMovements model, int Case)
        {
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
                model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 4);
                model.StockTotalSythese = StkStockInitial.Last().Qte;
                model.ValeurValorisation = Math.Round(StkStockInitial.Last().PrixUnitare, 4);
                model.ValeurStockTotal = Math.Round(model.ValeurValorisation * model.StockTotalSythese, 4);
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
                    i.ValeurStockTotal,
                    i.ValeurValorisation
                }).ToList();
                // in Sortie PU becomes Valeur de Valorisation
                model.PrixUnitaire = (double)StkMovements.Last().ValeurValorisation;
                model.Montant = Math.Round(model.Qte * model.PrixUnitaire, 4);
                model.ValeurValorisation = Math.Round((double)StkMovements.Last().ValeurValorisation, 4);
                model.StockTotalSythese = StkMovements.Last().StockTotalSythese;
                model.ValeurStockTotal = Math.Round(model.ValeurValorisation * model.StockTotalSythese, 4);
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
        private void repareSpots()
        {
            // we find article which doesnt have an emplacement
            // we get its lastmvt or stkInit and add new emplacement
            var articles = _context.StkPdr
            .AsNoTracking()
            .Select(i => new
            {
                i.CodePdr
            }).ToList();
            foreach (var itemarticles in articles)
            {
                var emplacements = _context.StkEmplacement
                                .AsNoTracking()
                                .Where(c=>c.CodePdr == itemarticles.CodePdr)
                                .Select(i => new
                                {
                                    i.CodePdr
                                }).ToList();
                if(emplacements.Count == 0)
                {
                    StkEmplacement newEmplacement = new StkEmplacement();
                    newEmplacement.CodeLieu = XpertHelper.CodeMagasin;
                    newEmplacement.CodePdr = itemarticles.CodePdr;
                    var movements = _context.StkMovements
                        .AsNoTracking()
                        .OrderBy(o => o.DateMovment)
                        .Where(c => c.CodePdr == itemarticles.CodePdr)
                        .Select(i => new
                        {
                            i.StockTotalSythese
                        }).ToList();
                    if (movements.Count > 0)
                    {
                        newEmplacement.Qte = movements.Last().StockTotalSythese;
                    }
                    else
                    {
                        var stockInitial = _context.StkStockInitial
                            .AsNoTracking()
                            .Where(c => c.CodePdr == itemarticles.CodePdr)
                            .Select(i => new
                            {
                                i.Qte
                            }).ToList();
                        if (stockInitial.Count > 0)
                        {
                            newEmplacement.Qte = stockInitial.Last().Qte;
                        }
                    }
                    _context.StkEmplacement.Add(newEmplacement);
                }
            }
            _context.SaveChanges();
        }
        private void changeSpot(StkAffectationsArticles model)
        {
            var affectation = _context.StkAffectations
                .AsNoTracking()
                .Where(c => c.NumBonAffectation == model.NumBonAffectation)
                .Select(i => new
                {
                    i.ServiceReceveur
                }).ToList();
            var emplacement = _context.StkEmplacement
                .AsNoTracking()
                .Where(c => c.CodePdr == model.CodePdr).ToList();
            if (emplacement.Count == 0)
            {
                //case new article en Entree
                StkEmplacement newEmplacement = new StkEmplacement();
                newEmplacement.CodeLieu = affectation.Last().ServiceReceveur;
                newEmplacement.CodePdr = model.CodePdr;
                newEmplacement.Qte = model.Qte;
                _context.StkEmplacement.Add(newEmplacement);
                _context.SaveChanges();
            }
            else 
            {
                //case there is an emplacements in
                StkEmplacement magasinP = emplacement.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin);//Principal
                if(magasinP != null)
                {
                    //we remove the QTE from source
                    double oldQte = (double)emplacement.SingleOrDefault(c => c.CodeLieu == XpertHelper.CodeMagasin).Qte;
                    magasinP.Qte -= model.Qte;
                    _context.StkEmplacement.Update(magasinP);
                    //we check if its an existnant destinaion or a new one
                    StkEmplacement destination = emplacement.SingleOrDefault(c => c.CodeLieu == affectation.Last().ServiceReceveur);
                    if (destination == null)
                    {
                        StkEmplacement newEmplacement = new StkEmplacement();
                        newEmplacement.CodeLieu = affectation.Last().ServiceReceveur;
                        newEmplacement.CodePdr = model.CodePdr;
                        newEmplacement.Qte = model.Qte;
                        _context.StkEmplacement.Add(newEmplacement);
                    }
                    else
                    {
                        destination.Qte += model.Qte;
                        _context.StkEmplacement.Update(destination);
                    }
                    _context.SaveChanges();
                }
            }
        }
        private void PopulateModelStkAffectations(StkAffectations model, IDictionary values)
        {
            string DateAffectation = nameof(StkAffectations.DateAffectation);
            string DateEntree = nameof(StkAffectations.DateEntree);  
            string NumBonEntree = nameof(StkAffectations.NumBonEntree);  
            string ServiceReceveur = nameof(StkAffectations.ServiceReceveur);  
            string CodeIntervenant = nameof(StkAffectations.CodeIntervenant);  
            if (values.Contains(DateAffectation))
            {
                model.DateAffectation = Convert.ToDateTime(values[DateAffectation]);
            }
            if (values.Contains(DateEntree))
            {
                model.DateEntree = Convert.ToDateTime(values[DateEntree]);
            }
            if (values.Contains(NumBonEntree))
            {
                model.NumBonEntree = Convert.ToInt32(values[NumBonEntree]);
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
        private void PopulateModelStkAffectationsArticles(StkAffectationsArticles model, IDictionary values)
        {
            string CodePdr = nameof(StkAffectationsArticles.CodePdr);
            string Qte = nameof(StkAffectationsArticles.Qte);
            if (values.Contains(CodePdr))
            {
                var CodePdrvar = values[CodePdr];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodePdr = Convert.ToInt32(CodePdrSplited);
            }     
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToDouble(values[Qte]);
            }
        }
    }
}
