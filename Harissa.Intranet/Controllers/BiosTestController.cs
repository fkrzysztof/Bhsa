using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;

namespace Harissa.Intranet.Controllers
{
    public class BiosTestController : Controller
    {
        private readonly HarissaContext _context;

        public BiosTestController(HarissaContext context)
        {
            _context = context;
        }

        // GET: BiosTest
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bio.ToListAsync());
        }

        // GET: BiosTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bio
                .FirstOrDefaultAsync(m => m.BioID == id);
            if (bio == null)
            {
                return NotFound();
            }

            return View(bio);
        }

        // GET: BiosTest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BiosTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BioID,Text")] Bio bio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bio);
        }

        // GET: BiosTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bio.FindAsync(id);
            if (bio == null)
            {
                return NotFound();
            }
            return View(bio);
        }

        // POST: BiosTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BioID,Text")] Bio bio)
        {
            if (id != bio.BioID)
            {
                return NotFound();
            }

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

        // GET: BiosTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bio = await _context.Bio
                .FirstOrDefaultAsync(m => m.BioID == id);
            if (bio == null)
            {
                return NotFound();
            }

            return View(bio);
        }

        // POST: BiosTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bio = await _context.Bio.FindAsync(id);
            _context.Bio.Remove(bio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioExists(int id)
        {
            return _context.Bio.Any(e => e.BioID == id);
        }
    }
}
