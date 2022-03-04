using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Hospital_Management.Models;

namespace Hospital_Management.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "satya";
            return View();
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

        [HttpPost]
        public ActionResult Login(User objUser)
        {
            if (ModelState.IsValid)
            {
                using (Hospital_DBEntities db = new Hospital_DBEntities())
                {
                    var obj = db.Tbl_User.Where(a => a.User_Name.Equals(objUser.name) && a.Password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.User_Id.ToString();
                        Session["UserName"] = obj.User_Name.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
