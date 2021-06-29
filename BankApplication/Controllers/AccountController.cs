using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly banksystemdbContext _context;

        public AccountController(banksystemdbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Show(long? id)
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

            return View(acc);
        }
    }
}
