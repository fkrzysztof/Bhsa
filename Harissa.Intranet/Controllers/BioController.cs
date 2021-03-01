using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Harissa.Intranet.Controllers.Abstract;
using Microsoft.Extensions.Logging;

namespace Harissa.Intranet.Controllers
{
    public class BioController : BaseClassController
    {
        public BioController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }

        private void naviPack()
        {
            ViewBag.Icon = "fas fa-book-open";
            ViewBag.Path = "Bio";
            logo();
        }

        public async Task<IActionResult> Index()
        {
            naviPack();
            var bio = await _context.Bio.FirstOrDefaultAsync();
            if (bio == null)
            {
                await _context.Bio.AddAsync(new Bio() { Text = "Napisz text" });
                await _context.SaveChangesAsync();
                var x = await _context.Bio.FirstAsync();
                return View(x);
            }
            return View(bio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("BioID,Text")] Bio bio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioExists(bio.BioID))
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
            return View(bio);
        }
        
        private bool BioExists(int id)
        {
            return _context.Bio.Any(e => e.BioID == id);
        }
    }
}
