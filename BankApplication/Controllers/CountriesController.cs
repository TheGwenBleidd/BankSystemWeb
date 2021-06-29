using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    public class CountriesController : Controller
    {
        private readonly banksystemdbContext _context;

        public CountriesController(banksystemdbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.ToList();

            return View(countries);
        }
    }
}
