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
    public class FhvTripDatasController : ControllerBase
    {
        private readonly easygoContext _context;

        public FhvTripDatasController(easygoContext context)
        {
            _context = context;
        }

        // GET: api/FhvTripDatas
        [HttpPost]
        public TripStatistics GetFhvTripData(string from, string to, string date)
        {
            if (!string.IsNullOrEmpty(date))
                return _context.GetFhvTripStatistics(Convert.ToInt32(from), Convert.ToInt32(to), Convert.ToDateTime(date));
            else
                return _context.GetFhvTripStatistics(Convert.ToInt32(from), Convert.ToInt32(to), null);

            //return _context.FhvTripData;
            //return new TripStatistics {
            //    AfternoonTripsCount = 8,
            //    AverageCost = 30.50m,
            //    AverageDistance = 10,
            //    AveragePassangerCount = 3,
            //    AverageTime = 30,
            //    AverageTip = 5,
            //    AverageTollAmount = 1,
            //    EveningTripsCount =10,
            //    FridayTripsCount = 20,
            //    From = "test1",
            //    MondayTripsCount = 50,
            //    MorningTripsCount = 8,
            //    SaturdayTripsCount = 60,
            //    SundayTripsCount = 70,
            //    ThursdayTripsCount = 90,
            //    To = "test2",
            //    TuesdayTripsCount = 80,
            //    WednesdayTripsCount = 70
            //};
        }

        private bool FhvTripDataExists(long id)
        {
            return _context.FhvTripData.Any(e => e.Id == id);
        }
    }
}