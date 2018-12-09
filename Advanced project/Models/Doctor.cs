using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Doctor
{[Key]
     
    public int Did { get; set; }
        [Required(ErrorMessage ="you must enter your name")]
        [Display(Name =" D name")]
    public string D_name { get; set; }
        [Required(ErrorMessage = "you must enter your age")]
        [Display(Name = " D age")]
        public int D_age { get; set; }
        [Required(ErrorMessage = "you must enter your address")]
        [Display(Name = " D address")]
        public string D_address { get; set; }
    public ICollection<Patient_Doctor> patientlist { get; set; }
    public int Dept_no { get; set; }
    public Department departement { get; set; }
    public List<Employee> employeelist { get; set; }
}
}
