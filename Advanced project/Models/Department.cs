using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Department
{
    public int Dept__no { get; set; }
    public int Dept_floor { get; set; }
    public string Dept_name { get; set; }
    public List<Patient> patientlist { get; set; }
    public List<Doctor> doctorlist { get; set; }
    public List<Room> roomlist { get; set; }


}
}
