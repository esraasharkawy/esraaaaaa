using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Employee
{[Key]
        
    public int Eid { get; set; }
       [Coloumn(TypeName ="decimal(6,2)")]
    
    public decimal E_salary { get; set; }
        [Required(ErrorMessage ="you must enter your phone")]
        [Display(Name =" E phone")]

    public int E_phone { get; set; }
        [Display(Name =" E gender")]
    public string E_gender { get; set; }
    public int D_id { get; set; }
    public Doctor doctor { get; set; }
}
}
