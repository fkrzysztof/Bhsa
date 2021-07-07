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
    public class ContactController : AbstractController
    {
        public ContactController(HarissaContext context)
        :base(context)
        {
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            Start();
            ViewBag.Page = "Kontakt";
            
            return View(await _context.Contacts.ToListAsync());
        }
    }
}
