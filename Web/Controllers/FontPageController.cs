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
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 企业介绍
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterPriseIntroduction()
        {
            return View();
        }

        /// <summary>
        /// 新闻中心
        /// </summary>
        /// <returns></returns>
        public ActionResult NewsCenter()
        {
            return View();
        }

        /// <summary>
        /// 楼盘风采
        /// </summary>
        /// <returns></returns>
        public ActionResult BuildingStyle()
        {
            return View();
        }

        /// <summary>
        /// 营销网络
        /// </summary>
        /// <returns></returns>
        public ActionResult BusinessChannel()
        {
            return View();
        }

        /// <summary>
        /// 信息反馈
        /// </summary>
        /// <returns></returns>
        public ActionResult RecruitmentTalents()
        {
            return View();
        }

        /// <summary>
        /// 阳光招采
        /// </summary>
        /// <returns></returns>
        public ActionResult SunRecruitment()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}