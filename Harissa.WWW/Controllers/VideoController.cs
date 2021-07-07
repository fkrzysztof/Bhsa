using System.Linq;
using System.Threading.Tasks;
using Harissa.Data;
using Harissa.WWW.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Harissa.WWW.Controllers
{
    public class VideoController : AbstractController
    {
        public VideoController(HarissaContext context)
        :base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            Start();
            ViewBag.Page = "Teledyski";
            ViewBag.VideoList = await _context.Videos.OrderByDescending(o => o.Index).ToListAsync();
           
            return View();
        }
    }
}