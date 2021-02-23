using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Harissa.WWW.Models;
using Facebook;
using System.Text.Json;
using Harissa.Data.HelperClass;
using Harissa.Data;
using Harissa.Data.Data;

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

        public IActionResult Index()
        {
            //dodac warunek do aktualnej daty
            List<News> newsList = _context.News.ToList();
            ViewBag.News = newsList;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
