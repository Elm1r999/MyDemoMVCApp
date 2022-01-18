using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MyDemoMVCApp.Models;

namespace MyDemoMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeDbHandler dbHandle = new EmployeeDbHandler();
            ModelState.Clear();
            return View(dbHandle.GetEmployee());
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeDbHandler dbHandler = new EmployeeDbHandler();
                    if (dbHandler.AddEmployee(employeeModel))
                    {
                        ViewBag.Message = "Employee Details added Successfully";
                        ModelState.Clear();
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeDbHandler dbHandler = new EmployeeDbHandler();
            return View(dbHandler.GetEmployee().Find(employee => employee.ID == id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employeeModel)
        {
            try
            {
                EmployeeDbHandler dbHandler = new EmployeeDbHandler();
                dbHandler.UpdateDetails(employeeModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EmployeeDbHandler dbHandler = new EmployeeDbHandler();
                if (dbHandler.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
