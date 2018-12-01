using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Advanced_project.Controllers
{
    public class TryTemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}