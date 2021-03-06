﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobBoard.Data.EF;

namespace JobBoard.MVC.UI.Controllers
{
    public class ApplicationsController : Controller
    {
        private JobBoardEntities db = new JobBoardEntities();

        // GET: Applications
        [Authorize(Roles = "Admin, Manager, Employee, Corporate")]
        public ActionResult Index()
        {
            var applications = db.Applications.Include(a => a.ApplicationStatu).Include(a => a.OpenPosition).Include(a => a.UserDetail);
            return View(applications.ToList());
        }

        // GET: Applications/Details/5
        [Authorize(Roles = "Admin, Manager, Employee, Corporate")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: Applications/Create
        [Authorize(Roles = "Admin, Manager, Employee, Corporate")]
        public ActionResult Create()
        {
            ViewBag.ApplicationsStatusID = new SelectList(db.ApplicationStatus, "ApplicationStatusID", "StatusName");
            ViewBag.OpenPositionsID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID");
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName");
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Employee, Corporate")]
        public ActionResult Create([Bind(Include = "ApplicationID,UserID,OpenPositionsID,ApplicationDate,MangerNotes,ApplicationsStatusID,ResumeFileName")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationsStatusID = new SelectList(db.ApplicationStatus, "ApplicationStatusID", "StatusName", application.ApplicationsStatusID);
            ViewBag.OpenPositionsID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID", application.OpenPositionsID);
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName", application.UserID);
            return View(application);
        }

        // GET: Applications/Edit/5
        [Authorize(Roles = "Admin, Manager, Employee, Corporate")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationsStatusID = new SelectList(db.ApplicationStatus, "ApplicationStatusID", "StatusName", application.ApplicationsStatusID);
            ViewBag.OpenPositionsID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID", application.OpenPositionsID);
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName", application.UserID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Employee, Corporate")]
        public ActionResult Edit([Bind(Include = "ApplicationID,UserID,OpenPositionsID,ApplicationDate,MangerNotes,ApplicationsStatusID,ResumeFileName")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationsStatusID = new SelectList(db.ApplicationStatus, "ApplicationStatusID", "StatusName", application.ApplicationsStatusID);
            ViewBag.OpenPositionsID = new SelectList(db.OpenPositions, "OpenPositionID", "OpenPositionID", application.OpenPositionsID);
            ViewBag.UserID = new SelectList(db.UserDetails, "UserID", "FirstName", application.UserID);
            return View(application);
        }

        // GET: Applications/Delete/5
        [Authorize(Roles = "Admin, Manager, Corporate")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager, Corporate")]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
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
