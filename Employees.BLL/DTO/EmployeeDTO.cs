using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.BLL.DTO
{
 public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; }
        public string CompanyId { get; set; }
        public string Companyname { get; set; }
        public DateTime Employmentdate { get; set; }
    }
}
