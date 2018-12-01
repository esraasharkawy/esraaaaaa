using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Patient_Department
{
    public int p_id { get; set; }
    public Patient patient { get; set; }
    public int dept_no { get; set; }
    public Department department { get; set; }
}
}
