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
    public class SocialMediasController : Controller
    {
        private readonly HarissaContext _context;

        public SocialMediasController(HarissaContext context)
        {
            _context = context;
        }

        // GET: SocialMedias
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialMedias.ToListAsync());
        }

        // GET: SocialMedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias
                .FirstOrDefaultAsync(m => m.SocialMediaID == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        // GET: SocialMedias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("SocialMediaView.SocialMediaID,SocialMediaView.Name," +
        //    "SocialMediaView.Link,SocialMediaView.Icon")] SocialMedia socialMedia)

        public async Task<IActionResult> Create(/*[Bind("SocialMediaView.Name, SocialMediaView.Link, SocialMediaView.Icon")]*/ViewPageSettings vps)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vps.SocialMediaView);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index","PageSettings");
            }
            return View(vps);
        }

        // GET: SocialMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            return View(socialMedia);
        }

        // POST: SocialMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("SocialMediaID,Name,Link,Icon")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaExists(socialMedia.SocialMediaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","PageSettings");
            }
            return View(socialMedia);
        }

        // GET: SocialMedias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedias
                .FirstOrDefaultAsync(m => m.SocialMediaID == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        // POST: SocialMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            _context.SocialMedias.Remove(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaExists(int id)
        {
            return _context.SocialMedias.Any(e => e.SocialMediaID == id);
        }
    }
}
