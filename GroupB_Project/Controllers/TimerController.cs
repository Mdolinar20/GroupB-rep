using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupB_Project.Controllers
{
    public class TimerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
