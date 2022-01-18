using System;
using System.ComponentModel.DataAnnotations;

namespace MyDemoMVCApp.Models
{
    public class Employee
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Department { get; set; }
        public string JobPosition { get; set; }
    }
}