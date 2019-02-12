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
   public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository employeeRepository;

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public void CreateEmployee(EmployeeDTO item)
        {
            employeeRepository.OpenConnection();

            Employee employee = new Employee { CompanyId = item.CompanyId, Companyname = item.Companyname, Employmentdate = item.Employmentdate,Middlename=item.Middlename,Name=item.Name,Position=item.Position,Surname=item.Surname };
            employeeRepository.Create(employee);
            employeeRepository.CloseConnection();
        }

        public void DeleteEmployee(int Id)
        {
            employeeRepository.OpenConnection();

            employeeRepository.Delete(Id);
            employeeRepository.CloseConnection();
        }

        public List<EmployeeDTO> GetAllEmployee()
        {
            employeeRepository.OpenConnection();

            List<EmployeeDTO> ListDTO = new List<EmployeeDTO>();
            List<Employee> list = new List<Employee>();
            foreach (Employee item in list)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO
                {
                    Id=item.Id,
                    CompanyId=item.CompanyId,
                    Companyname=item.Companyname,
                    Employmentdate=item.Employmentdate,
                    Middlename=item.Middlename,
                    Name=item.Name,
                    Position=item.Position,
                    Surname=item.Surname
                };
                ListDTO.Add(employeeDTO);
            }

            employeeRepository.CloseConnection();
            return ListDTO;
        }

        public EmployeeDTO GetEmployee(int Id)
        {
            employeeRepository.OpenConnection();
            employeeRepository.Get(Id);

            employeeRepository.CloseConnection();
        }

        public void UpdateEmployee(EmployeeDTO Employee)
        {
            employeeRepository.OpenConnection();


            employeeRepository.CloseConnection();
        }

    }
}
