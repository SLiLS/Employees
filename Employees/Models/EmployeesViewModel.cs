using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public class EmployeesViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]  
        public string Middlename { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }       
        public string CompanyId { get; set; }
        [Display(Name = "Название компании")]
        public string Companyname { get; set; }
        [Display(Name = "Дата трудоустройства")]           
        public DateTime Employmentdate { get; set; }
    }
}