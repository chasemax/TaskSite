using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private TaskContext _tc { get; set; }

        public HomeController(TaskContext tc)
        {
            _tc = tc;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Quadrant()
        {
            var allTasks = _tc.TaskInfo
                .Include(x => x.Category)
                .Where(x => x.Completed == false)
                .ToList();
            return View(allTasks);
        }

        [HttpGet]
        public IActionResult DeleteTask(string id)
        {
            TaskInfo toDelete = _tc.TaskInfo.Single(x => x.Task == id);
            _tc.Remove(toDelete);
            _tc.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult CheckOffTask(string id)
        {
            TaskInfo toCheckOff = _tc.TaskInfo.Single(x => x.Task == id);
            toCheckOff.Completed = true;
            _tc.Update(toCheckOff);
            _tc.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult UpdateTask(string id)
        {
            TaskInfo t = _tc.TaskInfo.Single(x => x.Task == id);
            ViewBag.categories = _tc.Categories.ToList();
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
            ViewBag.categories = _tc.Categories.ToList();
            return View("tasks");
        }

        [HttpPost]
        public IActionResult AddTask(TaskInfo ti)
        {
            if (ModelState.IsValid)
            {
                _tc.Add(ti);
                _tc.SaveChanges();
                return RedirectToAction("Quadrant");
            }
            else
            {
                ViewBag.categories = _tc.Categories.ToList();
                return View("tasks");
            }
            
        }
    }
}
