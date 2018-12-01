using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Patient
{
    public int p_id { get; set; }
    public string p_name { get; set; }
    public string p_gender { get; set; }
    public DateTime p_birthdate { get; set; }
    public List<Doctor> doctorlist { get; set; }
    public List<Department> departmentlist { get; set; }

}
}
