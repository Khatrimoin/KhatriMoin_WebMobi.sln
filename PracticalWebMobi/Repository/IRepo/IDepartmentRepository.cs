using PracticalWebMobi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticalWebMobi.Repository.IRepo
{
    public interface IDepartmentRepository
    {
        Task<List<tblDepartment>> GetAll();
        Task<tblDepartment> GetById(int? id);
        Task<int> Add(tblDepartment model);
        Task Update(tblDepartment model);
        Task Deactive(int? id);
        Task Active(int? id);
    }
}
