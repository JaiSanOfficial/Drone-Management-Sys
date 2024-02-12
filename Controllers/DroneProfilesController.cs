using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drone_Management_Sys.Models;

namespace Drone_Management_Sys.Controllers
{
    public class DroneProfilesController : Controller
    {
        private DroneEntities db = new DroneEntities();

        // GET: DroneProfiles Comment added
        public ActionResult Index()
        {
            return View(db.DroneProfiles.ToList());
        }

        // GET: DroneProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DroneProfile droneProfile = db.DroneProfiles.Find(id);
            if (droneProfile == null)
            {
                return HttpNotFound();
            }
            return View(droneProfile);
        }

        // GET: DroneProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DroneProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DroneID,DroneName,DroneCost,DroneModelNumber")] DroneProfile droneProfile)
        {
            if (ModelState.IsValid)
            {
                db.DroneProfiles.Add(droneProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(droneProfile);
        }

        // GET: DroneProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DroneProfile droneProfile = db.DroneProfiles.Find(id);
            if (droneProfile == null)
            {
                return HttpNotFound();
            }
            return View(droneProfile);
        }

        // POST: DroneProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DroneID,DroneName,DroneCost,DroneModelNumber")] DroneProfile droneProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(droneProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(droneProfile);
        }

        // GET: DroneProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DroneProfile droneProfile = db.DroneProfiles.Find(id);
            if (droneProfile == null)
            {
                return HttpNotFound();
            }
            return View(droneProfile);
        }

        // POST: DroneProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DroneProfile droneProfile = db.DroneProfiles.Find(id);
            db.DroneProfiles.Remove(droneProfile);
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
