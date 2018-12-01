using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Room
{
    public int R_no { get; set; }
public int R_floor { get; set; }
    public int dept_no { get; set; }
    public Department department { get; set; }
}
}
