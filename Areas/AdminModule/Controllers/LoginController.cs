using mediflow.Models;
using mediflow.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mediflow.Areas.AdminModule.Controllers
{
   
    public class LoginController : Controller
    {
     
        RegisterRepository reg = new RegisterRepository();
        // GET: AdminModule/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(register log)
        {
            //this data is from register 
            var data = reg.login(log.email, log.password);
            if (data == null)
            {
                ViewBag.message = "unauthorized user";
                return View();
            }
            else
            {
                //Swe set session value from register
                Session["email"] = data.email;
                Session["userId"] = data.id;
                Session["name"] = data.name;
                Session["username"] = data.username;
                Session["occupation"] = data.occupation;
                Session["about"] = data.id;
                return RedirectToAction("../../Post/Index");
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }





    }
}