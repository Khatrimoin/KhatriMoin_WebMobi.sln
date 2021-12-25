using PracticalWebMobi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalWebMobi.Controllers
{
    public class EmployeeController : Controller
    {
        TestWebMobiEntities db = new TestWebMobiEntities();

        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.Department = lstDprt();
            ViewBag.Employee = lstEmp();
            return View();
        }
        public List<tblEmployee> lstEmp()
        {
            try
            {
                return db.tblEmployees.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<tblDepartment> lstDprt()
        {
            try
            {
                return db.tblDepartments.Where(d => d.status == true).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult EmployeeCreation(tblEmployee employee)
        {
            try
            {
                var isExistm = db.tblEmployees.Any(x => x.employeeId == employee.employeeId);
                if (!isExistm)
                {
                    employee.status = true;
                    db.tblEmployees.Add(employee);
                    db.SaveChanges();
                    return Json("Save Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("Update Success", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult EmployeeEdit(int id)
        {
            try
            {
                var lstemployee = db.tblEmployees.Where(x => x.employeeId == id).FirstOrDefault();
                return Json(lstemployee, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult EmployeeDeactive(int id)
        {
            try
            {
                tblEmployee employee = db.tblEmployees.Where(d => d.employeeId == id).FirstOrDefault();
                employee.status = false;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Data Deactive Successfull", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}