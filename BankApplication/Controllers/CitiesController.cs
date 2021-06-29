using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    public class CitiesController : Controller
    {
        private readonly banksystemdbContext _context;

        public CitiesController(banksystemdbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cities = _context.Cities.ToList();

            return View(cities);
        }
    }
}
