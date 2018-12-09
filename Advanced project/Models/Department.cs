using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Department
{[Key]
    public int Deptno { get; set; }
        [Required(ErrorMessage ="you must enter  dept floor")]
        [Display(Name =" Dept floor")]
    public int Dept_floor { get; set; }
        [Required(ErrorMessage = "you must enter dept name")]
        [Display(Name = " Dept name")]

        public string Dept_name { get; set; }
    public ICollection<Patient_Department> patientlist { get; set; }
    public List<Doctor> doctorlist { get; set; }
    public List<Room> roomlist { get; set; }


}
}
