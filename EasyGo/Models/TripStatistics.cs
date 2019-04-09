using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGo.Models
{
    public class TripStatistics
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal AverageCost { get; set; }
        public decimal AverageTime { get; set; }
        public decimal AverageDistance { get; set; }
        public int AveragePassangerCount { get; set; }
        public decimal AverageTip { get; set; }
        public decimal AverageTollAmount { get; set; }
        public int MorningTripsCount { get; set; }
        public int AfternoonTripsCount { get; set; }
        public int EveningTripsCount { get; set; }
        public int MondayTripsCount { get; set; }
        public int TuesdayTripsCount { get; set; }
        public int WednesdayTripsCount { get; set; }
        public int ThursdayTripsCount { get; set; }
        public int FridayTripsCount { get; set; }
        public int SaturdayTripsCount { get; set; }
        public int SundayTripsCount { get; set; }
    }
}
