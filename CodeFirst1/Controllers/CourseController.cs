using CodeFirst1.Dal;
using CodeFirst1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst1.Controllers
{
    public class CourseController : Controller
    {
        private SchoolContext db = new SchoolContext();

        //
        // GET: /Course/
        public ActionResult Index()
        {
            IEnumerable<Course> courses = db.Courses;
            ViewBag.Courses = courses;
            return View();
        }
	}
}