using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity;
using Model;
using Model.EnumModel;
using Common;

namespace Business
{
    public class WebsiteManage
    {
        #region 楼盘管理
        public bool AddBuilding(WJ_BuildingModel model, string rootPath)
        {
            using (DataProvider dp = new DataProvider())
            {
                try
                {
                    WJ_Building entity = Mapper.Map<WJ_Building>(model);
                    entity.Id = Guid.NewGuid();
                    entity.CreateTime = DateTime.Now;
                    entity.IsDel = false;
                    model.BuildTypeList.ForEach(m =>
                    {
                        dp.WJ_BuildingAttr.Add(new WJ_BuildingAttr
                        {
                            BuildingId = entity.Id,
                            AttrType = DicGroupCode.BuildingType.ToString(),
                            DicId = m
                        });
                    });
                    model.BuildTagList.ForEach(m =>
                    {
                        dp.WJ_BuildingAttr.Add(new WJ_BuildingAttr
                        {
                            BuildingId = entity.Id,
                            AttrType = DicGroupCode.BuildingTag.ToString(),
                            DicId = m
                        });
                    });
                    model.BuildPropertyTypeLsit.ForEach(m =>
                    {
                        dp.WJ_BuildingAttr.Add(new WJ_BuildingAttr
                        {
                            BuildingId = entity.Id,
                            AttrType = DicGroupCode.BuildPropertyType.ToString(),
                            DicId = m
                        });
                    });

                    model.BuildShowImage.ForEach(m =>
                    {
                        string newPath = FileHelper.GetNewFile("/Upload/BuildShow/", m);
                        FileHelper.CutFile(rootPath + m, rootPath + newPath);
                        dp.WJ_BuildingPhoto.Add(new WJ_BuildingPhoto
                        {
                            BuildingId = entity.Id,
                            PhotoType = "Show",
                            PhotoPath = newPath
                        });
                    });

                    model.BuildAlbumList.ForEach(m =>
                    {
                        string newPath = FileHelper.GetNewFile("/Upload/Album/", m);
                        FileHelper.CutFile(rootPath + m, rootPath + newPath);
                        dp.WJ_BuildingPhoto.Add(new WJ_BuildingPhoto
                        {
                            BuildingId = entity.Id,
                            PhotoType = "Album",
                            PhotoPath = newPath
                        });
                    });

                    model.BuildHouseTypeList.ForEach(m =>
                    {
                        string newPath = FileHelper.GetNewFile("/Upload/HouseType/", m);
                        FileHelper.CutFile(rootPath + m, rootPath + newPath);
                        dp.WJ_BuildingPhoto.Add(new WJ_BuildingPhoto
                        {
                            BuildingId = entity.Id,
                            PhotoType = "HouseType",
                            PhotoPath = newPath
                        });
                    });
                    dp.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditBuilding(WJ_BuildingModel model, string rootPath)
        {
            using (DataProvider dp = new DataProvider())
            {
                if (model.Id == Guid.Empty)
                {
                    return false;
                }
                var entity = dp.WJ_Building.FirstOrDefault(m => m.Id == model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.ShortRemark = model.ShortRemark;
                entity.ContactTel = model.ContactTel;
                entity.Address = model.Address;
                entity.BuildName = model.BuildName;
                entity.Sort = model.Sort;
                entity.StarsCount = model.StarsCount;
                entity.BuildIntro = model.BuildIntro;
                entity.OpeningTime = model.OpeningTime;
                entity.BuildPrice = model.BuildPrice;
                entity.BuildType = model.BuildType;
                entity.Households = model.Households;
                entity.BelogEstate = model.BelogEstate;
                entity.Years = model.Years;
                entity.SalesAddress = model.SalesAddress;
                entity.AreaCovered = model.AreaCovered;
                entity.BuildingCount = model.BuildingCount;
                entity.RenovationCondition = model.RenovationCondition;
                entity.GreeningRate = model.GreeningRate;
                entity.UpdateTime = DateTime.Now;


                dp.WJ_BuildingAttr.RemoveRange(dp.WJ_BuildingAttr.Where(m => m.BuildingId == model.Id));
                model.BuildTagList.ForEach(m =>
                {
                    dp.WJ_BuildingAttr.Add(new WJ_BuildingAttr
                    {
                        BuildingId = entity.Id,
                        AttrType = DicGroupCode.BuildingTag.ToString(),
                        DicId = m
                    });
                });
                model.BuildPropertyTypeLsit.ForEach(m =>
                {
                    dp.WJ_BuildingAttr.Add(new WJ_BuildingAttr
                    {
                        BuildingId = entity.Id,
                        AttrType = DicGroupCode.BuildPropertyType.ToString(),
                        DicId = m
                    });
                });
                model.BuildShowImage.ForEach(m =>
                {
                    string newPath = FileHelper.GetNewFile("/Upload/BuildShow/", m);
                    FileHelper.CutFile(rootPath + m, rootPath + newPath);
                    dp.WJ_BuildingPhoto.Add(new WJ_BuildingPhoto
                    {
                        BuildingId = entity.Id,
                        PhotoType = "Show",
                        PhotoPath = newPath
                    });
                });

                return true;
            }
        }
        #endregion
    }
}
