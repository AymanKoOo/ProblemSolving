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
    public class SubProblemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubProblems
        public ActionResult Index()
        {
            var subProblems = db.SubProblems.Include(s => s.problem);
            return View(subProblems.ToList());
        }

        // GET: SubProblems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubProblem subProblem = db.SubProblems.Find(id);
            if (subProblem == null)
            {
                return HttpNotFound();
            }
            return View(subProblem);
        }

        // GET: SubProblems/Create
        public ActionResult Create()
        {
            ViewBag.problemId = new SelectList(db.Problems, "ProblemID", "ProblemName");
            return View();
        }

        // POST: SubProblems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubProblem subProblem, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //
                //Insert File//
                string path = Path.Combine(Server.MapPath("~/Img"), upload.FileName);
                upload.SaveAs(path);
                subProblem.probImg = upload.FileName;
                //
                //
                db.SubProblems.Add(subProblem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.problemId = new SelectList(db.Problems, "ProblemID", "ProblemName", subProblem.problemId);
            return View(subProblem);
        }

        // GET: SubProblems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubProblem subProblem = db.SubProblems.Find(id);
            if (subProblem == null)
            {
                return HttpNotFound();
            }
            ViewBag.problemId = new SelectList(db.Problems, "ProblemID", "ProblemName", subProblem.problemId);
            return View(subProblem);
        }

        // POST: SubProblems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SubProbName,SubProbNameDescription,problemId,code")] SubProblem subProblem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subProblem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.problemId = new SelectList(db.Problems, "ProblemID", "ProblemName", subProblem.problemId);
            return View(subProblem);
        }

        // GET: SubProblems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubProblem subProblem = db.SubProblems.Find(id);
            if (subProblem == null)
            {
                return HttpNotFound();
            }
            return View(subProblem);
        }

        // POST: SubProblems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubProblem subProblem = db.SubProblems.Find(id);
            db.SubProblems.Remove(subProblem);
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
