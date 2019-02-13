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
    public class CompaniesController : Controller
    {
        CompanyService companyService;
        EmployeeService employeeService;
        public CompaniesController()//создание экземпляров сервисов для работы с бд 
        {
            if (companyService == null)
                companyService = new CompanyService();
            if (employeeService == null)
                employeeService = new EmployeeService();
        }
          
            public ActionResult Index()//Вывод компаний
        {
            List<CompaniesViewModel> list = MapCompanylist(companyService.GetAllCompanies());
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {       
            return PartialView();

        }
        [HttpPost]
        public ActionResult Create(CompaniesViewModel item)//Создание компании
        {

            if (ModelState.IsValid)
            {

                CompanyDTO companyDTO = new CompanyDTO
                {

                    Id = item.Id,
                    CompanyName = item.CompanyName,
                    Organizationalform = item.Organizationalform,
                    Size = item.Size

                };
                companyService.CreateCompany(companyDTO);


            }
            else
            {
                ModelState.AddModelError("", "incorrect data");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)//Редактирование компании
        {
            CompanyDTO item = companyService.GetCompany(id);
            CompaniesViewModel company = new CompaniesViewModel
            {
                Id = item.Id,
                CompanyName = item.CompanyName,
                Organizationalform = item.Organizationalform,
                Size = item.Size
            };
           
            return PartialView(company);
        }
        [HttpPost]
        public ActionResult Edit(CompaniesViewModel item)
        {
            CompanyDTO companyDTO = new CompanyDTO
            {
                Id = item.Id,
                CompanyName = item.CompanyName,
                Organizationalform = item.Organizationalform,
                Size = item.Size
            };

            companyService.UpdateCompany(companyDTO);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)//Удаление компании
        {
            companyService.DeleteCompany(id);
            return RedirectToAction("Index");
        }


        public List<CompaniesViewModel> MapCompanylist(List<CompanyDTO> companyDTO)
        {
            List<CompaniesViewModel> list = new List<CompaniesViewModel>();
            foreach (var item in companyDTO)
            {
                CompaniesViewModel viewModel = new CompaniesViewModel
                {
                    Id = item.Id,
                    CompanyName = item.CompanyName,
                    Organizationalform = item.Organizationalform,
                    Size = item.Size
                };
                list.Add(viewModel);
            }
            return list;
        }
    }
}