using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Harissa.Data.HelperClass;
using Microsoft.AspNetCore.Http;
using Harissa.Intranet.Controllers.Abstract;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Harissa.Intranet.Controllers
{
    public class NewsController : BaseClassController
    {
        public NewsController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.Include(i => i.NewsMediaCollections).OrderByDescending(o => o.DateOfPublication).ToListAsync());
        }        
        

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsID,Title,Message,DateOfPublication,FormFileItem")] News news, IFormFile[] newsMediaCollectionItem)
        {
            if (ModelState.IsValid)
            {

                if(news.FormFileItem != null)
                {
                    news.MediaItem = new CloudAccess().AddPic(news.FormFileItem, "News");
                }

                if(newsMediaCollectionItem != null)
                {
                    List<NewsMediaCollection> newsMediaList = new List<NewsMediaCollection>();
                    foreach (var item in newsMediaCollectionItem)
                    {
                        newsMediaList.Add(new NewsMediaCollection() { MediaItem = new CloudAccess().AddPic(item, "News") });
                    }
                    news.NewsMediaCollections = newsMediaList;
                }
                _context.Add(news);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.Include(i => i.NewsMediaCollections).FirstOrDefaultAsync(f => f.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsID,MediaItem,Title,Message,DateOfPublication,FormFileItem")] News news, IFormFile[] newsMediaCollectionItem)
        {
            if (id != news.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (news.FormFileItem != null)
                    {
                        news.MediaItem = new CloudAccess().ChangeItem(news.MediaItem, news.FormFileItem, "News");
                    }
                    if (newsMediaCollectionItem != null)
                    {
                        if(news.NewsMediaCollections != null)
                        {
                            foreach (var item in newsMediaCollectionItem)
                            {
                                news.NewsMediaCollections.Add(new NewsMediaCollection() { MediaItem = new CloudAccess().AddPic(item, "News") });
                            }
                        }
                        else
                        {
                            List<NewsMediaCollection> newsMediaList = new List<NewsMediaCollection>();
                            foreach (var item in newsMediaCollectionItem)
                            {
                                newsMediaList.Add(new NewsMediaCollection() { MediaItem = new CloudAccess().AddPic(item, "News") });
                            }
                            news.NewsMediaCollections = newsMediaList;
                        }
                    }
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsID))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            ViewBag.Message = "Are you sure you want to delete this ?";

            var news = await _context.News.FirstOrDefaultAsync(m => m.NewsID == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        //POST: News/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News
                .Include(i => i.NewsMediaCollections)
                .FirstOrDefaultAsync(f => f.NewsID == id);
            new CloudAccess().Remove(news.MediaItem);
            new CloudAccess().Remove(news.NewsMediaCollections.Select(s => s.MediaItem).ToList());
            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //public async Task<ActionResult> NewsMediaItems()
        //{
        //    var query = await _context.NewsMediaCollections
        //        .Select(s => new { publicId = s.MediaItem }).ToArrayAsync();
        //    return Json(query);
        //}

        [HttpPost]
        public async Task<bool> RemoveJS(int id)
        {
            if (id < 0)
                return false;
            var newsMedia = await _context.NewsMediaCollections.FindAsync(id);
            var query = _context.NewsMediaCollections.Remove(newsMedia).State.ToString();
            if (query != "Deleted")
            {
                return false;
            }
            else
                await _context.SaveChangesAsync();
            return true;
        }


        public async Task<ActionResult> ImgToModalNews(int id)
        {
            var query = await _context.NewsMediaCollections
                .Where(w => w.NewsID == id)
                .Select(s => new { publicId = s.MediaItem }).ToArrayAsync();
            return Json(query);
        }


        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsID == id);
        }
    }
}
