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
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Harissa.Intranet.Controllers
{
    public class PageSettingsController : BaseClassController
    {

        public PageSettingsController(ILogger<HomeController> logger, HarissaContext context)
        :base(logger, context)
        {
        }

        // GET: PageSettings
        public async Task<IActionResult> Index()
        {
            ViewBag.SelectListSocialMediaEdit = new SelectList(_context.SocialMedias.ToList(), "SocialMediaID","Name");
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
            //if (ModelState.IsValid)
            //{
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
            //}
            //return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditSocialMedias(int id)
        {
            return View(await _context.SocialMedias.FirstOrDefaultAsync(f => f.SocialMediaID == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSocialMedias([Bind("SocialMediaID,PageSettingsID,Name,Link,Icon,NewIcon")] SocialMedia sm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if(string.IsNullOrEmpty(sm.Icon))
                    {
                        sm.Icon = new CloudAccess().AddPic(sm.NewIcon, "SocialMedia");
                    }
                    else
                    {
                        sm.Icon = new CloudAccess().ChangeItem(sm.Icon, sm.NewIcon, "SocialMedia");
                    }
                    _context.SocialMedias.Update(sm);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> CreateSocialMedias([Bind("Name,Link,NewIcon")] SocialMedia sm)
        {
            sm.Icon = new CloudAccess().AddPic(sm.NewIcon, "SocialMedia");
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
            new CloudAccess().Remove(socialMedia.Icon);
            _context.SocialMedias.Remove(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
