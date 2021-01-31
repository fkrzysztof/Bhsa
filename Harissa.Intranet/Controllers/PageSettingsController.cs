using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Microsoft.AspNetCore.Http;
using Harissa.Data.HelperClass;

namespace Harissa.Intranet.Controllers
{
    public class PageSettingsController : Controller
    {
        private readonly HarissaContext _context;

        public PageSettingsController(HarissaContext context)
        {
            _context = context;
        }

        private void naviPack()
        {
            ViewBag.Path = "Page Settings";
            ViewBag.Icon = "bi bi-sliders";
        }

        // GET: PageSettings
        public async Task<IActionResult> Index()
        {
            naviPack();
            //var rezultSocialMedia = await _context.SocialMedias.FirstOrDefaultAsync();
            //var rezultPageSettings = await _context.PageSettings.Include(i => i.socialMedias).FirstOrDefaultAsync();
            //if (rezultPageSettings == null)
            //    rezultPageSettings = new PageSettings();
            //if (rezultSocialMedia == null)
            //    rezultSocialMedia = new SocialMedia();


            //ViewPageSettings pg = new ViewPageSettings();
            //pg.PageSettingsView = rezultPageSettings;
            //pg.SocialMediaView = rezultSocialMedia;
            //var x = pg;
            //return View(pg);
            ViewBag.PageSettings = _context.PageSettings.First();
            var x = _context.SocialMedias.ToList();
            ViewBag.SocialMedia = x;
            return View();
        }


        //Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(/*[Bind("PageSettingsID, NoPicture")]*/ ViewPageSettings vps, IFormFile NewNoPicture)
        {


            if (ModelState.IsValid || NewNoPicture != null)
            {
                try
                {
                    //Dodanie 
                    if (vps.PageSettingsView.NoPicture == null)
                    {
                        vps.PageSettingsView.NoPicture = new CloudAccess().AddPic(NewNoPicture, "PageSettings", true);
                        var x = vps.PageSettingsView;
                        _context.Add(x);
                    }
                    else
                    //Aktualizacja
                    {
                        new CloudAccess().Remove(vps.PageSettingsView.NoPicture);
                        vps.PageSettingsView.NoPicture = new CloudAccess().AddPic(NewNoPicture, "PageSettings", true);
                        _context.Update(vps.PageSettingsView);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageSettingsExists(vps.PageSettingsView.PageSettingsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vps);
        }



            ////Edit
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> Index(/*[Bind("PageSettingsID, NoPicture")]*/ PageSettings pageSettings, IFormFile NewNoPicture)
            //{
            //    if (ModelState.IsValid || NewNoPicture != null)
            //    {
            //        try
            //        {
            //            if (pageSettings.NoPicture == null)
            //            {
            //                pageSettings.NoPicture = new CloudAccess().AddPic(NewNoPicture, "PageSettings", true);
            //                _context.Add(pageSettings);
            //            }
            //            else
            //            {
            //                new CloudAccess().Remove(pageSettings.NoPicture);
            //                pageSettings.NoPicture = new CloudAccess().AddPic(NewNoPicture, "PageSettings", true);
            //                _context.Update(pageSettings);
            //            }
            //            await _context.SaveChangesAsync();
            //        }
            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!PageSettingsExists(pageSettings.PageSettingsID))
            //            {
            //                return NotFound();
            //            }
            //            else
            //            {
            //                throw;
            //            }
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View(pageSettings);
            //}



            private bool PageSettingsExists(int id)
        {
            return _context.PageSettings.Any(e => e.PageSettingsID == id);
        }
    }
}
