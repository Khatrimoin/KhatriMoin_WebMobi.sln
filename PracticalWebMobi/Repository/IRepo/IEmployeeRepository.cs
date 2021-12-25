using PracticalWebMobi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticalWebMobi.Repository.IRepo
{
    public interface IEmployeeRepository
    {
        Task<List<viewEmployee>> GetAll();
        Task<viewEmployee> GetById(int? id);
        Task<int> Add(tblEmployee model);
        Task Update(tblEmployee model);
        Task Deactive(int? id);
        Task Active(int? id);
    }
}
