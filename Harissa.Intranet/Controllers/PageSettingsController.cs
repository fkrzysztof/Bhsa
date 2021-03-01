using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using Microsoft.AspNetCore.Http;
using Harissa.Data.HelperClass;
using System.Collections.Generic;
using Harissa.Intranet.Controllers.Abstract;
using Microsoft.Extensions.Logging;

namespace Harissa.Intranet.Controllers
{
    public class PageSettingsController : BaseClassController
    {

        public PageSettingsController(ILogger<HomeController> logger, HarissaContext context)
        :base(logger, context)
        {
        }

        private void naviPack()
        {
            ViewBag.Path = "Page Settings";
            ViewBag.Icon = "fas fa-cogs";
            logo();
        }

        // GET: PageSettings
        public async Task<IActionResult> Index()
        {
            naviPack();
            var rezult = await _context.PageSettings
                .Include(i => i.socialMedias)
                .Include(i => i.privacyPolicy)
                .FirstOrDefaultAsync();
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
        //public async Task<IActionResult> Index([Bind("NoPictureNewFile")] IFormFile ps)
        public async Task<IActionResult> Index(IFormFile NoPictureNewFile)
        {
            if (ModelState.IsValid)
            {
                var pageSettings = await _context.PageSettings.FirstOrDefaultAsync();
                try
                {
                    //nie istnieje
                    if (pageSettings == null)
                    {
                        //dodanie
                        pageSettings.NoPicture = new CloudAccess().AddPic(NoPictureNewFile, "PageSettings", true);
                           _context.Add(pageSettings);
                    }
                    else
                    //istnieje
                    {
                        //aktualizacja
                        if(!string.IsNullOrEmpty(pageSettings.NoPicture))
                        {
                            new CloudAccess().Remove(pageSettings.NoPicture);
                        }
                        
                        pageSettings.NoPicture = new CloudAccess().AddPic(NoPictureNewFile, "PageSettings", true);
                        _context.Update(pageSettings);
                    }
                    await _context.SaveChangesAsync();
                
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageSettingsExists(pageSettings.PageSettingsID))
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
            return RedirectToAction(nameof(Index));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLogo([Bind("logo,LogoNewFile")] PageSettings l)
        {
            var pageSettings = _context.PageSettings.First();
            pageSettings.Logo = new CloudAccess().ChangeItem(pageSettings.Logo, l.LogoNewFile, "Logo");
            _context.PageSettings.Update(pageSettings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //[HttpGet, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSocialMedias(int id)
        {
            var socialMedia = await _context.SocialMedias.FindAsync(id);
            _context.SocialMedias.Remove(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           // return View("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrivacyPolicyEdit([Bind("PrivacyPolicyID,PageSettingsID,Text")] PrivacyPolicy privacyPolicy)
        {
            //if (id != privacyPolicy.PrivacyPolicyID)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privacyPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivacyPolicyExists(privacyPolicy.PrivacyPolicyID))
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
            return View();
        }



        private bool SocialMediasExists(int id)
        {
            return _context.SocialMedias.Any(e => e.SocialMediaID == id);
        }
        private bool PageSettingsExists(int id)
        {
            return _context.PageSettings.Any(e => e.PageSettingsID == id);
        }
        private bool PrivacyPolicyExists(int id)
        {
            return _context.PrivacyPolicies.Any(e => e.PageSettingsID == id);
        }
    }
}
