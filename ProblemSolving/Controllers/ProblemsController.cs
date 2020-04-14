using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProblemSolving.Models;
using WebApplication2.Models;

namespace ProblemSolving.Controllers
{
    public class ProblemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Problems
        public ActionResult Index()
        {
            var problems = db.Problems.Include(p => p.Category);
            return View(problems.ToList());
        }   

        // GET: Problems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // GET: Problems/Create
        public ActionResult Create()
        {
            ViewBag.catId = new SelectList(db.cats, "Id", "CategoryName");
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Problem problem, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //Insert File//
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                problem.probImg = upload.FileName;
                //
                db.Problems.Add(problem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catId = new SelectList(db.cats, "Id", "CategoryName", problem.catId);
            return View(problem);
        }

        // GET: Problems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            ViewBag.catId = new SelectList(db.cats, "Id", "CategoryName", problem.catId);
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProblemID,ProblemName,ProblemDescription,catId")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(problem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catId = new SelectList(db.cats, "Id", "CategoryName", problem.catId);
            return View(problem);
        }

        // GET: Problems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Problem problem = db.Problems.Find(id);
            if (problem == null)
            {
                return HttpNotFound();
            }
            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Problem problem = db.Problems.Find(id);
            db.Problems.Remove(problem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
