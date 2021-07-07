using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Harissa.WWW.Controllers.Abstract;

namespace Harissa.WWW.Controllers
{
    public class MusicController : AbstractController
    {
        public MusicController(HarissaContext context)
        :base(context)
        {
        }

        // GET: Music
        public async Task<IActionResult> Index()
        {
            Start();
            ViewBag.Page = "Muzyka";
            
            return View(await _context.Musics.Include(i => i.MusicLinks).ThenInclude(m => m.MusicPlatform).OrderByDescending(o => o.DateOfPublication).ToListAsync());
        }
    }
}
