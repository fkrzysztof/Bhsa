using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;

namespace Harissa.WWW.Controllers.Abstract
{
    public abstract class AbstractController : Controller
    {
        protected readonly HarissaContext _context;

        public AbstractController(HarissaContext context)
        {
            _context = context;
        }

        // GET: Abstract
        public void Start()
        {
            var rand = new Random();
            int min = 0;

            int maxHead = _context.PageSettings.Include(i => i.HeadImgs).FirstOrDefaultAsync().Result.HeadImgs.Count();
            if (maxHead > 0)
            {
                int randRezultHead = rand.Next(min, maxHead);
                ViewBag.Head = _context.PageSettings.Include(i => i.HeadImgs).FirstOrDefaultAsync().Result.HeadImgs.ElementAt(randRezultHead).HeadMediaItem;
            }
            else
            {
                ViewBag.Head = null;
            }

            int maxFooter = _context.PageSettings.Include(i => i.FooterImgs).FirstOrDefaultAsync().Result.FooterImgs.Count();
            if (maxFooter > 0)
            {
                int randRezultFooter = rand.Next(min, maxFooter);
                ViewBag.Footer = _context.PageSettings.Include(i => i.FooterImgs).FirstOrDefaultAsync().Result.FooterImgs.ElementAt(randRezultFooter).FooterImgItem;
            }
            else
            {
                ViewBag.Footer = null;
            };

            ViewBag.HeaderText = _context.PageSettings.FirstOrDefault().HeaderText;
            ViewBag.SocialMedia = _context.SocialMedias.ToList();
            ViewBag.Contact = _context.Contacts.ToList();

        }

    }
}
