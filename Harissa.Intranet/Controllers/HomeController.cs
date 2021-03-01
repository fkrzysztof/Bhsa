using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Harissa.Intranet.Models;
using Harissa.Intranet.Controllers.Abstract;
using Harissa.Data;

namespace Harissa.Intranet.Controllers
{
    public class HomeController : BaseClassController
    {
        
        public HomeController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }

        public IActionResult Index()
        {
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
