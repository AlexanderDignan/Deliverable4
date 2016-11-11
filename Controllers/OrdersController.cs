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
    public class OrdersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Orders

        
        public ActionResult Index()
        {
            //var orders = db.Orders.Select(e => new
            //{
            //    OrderId = e.OrderId,
            //    UserId = e.UserId,
            //    TableId = e.TableId,
            //    DateTimeCreated = e.DateTimeCreated,
            //    TotalPrice = e.TotalPrice
            //}).AsEnumerable();
            //return View(orders.ToList());
            return View(db.Orders.Where(a => a.Status == "Pending").ToList());
        }

        public ActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.TableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", order.TableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", order.UserId);
            return View(order);
            //order.Status = "Confirmed";
            //db.Entry(order).State = EntityState.Modified;
            //db.SaveChanges();
            //RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(int id)
        {
            Order order = db.Orders.Find(id);
            if (ModelState.IsValid)
            {
                order.Status = "Confirmed";
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", order.TableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", order.UserId);
            return View(order);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.TableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,TableId")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.DateTimeCreated = System.DateTime.Now;
                order.Status = "Pending";
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", order.TableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.TableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", order.TableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,UserId,TableId,DateTimeCreated,TotalPrice,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", order.TableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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

     /*   public ActionResult GenieTap(Order order)
        {
            if (ModelState.IsValid)
            {
                order.DateTimeCreated = System.DateTime.Now;
                order.Status = "Pending";
                order.UserId = 1;
                order.TableId = 1;
               // OrderDetails od = new OrderDetails { };
              //  order.OrderDetails.Add(od);
                db.Orders.Add(order);
                db.SaveChanges();
                OrderDetails od = new OrderDetails();
                od.OrderId = 18;
                od.MenuItemId = 2;
                db.OrderDetailsSet.Add(od);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TableId = new SelectList(db.RestaurantTables, "RestaurantTableId", "RestaurantTableId", order.TableId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", order.UserId);
            return View(order);
        }
        */
    }
}
