using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.MethodeManager.Models
{
    public class SampleDataPreventif
    {
        public static IEnumerable<MethPlanningPreventifsModel> MethPlanningPreventifsModeldata = new[] {
            new MethPlanningPreventifsModel {
                AppointmentId = 1,
                Text = "Changement de crrois en VR01",
                StartDate = "2021-05-24T16:30:00.000Z",
                EndDate = "2021-05-24T18:30:00.000Z"
            },
            new MethPlanningPreventifsModel {
                AppointmentId = 2,
                Text = "Book Flights to San Fran for Sales Trip",
                StartDate = "2021-05-24T19:00:00.000Z",
                EndDate = "2021-05-24T20:00:00.000Z",
                AllDay = true
            },
            new MethPlanningPreventifsModel {
                AppointmentId = 3,
                Text = "Install New Router in Dev Room",
                StartDate = "2021-05-24T21:30:00.000Z",
                EndDate = "2021-05-24T22:30:00.000Z"
            },
            new MethPlanningPreventifsModel {
                AppointmentId = 4,
                Text = "Approve Personal Computer Upgrade Plan",
                StartDate = "2021-05-25T17:00:00.000Z",
                EndDate = "2021-05-25T18:00:00.000Z"
            },
            new MethPlanningPreventifsModel {
                AppointmentId = 5,
                Text = "Final Budget Review",
                StartDate = "2021-05-25T19:00:00.000Z",
                EndDate = "2021-05-25T20:35:00.000Z"
            }
        };
    }
}