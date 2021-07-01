using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankApplication.Expando;

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

        public IActionResult GroupbyCounrty()
        {

            var query = (from country in _context.Countries
                         join client in _context.Bankclients on country.Id equals client.CityId
                         select new { country.CountryName, client.Id }
                         into x
                         group x by new { x.CountryName }
                         into y
                         select new
                         {
                             y.Key.CountryName,
                             Count = y.Select(x => x.Id).Count()
                         }).AsEnumerable().Select(c => c.ToExpando());

            return View(query);
        }
    }
}
