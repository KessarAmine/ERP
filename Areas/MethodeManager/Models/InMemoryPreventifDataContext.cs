using DevKbfSteel.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MethodeManager.Models
{
    public class InMemoryPreventifDataContext : InMemoryDataContext<MethPlanningPreventifsModel>
    {
        public InMemoryPreventifDataContext(IHttpContextAccessor contextAccessor, IMemoryCache memoryCache)
            : base(contextAccessor, memoryCache){
        }
        public ICollection<MethPlanningPreventifsModel> Preventifs => ItemsInternal;
        protected override IEnumerable<MethPlanningPreventifsModel> Source => SampleDataPreventif.MethPlanningPreventifsModeldata;
        protected override int GetKey(MethPlanningPreventifsModel item) => item.AppointmentId;
        protected override void SetKey(MethPlanningPreventifsModel item, int key) => item.AppointmentId = key;
    }
}



