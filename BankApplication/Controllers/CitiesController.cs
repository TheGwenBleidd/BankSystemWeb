using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankApplication.Expando;

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

        public IActionResult GroupbyCity()
        {

            var query = (from city in _context.Cities
                        join client in _context.Bankclients on city.Id equals client.CityId
                        select new { FullName = client.ClientFullName, CityName = city.CityName, Address = client.Address, IIN = client.UniqueIdentityNumber, BirthDay = client.ClientBirthday }).OrderByDescending(c => c.CityName).AsEnumerable().Select(c=> c.ToExpando());

            return View(query);
        }


    }
}
