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

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class MaintPointControlMastersController : Controller
    {
        private KBFsteelContext _context;
        public MaintPointControlMastersController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetSuivi(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var bonproduction = _context.MaintPointControlMaster
                .Where(c => c.Date.Date >= dateDebut.Date && c.Date.Date <= dateFin.Date)
                .Select(i => new {
                    i.CodeService,
                    i.NumCheckList,
                    i.Date,
                    i.DateDebut,
                    i.DateFin
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.CheckListService = id;
            var bonproduction = _context.MaintPointControlMaster
                .Where(c => c.CodeService == id && c.Date.Date >= dateDebut.Date && c.Date.Date <= dateFin.Date)
                .Select(i => new {
                    i.Date,
                    i.NumCheckList,
                    i.DateDebut,
                    i.DateFin
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int NumCheckList, DataSourceLoadOptions loadOptions)
        {
            var bonproduction = _context.MaintPointControleDetail
                .Where(c => c.NumCheckList == NumCheckList)
                .Select(i => new {
                    i.Id,
                    i.CodeMachine,
                    i.Dimanche,
                    i.Lundi,
                    i.Mardi,
                    i.Mercredi,
                    i.Jeudi,
                    i.Vendredi,
                    i.Samedi,
                    i.Observation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpPost]
        public async Task PostCheckList(string values)
        {
            var Master = new MaintPointControlMaster();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelMaster(Master, valuesDict);
            Master.CodeService = XpertHelper.CheckListService;
            var CheckLists = _context.MaintPointControlMaster
                .Select(i => new {
                    i.NumCheckList
                }).ToList();
            if (CheckLists.Count() == 0)
            {
                Master.NumCheckList = 1;
            }
            else
            {
                Master.NumCheckList = CheckLists.Last().NumCheckList + 1;
            }
            _context.MaintPointControlMaster.Add(Master);

            var machines = _context.Machines
                .Where(c => c.NumMachine != 24 && c.NumMachine != 27)
                .Select(i => new {
                    i.NumMachine,
                    i.NomMachine
                }).ToList();
            foreach (var itemmachines in machines)
            {
                var Detail = new MaintPointControleDetail();
                var CheckListsDetails = _context.MaintPointControleDetail
                    .Select(i => new {
                        i.Id
                    }).ToList();
                if (CheckListsDetails.Count() == 0)
                {
                    Detail.Id = 1;
                }
                else
                {
                    Detail.Id = CheckListsDetails.Last().Id + 1;
                }
                Detail.NumCheckList = Master.NumCheckList;
                Detail.CodeMachine = Convert.ToInt32(itemmachines.NumMachine);
                PopulateModelDetail(Detail);
                _context.MaintPointControleDetail.Add(Detail);
                await _context.SaveChangesAsync();
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutDetail(int key, string values)
        {
            var model = await _context.MaintPointControleDetail.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetail(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.MaintPointControlMaster.FirstOrDefaultAsync(item => item.NumCheckList == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.MaintPointControlMaster.FirstOrDefaultAsync(item => item.NumCheckList == key);
            _context.MaintPointControlMaster.Remove(model);
            var details = _context.MaintPointControleDetail
                .Where(c => c.NumCheckList == key)
                .Select(i => new {
                    i.Id
                }).ToList();
            foreach (var itemdetails in details)
            {
                var detail = await _context.MaintPointControleDetail.FirstOrDefaultAsync(item => item.Id == itemdetails.Id);
                _context.MaintPointControleDetail.Remove(detail);
            }
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult> DesignationLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Machines
                         select new
                         {
                             Value = i.NumMachine,
                             Text = i.NomMachine
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> StructureLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Structure
                         orderby i.Designation
                         select new
                         {
                             Value = i.CodeStructure,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(MaintPointControlMaster model, IDictionary values)
        {
            string Date = nameof(MaintPointControlMaster.Date);
            string DateDebut = nameof(MaintPointControlMaster.DateDebut);
            string DateFin = nameof(MaintPointControlMaster.DateFin);
            if (values.Contains(Date))
            {
                model.Date = Convert.ToDateTime(values[Date]);
            }
            if (values.Contains(DateDebut))
            {
                model.DateDebut = Convert.ToDateTime(values[DateDebut]);
            }
            if (values.Contains(DateFin))
            {
                model.DateFin = Convert.ToDateTime(values[DateFin]);
            }
        }
        private void PopulateModelDetail(MaintPointControleDetail model, IDictionary values)
        {
            string Observation = nameof(MaintPointControleDetail.Observation);
            string Dimanche = nameof(MaintPointControleDetail.Dimanche);
            string Lundi = nameof(MaintPointControleDetail.Lundi);
            string Mardi = nameof(MaintPointControleDetail.Mardi);
            string Mercredi = nameof(MaintPointControleDetail.Mercredi);
            string Jeudi = nameof(MaintPointControleDetail.Jeudi);
            string Vendredi = nameof(MaintPointControleDetail.Vendredi);
            string Samedi = nameof(MaintPointControleDetail.Samedi);
            if (values.Contains(Dimanche))
            {
                model.Dimanche = Convert.ToBoolean(values[Dimanche]);
            }
            if (values.Contains(Lundi))
            {
                model.Lundi = Convert.ToBoolean(values[Lundi]);
            }
            if (values.Contains(Mardi))
            {
                model.Mardi = Convert.ToBoolean(values[Mardi]);
            }
            if (values.Contains(Mercredi))
            {
                model.Mercredi = Convert.ToBoolean(values[Mercredi]);
            }
            if (values.Contains(Jeudi))
            {
                model.Jeudi = Convert.ToBoolean(values[Jeudi]);
            }
            if (values.Contains(Vendredi))
            {
                model.Vendredi = Convert.ToBoolean(values[Vendredi]);
            }
            if (values.Contains(Samedi))
            {
                model.Samedi = Convert.ToBoolean(values[Samedi]);
            }
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }
        }
        private void PopulateModelMaster(MaintPointControlMaster Master, IDictionary values)
        {
            string Date = nameof(MaintPointControlMaster.Date);
            string DateDebut = nameof(MaintPointControlMaster.DateDebut);
            string DateFin = nameof(MaintPointControlMaster.DateFin);

            if (values.Contains(Date))
            {
                Master.Date = Convert.ToDateTime(values[Date]);
            }
            if (values.Contains(DateDebut))
            {
                Master.DateDebut = Convert.ToDateTime(values[DateDebut]);
            }
            if (values.Contains(DateFin))
            {
                Master.DateFin = Convert.ToDateTime(values[DateFin]);
            }
        }
        private void PopulateModelDetail(MaintPointControleDetail Detail)
        {
            Detail.Dimanche = Convert.ToBoolean(0);
            Detail.Lundi = Convert.ToBoolean(0);
            Detail.Mardi = Convert.ToBoolean(0);
            Detail.Mercredi = Convert.ToBoolean(0);
            Detail.Jeudi = Convert.ToBoolean(0);
            Detail.Vendredi = Convert.ToBoolean(0);
            Detail.Samedi = Convert.ToBoolean(0);
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