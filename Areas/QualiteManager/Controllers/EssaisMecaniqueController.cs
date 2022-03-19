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
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Internal;
using DevExpress.Data.Extensions;
using Newtonsoft.Json.Linq;
using DevKbfSteel.Helpers;
namespace DevKbfSteel.Controllers
{
    [Area(nameof(Areas.QualiteManager))]
    public class EssaisMecaniqueController : Controller
    {
        private KBFsteelContext _context;
        public EssaisMecaniqueController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var QualiteEssaisMecanique = _context.QualiteEssaisMecanique.AsNoTracking().Where(c => c.DateEssaie.Date >= dateDebut.Date && c.DateEssaie.Date <= dateFin.Date)
                .Select(i => new {
                    i.Commentaire,
                    i.DateEssaie,
                    i.IdControleur,
                    i.NumEssai,
                    i.Poste
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteEssaisMecanique, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.QualiteEssaisMecanique = id;
            var QualiteEssaisMecaniqueDetails = _context.QualiteEssaisMecaniqueDetails.AsNoTracking().Where(c => c.NumControl == id)
                .Select(i => new {
                    i.NumControl,
                    i.Id,
                    i.EssaiTorsion,
                    i.HorraireEssai,
                    i.IdControleur,
                    i.LimiteElastique,
                    i.MasseLineique,
                    i.MesureProfileLamineExacte,
                    i.PessageProfile,
                    i.Profile,
                    i.Remarque,
                    i.RuptureTraction,
                    i.SectionMetal,
                    i.TauxAllongement,
                    i.TauxRmre
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteEssaisMecaniqueDetails, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new QualiteEssaisMecanique();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var result = _context.QualiteEssaisMecanique.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumEssai);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetails(string values)
        {
            var model = new QualiteEssaisMecaniqueDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetails(model, valuesDict);
            model.NumControl = XpertHelper.QualiteEssaisMecanique;
            model.TauxRmre = Math.Round(model.LimiteElastique / model.RuptureTraction, 2);
            var result = _context.QualiteEssaisMecaniqueDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.QualiteEssaisMecanique.FirstOrDefaultAsync(item => item.NumEssai == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetails(int key, string values)
        {
            var model = await _context.QualiteEssaisMecaniqueDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetails(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.QualiteEssaisMecanique.FirstOrDefaultAsync(item => item.NumEssai == key);

            _context.QualiteEssaisMecanique.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetails(int key)
        {
            var model = await _context.QualiteEssaisMecaniqueDetails.FirstOrDefaultAsync(item => item.Id == key);

            _context.QualiteEssaisMecaniqueDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(QualiteEssaisMecanique model, IDictionary values)
        {
            string Commentaire = nameof(QualiteEssaisMecanique.Commentaire);
            string DateEssaie = nameof(QualiteEssaisMecanique.DateEssaie);
            string IdControleur = nameof(QualiteEssaisMecanique.IdControleur);
            string Poste = nameof(QualiteEssaisMecanique.Poste);
            string NumEassai = nameof(QualiteEssaisMecanique.NumEssai);

            if (values.Contains(DateEssaie))
            {
                model.DateEssaie = Convert.ToDateTime(values[DateEssaie]);
            }
            if (values.Contains(NumEassai))
            {
                model.NumEssai = Convert.ToInt32(values[NumEassai]);
            }
            if (values.Contains(IdControleur))
            {
                model.IdControleur = Convert.ToInt32(values[IdControleur]);
            }
            if (values.Contains(Poste))
            {
                model.Poste = Convert.ToInt32(values[Poste]);
            }
            if (values.Contains(Commentaire))
            {
                model.Commentaire = Convert.ToString(values[Commentaire]);
            }
        }
        private void PopulateModelDetails(QualiteEssaisMecaniqueDetails model, IDictionary values)
        {
            string EssaiTorsion = nameof(QualiteEssaisMecaniqueDetails.EssaiTorsion);
            string HorraireEssai = nameof(QualiteEssaisMecaniqueDetails.HorraireEssai);
            string IdControleur = nameof(QualiteEssaisMecaniqueDetails.IdControleur);
            string LimiteElastique = nameof(QualiteEssaisMecaniqueDetails.LimiteElastique);
            string MasseLineique = nameof(QualiteEssaisMecaniqueDetails.MasseLineique);
            string MesureProfileLamineExacte = nameof(QualiteEssaisMecaniqueDetails.MesureProfileLamineExacte);
            string PessageProfile = nameof(QualiteEssaisMecaniqueDetails.PessageProfile);
            string Profile = nameof(QualiteEssaisMecaniqueDetails.Profile);
            string Remarque = nameof(QualiteEssaisMecaniqueDetails.Remarque);
            string RuptureTraction = nameof(QualiteEssaisMecaniqueDetails.RuptureTraction);
            string SectionMetal = nameof(QualiteEssaisMecaniqueDetails.SectionMetal);
            string TauxAllongement = nameof(QualiteEssaisMecaniqueDetails.TauxAllongement);
            string TauxRmre = nameof(QualiteEssaisMecaniqueDetails.TauxRmre);
            if (values.Contains(EssaiTorsion))
            {
                model.EssaiTorsion = Convert.ToDouble(values[EssaiTorsion]);
            }
            if (values.Contains(HorraireEssai))
            {
                model.HorraireEssai = Convert.ToDateTime(values[HorraireEssai]);
            }
            if (values.Contains(IdControleur))
            {
                model.IdControleur = Convert.ToInt32(values[IdControleur]);
            }
            if (values.Contains(MasseLineique))
            {
                model.MasseLineique = Convert.ToDouble(values[MasseLineique]);
            }
            if (values.Contains(MesureProfileLamineExacte))
            {
                model.MesureProfileLamineExacte = Convert.ToDouble(values[MesureProfileLamineExacte]);
            }
            if (values.Contains(LimiteElastique))
            {
                model.LimiteElastique = Convert.ToDouble(values[LimiteElastique]);
            }
            if (values.Contains(PessageProfile))
            {
                model.PessageProfile = Convert.ToDouble(values[PessageProfile]);
            }
            if (values.Contains(RuptureTraction))
            {
                model.RuptureTraction = Convert.ToDouble(values[RuptureTraction]);
            }
            if (values.Contains(TauxAllongement))
            {
                model.TauxAllongement = Convert.ToDouble(values[TauxAllongement]);
            }
            if (values.Contains(TauxRmre))
            {
                model.TauxRmre = Convert.ToDouble(values[TauxRmre]);
            }
            if (values.Contains(SectionMetal))
            {
                model.SectionMetal = Convert.ToDouble(values[SectionMetal]);
            }
            if (values.Contains(Profile))
            {
                model.Profile = Convert.ToString(values[Profile]);
            }
            if (values.Contains(Remarque))
            {
                model.Remarque = Convert.ToString(values[Remarque]);
            }
        }
        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
        [HttpGet]
        public async Task<IActionResult> MachinesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Machines
                         orderby i.NumMachine
                         select new
                         {
                             Value = i.NumMachine,
                             Text = i.NomMachine
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
    }
}