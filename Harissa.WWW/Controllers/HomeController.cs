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
            ViewBag.Page = "News";
            ViewBag.HeaderText = _context.PageSettings.FirstOrDefault().HeaderText;
            var ps = await _context.PageSettings.FirstOrDefaultAsync();
            //dodac warunek do aktualnej daty
            List<News> newsList = _context.News.OrderByDescending(o => o.DateOfPublication).ToList();
            ViewBag.News = newsList;
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();
            return View(ps);
        }
        //public IActionResult Video()
        //{
        //    //dodac warunek do aktualnej daty
        //    List<News> newsList = _context.News.ToList();
        //    ViewBag.News = newsList;
        //    ViewBag.SocialMedia = _context.SocialMedias.ToList();
        //    ViewBag.MusicPlatforms = _context.MusicPlatforms.ToList();
        //    return View();
        //}

        //public IActionResult Www()
        //{
        //    AllPages();
        //    return View(_context.PageSettings.FirstOrDefault());
        //}
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
    }
}
