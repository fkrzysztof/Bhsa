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
using Harissa.Intranet.Controllers.Abstract;
using Microsoft.Extensions.Logging;

namespace Harissa.Intranet.Controllers
{
    public class MusicController : BaseClassController
    {
        public MusicController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }

        private void naviPack()
        {
            ViewBag.Path = "Music";
            ViewBag.Icon = "fas fa-volume-up";
            logo();
        }

        // GET: Music
        public async Task<IActionResult> Index()
        {
            naviPack();
            return View(await _context.Musics.Include(i => i.MusicLinks).ThenInclude(m => m.MusicPlatform).ToListAsync());
        }

        // GET: Music/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Musics
                .FirstOrDefaultAsync(m => m.MusicID == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // GET: Music/Create
        public IActionResult Create()
        {
            ViewBag.MusicPlatfomrs = _context.MusicPlatforms.ToList();
            return View();
        }

        // POST: Music/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicID,IFrame,Title,DateOfPublication,NewCover")] Music music, string[]LinkToAlbum)
        {
            if (ModelState.IsValid)
            {
                List<MusicLink> musicLinkList = new List<MusicLink>();

                for (int i = 0; i < LinkToAlbum.Length; i++)
                {
                    musicLinkList.Add(new MusicLink {
                        MusicPlatformID =  Convert.ToInt32(LinkToAlbum[i]),
                        LinkToAlbum = LinkToAlbum[++i],
                    }) ;
                    music.MusicLinks = musicLinkList;
                    _context.Musics.Add(music);
                }
                music.Cover = new CloudAccess().AddPic(music.NewCover, "Cover");
                _context.Add(music);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        // GET: Music/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Musics.FindAsync(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        // POST: Music/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusicID,IFrame,Title,DateOfPublication,Cover")] Music music)
        {
            if (id != music.MusicID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(music);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusicExists(music.MusicID))
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
            return View(music);
        }

        // GET: Music/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var music = await _context.Musics
                .FirstOrDefaultAsync(m => m.MusicID == id);
            if (music == null)
            {
                return NotFound();
            }

            return View(music);
        }

        // POST: Music/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var music = await _context.Musics.FindAsync(id);
            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicExists(int id)
        {
            return _context.Musics.Any(e => e.MusicID == id);
        }
    }
}
