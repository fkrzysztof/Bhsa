using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;

namespace Harissa.WWW.Controllers
{
    public class MusicController : Controller
    {
        private readonly HarissaContext _context;

        public MusicController(HarissaContext context)
        {
            _context = context;
        }

        // GET: Music
        public async Task<IActionResult> Index()
        {
            @ViewBag.Page = "Muzyka";
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();
            return View(await _context.Musics.Include(i => i.MusicLinks).ThenInclude(m => m.MusicPlatform).ToListAsync());
        }
    }
}
