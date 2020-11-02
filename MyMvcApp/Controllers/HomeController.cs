using MyMvcApp.Models;
//using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.Mvc;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult ShowEmployees()
        {
            var context = new LnTDatabaseEntities();
            var model = context.EmpTables.ToList();
            return View(model);
        }

        public ViewResult Find(string id)
        {
            int empId = int.Parse(id);
            var context = new LnTDatabaseEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == empId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Find(EmpTable emp)
        {
            var context = new LnTDatabaseEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == emp.EmpId);
            model.EmpName = emp.EmpName;
            model.EmpAddress = emp.EmpAddress;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }
        public ViewResult AddEmployee()
        {
            var model = new EmpTable();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmployee(EmpTable emp)
        {
            var context = new LnTDatabaseEntities();
            context.EmpTables.Add(emp);
            context.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }
        public ActionResult DeleteEmployee(string id)
        {
            int EmpId = int.Parse(id);
            var context = new LnTDatabaseEntities();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpId == EmpId);
            context.EmpTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }
    }
}