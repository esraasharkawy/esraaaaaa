using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advancedproject.Models
{
    public class Room
{[Key]
    public int Rno { get; set; }
        [Required(ErrorMessage ="you must enter r floor")]
        [Display(Name ="r floor")]
public int R_floor { get; set; }
    public int dept_no { get; set; }
    public Department department { get; set; }
}
}
