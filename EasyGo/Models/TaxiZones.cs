using System;
using System.Collections.Generic;

namespace EasyGo.Models
{
    public partial class TaxiZones
    {
        public long Id { get; set; }
        public string LocationId { get; set; }
        public string Borough { get; set; }
        public string TaxiZone { get; set; }
        public string ServiceZone { get; set; }
    }
}
