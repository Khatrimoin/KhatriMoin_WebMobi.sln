using PracticalWebMobi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalWebMobi.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        TestWebMobiEntities db = new TestWebMobiEntities();
        public ActionResult Index()
        {
            ViewBag.LstDpart = lstDprt();
            return View();
        }
        public List<tblDepartment> lstDprt()
        {
            try
            {
                return db.tblDepartments.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult DepartmentCreation(tblDepartment deprtment)
        {
            try
            {
                var isExistm = db.tblDepartments.Any(x => x.departmentId == deprtment.departmentId);
                if (!isExistm)
                {
                    deprtment.status = true;
                    db.tblDepartments.Add(deprtment);
                    db.SaveChanges();
                    return Json("Save Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(deprtment).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("Update Success", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult DepartmentEdit(int id)
        {
            try
            {
                var lstdepartment = db.tblDepartments.Where(x => x.departmentId == id).FirstOrDefault();
                return Json(lstdepartment, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult DepartmentDeactive(int id)
        {
            try
            {
                tblDepartment deprtment = db.tblDepartments.Where(d => d.departmentId == id).FirstOrDefault();
                deprtment.status = false;
                db.Entry(deprtment).State = EntityState.Modified;
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