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

    public class SliderController : Controller
    {
        SliderRepository slide = new SliderRepository();
        // GET: Slider
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Insert(slider s,HttpPostedFileBase ImageFile)
        {

            //for image
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            fileName = fileName + extension;
            s.image = "../images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
            slide.Insert(s);
            ImageFile.SaveAs(fileName);
            return Json( JsonRequestBehavior.AllowGet);

        }

        //two method for get slider
        [HttpGet]
        public ActionResult AllSlider()
        {
         

            return View();
        }

        [HttpGet]
        public JsonResult GetAllSlider()
        {
            var data = slide.GetPSliderList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteFromMoadl(int id)
        {
            var data = slide.GetById(id);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(slider s)
        {
            slide.Delete(s);
            return RedirectToAction("GetAllSlider");
        }

        public ActionResult GetById(int id)
        {
            var data = slide.GetById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            var datas = slide.GetById(id);
            return View(datas);
        }



        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase ImageFile, slider s)
        {
            if (Request.Files.Count > 0)
            {
                //var data = slide.GetPostList();
                //ViewBag.data = data;

                string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                string extension = Path.GetExtension(ImageFile.FileName);
                fileName = fileName + extension;
                s.image = "../images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                slide.Update(s);
                ImageFile.SaveAs(fileName);
                return Json("Updated Sucessfully");
            }
            slide.Update(s);
            return Json("Updated Sucessfully");

        }


    }
}