using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using CentricProject_Team10.DAL;
using CentricProject_Team10.Models;

namespace CentricProject_Team10.Controllers
{
    [Authorize]
    public class userRecognitionsController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: userRecognitions
        public ActionResult Index()
        {
            var userRecognition = db.UserRecognition.Include(u => u.CoreValues).Include(u => u.UserData);
            return View(userRecognition.ToList());
        }

        // GET: userRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userRecognition userRecognition = db.UserRecognition.Find(id);
            if (userRecognition == null)
            {
                return HttpNotFound();
            }
            return View(userRecognition);
        }

        // GET: userRecognitions/Create
        public ActionResult Create()
        {
            ViewBag.valueID = new SelectList(db.CoreValues, "valueID", "valueName");
            ViewBag.ID = new SelectList(db.UserData, "ID", "fullName");
            return View();
        }

        // POST: userRecognitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionID,valueID,ID,recognitionComment")] userRecognition userRecognition)
        {
            if (ModelState.IsValid)
            {
                db.UserRecognition.Add(userRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.valueID = new SelectList(db.CoreValues, "valueID", "valueName", userRecognition.valueID);
            ViewBag.ID = new SelectList(db.UserData, "ID", "fullName", userRecognition.ID);
            return View(userRecognition);
        }

// GET: userRecognitions/Edit/5
public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userRecognition userRecognition = db.UserRecognition.Find(id);
            if (userRecognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.valueID = new SelectList(db.CoreValues, "valueID", "valueName", userRecognition.valueID);
            ViewBag.ID = new SelectList(db.UserData, "ID", "fullName", userRecognition.ID);
            return View(userRecognition);
        }

        // POST: userRecognitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionID,valueID,ID,recognitionComment")] userRecognition userRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.valueID = new SelectList(db.CoreValues, "valueID", "valueName", userRecognition.valueID);
            ViewBag.ID = new SelectList(db.UserData, "ID", "fullName", userRecognition.ID);
            return View(userRecognition);
        }

        // GET: userRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userRecognition userRecognition = db.UserRecognition.Find(id);
            if (userRecognition == null)
            {
                return HttpNotFound();
            }
            return View(userRecognition);
        }

        // POST: userRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userRecognition userRecognition = db.UserRecognition.Find(id);
            db.UserRecognition.Remove(userRecognition);
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
    }
}
