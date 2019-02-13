using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.BLL.DTO;
using Employees.Models;
using Employees.BLL.Services;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        CompanyService companyService;
        EmployeeService employeeService;
        public HomeController()
        {
            if (companyService == null)
                companyService = new CompanyService();
            if (employeeService == null)
                employeeService = new EmployeeService();
        }
      
        public ActionResult Index()
        {
            List<EmployeeDTO> listdto = employeeService.GetAllEmployee();
            List<EmployeesViewModel> list = new List<EmployeesViewModel>();
            foreach (var item in listdto)
            {
                EmployeesViewModel viewModel = new EmployeesViewModel
                {   
                    Id=item.Id,
                    CompanyId = item.CompanyId,
                    Companyname = item.Companyname,
                    Employmentdate = item.Employmentdate,
                    Middlename = item.Middlename,
                    Name = item.Name,
                    Position = item.Position,
                    Surname = item.Surname
                };
                list.Add(viewModel);
            }
        
            return View(list);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            ViewBag.Companies = new SelectList(companyService.GetAllCompanies(), "Id", "CompanyName");
            return PartialView();

        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeesViewModel item)
        {

            if (ModelState.IsValid)
            {

               EmployeeDTO employeeDTO = new EmployeeDTO
                {

                   
                   CompanyId = item.CompanyId,
                   Companyname = item.Companyname,
                   Employmentdate = item.Employmentdate,
                   Middlename = item.Middlename,
                   Name = item.Name,
                   Position = item.Position,
                   Surname = item.Surname
               };
                employeeService.CreateEmployee(employeeDTO);


            }
            else
            {
                ModelState.AddModelError("", "incorrect data");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeDTO item = employeeService.GetEmployee(id);
            EmployeesViewModel employeesView = new EmployeesViewModel
            {

                Id = item.Id,
                CompanyId = item.CompanyId,
                Companyname = item.Companyname,
                Employmentdate = item.Employmentdate,
                Middlename = item.Middlename,
                Name = item.Name,
                Position = item.Position,
                Surname = item.Surname
            };
            ViewBag.Companies = new SelectList(companyService.GetAllCompanies(), "Id", "CompanyName");
            return PartialView(employeesView);
        }
        [HttpPost]
        public ActionResult Edit(EmployeesViewModel item)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO
            {

                Id = item.Id,
                CompanyId = item.CompanyId,
                Companyname = item.Companyname,
                Employmentdate = item.Employmentdate,
                Middlename = item.Middlename,
                Name = item.Name,
                Position = item.Position,
                Surname = item.Surname
            };
           
            employeeService.UpdateEmployee(employeeDTO);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        
    }
}