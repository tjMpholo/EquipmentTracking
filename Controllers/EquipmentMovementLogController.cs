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
    public class EquipmentMovementLogController : Controller
    {
        private EquipmentTrackingContext db = new EquipmentTrackingContext();

        // GET: EquipmentMovementLog
        public ActionResult Index()
        {
            var equipmentMovementLogs = db.EquipmentMovementLogs.Include(e => e.Equipment).OrderByDescending(a => a.LogDate);


            return View(equipmentMovementLogs.ToList());
        }

        // GET: EquipmentMovementLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentMovementLog equipmentMovementLog = db.EquipmentMovementLogs.Find(id);
            if (equipmentMovementLog == null)
            {
                return HttpNotFound();
            }
            return View(equipmentMovementLog);
        }

        // GET: EquipmentMovementLog/Create
        public ActionResult Create()
        {
            ViewBag.EquipmentMovementLog = new EquipmentMovementLog { LogDate = DateTime.Now};
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "Name");

            EquipmentMovementLog movement = new EquipmentMovementLog()
            {
                LogDate = DateTime.Now,
            };

            return View(movement);
        }

        // POST: EquipmentMovementLog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipmentMovementLogID,EmployeeNo,LogDate,Qty,Direction,EquipmentID")] EquipmentMovementLog equipmentMovementLog)
        {
            ViewBag.ErrorMessage = "";
            if (ModelState.IsValid)
            {
                var bookedQty = equipmentMovementLog.Qty;
                var equipment = db.Equipments.Find(equipmentMovementLog.EquipmentID);

                // Returning the equipment
                if (equipmentMovementLog.Direction == DIRECTION.IN)
                {
                    equipment.Qty = equipment.Qty + bookedQty; ;

                    db.Entry(equipment).State = EntityState.Modified;
                    db.SaveChanges();

                    db.EquipmentMovementLogs.Add(equipmentMovementLog);
                    db.SaveChanges();
                    ViewBag.ErrorMessage = "Success: Logged successfully.";
                }
                else if (bookedQty > equipment.Qty)
                {
                    ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "Name");
                    ViewBag.ErrorMessage = "Error: The amount of equipment booked cannot be greater than " + equipment.Qty;
                    return View(equipmentMovementLog);
                }
                else
                {
                    equipment.Qty = equipment.Qty - bookedQty;

                    db.Entry(equipment).State = EntityState.Modified;
                    db.SaveChanges();

                    db.EquipmentMovementLogs.Add(equipmentMovementLog);
                    db.SaveChanges();
                    ViewBag.ErrorMessage = "Success: Logged successfully.";
                }

                return RedirectToAction("Index");
            }

            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "Code", equipmentMovementLog.EquipmentID);
            return View(equipmentMovementLog);
        }

        // GET: EquipmentMovementLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentMovementLog equipmentMovementLog = db.EquipmentMovementLogs.Find(id);
            if (equipmentMovementLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "Code", equipmentMovementLog.EquipmentID);
            return View(equipmentMovementLog);
        }

        // POST: EquipmentMovementLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipmentMovementLogID,EmployeeNo,LogDate,Qty,Direction,EquipmentID")] EquipmentMovementLog equipmentMovementLog)
        {
            if (ModelState.IsValid)
            {
                equipmentMovementLog.LogDate = DateTime.Now;
                db.Entry(equipmentMovementLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "Code", equipmentMovementLog.EquipmentID);
            return View(equipmentMovementLog);
        }

        // GET: EquipmentMovementLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentMovementLog equipmentMovementLog = db.EquipmentMovementLogs.Find(id);
            if (equipmentMovementLog == null)
            {
                return HttpNotFound();
            }
            return View(equipmentMovementLog);
        }

        // POST: EquipmentMovementLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentMovementLog equipmentMovementLog = db.EquipmentMovementLogs.Find(id);
            db.EquipmentMovementLogs.Remove(equipmentMovementLog);
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
