﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Patient_Doctor
{
    public int pid { get; set; }
    public Patient patient  { get; set; }
    public int Did { get; set; }
    public Doctor doctor{ get; set; }

}
}
