using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Employee
{
    public int E_id { get; set; }
    public int E_salary { get; set; }
    public int E_phone { get; set; }
    public string E_gender { get; set; }
    public int D_id { get; set; }
    public Doctor doctor { get; set; }
}
}
