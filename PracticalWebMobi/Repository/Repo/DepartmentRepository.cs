using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PracticalWebMobi.Models;
using PracticalWebMobi.Repository.IRepo;

namespace PracticalWebMobi.Repository.Repo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        TestWebMobiEntities db;
        public DepartmentRepository(TestWebMobiEntities _db)
        {
            db = _db;
        }

        public async Task<List<tblDepartment>> GetAll()
        {
            if (db != null)
                return await db.tblDepartments.ToListAsync();
            return null;
        }
        public async Task<tblDepartment> GetById(int? id)
        {
            if (db != null)
                return await db.tblDepartments.Where(d => d.departmentId == id).FirstOrDefaultAsync();
            return null;
        }
        public async Task<int> Add(tblDepartment model)
        {
            if (db != null)
            {
                model.status = true;
                db.tblDepartments.Add(model);
                await db.SaveChangesAsync();
                return model.departmentId;
            }

            return 0;
        }
        public async Task Update(tblDepartment model)
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
                var data = db.tblDepartments.Where(x => x.departmentId == id).FirstOrDefault();
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
                var data = db.tblDepartments.Where(x => x.departmentId == id).FirstOrDefault();
                data.status = true;
                //Update that post
                db.Entry(data).State = EntityState.Modified;
                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
