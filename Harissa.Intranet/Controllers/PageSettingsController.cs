using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Microsoft.AspNetCore.Http;
using Harissa.Data.HelperClass;
using System.Collections.Generic;

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
            var rezult = await _context.PageSettings.Include(i => i.socialMedias).Include(i => i.privacyPolicy).FirstOrDefaultAsync();
            if (rezult.privacyPolicy == null)
            {
                _context.PrivacyPolicies.Add(new PrivacyPolicy() { PageSettingsID = rezult.PageSettingsID, Text = "Napisz.." });
                _context.SaveChanges();
            }
            return View(rezult);
        }


        //Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("NewFile")] PageSettings ps)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pageSettings = await _context.PageSettings.FirstOrDefaultAsync();
                    //nie istnieje
                    if (pageSettings == null)
                    {
                           //dodanie
                           ps.NoPicture = new CloudAccess().AddPic(ps.NewFile, "PageSettings", true);
                           _context.Add(ps);
                    }
                    else
                    //istnieje
                    {
                        //aktualizacja
                        if(!string.IsNullOrEmpty(pageSettings.NoPicture))
                        {
                            new CloudAccess().Remove(pageSettings.NoPicture);
                        }
                        
                        pageSettings.NoPicture = new CloudAccess().AddPic(ps.NewFile, "PageSettings", true);
                        _context.Update(pageSettings);
                    }
                    await _context.SaveChangesAsync();
                
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageSettingsExists(ps.PageSettingsID))
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
            return View(ps);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSocialMedias([Bind("SocialMediaID,Name,Link,Icon")] SocialMedia sm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var dbSm = _context.SocialMedias.FirstOrDefault(f => f.SocialMediaID == sm.SocialMediaID);
                    if (dbSm != null)
                    {
                        dbSm.Name = sm.Name;
                        dbSm.Link = sm.Link;
                        dbSm.Icon = sm.Icon;
                        _context.Update(dbSm);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediasExists(sm.SocialMediaID))
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
            return View(); //nie wraca sm
        }


        public async Task<IActionResult> CreateSocialMedias([Bind("Name,Link,Icon")] SocialMedia sm)
        {
            if (ModelState.IsValid)
            {
                PageSettings pageSettingsItem = await _context.PageSettings.FirstOrDefaultAsync();
                if (pageSettingsItem != null)
                //istnieje juz pagesettings
                {
                    sm.PageSettingsID = pageSettingsItem.PageSettingsID;
                    _context.SocialMedias.Add(sm);
                }
                else
                //nie istnieje pagesettings
                {
                    pageSettingsItem = new PageSettings()
                    {
                        socialMedias = new List<SocialMedia> { sm }
                    };
                    _context.PageSettings.Add(pageSettingsItem);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(); // nie wraca sm
        }


        //[HttpGet, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSocialMedias(int id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            _context.SocialMedias.Remove(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrivacyPolicyEdit([Bind("id","text")]PrivacyPolicy pp)
        {
            _context.PrivacyPolicies.Update(pp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool SocialMediasExists(int id)
        {
            return _context.SocialMedias.Any(e => e.SocialMediaID == id);
        }
        private bool PageSettingsExists(int id)
        {
            return _context.PageSettings.Any(e => e.PageSettingsID == id);
        }
    }
}
