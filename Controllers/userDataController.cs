﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CentricProject_Team10.DAL;
using CentricProject_Team10.Models;
using Microsoft.AspNet.Identity;

namespace CentricProject_Team10.Controllers
{
    [Authorize]
    public class userDataController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: userData
        public ActionResult Index(string searchString)
        {
            var testusers = from u in db.UserData select u;
            if (!String.IsNullOrEmpty(searchString))
            {
                testusers = testusers.Where(u => u.lastName.Contains(searchString) || u.firstName.Contains(searchString));
                return View(testusers.ToList());
            }
            return View(db.UserData.ToList());
        }

        // GET: userData/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.UserData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // GET: userData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,lastName,firstName,emailAddress,phoneNumber,officeLocation,position,startDate")] userData userData)
        {
            if (ModelState.IsValid)
            {
                //userData.ID = Guid.NewGuid();
                Guid memberID;
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                userData.ID = memberID;
                db.UserData.Add(userData);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("duplicateUser");
                }
                return RedirectToAction("Index");
            }

            return View(userData);
        }

        // GET: userData/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.UserData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (userData.ID == memberID)
            {
                return View(userData);
            }
            else
            {
                return View("NotAuthenticated");
            }

        }

        // POST: userData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,lastName,firstName,emailAddress,phoneNumber,officeLocation,position,startDate")] userData userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userData);
        }

        // GET: userData/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.UserData.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (userData.ID == memberID)
            {
                return View(userData);
            }
            else
            {
                return View("NotAuthenticated");
            }

        }

        // POST: userData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            userData userData = db.UserData.Find(id);
            db.UserData.Remove(userData);
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
