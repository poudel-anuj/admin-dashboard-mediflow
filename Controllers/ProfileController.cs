using mediflow.Models;
using mediflow.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mediflow.Controllers
{
    public class ProfileController : Controller
    {

        RegisterRepository register = new RegisterRepository();
        // GET: Profile
        public ActionResult Index()
        {
            if (Session["userId"] != null) {
                return View();
            }
            else
            {
                return RedirectToAction("../AdminModule/Login/Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase ImageFile, register reg)
        {
            //tch.userId = (int)Session["userId"];

            if (Request.Files.Count > 0)
            {
                //var data = pro.GetPostListre
                //ViewBag.data = data;

                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + extension;
                reg.image = "../images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                register.ProfileUpdate(reg);
                ImageFile.SaveAs(fileName);
                return Json("Updated Sucessfully");
            }
            register.ProfileUpdate(reg);
            return Json("Updated Sucessfully");
        }
    }
}