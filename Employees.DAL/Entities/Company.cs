using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DAL.Entities
{
   public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Organizationalform { get; set; }
    }
}
