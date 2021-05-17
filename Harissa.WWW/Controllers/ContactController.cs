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
    public class ContactController : Controller
    {
        private readonly HarissaContext _context;

        public ContactController(HarissaContext context)
        {
            _context = context;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            ViewBag.HeaderText = _context.PageSettings.FirstOrDefault().HeaderText;
            ViewBag.Page = "Kontakt";
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();
            return View(await _context.Contacts.ToListAsync());
        }
    }
}
