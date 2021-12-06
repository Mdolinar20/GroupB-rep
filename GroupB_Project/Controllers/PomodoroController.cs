using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomodoro_Timer.Controllers
{
    public class PomodoroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
