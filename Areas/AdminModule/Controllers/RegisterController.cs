using mediflow.Models;
using mediflow.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mediflow.Areas.AdminModule.Controllers
{
    public class RegisterController : Controller
    {
        RegisterRepository register = new RegisterRepository();

        // GET: AdminModule/Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(register reg)
        {
            var data = register.Insert(reg);

            if (data == "Email already exist")
            {
                ViewBag.message = data;     //thi is for razor view
                return View("../Register/Index");
            }
            else if (reg.password != reg.confirmPassword)
            {
                ViewBag.message = "Enter same password for registration.";
                return View("../Register/Index");
            }
            else
            {
                return RedirectToAction("../Login/Index");
            }

        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Insert(register reg)
        {
            if (reg.password != reg.confirmPassword)
            {
                return Json("Password do not match", JsonRequestBehavior.AllowGet);
           
            }
            else
            {
                var data = register.Insert(reg);

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            
         
            //reg.userId = (int)Session["userId"];
        
        }

        [HttpGet]
        public ActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdatePassword(register r)
        {
            //change password of that particular email,pass email through session
            r.email = (string)Session["email"];
            register.UpdatePassword(r);
            return Json(JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult userProfile()
        {
            if (Session["userId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login/Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase ImageFile, register reg)
        {
            reg.userId = (int)Session["userId"];

            if (Request.Files.Count > 0)
            {
           

                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + extension;
                reg.image = "/images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                register.ProfileUpdate(reg);
                ImageFile.SaveAs(fileName);
                return Json("Updated Sucessfully");
            }
            register.ProfileUpdate(reg);
            return Json("Updated Sucessfully");
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var data = register.GetById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}