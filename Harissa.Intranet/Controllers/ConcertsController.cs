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
    public class ConcertsController : BaseClassController
    {
        public ConcertsController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }


        // GET: Concerts
        public async Task<IActionResult> Index()
        {
            ViewBag.ConcertList = await _context.Concerts.OrderByDescending(o => o.Date).ToListAsync();
            return View();
        }


        // POST: Concerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcertID,Name,Address,Description,Link,Price,Date,MediaItem,FormFileItem")] Concert concert )
        {
            if (ModelState.IsValid)
            {
                concert.MediaItem = new CloudAccess().AddPic(concert.FormFileItem, "Concerts");
                _context.Add(concert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index",concert);
        }

        // GET: Concerts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert =  await _context.Concerts.FindAsync(id);

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
        public async Task<IActionResult> Edit(int id, [Bind("ConcertID,Name,Address,Description,Link,Price,Date,MediaItem,FormFileItem")] Concert concert)
        {

            if (id != concert.ConcertID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(concert.MediaItem != null)
                        concert.MediaItem = new CloudAccess().ChangeItem(concert.MediaItem, concert.FormFileItem, "Concerts");                        
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
            if (id == null)
            {
                return NotFound();
            }

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
