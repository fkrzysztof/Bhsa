using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using System.Linq;

namespace Harissa.WWW.Controllers
{
    public class ConcertController : Controller
    {
        private readonly HarissaContext _context;

        public ConcertController(HarissaContext context)
        {
            _context = context;
        }

        // GET: Concert
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderText = _context.PageSettings.FirstOrDefault().HeaderText;
            ViewBag.Page = "Koncerty / Wydarzenia";
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();
            return View(await _context.Concerts.OrderByDescending(o => o.Date).ToListAsync());
        }
    }
}
