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
    [Area(nameof(Areas.MethodeManager))]

    public class MethOperationsController : Controller
    {
        private KBFsteelContext _context;

        public MethOperationsController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var methOperations = _context.MethOperations.Select(i => new {
                i.Idoperation,
                i.NumMachine,
                i.NumEquipement,
                i.Description,
                i.Fréquence,
                i.Unité,
                i.Guide,
                i.StructreConcernée
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(methOperations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetID(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.IdOperation = id;
            var methOperationsMaterielsOperationId = _context.MethOperationsMateriels
            .Where(x => x.IdOperation == id)
            .Select(i => new {
                i.Id,
                i.NumEquipement
            });
            return Json(await DataSourceLoader.LoadAsync(methOperationsMaterielsOperationId, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new MethOperations();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelOperation(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var LastId = _context.MethOperations
            .Select(i => new {
                i.Idoperation
            }).ToList();
            if (LastId.Count > 0)
            {
                var m = LastId.Last();
                model.Idoperation = m.Idoperation + 1;
            }
            else
            {
                model.Idoperation = 1;
            }
            var result = _context.MethOperations.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Idoperation);
        }
        [HttpPost]
        public async Task<IActionResult> PostMateriel(string values)
        {
            var model = new MethOperationsMateriels();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelMateriel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.MethOperationsMateriels.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.MethOperations.FirstOrDefaultAsync(item => item.Idoperation == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelOperation(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutMateriel(int key, string values)
        {
            var model = await _context.MethOperationsMateriels.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelMateriel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.MethOperations.FirstOrDefaultAsync(item => item.Idoperation == key);
            var modelMateriels = await _context.MethOperationsMateriels.FirstOrDefaultAsync(item => item.IdOperation == key);
            while(modelMateriels != null)
            {
                _context.MethOperationsMateriels.Remove(modelMateriels);
                modelMateriels = await _context.MethOperationsMateriels.FirstOrDefaultAsync(item => item.IdOperation == key);
            }
            _context.MethOperations.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteMateriel(int key)
        {
            var model = await _context.MethOperationsMateriels.FirstOrDefaultAsync(item => item.Id == key);
            _context.MethOperationsMateriels.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult> MaterielLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.MethStructureMachine
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.Equipement
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
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
        [HttpGet]
        public async Task<IActionResult> UniteLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.MethOperationsUniteFrequence
                         orderby i.CodeFrequenceUnite
                         select new
                         {
                             Value = i.CodeFrequenceUnite,
                             Text = i.DesignationFrequenceUnite
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModelOperation(MethOperations model, IDictionary values) {

            string NumMachine = nameof(MethOperations.NumMachine);
            string NumEquipement = nameof(MethOperations.NumEquipement);
            string Fréquence = nameof(MethOperations.Fréquence);
            string Unité = nameof(MethOperations.Unité);
            string Description = nameof(MethOperations.Description);
            string Guide = nameof(MethOperations.Guide);
            string StructreConcernée = nameof(MethOperations.StructreConcernée);
            if (values.Contains(StructreConcernée))
            {
                model.StructreConcernée = Convert.ToInt32(values[StructreConcernée]);
            }
            if (values.Contains(NumMachine))
            {
                model.NumMachine = Convert.ToInt32(values[NumMachine]);
            }
            if (values.Contains(NumEquipement))
            {
                var CodePdrvar = values[NumEquipement];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.NumEquipement = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(Fréquence))
            {
                model.Fréquence = Convert.ToInt32(values[Fréquence]);
            }
            if (values.Contains(Unité))
            {
                model.Unité = Convert.ToInt32(values[Unité]);
            }
            if (values.Contains(Description)) {
                model.Description = Convert.ToString(values[Description]);
            }
            if (values.Contains(Guide))
            {
                model.Guide = Convert.ToString(values[Guide]);
            }
        }
        private void PopulateModelMateriel(MethOperationsMateriels model, IDictionary values)
        {
            string Id = nameof(MethOperationsMateriels.Id);
            string IdOperation = nameof(MethOperationsMateriels.IdOperation);
            string NumEquipement = nameof(MethOperationsMateriels.NumEquipement);

            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            else
            {
                var LastId = _context.MethOperationsMateriels
                .Select(i => new {
                    i.Id
                }).ToList();
                if (LastId.Count > 0)
                {
                    var m = LastId.Last();
                    model.Id = m.Id + 1;
                }
                else
                {
                    model.Id = 1;
                }
            }
            if (values.Contains(IdOperation))
            {
                model.IdOperation = Convert.ToInt32(values[IdOperation]);
            }
            else
            {
                model.IdOperation = XpertHelper.IdOperation;
            }
            if (values.Contains(NumEquipement))
            {
                model.NumEquipement = Convert.ToInt32(values[NumEquipement]);
            }
        }
        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}