using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Model.SystemModel;
using Model;


namespace Business.SystemBusiness
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(m =>
            {
                m.CreateMap<System_User, UserModel>();
                m.CreateMap<UserModel, System_User>();
                m.CreateMap<System_Role, RoleModel>();
                m.CreateMap<RoleModel, System_Role>();
                m.CreateMap<System_Menu, MenuModel>();
                m.CreateMap<MenuModel, System_Menu>();
                m.CreateMap<System_Log, LogModel>();
                m.CreateMap<LogModel, System_Log>();
                m.CreateMap<System_Message, SysMessageModel>();
                m.CreateMap<SysMessageModel, System_Message>();
                m.CreateMap<DicGroupModel, System_DicGroup>();
                m.CreateMap<System_DicGroup,DicGroupModel>();

                m.CreateMap<DicItemModel, System_DicItem>();
                m.CreateMap<System_DicItem, DicItemModel>();

                m.CreateMap<WJ_Building, WJ_BuildingModel>();
                m.CreateMap<WJ_BuildingModel, WJ_Building>();

                m.CreateMap<WJ_News, WJ_NewsModel>();
                m.CreateMap<WJ_NewsModel, WJ_News>();

                m.CreateMap<WJ_Tender, WJ_TenderModel>();
                m.CreateMap<WJ_TenderModel, WJ_Tender>();

                m.CreateMap<WJ_Job, WJ_JobModel>();
                m.CreateMap<WJ_JobModel, WJ_Job>();

            });
        }
    }
}
