using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskSite.Models;

namespace TaskSite.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext _tc;

        public HomeController(TaskContext tc)
        {
            _tc = tc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Quandrant()
        {
            List<TaskInfo> allTasks = _tc.TaskInfo.ToList();
            return View(allTasks);
        }

        [HttpGet]
        public IActionResult DeleteTask(string id)
        {
            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult UpdateTask(string id)
        {
            TaskInfo t = _tc.TaskInfo.Single(x => x.Task == id);
            return View("tasks", t);
        }

        [HttpPost]
        public IActionResult UpdateTask(TaskInfo ti)
        {
            _tc.Update(ti);
            _tc.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View("tasks");
        }

        [HttpPost]
        public IActionResult AddTask(TaskInfo ti)
        {
            _tc.Add(ti);
            _tc.SaveChanges();
            return RedirectToAction("Quadrant");
        }
    }
}
