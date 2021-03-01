using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Harissa.Data;
using Harissa.Data.Data;
using System;
using Harissa.Intranet.Controllers.Abstract;
using Microsoft.Extensions.Logging;

namespace Harissa.Intranet.Controllers
{
    public class ContactController : BaseClassController
    {

        public ContactController(ILogger<HomeController> logger, HarissaContext context)
        : base(logger, context)
        {
        }

        private void naviPack()
        {
            ViewBag.Path = "Contact";
            ViewBag.Icon = "fas fa-phone-alt";
            logo();
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            naviPack();
            ViewBag.ContactList = await _context.Contacts.ToListAsync();
            return View();
        }

                                                     //po cacel edit widac co bylo edytowane orazdiv nie jest wylaczony


        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,Email,Phone,Name")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }


        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ContactID,Email,Phone,Name")] Contact contact)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactID))
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
            return View(contact);
        }


        public async Task<ActionResult> ListJS([Bind("ContactID,Email,Phone,Name")] Contact contact)
        {
            var query = await _context.Contacts
                .Select(s => new { contactID = s.ContactID, email = s.Email, phone = s.Phone, name = s.Name }).ToListAsync();
            return Json(query);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> EditJS([Bind("ContactID,Email,Phone,Name")] Contact contact)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactID))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
                return true;
            }
            return false;
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> CreateJS([Bind("ContactID,Email,Phone,Name")] Contact contact)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactID))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
                return true;
            }
            return false;
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // POST: Contact/Delete/5
        [HttpPost]
      //[ValidateAntiForgeryToken]
        //public async Task<bool> RemoveJS([Bind("id")] int id)
        public async Task<bool> RemoveJS(int id)
        {
            if ( id < 0)
                return false;
            //int key = Convert.ToInt32(id);
            var contact = await _context.Contacts.FindAsync(id);
            var query = _context.Contacts.Remove(contact).State.ToString();
            if ( query != "Deleted")
            {
                return false;
            }
            else
            await _context.SaveChangesAsync();
            return  true;
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ContactID == id);
        }
    }
}
