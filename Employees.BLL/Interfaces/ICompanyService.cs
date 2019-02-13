using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.BLL.DTO;

namespace Employees.BLL.Interfaces
{
   public  interface ICompanyService
    {
        List<CompanyDTO> GetAllCompanies();
        CompanyDTO GetCompany(int Id);
        void UpdateCompany(CompanyDTO Company);
        void CreateCompany(CompanyDTO Company);

        void DeleteCompany(int Id);
    }
}
