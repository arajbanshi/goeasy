using System;
using System.Collections.Generic;

namespace EasyGo.Models
{
    public partial class FhvTripData
    {
        public long Id { get; set; }
        public string DispatchingBaseNum { get; set; }
        public string PickupDateTime { get; set; }
        public string DropOffDateTime { get; set; }
        public string PickupLocationId { get; set; }
        public string DropOffLocationId { get; set; }
        public string SrFlag { get; set; }
        public string DispatchBaseNum { get; set; }
        public DateTime? PkpDateTime { get; set; }
        public DateTime? DropDateTime { get; set; }
        public int? PkpLocationId { get; set; }
        public int? DropLocationId { get; set; }
        public int? Srflag1 { get; set; }
    }
}
