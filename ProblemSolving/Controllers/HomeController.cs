using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.cats.ToList());
        }
     
        //returns subitems 
        public ActionResult SubItemsV(int ProblemID)
        {
            var subitem = from a in db.SubProblems
                          where ProblemID == a.id
                          select a;
     
            if (subitem == null)
            {
                return HttpNotFound();
            }
            Session["subitem"] = ProblemID;
            return View(subitem);
        }

        public ActionResult Details(int SubId)
        {
            var sub = db.SubProblems.Find(SubId);

            if (sub == null)
            {
                return HttpNotFound();
            }
            Session["sub"] = sub;
            return View(sub);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}