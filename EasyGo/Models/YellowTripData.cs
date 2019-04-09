using System;
using System.Collections.Generic;

namespace EasyGo.Models
{
    public partial class YellowTripData
    {
        public long Id { get; set; }
        public string VendorId { get; set; }
        public DateTime? PickupDateTime { get; set; }
        public DateTime? DropOffDateTime { get; set; }
        public int? PassangerCount { get; set; }
        public string TripDistance { get; set; }
        public int? RateCodeId { get; set; }
        public string StoreAndForwardFlag { get; set; }
        public int? PickupLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public int? PaymentType { get; set; }
        public string FareAmount { get; set; }
        public string Extra { get; set; }
        public string MtaTax { get; set; }
        public string TipAmount { get; set; }
        public string TollsAmount { get; set; }
        public string ImprovementSurcharge { get; set; }
        public string TotalAmount { get; set; }
    }
}
