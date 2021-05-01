using System.Linq;
using System.Threading.Tasks;
using Harissa.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harissa.WWW.Controllers
{
    public class VideoController : Controller
    {
        private readonly HarissaContext _context;

        public VideoController(HarissaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Page = "Teledyski";
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();
            ViewBag.VideoList = await _context.Videos.OrderByDescending(o => o.Index).ToListAsync();
            return View();
        }
    }
}