using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EquipmentTracking.DAL;
using EquipmentTracking.Models;

namespace EquipmentTracking.Controllers
{
    public class EquipmentClassificationController : Controller
    {
        private EquipmentTrackingContext db = new EquipmentTrackingContext();

        // GET: EquipmentClassification
        public ActionResult Index()
        {
            return View(db.EquipmentClassifications.ToList());
        }

        // GET: EquipmentClassification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentClassification equipmentClassification = db.EquipmentClassifications.Find(id);
            if (equipmentClassification == null)
            {
                return HttpNotFound();
            }
            return View(equipmentClassification);
        }

        // GET: EquipmentClassification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipmentClassification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] EquipmentClassification equipmentClassification)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentClassifications.Add(equipmentClassification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipmentClassification);
        }

        // GET: EquipmentClassification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentClassification equipmentClassification = db.EquipmentClassifications.Find(id);
            if (equipmentClassification == null)
            {
                return HttpNotFound();
            }
            return View(equipmentClassification);
        }

        // POST: EquipmentClassification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] EquipmentClassification equipmentClassification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentClassification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipmentClassification);
        }

        // GET: EquipmentClassification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentClassification equipmentClassification = db.EquipmentClassifications.Find(id);
            if (equipmentClassification == null)
            {
                return HttpNotFound();
            }
            return View(equipmentClassification);
        }

        // POST: EquipmentClassification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentClassification equipmentClassification = db.EquipmentClassifications.Find(id);
            db.EquipmentClassifications.Remove(equipmentClassification);
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
