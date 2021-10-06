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

    public class PostController : Controller
    {
        CategoryRepository cat = new CategoryRepository();
        PostRepository pro = new PostRepository();

        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["email"] != null)
            {
                var data = cat.GetCategoryList();
                ViewBag.data = data;
                return View();
            }
            else
            {
                return RedirectToAction("../AdminModule/Login/Index");
            }
        }

        [HttpGet]
        public ActionResult GetPostList()
        {
                var data = pro.GetPostList();
                //return Json(data, JsonRequestBehavior.AllowGet);
                return Json(data, JsonRequestBehavior.AllowGet);
          
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var data = pro.GetById(id);
            //return Json(data, JsonRequestBehavior.AllowGet);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(post p)
        {
            //to keep history 
            p.userId = (int)Session["userId"];
            pro.Delete(p);
            return RedirectToAction("GetPostList");
        }

        //from modal
        [HttpGet]
        public ActionResult DeleteFromMoadl(int id)
        {
            var data = pro.GetById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase ImageFile,post tch)
        {
            tch.userId = (int)Session["userId"];

            if (Request.Files.Count > 0)
            {
                var data = pro.GetPostList();
                ViewBag.data = data;

                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + extension;
                tch.image = "../images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                pro.Update(tch);
                ImageFile.SaveAs(fileName);
                return Json("Updated Sucessfully");
            }
            pro.Update(tch);
            return Json("Updated Sucessfully");
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult Insert(post tch,HttpPostedFileBase ImageFile)
        {
            //for image
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + extension;
            tch.image = "../images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            tch.userId = (int)Session["userId"];
            pro.Insert(tch);
            ImageFile.SaveAs(fileName);
            return Json(1,JsonRequestBehavior.AllowGet);
        }


        public ActionResult AllPost()
        {
            var data = cat.GetCategoryList();
            ViewBag.data = data;
            return View();
        }
      
    }
}