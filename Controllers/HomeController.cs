using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Quandrant()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteTask(string id)
        {
            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult UpdateTask(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateTask()
        {
            return RedirectToAction("Quadrant");
        }

        public IActionResult AddTask()
        {
            return View();
        }
    }
}
