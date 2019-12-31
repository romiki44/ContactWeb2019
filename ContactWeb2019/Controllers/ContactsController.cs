using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactWeb2019.Models;
using Microsoft.AspNet.Identity;

namespace ContactWeb2019.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public ActionResult Index()
        {
            var userId= GetCurrentUserId();
            var contacts = db.Contacts.Include(c => c.State).Include(c => c.User).Where(c=>c.UserId==userId);
            return View(contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.StateId = new SelectList(db.States, "Id", "Name");
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.UserId = GetCurrentUserId();
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,PhonePrimary,PhoneSecondary,Birtday,StreetAddress1,StreetAddress2,City,Zip,StateId,UserId")] Contact contact)
        {
            //contact.UserId = GetCurrentUserId();
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateId = new SelectList(db.States, "Id", "Name", contact.StateId);
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", contact.UserId);
            ViewBag.UserId = GetCurrentUserId();
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = GetCurrentUserId();
            Contact contact = db.Contacts.FirstOrDefault(c=>c.Id==id && c.UserId==userId);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateId = new SelectList(db.States, "Id", "Name", contact.StateId);
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", contact.UserId);
            ViewBag.UserId = GetCurrentUserId();
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,PhonePrimary,PhoneSecondary,Birtday,StreetAddress1,StreetAddress2,City,Zip,StateId,UserId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateId = new SelectList(db.States, "Id", "Name", contact.StateId);
            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", contact.UserId);
            ViewBag.UserId = GetCurrentUserId();
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = GetCurrentUserId();
            Contact contact = db.Contacts.FirstOrDefault(c => c.Id == id && c.UserId == userId);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected string GetCurrentUserId()
        {
            return User.Identity.GetUserId();
        }
    }
}
