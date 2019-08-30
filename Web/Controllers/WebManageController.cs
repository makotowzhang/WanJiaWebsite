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
            return Json(new JsonMessage(service.DeleteBuilding(ids.Select(m=>m.Id).ToList(), Server.MapPath("~"))));
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



    }
}