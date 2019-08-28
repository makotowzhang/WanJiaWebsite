using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class WebManageController : Controller
    {
        // GET: WebManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildingManage()
        {
            return View();
        }


        public ActionResult UploadImg()
        {
            return Content("");
        }
    }
}