using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Patient_Department
{
    public int pid { get; set; }
    public Patient patient { get; set; }
    public int deptno { get; set; }
    public Department department { get; set; }
}
}
