using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Patient
    {


[Key]
        public int pid { get; set; }
        [Required(ErrorMessage = "you must enter your  name ")]
        [Display(Name = "P name")]
        public string p_name { get; set; }
        [Display(Name = "p gender")]
        public string p_gender { get; set; }

        
       

    public ICollection<Patient_Doctor> doctorlist { get; set; }
    public ICollection<Patient_Department> Departmentlist { get; set; }

}

    internal class DisplyFormat
    {
    }

    internal class DataType
    {
    }

    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage;
    }
}

namespace Advancedproject.Models{
    class DataTypeAttribute : Attribute
    {
    }
}