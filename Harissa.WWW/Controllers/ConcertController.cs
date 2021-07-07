using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using System.Linq;
using Harissa.WWW.Controllers.Abstract;

namespace Harissa.WWW.Controllers
{
    public class ConcertController : AbstractController
    {
        public ConcertController(HarissaContext context)
        :base(context)
        {
        }

        // GET: Concert
        public async Task<IActionResult> Index()
        {
            Start();
            ViewBag.Page = "Koncerty / Wydarzenia";
            
            return View(await _context.Concerts.OrderByDescending(o => o.Date).ToListAsync());
        }
    }
}
