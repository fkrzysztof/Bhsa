using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Harissa.WWW.Models;
using Harissa.Data;
using Harissa.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Harissa.WWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HarissaContext _context;

        public HomeController(ILogger<HomeController> logger, HarissaContext context)
        {
            _logger = logger;
            _context = context;
        }

        private void AllPages()
        {
            ViewBag.HeaderText = _context.PageSettings.FirstOrDefault().HeaderText;
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();
        }

        public async Task<IActionResult> Index()
        {
            var rand = new System.Random();
            int min = 0;
            int max = _context.PageSettings.Include(i => i.HeadImgs).FirstOrDefaultAsync().Result.HeadImgs.Count();
            int randRezult = rand.Next(min,max);
            ViewBag.Head = _context.PageSettings.Include(i => i.HeadImgs).FirstOrDefaultAsync().Result.HeadImgs.ElementAt(randRezult).HeadMediaItem; 
            ViewBag.Page = "News";
            ViewBag.HeaderText = _context.PageSettings.FirstOrDefault().HeaderText;
            var ps = await _context.PageSettings.FirstOrDefaultAsync();
            //dodac warunek do aktualnej daty
            List<News> newsList = _context.News.Include(i => i.NewsMediaCollections).OrderByDescending(o => o.DateOfPublication).ToList();
            ViewBag.News = newsList;
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();
            return View(ps);
        }

        public async Task<IActionResult> Privacy()
        {
            ViewBag.Page = "Prywatność";
            AllPages();
            return View(await _context.PageSettings.Include(i => i.privacyPolicy).FirstOrDefaultAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<ActionResult> ImgToModalNews(int id)
        //{
        //    var query = await _context.NewsMediaCollections
        //        .Where(w => w.NewsID == id)
        //        .Select(s => new { publicId = s.MediaItem }).ToArrayAsync();
        //    return Json(query);
        //}

    }
}
