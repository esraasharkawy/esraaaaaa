using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Doctor
{
    public int D_id { get; set; }
    public string D_name { get; set; }
    public int D_age { get; set; }
    public string D_address { get; set; }
    public List<Patient> patientlist { get; set; }
    public int Dept_no { get; set; }
    public Department departement { get; set; }
    public List<Employee> employeelist { get; set; }
}
}
