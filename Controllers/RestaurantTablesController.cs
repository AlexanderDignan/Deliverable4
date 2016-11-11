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
    public class RestaurantTablesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: RestaurantTables
        public ActionResult Index()
        {
            return View(db.RestaurantTables.ToList());
        }

        // GET: RestaurantTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantTable restaurantTable = db.RestaurantTables.Find(id);
            if (restaurantTable == null)
            {
                return HttpNotFound();
            }
            return View(restaurantTable);
        }

        // GET: RestaurantTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TableNumber")] RestaurantTable restaurantTable)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantTables.Add(restaurantTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantTable);
        }

        // GET: RestaurantTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantTable restaurantTable = db.RestaurantTables.Find(id);
            if (restaurantTable == null)
            {
                return HttpNotFound();
            }
            return View(restaurantTable);
        }

        // POST: RestaurantTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantTableId,TableNumber")] RestaurantTable restaurantTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantTable);
        }

        // GET: RestaurantTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantTable restaurantTable = db.RestaurantTables.Find(id);
            if (restaurantTable == null)
            {
                return HttpNotFound();
            }
            return View(restaurantTable);
        }

        // POST: RestaurantTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantTable restaurantTable = db.RestaurantTables.Find(id);
            db.RestaurantTables.Remove(restaurantTable);
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
