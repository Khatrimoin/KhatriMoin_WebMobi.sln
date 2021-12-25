using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PracticalWebMobi.Models;
using PracticalWebMobi.Repository.IRepo;

namespace PracticalWebMobi.Repository.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        TestWebMobiEntities db;

        public EmployeeRepository(TestWebMobiEntities _db)
        {
            db = _db;
        }
        public async Task<List<viewEmployee>> GetAll()
        {
            if (db != null)
                return await (from d in db.tblEmployees
                              join a in db.tblDepartments on d.departmentId equals a.departmentId
                              select new viewEmployee
                              {
                                  employeeId = d.employeeId,
                                  firstName = d.firstName,
                                  lastName = d.lastName,
                                  gender = d.gender,
                                  dateOfBirth = d.dateOfBirth,
                                  profilephoto = d.profilephoto,
                                  departmentId = d.departmentId,
                                  departmentName = a.demartmentName,
                                  status = d.status
                              }).ToListAsync();
            return null;
        }
        public async Task<viewEmployee> GetById(int? id)
        {
            if (db != null)
                return await (from d in db.tblEmployees
                              join a in db.tblDepartments on d.departmentId equals a.departmentId
                              where d.employeeId == id
                              select new viewEmployee
                              {
                                  employeeId = d.employeeId,
                                  firstName = d.firstName,
                                  lastName = d.lastName,
                                  gender = d.gender,
                                  dateOfBirth = d.dateOfBirth,
                                  profilephoto = d.profilephoto,
                                  departmentId = d.departmentId,
                                  departmentName = a.demartmentName,
                                  status = d.status
                              }).FirstOrDefaultAsync();

            return null;
        }
        public async Task<int> Add(tblEmployee model)
        {
            if (db != null)
            {
                model.status = true;
                db.tblEmployees.Add(model);
                await db.SaveChangesAsync();
                return model.departmentId;
            }

            return 0;
        }
        public async Task Update(tblEmployee model)
        {
            if (db != null)
            {
                //Update that post
                db.Entry(model).State = EntityState.Modified;
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
        public async Task Deactive(int? id)
        {
            if (db != null)
            {
                var data = db.tblEmployees.Where(x => x.departmentId == id).FirstOrDefault();
                data.status = false;
                //Update that post
                db.Entry(data).State = EntityState.Modified;
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
        public async Task Active(int? id)
        {
            if (db != null)
            {
                var data = db.tblEmployees.Where(x => x.departmentId == id).FirstOrDefault();
                data.status = true;
                //Update that post
                db.Entry(data).State = EntityState.Modified;
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
