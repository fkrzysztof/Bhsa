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
using Harissa.WWW.Controllers.Abstract;

namespace Harissa.WWW.Controllers
{
    public class HomeController : AbstractController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, HarissaContext context)
        :base(context)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Start();
            ViewBag.Page = "News";
            var ps = await _context.PageSettings.FirstOrDefaultAsync();
            //dodac warunek do aktualnej daty
            List<News> newsList = _context.News.Include(i => i.NewsMediaCollections).OrderByDescending(o => o.DateOfPublication).ToList();
            ViewBag.News = newsList;

            return View(ps);
        }

        public async Task<IActionResult> Privacy()
        {
            ViewBag.Page = "Prywatność";
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
