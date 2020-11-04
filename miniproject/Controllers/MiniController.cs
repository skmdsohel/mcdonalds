using miniproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace miniproject.Controllers
{
    public class MiniController : Controller
    {
        public ViewResult Home()
        {
            var context = new LntDatabaseEntitiesEntities();
            var model = context.orders.ToList();
            return View(model);
        }
        public ViewResult Login()
        {
            var context = new LntDatabaseEntitiesEntities();
            var model = context.orders.ToList();
            return View(model);
        }
        public ViewResult showorder()
        {
            var context = new LntDatabaseEntitiesEntities();
            var model = context.orders.ToList();
            return View(model);
        }
        public ViewResult Find(string id)
        {
            int custid = int.Parse(id);
            var context = new LntDatabaseEntitiesEntities();
            var model = context.orders.FirstOrDefault((e) => e.cust_id == custid);
            return View(model);

        }
        [HttpPost]
        public ActionResult Find(order ord)
        {
            var context = new LntDatabaseEntitiesEntities();
            var model = context.orders.FirstOrDefault((e) => e.cust_id == ord.cust_id);
            model.cust_name = ord.cust_name;
            model.item_name = ord.item_name;
            model.price = ord.price;
            context.SaveChanges();//Commits the changes made to the records...
            return RedirectToAction("showorder");
        }

        public ViewResult Neworders()
        {
            var model = new order();//No Values in it...
            return View(model);
        }
        [HttpPost]
        public ActionResult Neworders(order ord)
        {
            var context = new LntDatabaseEntitiesEntities();
            context.orders.Add(ord);
            context.SaveChanges();
            return RedirectToAction("showorder");
        }

        public ActionResult Delete(string id)
        {
            //convert string to int
            int custid = int.Parse(id);
            var context = new LntDatabaseEntitiesEntities();
            var model = context.orders.FirstOrDefault((e) => e.cust_id == custid);
            context.orders.Remove(model);
            context.SaveChanges();
            return RedirectToAction("showorder");
        }

    }
}