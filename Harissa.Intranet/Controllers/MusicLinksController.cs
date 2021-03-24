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
    public class MusicLinksController : Controller
    {
        private readonly HarissaContext _context;

        public MusicLinksController(HarissaContext context)
        {
            _context = context;
        }

        // GET: MusicLinks
        public async Task<IActionResult> Index()
        {
            var harissaContext = _context.MusicLinks.Include(m => m.Music).Include(m => m.MusicPlatform);
            return View(await harissaContext.ToListAsync());
        }

        // GET: MusicLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicLink = await _context.MusicLinks
                .Include(m => m.Music)
                .Include(m => m.MusicPlatform)
                .FirstOrDefaultAsync(m => m.MusicLinkID == id);
            if (musicLink == null)
            {
                return NotFound();
            }

            return View(musicLink);
        }

        // GET: MusicLinks/Create
        public IActionResult Create()
        {
            ViewData["MusicID"] = new SelectList(_context.Musics, "MusicID", "IFrame");
            ViewData["MusicPlatformID"] = new SelectList(_context.MusicPlatforms, "MusicPlatformID", "Name");
            return View();
        }

        // POST: MusicLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicLinkID,LinkToAlbum,MusicPlatformID,MusicID")] MusicLink musicLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musicLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusicID"] = new SelectList(_context.Musics, "MusicID", "IFrame", musicLink.MusicID);
            ViewData["MusicPlatformID"] = new SelectList(_context.MusicPlatforms, "MusicPlatformID", "Name", musicLink.MusicPlatformID);
            return View(musicLink);
        }

        // GET: MusicLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicLink = await _context.MusicLinks.FindAsync(id);
            if (musicLink == null)
            {
                return NotFound();
            }
            ViewData["MusicID"] = new SelectList(_context.Musics, "MusicID", "IFrame", musicLink.MusicID);
            ViewData["MusicPlatformID"] = new SelectList(_context.MusicPlatforms, "MusicPlatformID", "Name", musicLink.MusicPlatformID);
            return View(musicLink);
        }

        // POST: MusicLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusicLinkID,LinkToAlbum,MusicPlatformID,MusicID")] MusicLink musicLink)
        {
            if (id != musicLink.MusicLinkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musicLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicLinkExists(musicLink.MusicLinkID))
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
            ViewData["MusicID"] = new SelectList(_context.Musics, "MusicID", "IFrame", musicLink.MusicID);
            ViewData["MusicPlatformID"] = new SelectList(_context.MusicPlatforms, "MusicPlatformID", "Name", musicLink.MusicPlatformID);
            return View(musicLink);
        }

        // GET: MusicLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musicLink = await _context.MusicLinks
                .Include(m => m.Music)
                .Include(m => m.MusicPlatform)
                .FirstOrDefaultAsync(m => m.MusicLinkID == id);
            if (musicLink == null)
            {
                return NotFound();
            }

            return View(musicLink);
        }

        // POST: MusicLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musicLink = await _context.MusicLinks.FindAsync(id);
            _context.MusicLinks.Remove(musicLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicLinkExists(int id)
        {
            return _context.MusicLinks.Any(e => e.MusicLinkID == id);
        }
    }
}
