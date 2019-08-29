using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class WebManageController : BaseController
    {
        // GET: WebManage
        public ActionResult Index()
        {
            return View();
        }

        #region 楼盘管理
        public ActionResult BuildingManage()
        {
            return View();
        } 
        #endregion



    }
}