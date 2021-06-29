using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankApplication;

namespace BankApplication.Controllers
{
    public class BankclientsController : Controller
    {
        private readonly banksystemdbContext _context;

        public BankclientsController(banksystemdbContext context)
        {
            _context = context;
        }

        // GET: Bankclients
        public async Task<IActionResult> Index()
        {
            var banksystemdbContext = _context.Bankclients.Include(b => b.CityIdKeyNavigation).Include(b => b.CountryIdKeyNavigation);
            return View(await banksystemdbContext.ToListAsync());
        }

        // GET: Bankclients/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankclient = await _context.Bankclients
                .Include(b => b.CityIdKeyNavigation)
                .Include(b => b.CountryIdKeyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankclient == null)
            {
                return NotFound();
            }

            return View(bankclient);
        }

        // GET: Bankclients/Create
        public IActionResult Create()
        {
            ViewData["CityIdKey"] = new SelectList(_context.Cities, "Id", "CityName");
            ViewData["CountryIdKey"] = new SelectList(_context.Countries, "Id", "CountryName");
            return View();
        }

        // POST: Bankclients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientFullName,CountryId,CountryIdKey,CityId,CityIdKey,Address,UniqueIdentityNumber,ClientBirthday")] Bankclient bankclient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankclient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityIdKey"] = new SelectList(_context.Cities, "Id", "CityName", bankclient.CityIdKey);
            ViewData["CountryIdKey"] = new SelectList(_context.Countries, "Id", "CountryName", bankclient.CountryIdKey);
            return View(bankclient);
        }

        // GET: Bankclients/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankclient = await _context.Bankclients.FindAsync(id);
            if (bankclient == null)
            {
                return NotFound();
            }

            var accounts = _context.Accounts.ToList();

            var acc = accounts.SingleOrDefault(a => a.BankClientId == id);

            if (acc == null)
            {
                return NotFound();
            }


            ViewData["CityIdKey"] = new SelectList(_context.Cities, "Id", "CityName", bankclient.CityIdKey);
            ViewData["CountryIdKey"] = new SelectList(_context.Countries, "Id", "CountryName", bankclient.CountryIdKey);
            ViewData["ClientAcc"] = acc;


            return View(bankclient);
        }

        // POST: Bankclients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ClientFullName,CountryId,CountryIdKey,CityId,CityIdKey,Address,UniqueIdentityNumber,ClientBirthday")] Bankclient bankclient)
        {
            if (id != bankclient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankclient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankclientExists(bankclient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityIdKey"] = new SelectList(_context.Cities, "Id", "CityName", bankclient.CityIdKey);
            ViewData["CountryIdKey"] = new SelectList(_context.Countries, "Id", "CountryName", bankclient.CountryIdKey);
            return View(bankclient);
        }

        // GET: Bankclients/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankclient = await _context.Bankclients
                .Include(b => b.CityIdKeyNavigation)
                .Include(b => b.CountryIdKeyNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankclient == null)
            {
                return NotFound();
            }

            return View(bankclient);
        }

        // POST: Bankclients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bankclient = await _context.Bankclients.FindAsync(id);
            _context.Bankclients.Remove(bankclient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankclientExists(long id)
        {
            return _context.Bankclients.Any(e => e.Id == id);
        }
    }
}
