using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaacTapTerminalApp.Models;

namespace TaacTapTerminalApp.Controllers
{
    public class ReservationsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.RestaurantTable).Include(r => r.User);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantTableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "LastName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantTableId,UserId,Date")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                reservation.Status = "Reserved";
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantTableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", reservation.RestaurantTableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "LastName", reservation.UserId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantTableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", reservation.RestaurantTableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", reservation.UserId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,RestaurantTableId,UserId,Date,Status")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantTableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", reservation.RestaurantTableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", reservation.UserId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
