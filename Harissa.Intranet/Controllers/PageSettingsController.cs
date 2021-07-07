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

        // GET: PageSettings
        public async Task<IActionResult> Index()
        {
            var rezult = await _context.PageSettings
                .Include(i => i.HeadImgs)
                .Include(i => i.FooterImgs)
                .FirstOrDefaultAsync();

            return View(rezult);
        }

        // GET: PrivacyPolicy
        public async Task<IActionResult> PrivacyPolicy()
        {
            var rezult = await _context.PrivacyPolicies.FirstOrDefaultAsync();
            if (rezult.Text == null)
            {
                _context.PrivacyPolicies.Add(new PrivacyPolicy() { PageSettingsID = rezult.PageSettingsID, Text = "Napisz.." });
                _context.SaveChanges();
            }
            return View("PrivacyPolicy", rezult);
        }
        
        // GET: SocialMedia
        public async Task<IActionResult> SocialMedia()
        {
            var rezult = await _context.SocialMedias.ToListAsync();
            return View("SocialMedia", rezult);
        }


        //Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IFormFile NoPictureNewFile)
        {
                var pageSettings = await _context.PageSettings.FirstOrDefaultAsync();
                try
                {
                    //nie istnieje
                    if (pageSettings == null)
                    {
                        //dodanie
                        pageSettings.NoPicture = new CloudAccess().AddPic(NoPictureNewFile, "noPictureFile");
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
                        
                        pageSettings.NoPicture = new CloudAccess().AddPic(NoPictureNewFile, "noPictureFile");
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
                return RedirectToAction("SocialMedia");
            }
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSocialMedias([Bind("Name,Link,NewIcon")] SocialMediaCreate sm)
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
                return RedirectToAction("SocialMedia");
            }
            return View(); 
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
            return RedirectToAction("SocialMedia");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrivacyPolicyEdit([Bind("PrivacyPolicyID,PageSettingsID,Text")] PrivacyPolicy privacyPolicy)
        {
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
            }
            return RedirectToAction("PrivacyPolicy");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HeaderTextEdit(string headerText)
        {
            var ps = await _context.PageSettings.FirstOrDefaultAsync();
            if(!string.IsNullOrEmpty(headerText))
            {
                ps.HeaderText = headerText;
                _context.Update(ps);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IframeIndexPage(string IframeVideo, string IframeTitle, string IframeText)
        {
            if (ModelState.IsValid)
            {
                PageSettings ps = await _context.PageSettings.FirstOrDefaultAsync();
                try
                {
                    IframeVideo = IframeVideo.Replace("https://", "");
                    IframeVideo = IframeVideo.Replace("www.", "");
                    IframeVideo = IframeVideo.Replace("youtu.be/", "");
                    IframeVideo = IframeVideo.Replace("youtube.com/watch?v=", "");

                    ps.IframeVideo = IframeVideo;
                    ps.IframeTitle = IframeTitle;
                    ps.IframeText = IframeText;

                    _context.PageSettings.Update(ps);
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
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImgCollectionHead(IFormFile[] imgCollection)
        {
            if (ModelState.IsValid)
            {  
                var ps = await _context.PageSettings.Include(i => i.HeadImgs).FirstOrDefaultAsync();

                if (imgCollection != null)
                {
                    if(ps.HeadImgs == null)
                    {
                        ps.HeadImgs = new List<HeadImg>();
                    }
                    else
                    {
                        foreach (var item in imgCollection)
                        {
                            ps.HeadImgs.Add(new HeadImg() { HeadMediaItem = new CloudAccess().AddPic(item, "HeadImg") });
                        }
                    }
                    _context.PageSettings.Update(ps);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImgCollectionFooter(IFormFile[] imgCollection)
        {
            if (ModelState.IsValid)
            {  
                var ps = await _context.PageSettings.Include(i => i.FooterImgs).FirstOrDefaultAsync();

                if (imgCollection != null)
                {
                    if(ps.FooterImgs == null)
                    {
                        ps.FooterImgs = new List<FooterImg>();
                    }
                    else
                    {
                        foreach (var item in imgCollection)
                        {
                            ps.FooterImgs.Add(new FooterImg() { FooterImgItem = new CloudAccess().AddPic(item, "FooterImg") });
                        }
                    }
                    _context.PageSettings.Update(ps);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<bool> RemoveJSHead(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            var media = await _context.HeadImgs.FirstOrDefaultAsync(f => f.HeadMediaItem == id);
            var query = _context.HeadImgs.Remove(media).State.ToString();

            if (query != "Deleted")
            {
                return false;
            }
            else
            {
                await _context.SaveChangesAsync();
                new CloudAccess().Remove(id);
                return true;
            }
        }

        [HttpPost]
        public async Task<bool> RemoveJSFooter(string id)
        {
            if (string.IsNullOrEmpty(id) == true)
                return false;

            var media = await _context.FooterImgs.FirstOrDefaultAsync(f => f.FooterImgItem == id);
            var query = _context.FooterImgs.Remove(media).State.ToString();

            if (query != "Deleted")
            {
                return false;
            }
            else
            {
                await _context.SaveChangesAsync();
                new CloudAccess().Remove(id);
                return true;
            }
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
