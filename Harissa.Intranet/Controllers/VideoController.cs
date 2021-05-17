using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Harissa.Intranet.Controllers.Abstract;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Harissa.Intranet.Controllers
{
    public class VideoController : BaseClassController
    {
        public VideoController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }

        public async Task<IActionResult> Up(int index)
        {
            var videoList = await _context.Videos.ToListAsync();
            Video videoUp = videoList.FirstOrDefault(f => f.Index == index);
            var nextList = videoList.Where(w => w.Index > videoUp.Index).Select(s => s.Index);
            
            if(nextList.Count() == 0)
                return RedirectToAction("Index");
            
            int indexNext = nextList.Min();
            Video videoDown = videoList.FirstOrDefault(f => f.Index == indexNext);
            List<Video> vlist = swapPlaces(videoUp, videoDown);
            _context.Update(vlist[0]);
            _context.Update(vlist[1]);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Down(int index)
        {
            var videoList = await _context.Videos.ToListAsync();
            Video videoDown = videoList.FirstOrDefault(f => f.Index == index);
            var nextList = videoList.Where(w => w.Index < videoDown.Index).Select(s => s.Index);
            
            if(nextList.Count() == 0)
                return RedirectToAction("Index");
            
            int indexNext = nextList.Max();
            Video videoUp = videoList.FirstOrDefault(f => f.Index == indexNext);
            List<Video> vlist = swapPlaces(videoUp, videoDown);
            _context.Update(vlist[0]);
            _context.Update(vlist[1]);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private List<Video> swapPlaces(Video x, Video y)
        {
            int z = x.Index;
            x.Index = y.Index;
            y.Index = z;
            return new List<Video> { x, y };
        }

        // GET: Video
        public async Task<IActionResult> Index()
        {
            ViewBag.VideoList = await _context.Videos.OrderByDescending(o => o.Index).ToListAsync();
            return View();
        }


        // POST: Video/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VideoID,Link")] Video video)
        {
            
            if (ModelState.IsValid)
            {
                video.Link = video.Link.Replace("https://", "");
                video.Link = video.Link.Replace("www.", "");
                video.Link = video.Link.Replace("youtu.be/", "");
                video.Link = video.Link.Replace("youtube.com/watch?v=", "");

                video.Index = _context.Videos.Count() + 1;
                _context.Add(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = "Bad link to the video";
            return View("Index");
        }

        // GET: Video/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var video = await _context.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Video/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VideoID,Link")] Video video)
        {
            if (id != video.VideoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(video);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.VideoID))
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
            return View(video);
        }


        // POST: Video/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var video = await _context.Videos.FindAsync(id);
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(e => e.VideoID == id);
        }
    }
}
