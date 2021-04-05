using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Harissa.Data.HelperClass;
using Harissa.Intranet.Controllers.Abstract;
using Microsoft.Extensions.Logging;

namespace Harissa.Intranet.Controllers
{
    public class MusicPlatformsController : BaseClassController
    {
        public MusicPlatformsController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }

        // GET: MusicPlatforms
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusicPlatforms.ToListAsync());
        }


        // POST: MusicPlatforms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusicPlatformID,Name,NewIcon,UrlArtist")] MusicPlatform musicPlatform)
        {
            if (ModelState.IsValid)
            {
                musicPlatform.Icon = new CloudAccess().AddPic(musicPlatform.NewIcon, "Music");
                _context.Add(musicPlatform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index",musicPlatform);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusicPlatformID,Name,Icon,UrlArtist,NewIcon")] MusicPlatform musicPlatform)
        {
            if (id != musicPlatform.MusicPlatformID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    musicPlatform.Icon = new CloudAccess().ChangeItem(musicPlatform.Icon ,musicPlatform.NewIcon, "Music");
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
            new CloudAccess().Remove(musicPlatform.Icon);
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
