using Drone_Management_Sys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drone_Management_Sys.Controllers
{
    public class LoginController : Controller
    {
        private DroneEntities db = new DroneEntities();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customer)
        {
            
                using (db)
                {
                    var obj = db.Customers.Where(a => a.username.Equals(customer.username) && a.password.Equals(customer.password)).FirstOrDefault()                       ;
                    if (obj != null)
                    {
                        Session["username"] = obj.username.ToString();
                        Session["password"] = obj.password.ToString();
                        return RedirectToAction("Index", "DroneProfiles");
                    }
                }
            return View(customer);
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