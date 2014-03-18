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

namespace CodeFirst1.Controllers
{
    public class StudentController : Controller
    {
        //private SchoolContext db;
        private IRepository repository;
        private IUnitOfWork repositoryContext;
        
        
        public StudentController(IRepository repository, IUnitOfWork repositoryContext)
        {
            this.repository = repository;
            this.repositoryContext = repositoryContext;
        }
        
        // GET: /Student/
        public ActionResult Index()
        {
            //return View(db.Students.ToList());
            return View(repository.GetList<Student>());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = repository.GetEntity<Student>(id);
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
                    repository.AddEntity<Student>(student);
                    repositoryContext.SaveChanges();
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = db.Students.Find(id);
            Student student = repository.GetEntity<Student>(id);
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
                repository.UpdateEntity<Student>(student);
                repositoryContext.SaveChanges();
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
            Student student = repository.GetEntity<Student>(id);
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
            Student student = repository.GetEntity<Student>(id);
            repository.DeleteEntity<Student>(student);
            repositoryContext.SaveChanges();
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
