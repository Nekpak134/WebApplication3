using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.dbcontext;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        NekpalEntities db = new NekpalEntities();
        public ActionResult Index()
        {
            var result = db.emloyeeas.ToList();
            List<empmodel> e = new List<empmodel>();
            foreach (var item in result)
            {
                e.Add(new empmodel { id = item.id, fname = item.fname, dept = item.dept, lname = item.lname });
            }
            return View(e);
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
        public ActionResult delete(int? id)
        {
            var delete = db.emloyeeas.Where(m => m.id == id).First();
            db.emloyeeas.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(empmodel e)
        {
            emloyeea a = new emloyeea();
            a.id = e.id;
            a.fname = e.fname;
            a.lname = e.lname;
            a.dept = e.dept;
          
            if(a.id==0)
            {
                db.emloyeeas.Add(a);
                db.SaveChanges();
            }
            else
            {
                db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
         
        public ActionResult details(int? id)
        {
            var details = db.emloyeeas.Where(m => m.id == id).First();
            empmodel a = new empmodel();
            a.id = details.id;
            a.fname = details.fname;
            a.lname = details.lname;
            a.dept = details.dept;
            return View(a);
        }
        public ActionResult edit(int? id)
        {
            var edit = db.emloyeeas.Where(m => m.id == id).First();
            empmodel a = new empmodel();
            a.id = edit.id;
            a.fname = edit.fname;
            a.lname = edit.lname;
            a.dept = edit.dept;
            return View("create", a);
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(loginmodel l)
        {
            var s = db.logins.Where(m => m.email == l.email).FirstOrDefault();
            if(s==null)
            {
                TempData["email"] = "email not found";
            }
            else
            {
                if(s.email==l.email && s.password==l.password)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["password"] = "password is incorrect";
                }
            }
            return View();
        }
        public ActionResult create_new()
        {
            return View();
        }

    }
}