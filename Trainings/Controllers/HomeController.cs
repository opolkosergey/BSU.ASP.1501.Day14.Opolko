using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Trainings.Models;
using Trainings.Infrastructure;

namespace Trainings.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            var db = new ApplicationDbContext();
            var trainings = db.Trainings as IEnumerable<Training>;
            IEnumerable<Training> trainingsPerPages = trainings.Skip((page - 1) * 5).Take(5);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = 5, TotalItems = trainings.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Trainings = trainingsPerPages };
            return View(ivm);
        }

        [HttpGet]
        public ActionResult NewTraining()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewTraining(Training training)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Trainings.Add(training);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var db = new ApplicationDbContext();
            var training = db.Trainings.First(t => t.Id == id);
            ViewBag.Students = training.Students;
            ViewBag.trainingName = training.Name;
            TempData["TrainingId"] = training.Id;
            return View();
        }

        [HttpPost]
        public ActionResult Details(Student student)
        {
            var db = new ApplicationDbContext();
            var trainingId = TempData["TrainingId"];
            var training = db.Trainings.First(t => t.Id == (int)trainingId);
            TempData["TrainingId"] = training.Id;
            if (ModelState.IsValid && Request.IsAjaxRequest())
            {
                training.Students.Add(student);
                db.SaveChanges();
                return Content("<li>" + student.FirstName + " " + student.LastName
                                + " " + student.University + " " + student.UniversityClass +
                                " cource</li>");
            }
            if (ModelState.IsValid)
            {
                training.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = training.Id });
            }

            return (Request.IsAjaxRequest())? (ActionResult) Content(String.Empty) : RedirectToAction("Details", new { id = training.Id });
        }
    }
}