using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Employees.Models
{
    public class CompaniesViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название компании")]    
        public string CompanyName { get; set; }
        [Display(Name = "Размер компании")]    
        public int Size { get; set; }
        [Display(Name = "Организационная форма")]
        public string Organizationalform { get; set; }
    }
}