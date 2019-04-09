using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyGo.Models;

namespace EasyGo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YellowTripDatasController : ControllerBase
    {
        private readonly easygoContext _context;

        public YellowTripDatasController(easygoContext context)
        {
            _context = context;
        }

        // GET: api/YellowTripDatas
        [HttpPost]
        public TripStatistics GetYellowTripData(string from, string to, string date)
        {
            if (!string.IsNullOrEmpty(date))
                return _context.GetYellowCabTripStatistics(Convert.ToInt32(from), Convert.ToInt32(to), Convert.ToDateTime(date));
            else
                return _context.GetYellowCabTripStatistics(Convert.ToInt32(from), Convert.ToInt32(to), null);

            //return new TripStatistics
            //{
            //    AfternoonTripsCount = 1,
            //    AverageCost = 20.50m,
            //    AverageDistance = 20,
            //    AveragePassangerCount = 6,
            //    AverageTime = 40,
            //    AverageTip = 3,
            //    AverageTollAmount = 2,
            //    EveningTripsCount = 2,
            //    FridayTripsCount = 6,
            //    From = "test3",
            //    MondayTripsCount = 10,
            //    MorningTripsCount = 4,
            //    SaturdayTripsCount = 20,
            //    SundayTripsCount = 17,
            //    ThursdayTripsCount = 18,
            //    To = "test4",
            //    TuesdayTripsCount = 12,
            //    WednesdayTripsCount = 14
            //};
        }

        private bool YellowTripDataExists(long id)
        {
            return _context.YellowTripData.Any(e => e.Id == id);
        }
    }
}