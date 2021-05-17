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
    public class BandController : Controller
    {
        private readonly HarissaContext _context;

        public BandController(HarissaContext context)
        {
            _context = context;
        }

        // GET: Band
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderText = _context.PageSettings.FirstOrDefault().HeaderText;
            ViewBag.Page = "Zespół";
            ViewBag.SocialMedia = await _context.SocialMedias.ToListAsync();
            ViewBag.Contact = await _context.Contacts.ToListAsync();
            
            return View(await _context.Bio.FirstAsync());
        }
    }
}
