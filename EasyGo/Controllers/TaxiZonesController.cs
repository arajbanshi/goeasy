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
    public class TaxiZonesController : ControllerBase
    {
        private readonly easygoContext _context;

        public TaxiZonesController(easygoContext context)
        {
            _context = context;
        }

        // GET: api/TaxiZones
        [HttpGet]
        public IEnumerable<TaxiZones> GetTaxiZones()
        {
            return _context.TaxiZones.OrderBy(t => t.Borough).ToList();
        }

        private bool TaxiZonesExists(long id)
        {
            return _context.TaxiZones.Any(e => e.Id == id);
        }
    }
}