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
    public class GreenTripDatasController : ControllerBase
    {
        private readonly easygoContext _context;

        public GreenTripDatasController(easygoContext context)
        {
            _context = context;
        }

        // GET: api/GreenTripDatas
        [HttpPost]
        public TripStatistics GetGreenTripData(string from, string to, string date)
        {
            if (!string.IsNullOrEmpty(date))
                return _context.GetGreenCabTripStatistics(Convert.ToInt32(from), Convert.ToInt32(to), Convert.ToDateTime(date));
            else
                return _context.GetGreenCabTripStatistics(Convert.ToInt32(from), Convert.ToInt32(to), null);

            //return new TripStatistics
            //{
            //    AfternoonTripsCount = 14,
            //    AverageCost = 22.50m,
            //    AverageDistance = 15,
            //    AveragePassangerCount = 3,
            //    AverageTime = 20.5m,
            //    AverageTip = 5,
            //    AverageTollAmount = 2,
            //    EveningTripsCount = 12,
            //    FridayTripsCount = 15,
            //    From = "test5",
            //    MondayTripsCount = 12,
            //    MorningTripsCount = 9,
            //    SaturdayTripsCount = 32,
            //    SundayTripsCount = 34,
            //    ThursdayTripsCount = 21,
            //    To = "test6",
            //    TuesdayTripsCount = 43,
            //    WednesdayTripsCount = 44
            //};
        }

        
        private bool GreenTripDataExists(long id)
        {
            return _context.GreenTripData.Any(e => e.Id == id);
        }
    }
}