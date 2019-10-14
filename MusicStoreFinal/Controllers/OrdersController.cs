using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    [RequireHttps]
    [Authorize]
    public class OrdersController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        IOrderDAL DAL;
        public OrdersController(IOrderDAL DAL)
        {
            this.DAL = DAL;
        }


        public OrdersController()
        {
            this.DAL = new OrderDAL();
        }

        [Route("orders/list")]
        // GET: Orders
        public ActionResult Index()
        {
            return View(storeDB.Orders.Where(o => o.Username == User.Identity.Name).ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Order order = DAL.FindById(id);
            if (order == null)
            {
                return View("Error");
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderDate,Username,FirstName,LastName,Address,City,State,PostalCode,Country,Phone,Email,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                DAL.SaveNewOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = DAL.FindById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderDate,Username,FirstName,LastName,Address,City,State,PostalCode,Country,Phone,Email,Total")] Order order)
        {
            if (ModelState.IsValid)
            {
                DAL.UpdateOrder(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DAL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
