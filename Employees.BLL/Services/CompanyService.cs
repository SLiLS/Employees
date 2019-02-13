using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Employees.DAL.Repositories;
using Employees.BLL.DTO;
using Employees.BLL.Interfaces;
using System.Threading.Tasks;
using Employees.DAL.Entities;


namespace Employees.BLL.Services
{
   public class CompanyService : ICompanyService
    {
        private CompanyRepository companyRepository;

        public CompanyService()
        {
            companyRepository = new CompanyRepository();
        }

        public void CreateCompany(CompanyDTO item)
        {
            companyRepository.OpenConnection();

            Company com = new Company
            {
                CompanyName=item.CompanyName,
               Organizationalform=item.Organizationalform,
               Size=item.Size
            };
                companyRepository.Create(com);
            companyRepository.CloseConnection();
        }

        public void DeleteCompany(int Id)
        {
            companyRepository.OpenConnection();

            companyRepository.Delete(Id);
            companyRepository.CloseConnection();
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            companyRepository.OpenConnection();

            List<CompanyDTO> ListDTO = new List<CompanyDTO>();
            List<Company> list = companyRepository.GetAll();
            foreach (Company item in list)
            {
                CompanyDTO com = new CompanyDTO
                {
                    Id = item.Id,
                    Size=item.Size,
                    Organizationalform=item.Organizationalform,
                    CompanyName=item.CompanyName
                };
                ListDTO.Add(com);
            }

            companyRepository.CloseConnection();
            return ListDTO;
        }

        public CompanyDTO GetCompany(int Id)
        {
            companyRepository.OpenConnection();
            Company item = companyRepository.Get(Id);
            companyRepository.CloseConnection();
            CompanyDTO companyDTO = new CompanyDTO
            {
              CompanyName=item.CompanyName,
              Organizationalform=item.Organizationalform,
              Size=item.Size,
              Id=item.Id
            };
            return companyDTO;
        }

        public void UpdateCompany(CompanyDTO item)
        {
           
            Company com = new Company
            {
                CompanyName = item.CompanyName,
                Organizationalform = item.Organizationalform,
                Size = item.Size,
                Id = item.Id
            };
            companyRepository.OpenConnection();
            companyRepository.Update(com);

            companyRepository.CloseConnection();
        }

    }
}
