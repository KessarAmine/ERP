using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevKbfSteel.Areas.MethodeManager.Models;
using DevKbfSteel.Entities;
using DevKbfSteel.Helpers;
using DevKbfSteel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class MachineEquioementsController : Controller
    {
        private KBFsteelContext _context;
        public MachineEquioementsController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumMachine = id;
            var machineequioement = _context.MachineEquioement.Where(c => c.NumMachine == id)
                .Select(i => new
                {
                    i.Id,
                    i.NumEquipement,
                    i.Qte,
                    i.NumComposition,
                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(machineequioement, loadOptions));
        }
        [HttpGet]
        public object GetSuiviNew(int id, DataSourceLoadOptions loadOptions)
        {
            List<FicheSuiviMachine> ficheSuiviMachines = new List<FicheSuiviMachine>();
            var Alltravaux = _context.AssOtTraveaux.AsNoTracking().Where(c => c.CodeMachine == id)
                .Select(i => new
                {
                    i.NumOt,
                    i.CodeMachine,
                    i.CodeEquipement,
                    i.Autres,
                    i.Qte,
                    i.TypeTraveaux
                }).ToList();
            foreach (var itemAlltravaux in Alltravaux)
            {
                var ordre = _context.OrdreTravail.AsNoTracking().Where(c => c.NumOt == itemAlltravaux.NumOt).Select(i => new
                {
                    i.NumOt,
                    i.NumDt,
                    i.DateOt,
                    i.CodeMaintenance,
                    i.CodeDemandeur
                }).ToList();
                if (ordre.Count != 0)
                {
                    var TypeTravau = _context.LookupTypeTraveauxOt.AsNoTracking().Where(c => c.Id == Convert.ToInt32(itemAlltravaux.TypeTraveaux)).Select(i => new
                    {
                        i.Id,
                        i.Designation
                    }).ToList();
                    FicheSuiviMachine ficheSuiviMachine = new FicheSuiviMachine();
                    ficheSuiviMachine.id = ficheSuiviMachines.Count + 1;
                    if(!ordre.Last().NumDt.Equals(null))
                        ficheSuiviMachine.NumDt = (int)ordre.Last().NumDt;
                    ficheSuiviMachine.NumOt = ordre.Last().NumOt;
                    ficheSuiviMachine.TypeMaintenance = ordre.Last().CodeMaintenance;
                    ficheSuiviMachine.Datentervention = ordre.Last().DateOt;
                    ficheSuiviMachine.CodeDemandeur = ordre.Last().CodeDemandeur;
                    if (TypeTravau.Last().Id.Equals(0))
                    {
                        ficheSuiviMachine.ActionDetaile = itemAlltravaux.Autres;
                    }
                    else
                    {
                        if (!(itemAlltravaux.CodeEquipement == null))
                        {
                            if (!itemAlltravaux.CodeEquipement.Equals(""))
                            {
                                var Eqp = _context.MethStructureMachine.AsNoTracking().Where(c => c.Id == Convert.ToInt32(itemAlltravaux.CodeEquipement)).Select(i => new
                                {
                                    i.Equipement
                                }).ToList();
                                ficheSuiviMachine.ActionDetaile = TypeTravau.Last().Designation + " / " + Eqp.Last().Equipement;
                            }
                            else
                            {
                                ficheSuiviMachine.ActionDetaile = TypeTravau.Last().Designation + " / " + itemAlltravaux.Autres;
                            }
                        }
                        else
                        {
                            ficheSuiviMachine.ActionDetaile = TypeTravau.Last().Designation + " / " + itemAlltravaux.Autres;
                        }
                    }
                    ficheSuiviMachines.Add(ficheSuiviMachine);
                }
            }
            return DataSourceLoader.Load(ficheSuiviMachines.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetSuivi(int id, DataSourceLoadOptions loadOptions)
        {
            List<FicheSuiviMachine> ficheSuiviMachines = new List<FicheSuiviMachine>();
            var Alltravaux = _context.AssOtTraveaux.AsNoTracking().Where(c => c.CodeMachine == id)
                .Select(i => new
                {
                    i.NumOt
                }).ToList();
            List<int> OtDone = new List<int>();
            foreach (var itemAlltravaux in Alltravaux)
            {
                OtDone.Add(itemAlltravaux.NumOt);
                //Check for occurences to avoid recalculating the Sam Ot with many Travaux
                var occ = 0;
                foreach (var itemOtDone in OtDone)
                {
                    if (itemAlltravaux.NumOt == itemOtDone)
                    {
                        occ += 1;
                    }
                }
                if (occ == 1)
                {
                    var machineequioement = _context.OrdreTravail.AsNoTracking().Where(c => c.NumOt == itemAlltravaux.NumOt
                    )
                    .Select(i => new
                    {
                        i.DateOt,
                        i.NumDt,
                        i.NumOt
                    }).ToList();
                    foreach (var itemmachineequioement in machineequioement)
                    {
                        var travaux = _context.AssOtTraveaux.AsNoTracking().Where(c => c.NumOt == itemmachineequioement.NumOt && c.CodeMachine == id)
                            .Select(i => new
                            {
                                i.TypeTraveaux,
                                i.CodeMachine,
                                i.CodeEquipement,
                                i.Autres
                            }).ToList();
                        foreach (var itemtravaux in travaux)
                        {
                            FicheSuiviMachine ficheSuiviMachine = new FicheSuiviMachine();
                            var typeTravail = _context.LookupTypeTraveauxOt.AsNoTracking()
                                .FirstOrDefault(c => c.Id == itemtravaux.TypeTraveaux);
                            if (typeTravail.Id != 0)
                            {
                                ficheSuiviMachine.ActionDetaile += typeTravail.Designation;
                            }
                            else
                            {
                                ficheSuiviMachine.ActionDetaile += itemtravaux.Autres;
                            }

                            if (itemtravaux.CodeEquipement != null)
                            {
                                var equipement = _context.MethStructureMachine.AsNoTracking().FirstOrDefault(c => c.Id.ToString() == itemtravaux.CodeEquipement);
                                if(equipement!=null)
                                    ficheSuiviMachine.ActionDetaile += ", de l'équipement" + equipement.Equipement;
                            }
                            ficheSuiviMachine.id = ficheSuiviMachines.Count + 1;
                            ficheSuiviMachine.Datentervention = itemmachineequioement.DateOt;
                            ficheSuiviMachine.NumDt = Convert.ToInt32(itemmachineequioement.NumDt);
                            ficheSuiviMachine.NumOt = itemmachineequioement.NumOt;
                            ficheSuiviMachines.Add(ficheSuiviMachine);
                        }
                    }
                }
            }
            return DataSourceLoader.Load(ficheSuiviMachines.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetSuiviTravaux(int id, DataSourceLoadOptions loadOptions)
        {
            var currentYear = DateTime.Now.Year;

            List<SuiviTravauxMachine> SuiviTravauxMachines = new List<SuiviTravauxMachine>();
            var Alltravaux = _context.AssOtTraveaux.AsNoTracking().Where(c => c.CodeMachine == id)
                .Select(i => new
                {
                    i.NumOt
                }).ToList();
            List<int> OtDone = new List<int>();
            foreach (var itemAlltravaux in Alltravaux)
            {
                OtDone.Add(itemAlltravaux.NumOt);
                //Check for occurences to avoid recalculating the Sam Ot with many Travaux
                var occ = 0;
                foreach (var itemOtDone in OtDone)
                {
                    if (itemAlltravaux.NumOt == itemOtDone)
                    {
                        occ += 1;
                    }
                }
                if (occ == 1)
                {
                    //No occurence lets do it
                    var ordres = _context.OrdreTravail.Where(c => c.NumOt == itemAlltravaux.NumOt && c.CodeMaintenance == Convert.ToBoolean(0)).ToList();
                    foreach (var itemordres in ordres)
                    {
                        var travauxOt = _context.AssOtTraveaux.AsNoTracking().Where(c => c.NumOt == itemordres.NumOt && c.CodeMachine == id).ToList();
                        foreach (var itemtravauxOt in travauxOt)
                        {
                            SuiviTravauxMachine suiviTravauxMachine = new SuiviTravauxMachine();
                            suiviTravauxMachine.DateOt = itemordres.DateOt;
                            suiviTravauxMachine.NumOt = itemordres.NumOt;
                            suiviTravauxMachine.Autres = itemtravauxOt.Autres;
                            if (itemtravauxOt.CodeEquipement != null)
                            {
                                if (!itemtravauxOt.CodeEquipement.Equals(""))
                                {
                                    suiviTravauxMachine.CodeEquipement = Convert.ToInt32(itemtravauxOt.CodeEquipement);
                                }
                            }
                            suiviTravauxMachine.TypeTravaux = Convert.ToInt32(itemtravauxOt.TypeTraveaux);
                            var rapportOt = _context.RapportIntervention.AsNoTracking().Where(c => c.NumOt == itemordres.NumOt).FirstOrDefault();
                            if (rapportOt != null)
                            {
                                suiviTravauxMachine.DureeIntervention = rapportOt.DureeIntervention;
                                suiviTravauxMachine.CompteRendu = rapportOt.CompteRendu;
                            }
                            SuiviTravauxMachines.Add(suiviTravauxMachine);
                        }
                    }
                }
            }

            return DataSourceLoader.Load(SuiviTravauxMachines.AsEnumerable(), loadOptions);
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new MachineEquioement();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            model.NumMachine = XpertHelper.NumMachine;
            var machineEquioement = _context.MachineEquioement
            .AsNoTracking()
            .OrderBy(o => o.Id)
            .Select(i => new
            {
                i.Id
            }).ToList();
            if (machineEquioement.Count > 0)
            {
                var m = machineEquioement.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            else
            {
                model.Id = 1;
            }
            var result = _context.MachineEquioement.Add(model);
            //Gestion des detail de cette equipement
            for (int i = 1; i<=model.Qte;i++)
            {
                MethStructureMachine methStructureMachine = new MethStructureMachine();
                var MethStructureMachine = _context.MethStructureMachine
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();
                if (MethStructureMachine.Count > 0)
                {
                    var mMethStructureMachine = MethStructureMachine.Last();
                    methStructureMachine.Id = Convert.ToInt32(mMethStructureMachine.Id) + 1;
                }
                else
                {
                    methStructureMachine.Id = 1;
                }
                methStructureMachine.CodeInstallation = model.NumMachine;
                methStructureMachine.NumEquipement = model.NumEquipement;
                var Equipements = _context.Equipements
                .AsNoTracking()
                .Where(o => o.NumEquipement == model.NumEquipement)
                .Select(i => new
                {
                    i.NumEquipement,
                    i.Nom,
                    i.Designation
                }).ToList();
                var EquipementsLast = Equipements.Last();
                methStructureMachine.Equipement = EquipementsLast.Nom + EquipementsLast.Designation +" N° : "+ i;
                var resultDeail = _context.MethStructureMachine.Add(methStructureMachine);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.MachineEquioement.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            //Gestion des detail de cette equipement
            //First we delete all the previous Details before doing the update
            var ModelDetail = _context.MethStructureMachine.Where(item => item.NumEquipement == model.NumEquipement).ToList();
            foreach (var itemModelDetail in ModelDetail)
            {
                _context.MethStructureMachine.Remove(itemModelDetail);
                await _context.SaveChangesAsync();
            }
            PopulateModel(model, valuesDict);
            await _context.SaveChangesAsync();
            //After saving the update we comit to detail
            for (int i = 1; i <= model.Qte; i++)
            {
                MethStructureMachine methStructureMachine = new MethStructureMachine();
                var MethStructureMachine = _context.MethStructureMachine
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();
                if (MethStructureMachine.Count > 0)
                {
                    var mMethStructureMachine = MethStructureMachine.Last();
                    methStructureMachine.Id = Convert.ToInt32(mMethStructureMachine.Id) + 1;
                }
                else
                {
                    methStructureMachine.Id = 1;
                }
                methStructureMachine.CodeInstallation = model.NumMachine;
                methStructureMachine.NumEquipement = model.NumEquipement;
                var Equipements = _context.Equipements
                .AsNoTracking()
                .Where(o => o.NumEquipement == model.NumEquipement)
                .Select(i => new
                {
                    i.NumEquipement,
                    i.Nom,
                    i.Designation
                }).ToList();
                var EquipementsLast = Equipements.Last();
                methStructureMachine.Equipement = EquipementsLast.Nom + EquipementsLast.Designation + " N° : " + i;
                var resultDeail = _context.MethStructureMachine.Add(methStructureMachine);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.MachineEquioement.FirstOrDefaultAsync(item => item.Id == key);
            //Gestion des detail de cette equipement
            var ModelDetail = _context.MethStructureMachine.Where(item => item.NumEquipement == model.NumEquipement).ToList();
            foreach (var itemModelDetail in ModelDetail)
            {
                _context.MethStructureMachine.Remove(itemModelDetail);
                await _context.SaveChangesAsync();
            }
            _context.MachineEquioement.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(MachineEquioement model, IDictionary values)
        {
            string ID = nameof(MachineEquioement.Id);
            string NUM_MACHINE = nameof(MachineEquioement.NumMachine);
            string NUM_EQUIPEMENT = nameof(MachineEquioement.NumEquipement);
            string QTE = nameof(MachineEquioement.Qte);
            string COMPOSITION = nameof(MachineEquioement.NumComposition);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(NUM_MACHINE))
            {
                model.NumMachine = Convert.ToInt32(values[NUM_MACHINE]);
            }

            if (values.Contains(NUM_EQUIPEMENT))
            {
                var Idemployevar = values[NUM_EQUIPEMENT];
                var Idemployestrings = Idemployevar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var value = SplitThesecond[0];
                model.NumEquipement = Convert.ToInt32(value);
            }

            if (values.Contains(QTE))
            {
                model.Qte = Convert.ToInt32(values[QTE]);
            }

            if (values.Contains(COMPOSITION))
            {
                model.NumComposition = Convert.ToString(values[COMPOSITION]);
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
    }
}