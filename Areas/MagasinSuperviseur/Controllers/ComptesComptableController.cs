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

    public class ComptesComptableController : Controller
    {
        private KBFsteelContext _context;
        public ComptesComptableController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var ComptComptesComptable = _context.ComptComptesComptable
                .Select(i => new {
                    i.NumCompte,
                    i.DesignationCompte
                });
            return Json(await DataSourceLoader.LoadAsync(ComptComptesComptable, loadOptions));
        }
        [HttpGet]
        public object GetEntrees(int id,DataSourceLoadOptions loadOptions)
        {
            List<SuiviCCEntreesModel> SuiviCCEntreesModelList = new List<SuiviCCEntreesModel>();
            var StkPdr = _context.StkPdr
            .Where(o => o.CompteComptable == id)
            .AsNoTracking()
            .Select(i => new {
                i.CodePdr,
                i.CodeFamillePdr
            }).ToList();
            if(StkPdr.Count != 0)
            {
                var article = StkPdr.Last();
                if (article != null)
                {
                    foreach (var itemStkPdr in StkPdr)
                    {
                        var StkBonSortieArticles = _context.StkBonEntreeArticles
                        .AsNoTracking()
                        .Where(o => o.CodePdr == itemStkPdr.CodePdr)
                        .Select(i => new {
                            i.NumBonEntree,
                            i.QteRecu,
                            i.PrixUnitaire,
                            i.Montant
                        }).ToList();
                        foreach (var itemStkBonSortieArticles in StkBonSortieArticles)
                        {
                            SuiviCCEntreesModel suiviCCEntreesModel = new SuiviCCEntreesModel();
                            suiviCCEntreesModel.NumEntrree = itemStkBonSortieArticles.NumBonEntree;
                            suiviCCEntreesModel.CodeArticle = (int)itemStkPdr.CodePdr;
                            suiviCCEntreesModel.CodeFamille = itemStkPdr.CodeFamillePdr;
                            suiviCCEntreesModel.Quantite = itemStkBonSortieArticles.QteRecu;
                            suiviCCEntreesModel.Cout = itemStkBonSortieArticles.PrixUnitaire;
                            suiviCCEntreesModel.Montant = itemStkBonSortieArticles.Montant;
                            var StkBonEntree = _context.StkBonEntree
                            .AsNoTracking()
                            .Where(o => o.NumBon == suiviCCEntreesModel.NumEntrree)
                            .Select(i => new {
                                i.CodeFournisseur,
                                i.DateEntree
                            }).ToList();
                            var Entree = StkBonEntree.Last();
                            suiviCCEntreesModel.DateEntree = Entree.DateEntree;
                            suiviCCEntreesModel.CodeFournisseur = Entree.CodeFournisseur;
                            SuiviCCEntreesModelList.Add(suiviCCEntreesModel);
                        }
                    }
                }
            }

            return DataSourceLoader.Load(SuiviCCEntreesModelList, loadOptions);
        }
        [HttpGet]
        public object GetSorties(int id,DataSourceLoadOptions loadOptions)
        {
            List<SuiviCCSortiesModel> SuiviCCSortiesModelList = new List<SuiviCCSortiesModel>();
            var StkPdr = _context.StkPdr
            .Where(o => o.CompteComptable == id)
            .AsNoTracking()
            .Select(i => new {
                i.CodePdr,
                i.CodeFamillePdr
            }).ToList();
            if(StkPdr.Count()!= 0)
            {
                var article = StkPdr.Last();
                if (article != null)
                {
                    foreach (var itemStkPdr in StkPdr)
                    {
                        var StkBonSortieArticles = _context.StkBonSortieArticles
                        .AsNoTracking()
                        .Where(o => o.CodeArticle == itemStkPdr.CodePdr)
                        .Select(i => new {
                            i.NumBonSortie,
                            i.DateSortie,
                            i.Qte,
                            i.PrixUnitaire,
                            i.Montant
                        }).ToList();
                        foreach (var itemStkBonSortieArticles in StkBonSortieArticles)
                        {
                            SuiviCCSortiesModel suiviCCSortiesModel = new SuiviCCSortiesModel();
                            suiviCCSortiesModel.DateSortie = (DateTime)itemStkBonSortieArticles.DateSortie;
                            suiviCCSortiesModel.NumSortie = itemStkBonSortieArticles.NumBonSortie;
                            suiviCCSortiesModel.CodeArticle = (int)itemStkPdr.CodePdr;
                            suiviCCSortiesModel.CodeFamille = itemStkPdr.CodeFamillePdr;
                            suiviCCSortiesModel.Quantite = itemStkBonSortieArticles.Qte;
                            suiviCCSortiesModel.Cout = itemStkBonSortieArticles.PrixUnitaire;
                            suiviCCSortiesModel.Montant = itemStkBonSortieArticles.Montant;
                            var StkBonSortie = _context.StkBonSortie
                            .AsNoTracking()
                            .Where(o => o.NumBonSortie == suiviCCSortiesModel.NumSortie)
                            .Select(i => new {
                                i.CentreFrais
                            }).ToList();
                            var CF = StkBonSortie.Last();
                            if (CF.CentreFrais != null)
                            {
                                suiviCCSortiesModel.CentreFrais = (int)CF.CentreFrais;
                            }
                            SuiviCCSortiesModelList.Add(suiviCCSortiesModel);
                        }
                    }
                }
            }
            return DataSourceLoader.Load(SuiviCCSortiesModelList, loadOptions);
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new ComptComptesComptable();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var SrkBonRetour = _context.ComptComptesComptable
                .Select(i => new
                {
                    i.NumCompte
                }).ToList();

            if (SrkBonRetour.Count == 0)
                model.NumCompte = 1;
            else
            {
                var m = SrkBonRetour.Last();
                model.NumCompte = Convert.ToInt32(m.NumCompte) + 1;
            }
            var result = _context.ComptComptesComptable.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumCompte);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.ComptComptesComptable.FirstOrDefaultAsync(item => item.NumCompte == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.ComptComptesComptable.FirstOrDefaultAsync(item => item.NumCompte == key);
            _context.ComptComptesComptable.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================

        //=================================================PopulateModels===================================
        private void PopulateModel(ComptComptesComptable model, IDictionary values)
        {
            string NumCompte = nameof(ComptComptesComptable.NumCompte);
            string DesignationCompte = nameof(ComptComptesComptable.DesignationCompte);
            if (values.Contains(NumCompte))
            {
                model.NumCompte = Convert.ToInt32(values[NumCompte]);
            }
            if (values.Contains(DesignationCompte))
            {
                model.DesignationCompte = Convert.ToString(values[DesignationCompte]);
            }
        }
    }
}
