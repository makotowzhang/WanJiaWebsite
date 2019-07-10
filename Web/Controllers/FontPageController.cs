using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class FontPageController : Controller
    {
        // GET: FontPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnterPriseIntroduction()
        {
            return View();
        }

        public ActionResult NewsCenter()
        {
            return View();
        }
    }
}