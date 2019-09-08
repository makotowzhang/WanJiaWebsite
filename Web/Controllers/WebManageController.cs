using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.SystemModel;
using Business;
using Entity;

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

        #region 客户管理
        public ActionResult CustomerManage()
        {
            return View();
        }

        public ActionResult GetCustomerList(WJ_CustomerFilter filter)
        {
            var data = service.GetCustomerList(filter, out int total);
            return Json(new TableDataModel(total, data));
        }

        public ActionResult DeleteCustomer(List<WJ_Customer> ids)
        {
            return Json(new JsonMessage(service.DeleteCustomer(ids.Select(m => m.Id).ToList())));
        }
        #endregion

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

        #region 招标管理
        public ActionResult TenderManage()
        {
            return View();
        }

        public ActionResult AddTender(WJ_TenderModel model)
        {
            if (model.Id.HasValue)
            {
                model.UpdateUser = CurrentUser.Id;
            }
            else
            {
                model.CreateUser = CurrentUser.Id;
            }
            return Json(new JsonMessage(service.AddTender(model)));
        }



        public ActionResult GetTenderModel(int id)
        {
            return Json(service.GetTenderModel(id));
        }

        public ActionResult GetTenderList(WJ_TenderFilter filter)
        {
            var data = service.GetTenderList(filter, out int total);
            return Json(new TableDataModel(total, data));
        }

        public ActionResult DeleteTender(List<WJ_TenderModel> ids)
        {
            return Json(new JsonMessage(service.DeleteTender(ids.Select(m => m.Id.Value).ToList())));
        }

        #endregion

        #region 招贤管理
        public ActionResult JobManage()
        {
            return View();
        }

        public ActionResult AddJob(WJ_JobModel model)
        {
            if (model.Id.HasValue)
            {
                model.UpdateUser = CurrentUser.Id;
            }
            else
            {
                model.CreateUser = CurrentUser.Id;
            }
            return Json(new JsonMessage(service.AddJob(model)));
        }



        public ActionResult GetJobModel(int id)
        {
            return Json(service.GetJobModel(id));
        }

        public ActionResult GetJobList(WJ_JobFilter filter)
        {
            var data = service.GetJobList(filter, out int total);
            return Json(new TableDataModel(total, data));
        }

        public ActionResult DeleteJob(List<WJ_JobModel> ids)
        {
            return Json(new JsonMessage(service.DeleteJob(ids.Select(m => m.Id.Value).ToList())));
        }
        #endregion

    }
}