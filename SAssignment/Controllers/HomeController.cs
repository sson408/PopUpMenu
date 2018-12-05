using SAssignment.DAL;
using SAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data;

namespace SAssignment.Controllers
{
    public class HomeController : Controller
    {

        private IExerciseRepository exerciseRepository;

        public HomeController()
        {
            this.exerciseRepository = new ExerciseRepository(new AssignmentEntities());
        }


        public HomeController( IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        // GET: 
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var exercises = from e in exerciseRepository.GetExerciseRecords()
                            select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                exercises = exercises.Where(e => e.ExerciseName.ToUpper().Contains(searchString.ToUpper()));
                                      
            }
            switch (sortOrder)
            {
                case "name_desc":
                    exercises = exercises.OrderByDescending(e => e.ExerciseName);
                    break;
                case "Date":
                    exercises = exercises.OrderBy(e => e.ExerciseDate);
                    break;
                case "date_desc":
                    exercises = exercises.OrderByDescending(e => e.DurationInMinutes);
                    break;
                default:  // Name ascending 
                    exercises = exercises.OrderBy(e => e.ExerciseDate);
                    break;
            }
           
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //List<ExerciseRecord> model = (List<ExerciseRecord>)exerciseRepository.GetExerciseRecords();
 
            return View(exercises.ToPagedList(pageNumber, pageSize));
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseName, ExerciseDate, DurationInMinutes")] ExerciseRecord obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    exerciseRepository.InsertStudent(obj);
                    exerciseRepository.Save();
                    return RedirectToAction("Index");
                    //return View(obj);
                }
                //using (var db = new AssignmentEntities())
                //{
                //    db.ExerciseRecords.Add(obj);
                //    db.SaveChanges();
                //}
                    
            }
            catch(DataException /* dex */)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View();
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            exerciseRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
