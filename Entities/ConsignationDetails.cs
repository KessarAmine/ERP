using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ConsignationDetails
    {
        public int Id { get; set; }
        public int? NumConsignation { get; set; }
        public bool Signalsiation { get; set; }
        public bool Separation { get; set; }
        public bool Condamnation { get; set; }
        public bool Identification { get; set; }
        public bool Verification { get; set; }
        public string AutresOperation { get; set; }
        public string MesureSecurite { get; set; }
        public int IdChargeConsignation { get; set; }
        public DateTime DateChargeConsignation { get; set; }
        public int IdChargeTravaux { get; set; }
        public DateTime DateChargeTravaux { get; set; }
        public int IdChangementChargeTravaux { get; set; }
        public DateTime DateChangementChargeTravaux { get; set; }
    }
}
