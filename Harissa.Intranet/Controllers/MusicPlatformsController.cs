using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Harissa.Data.HelperClass;

namespace Harissa.Intranet.Controllers
{
    public class MusicPlatformsController : Controller
    {
        private readonly HarissaContext _context;

        public MusicPlatformsController(HarissaContext context)
        {
            _context = context;
        }

        // GET: MusicPlatforms
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusicPlatforms.ToListAsync());
        }

        // GET: MusicPlatforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicPlatform = await _context.MusicPlatforms
                .FirstOrDefaultAsync(m => m.MusicPlatformID == id);
            if (musicPlatform == null)
            {
                return NotFound();
            }

            return View(musicPlatform);
        }

        // GET: MusicPlatforms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicPlatforms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicPlatformID,Name,NewIcon")] MusicPlatform musicPlatform)
        {
            if (ModelState.IsValid)
            {
                musicPlatform.Icon = new CloudAccess().AddPic(musicPlatform.NewIcon, "Music");
                _context.Add(musicPlatform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musicPlatform);
        }

        // GET: MusicPlatforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicPlatform = await _context.MusicPlatforms.FindAsync(id);
            if (musicPlatform == null)
            {
                return NotFound();
            }
            return View(musicPlatform);
        }

        // POST: MusicPlatforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusicPlatformID,Name,Icon")] MusicPlatform musicPlatform)
        {
            if (id != musicPlatform.MusicPlatformID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicPlatform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicPlatformExists(musicPlatform.MusicPlatformID))
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
            return View(musicPlatform);
        }

        // GET: MusicPlatforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicPlatform = await _context.MusicPlatforms
                .FirstOrDefaultAsync(m => m.MusicPlatformID == id);
            if (musicPlatform == null)
            {
                return NotFound();
            }

            return View(musicPlatform);
        }

        // POST: MusicPlatforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicPlatform = await _context.MusicPlatforms.FindAsync(id);
            _context.MusicPlatforms.Remove(musicPlatform);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicPlatformExists(int id)
        {
            return _context.MusicPlatforms.Any(e => e.MusicPlatformID == id);
        }
    }
}
