using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst1.Models;
using CodeFirst1.Dal;
using CodeFirst1.Dal.Repository;
using PagedList;

namespace CodeFirst1.Controllers
{
    public class StudentController : Controller
    {
        //private SchoolContext db;
        private IRepository<Student> repository;
        private IUnitOfWork _uow;
        
        
        public StudentController(IUnitOfWork repositoryContext)
        {
            this._uow = repositoryContext;

            repository = _uow.GetRepository<Student>();
        }
        
        // GET: /Student/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //return View(db.Students.ToList());
            //return View(repository.GetList());
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

            IEnumerable<Student> students = repository.GetList();
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                       || s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = repository.GetEntity(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Students.Add(student);
                    //db.SaveChanges();
                    repository.AddEntity(student);
                    _uow.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
              //Log the error (uncomment dex variable name and add a line here to write a log.
              ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            throw new InvalidOperationException();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = repository.GetEntity(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();
                repository.UpdateEntity(student);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = repository.GetEntity(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Student student = db.Students.Find(id);
            //db.Students.Remove(student);
            //db.SaveChanges();
            Student student = repository.GetEntity(id);
            repository.DeleteEntity(student);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
//            if (disposing)
//            {
                //db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
