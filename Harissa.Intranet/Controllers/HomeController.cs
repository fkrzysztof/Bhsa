using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Harissa.Intranet.Models;
using Harissa.Intranet.Controllers.Abstract;
using Harissa.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Harissa.Intranet.Controllers
{
    public class HomeController : BaseClassController
    {
        
        public HomeController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {

        }

        private void logo()
        {
            string logo = _context.PageSettings.First().Logo;
            HttpContext.Session.SetString("Logo", logo);
        }

        public IActionResult Index()
        {
            logo();
            //return View();
            return RedirectToAction("Index", "News");
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
