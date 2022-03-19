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

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class FournisseursController : Controller
    {
        private KBFsteelContext _context;
        public FournisseursController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public async Task<IActionResult> GetFournisseurs(DataSourceLoadOptions loadOptions)
        {
            //add Fournisseurs NonG to Fournissuers Code...
            var entreeFN = _context.StkBonEntree
                .Where(c=> String.IsNullOrEmpty(c.CodeFournisseur))
                .Select(i => new {
                    i.FournisseurNonGere
                }).ToList();
            foreach (var itementreeFN in entreeFN)
            {
                var fournisuersExistant = _context.ApproFournisseurs
                    .AsNoTracking()
                    .Where(c=>c.SocieteFournisseur== itementreeFN.FournisseurNonGere)
                    .Select(i => new {
                       i.NumeroFournisseur
                    }).ToList();
                if(fournisuersExistant.Count == 0)
                {
                    ApproFournisseurs newFournissuer = new ApproFournisseurs();
                    newFournissuer.SocieteFournisseur = itementreeFN.FournisseurNonGere;
                    var fournisuers = _context.ApproFournisseurs
                        .AsNoTracking()
                        .Select(i => new {
                            i.NumeroFournisseur
                        }).ToList();
                    if (fournisuers.Count == 0)
                    {
                        newFournissuer.NumeroFournisseur = "FR00001";
                    }
                    else
                    {
                        var m = fournisuers.Last();
                        var value = m.NumeroFournisseur;
                        int numericValue;
                        bool isNumber = int.TryParse(value, out numericValue);
                        if (isNumber == true)
                        {
                            newFournissuer.NumeroFournisseur = Convert.ToString(Convert.ToInt32(m.NumeroFournisseur) + 1);
                        }
                        else
                        {
                            var info = value.ToString();//FR00017
                            var splited = info.Split("FR");//[FR,//00267]
                            var elem = splited[1];//00267
                            var ValueElem = Convert.ToInt32(elem);//267 
                            var StringNewElem = Convert.ToString((Convert.ToInt32(elem) + 1));// "268"
                            while (StringNewElem.Length < XpertHelper.MagasinSupervieurCodificationFournisseur)//Nbr De codification est 5
                            {
                                StringNewElem = "0" + StringNewElem;
                            }//"00268"
                            newFournissuer.NumeroFournisseur = Convert.ToString("FR" + StringNewElem);//"FR00268"
                        }
                    }
                    var result = _context.ApproFournisseurs.Add(newFournissuer);
                    _context.SaveChanges();
                }
            }
            //update Entrees with new fournissuers and delete fournisseurnongere
            var FournissuerEntrees = _context.ApproFournisseurs
                    .Select(i => new {
                        i.NumeroFournisseur,
                        i.SocieteFournisseur
                    }).ToList();
            foreach (var itemFournissuerEntrees in FournissuerEntrees)
            {
                var entreeNongere = _context.StkBonEntree
                    .AsNoTracking()
                    .Where(c => String.IsNullOrEmpty(c.CodeFournisseur)).ToList();
                if(entreeNongere.Count > 0)
                {
                    StkBonEntree Entree = entreeNongere.SingleOrDefault(c => c.FournisseurNonGere == itemFournissuerEntrees.SocieteFournisseur);//Principal
                    if (Entree != null)
                    {
                        Entree.CodeFournisseur = itemFournissuerEntrees.NumeroFournisseur;
                        Entree.FournisseurNonGere = null;
                        _context.StkBonEntree.Update(Entree);
                        _context.SaveChanges();
                    }
                }
            }
            var StkAffectations = _context.ApproFournisseurs
                .AsNoTracking()
                .Select(i => new {
                    i.Adresse,
                    i.CodePostal,
                    i.Fax,
                    i.Fonction,
                    i.Gmail,
                    i.NumeroFournisseur,
                    i.Pays,
                    i.SocieteFournisseur,
                    i.Telephone,
                    i.Ville,
                    i.Nrc,
                    i.Mf,
                    i.Art,
                    i.Contact
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetEntree(string id, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkBonEntree
            .Where(x => x.CodeFournisseur == id)
            .Select(i => new {
                i.NumBon,
                i.TypeAchat,
                i.DateEntree,
                i.CodeIntervenant
            });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetRetour(string id, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.SrkBonRetour
            .Where(x => x.CodeFournisseur == id)
            .Select(i => new {
                i.CodeIntervenant,
                i.DateRetour,
                i.NumBonEntree,
                i.NumBonRetour
            });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostFournisseurs(string values)
        {
            var model = new ApproFournisseurs();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFournisseurs(model, valuesDict);
            var ApproFournisseurs = _context.ApproFournisseurs
                .AsNoTracking()
                .OrderBy(o => o.NumeroFournisseur)
                .Select(i => new
                {
                    i.NumeroFournisseur
                }).ToList();
            if (String.IsNullOrEmpty(model.NumeroFournisseur))
            {
                if (ApproFournisseurs.Count == 0)
                    model.NumeroFournisseur = "FR00001";
                else
                {
                    var m = ApproFournisseurs.Last();
                    var value = m.NumeroFournisseur;
                    int numericValue;
                    bool isNumber = int.TryParse(value, out numericValue);
                    if (isNumber == true)
                    {
                        model.NumeroFournisseur = Convert.ToString(Convert.ToInt32(m.NumeroFournisseur) + 1);
                    }
                    else
                    {
                        var info = value.ToString();//FR00017
                        var splited = info.Split("FR");//[FR,//00267]
                        var elem = splited[1];//00267
                        var ValueElem = Convert.ToInt32(elem);//267 
                        var StringNewElem = Convert.ToString((Convert.ToInt32(elem) + 1));// "268"
                        while (StringNewElem.Length < XpertHelper.MagasinSupervieurCodificationFournisseur)//Nbr De codification est 5
                        {
                            StringNewElem = "0"+StringNewElem;
                        }//"00268"
                        model.NumeroFournisseur = Convert.ToString("FR"+ StringNewElem);//"FR00268"
                    }
                }
            }
            var result = _context.ApproFournisseurs.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumeroFournisseur);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutFournisseurs(string key, string values)
        {
            var model = await _context.ApproFournisseurs.FirstOrDefaultAsync(item => item.NumeroFournisseur == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelFournisseurs(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteFournisseurs(string key)
        {
            var model = await _context.ApproFournisseurs.FirstOrDefaultAsync(item => item.NumeroFournisseur == key);
            _context.ApproFournisseurs.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        [HttpGet]
        public async Task<IActionResult> FournisseurLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.ApproFournisseurs
                         orderby i.NumeroFournisseur
                         select new
                         {
                             Value = i.NumeroFournisseur,
                             Text = i.SocieteFournisseur
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
        private void PopulateModelFournisseurs(ApproFournisseurs model, IDictionary values)
        {
            string Adresse = nameof(ApproFournisseurs.Adresse);
            string CodePostal = nameof(ApproFournisseurs.CodePostal);
            string Fax = nameof(ApproFournisseurs.Fax);
            string Fonction = nameof(ApproFournisseurs.Fonction);
            string Gmail = nameof(ApproFournisseurs.Gmail);
            string Pays = nameof(ApproFournisseurs.Pays);
            string SocieteFournisseur = nameof(ApproFournisseurs.SocieteFournisseur);
            string Telephone = nameof(ApproFournisseurs.Telephone);
            string Ville = nameof(ApproFournisseurs.Ville);
            string Nrc = nameof(ApproFournisseurs.Nrc);
            string Mf = nameof(ApproFournisseurs.Mf);
            string Art = nameof(ApproFournisseurs.Art);
            string Contact = nameof(ApproFournisseurs.Contact);
            if (values.Contains(Nrc))
            {
                model.Nrc = Convert.ToInt32(values[Nrc]);
            }
            if (values.Contains(Mf))
            {
                model.Mf = Convert.ToInt32(values[Mf]);
            }
            if (values.Contains(Art))
            {
                model.Art = Convert.ToInt32(values[Art]);
            }
            if (values.Contains(Contact))
            {
                model.Contact = Convert.ToString(values[Contact]);
            }
            if (values.Contains(Adresse))
            {
                model.Adresse = Convert.ToString(values[Adresse]);
            }
            if (values.Contains(CodePostal))
            {
                model.CodePostal = Convert.ToString(values[CodePostal]);
            }
            if (values.Contains(Fax))
            {
                model.Fax = Convert.ToString(values[Fax]);
            }
            if (values.Contains(Fonction))
            {
                model.Fonction = Convert.ToString(values[Fonction]);
            }
            if (values.Contains(Gmail))
            {
                model.Gmail = Convert.ToString(values[Gmail]);
            }
            if (values.Contains(Pays))
            {
                model.Pays = Convert.ToString(values[Pays]);
            }
            if (values.Contains(SocieteFournisseur))
            {
                model.SocieteFournisseur = Convert.ToString(values[SocieteFournisseur]);
            }
            if (values.Contains(Telephone))
            {
                model.Telephone = Convert.ToInt32(values[Telephone]);
            }
            if (values.Contains(Ville))
            {
                model.Ville = Convert.ToString(values[Ville]);
            }
        }
    }
}