using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Microsoft.AspNetCore.Http;
using Harissa.Data.HelperClass;

namespace Harissa.Intranet.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly HarissaContext _context;

        public ConcertsController(HarissaContext context)
        {
            _context = context;
        }

        private void naviPack()
        {
            ViewBag.Icon = "bi bi-calendar-event";
        }

        // GET: Concerts
        public async Task<IActionResult> Index()
        {
            naviPack();
            ViewBag.Action = "";
            ViewBag.Path = "Concerts";
            ViewBag.ConcertList = await _context.Concerts.ToListAsync();
            return View();
        }


        // POST: Concerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcertID,Name,Address,Description,Link,Price,Date,MediaItem")] Concert concert, IFormFile FormFileItem )
        {
            if (ModelState.IsValid)
            {
                concert.MediaItem = new CloudAccess().AddPic(FormFileItem, "Concerts");
                _context.Add(concert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concert);
        }

        // GET: Concerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            naviPack();
            ViewBag.Action = "Back";
            ViewBag.Path = "Concerts / Edit";

            var concert = await _context.Concerts.FindAsync(id);
            if (concert == null)
            {
                return NotFound();
            }
            return View(concert);
        }

        // POST: Concerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConcertID,Name,Address,Description,Link,Price,Date,MediaItem")] Concert concert, IFormFile FormFileItem)
        {
            if (id != concert.ConcertID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    concert.MediaItem = new CloudAccess().ChangeItem(concert.MediaItem, FormFileItem, "Concerts");                        
                    _context.Update(concert);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertExists(concert.ConcertID))
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
            return View(concert);
        }

        // GET: Concerts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            naviPack();
            ViewBag.Path = "Concerts / Delete";
            ViewBag.Action = "Back";
            if (id == null)
            {
                return NotFound();
            }

            naviPack();


            var concert = await _context.Concerts
                .FirstOrDefaultAsync(m => m.ConcertID == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // POST: Concerts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concert = await _context.Concerts.FindAsync(id);
            _context.Concerts.Remove(concert);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertExists(int id)
        {
            return _context.Concerts.Any(e => e.ConcertID == id);
        }
    }
}
