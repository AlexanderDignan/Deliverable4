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
    public class RestaurantInfoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: RestaurantInfoes
        public ActionResult Index()
        {
            return View(db.RestaurantInfoes.ToList());
        }

        // GET: RestaurantInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantInfo restaurantInfo = db.RestaurantInfoes.Find(id);
            if (restaurantInfo == null)
            {
                return HttpNotFound();
            }
            return View(restaurantInfo);
        }

        // GET: RestaurantInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantInfoId,Name,Address,City,Phone,NumberOfTables")] RestaurantInfo restaurantInfo)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantInfoes.Add(restaurantInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantInfo);
        }

        // GET: RestaurantInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantInfo restaurantInfo = db.RestaurantInfoes.Find(id);
            if (restaurantInfo == null)
            {
                return HttpNotFound();
            }
            return View(restaurantInfo);
        }

        // POST: RestaurantInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantInfoId,Name,Address,City,Phone,NumberOfTables")] RestaurantInfo restaurantInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantInfo);
        }

        // GET: RestaurantInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantInfo restaurantInfo = db.RestaurantInfoes.Find(id);
            if (restaurantInfo == null)
            {
                return HttpNotFound();
            }
            return View(restaurantInfo);
        }

        // POST: RestaurantInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantInfo restaurantInfo = db.RestaurantInfoes.Find(id);
            db.RestaurantInfoes.Remove(restaurantInfo);
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
