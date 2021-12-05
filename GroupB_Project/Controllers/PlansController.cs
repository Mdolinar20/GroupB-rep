using GroupB_Project.Data;
using GroupB_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupB_Project.Controllers
{
    public class PlansController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlansController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Return the Current Plan of Studying for the Future on the Index Page
       public IActionResult Index()
        {
            IEnumerable<Plans> objList = _db.Plan;
            return View(objList);
        }
        
        // Post Generation 
        [HttpPost]
        // Log in Authentication 
        [ValidateAntiForgeryToken]
        public IActionResult Inputs(Plans obj)
        {
            //Add to DB
            _db.Plan.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Navigate to the Input Screen 
        public IActionResult Inputs()
        {
            return View();
        }


    }
}
