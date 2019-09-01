using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.SystemModel;
using Business;

namespace WebSite.Controllers
{
    public class WebManageController : BaseController
    {
        WebsiteManageBusiness service = new WebsiteManageBusiness();
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

        public ActionResult AddBuilding(WJ_BuildingModel model)
        {
            model.CreateUser = CurrentUser.Id;
            return Json(new JsonMessage(service.AddBuilding(model, Server.MapPath("~"))));
        }

        public ActionResult EditBuilding(WJ_BuildingModel model)
        {
            model.UpdateUser = CurrentUser.Id;
            return Json(new JsonMessage(service.EditBuilding(model, Server.MapPath("~"))));
        }

        public ActionResult DeleteBuilding(List<WJ_BuildingModel> ids)
        {
            return Json(new JsonMessage(service.DeleteBuilding(ids.Select(m => m.Id).ToList(), Server.MapPath("~"))));
        }

        public ActionResult GetBuildingModel(Guid id)
        {
            return Json(service.GetBuildingModel(id));
        }

        public ActionResult GetBuildingList(WJ_BuildingFilter filter)
        {
            var data = service.GetBuildingList(filter, out int total);
            return Json(new TableDataModel(total, data));
        }

        #endregion

        #region 新闻管理
        public ActionResult NewsManage()
        {
            return View();
        }

        public ActionResult AddNews(WJ_NewsModel model)
        {
            if (model.Id.HasValue)
            {
                model.UpdateUser = CurrentUser.Id;
            }
            else
            {
                model.CreateUser = CurrentUser.Id;
            }
            return Json(new JsonMessage(service.AddNews(model, Server.MapPath("~"))));
        }



        public ActionResult GetNewsModel(int id)
        {
            return Json(service.GetNewsModel(id));
        }

        public ActionResult GetNewsList(WJ_NewsModelFilter filter)
        {
            var data = service.GetNewsList(filter, out int total);
            return Json(new TableDataModel(total, data));
        }

        public ActionResult DeleteNews(List<WJ_NewsModel> ids)
        {
            return Json(new JsonMessage(service.DeleteNews(ids.Select(m => m.Id.Value).ToList())));
        }
        #endregion

        #region 招商管理
        public ActionResult InvestmentManage()
        {
            return View();
        }

        public ActionResult AddInvestment(WJ_InvestmentModel model)
        {
            if (model.Id.HasValue)
            {
                model.UpdateUser = CurrentUser.Id;
            }
            else
            {
                model.CreateUser = CurrentUser.Id;
            }
            return Json(new JsonMessage(service.AddInvestment(model, Server.MapPath("~"))));
        }



        public ActionResult GetInvestmentModel(int id)
        {
            return Json(service.GetInvestmentModel(id));
        }

        public ActionResult GetInvestmentList(WJ_InvestmentFilter filter)
        {
            var data = service.GetInvestmentList(filter, out int total);
            return Json(new TableDataModel(total, data));
        }

        public ActionResult DeleteInvestment(List<WJ_InvestmentModel> ids)
        {
            return Json(new JsonMessage(service.DeleteInvestment(ids.Select(m => m.Id.Value).ToList())));
        }

        #endregion

    }
}