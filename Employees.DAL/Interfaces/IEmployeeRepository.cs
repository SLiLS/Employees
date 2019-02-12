using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.DAL.Entities;

namespace Employees.DAL.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
