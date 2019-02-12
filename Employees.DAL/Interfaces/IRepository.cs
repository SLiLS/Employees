using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Interfaces
{
  public  interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T Get(int id);

        void Create(T item);
        void Delete(int id);
        void Update(T item);
        void OpenConnection();
        void CloseConnection();
    }
}
