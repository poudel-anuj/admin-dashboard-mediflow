using mediflow.Models;
using mediflow.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mediflow.Controllers
{

    public class CategoryController : Controller
    {
        CategoryRepository pro = new CategoryRepository();
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(category p)
        {
            pro.Insert(p);
            return RedirectToAction("GetCategoryList");
        }

        [HttpGet]
        public ActionResult GetCategoryList()
        {
            var data = pro.GetCategoryList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var data = pro.GetCategoryById(id);
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(category c)
        {
            var data = pro.Delete(c);
            ViewBag.data = data;
            return Json(data);

        }

        //delete from modal
        [HttpGet]
        public ActionResult DeleteFromMoadl(int id)
        {
            var data = pro.GetCategoryById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = pro.GetCategoryById(id);
            return View(data);
        }


        [HttpPost]
        public ActionResult Edit(category p)
        {
            pro.Update(p);
            return RedirectToAction("GetCategoryList");
        }

        [HttpPost]
        public JsonResult Insert(category tch)
        {
            var data = pro.Insert(tch);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}