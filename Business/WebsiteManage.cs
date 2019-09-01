using AutoMapper;
using Common;
using Entity;
using Model;
using Model.EnumModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business
{
    public class WebsiteManageBusiness
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
                    dp.WJ_Building.Add(entity);
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
                try
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


                    var showList = dp.WJ_BuildingPhoto.Where(m => m.BuildingId == model.Id && m.PhotoType == "Show" && !model.BuildShowImage.Contains(m.PhotoPath));
                    var albumList = dp.WJ_BuildingPhoto.Where(m => m.BuildingId == model.Id && m.PhotoType == "Album" && !model.BuildAlbumList.Contains(m.PhotoPath));
                    var htList = dp.WJ_BuildingPhoto.Where(m => m.BuildingId == model.Id && m.PhotoType == "HouseType" && !model.BuildHouseTypeList.Contains(m.PhotoPath));
                    foreach (var m in showList)
                    {
                        File.Delete(rootPath + m.PhotoPath);
                    }
                    foreach (var m in albumList)
                    {
                        File.Delete(rootPath + m.PhotoPath);
                    }
                    foreach (var m in htList)
                    {
                        File.Delete(rootPath + m.PhotoPath);
                    }

                    dp.WJ_BuildingPhoto.RemoveRange(dp.WJ_BuildingPhoto.Where(m => m.BuildingId == model.Id));

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

        public bool DeleteBuilding(List<Guid> ids, string rootPath)
        {
            using (DataProvider dp = new DataProvider())
            {
                try
                {
                    dp.WJ_Building.RemoveRange(dp.WJ_Building.Where(m => ids.Contains(m.Id)));
                    dp.WJ_BuildingAttr.RemoveRange(dp.WJ_BuildingAttr.Where(m => ids.Contains(m.BuildingId)));
                    var temp = dp.WJ_BuildingPhoto.Where(m => ids.Contains(m.BuildingId));
                    dp.WJ_BuildingPhoto.RemoveRange(temp);
                    dp.SaveChanges();
                    try
                    {
                        foreach (var m in temp)
                        {
                            File.Delete(rootPath + m.PhotoPath);
                        }
                    }
                    catch
                    {

                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public WJ_BuildingModel GetBuildingModel(Guid? id)
        {
            if (!id.HasValue)
            {
                return new WJ_BuildingModel();
            }
            using (DataProvider dp = new DataProvider())
            {
                WJ_BuildingModel model = Mapper.Map<WJ_BuildingModel>(dp.WJ_Building.FirstOrDefault(m => m.Id == id.Value));
                model.BuildTypeList.AddRange(dp.WJ_BuildingAttr.
                                             Where(m => m.BuildingId == model.Id && m.AttrType == "BuildingType").
                                             Select(m => m.DicId));
                model.BuildTagList.AddRange(dp.WJ_BuildingAttr.
                                           Where(m => m.BuildingId == model.Id && m.AttrType == "BuildingTag").
                                           Select(m => m.DicId));
                model.BuildPropertyTypeLsit.AddRange(dp.WJ_BuildingAttr.
                                           Where(m => m.BuildingId == model.Id && m.AttrType == "BuildPropertyType").
                                           Select(m => m.DicId));
                model.BuildShowImage.AddRange(dp.WJ_BuildingPhoto.
                                                 Where(m => m.BuildingId == model.Id && m.PhotoType == "Show").
                                                 Select(m => m.PhotoPath));
                model.BuildAlbumList.AddRange(dp.WJ_BuildingPhoto.
                                                 Where(m => m.BuildingId == model.Id && m.PhotoType == "Album").
                                                 Select(m => m.PhotoPath));
                model.BuildHouseTypeList.AddRange(dp.WJ_BuildingPhoto.
                                                 Where(m => m.BuildingId == model.Id && m.PhotoType == "HouseType").
                                                 Select(m => m.PhotoPath));
                return model;
            }
        }

        public List<WJ_BuildingModel> GetBuildingList(WJ_BuildingFilter filter, out int total)
        {
            using (DataProvider dp = new DataProvider())
            {
                var list = dp.WJ_Building.Where(m => !m.IsDel);
                if (filter.BuildingName.IsNotNullOrWhiteSpace())
                {
                    list = list.Where(m => m.BuildName.Contains(filter.BuildingName));
                }
                if (filter.BuildingTag.IsNotNullAndCountGtZero())
                {
                    list = list.Where(m => dp.WJ_BuildingAttr.Where(x => x.BuildingId == m.Id).Any(x => filter.BuildingTag.Contains(x.DicId)));
                }
                if (filter.BuildingType.IsNotNullAndCountGtZero())
                {
                    list = list.Where(m => dp.WJ_BuildingAttr.Where(x => x.BuildingId == m.Id).Any(x => filter.BuildingType.Contains(x.DicId)));
                }
                total = list.Count();
                var modelList = Mapper.Map<List<WJ_BuildingModel>>(list.OrderBy(m => m.Sort).ThenByDescending(m => m.CreateTime).Skip(filter.Skip).Take(filter.PageSize).ToList());
                var modelListId = modelList.Select(m => m.Id);
                var dicList = (from a in dp.WJ_BuildingAttr.Where(m => modelListId.Contains(m.BuildingId))
                               join b in dp.System_DicItem on a.DicId equals b.Id
                               select new
                               {
                                   a.BuildingId,
                                   a.AttrType,
                                   b.ItemDesc
                               }).ToList();
                modelList.ForEach(m =>
                {
                    m.BuildTypeListText = dicList.Where(x => x.AttrType == "BuildingType" && x.BuildingId == m.Id).Select(x => x.ItemDesc).ToList();
                    m.BuildTagListText = dicList.Where(x => x.AttrType == "BuildingTag" && x.BuildingId == m.Id).Select(x => x.ItemDesc).ToList();
                    m.BuildPropertyTypeLsitText = dicList.Where(x => x.AttrType == "BuildPropertyType" && x.BuildingId == m.Id).Select(x => x.ItemDesc).ToList();
                });
                return modelList;
            }
        }
        #endregion

        #region 新闻管理
        public bool AddNews(WJ_NewsModel model, string rootPath)
        {
            using (DataProvider dp = new DataProvider())
            {

                if (model.Id.HasValue)
                {
                    WJ_News entity = dp.WJ_News.FirstOrDefault(m => m.Id == model.Id.Value);
                    entity.Title = model.Title;
                    entity.Remark = model.Remark;
                    entity.PubUser = model.PubUser;
                    entity.NewsType = model.NewsType;
                    entity.IsTop = model.IsTop;
                    entity.Sort = model.Sort;
                    entity.CoverImg = model.CoverImg;
                    if (entity.CoverImg.IsNotNullOrWhiteSpace())
                    {
                        string newPath = FileHelper.GetNewFile("/Upload/NewsCover/", entity.CoverImg);
                        FileHelper.CutFile(rootPath + entity.CoverImg, rootPath + newPath);
                        entity.CoverImg = newPath;
                    }
                    entity.NewsContent = model.NewsContent;
                    entity.UpdateTime = DateTime.Now;
                }
                else
                {
                    WJ_News entity = Mapper.Map<WJ_News>(model);
                    if (entity.CoverImg.IsNotNullOrWhiteSpace())
                    {
                        string newPath = FileHelper.GetNewFile("/Upload/NewsCover/", entity.CoverImg);
                        FileHelper.CutFile(rootPath + entity.CoverImg, rootPath + newPath);
                        entity.CoverImg = newPath;
                    }
                    entity.IsDel = false;
                    entity.CreateTime = DateTime.Now;
                    dp.WJ_News.Add(entity);
                }
                try
                {
                    dp.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<WJ_NewsModel> GetNewsList(WJ_NewsModelFilter filter, out int total)
        {
            using (DataProvider dp = new DataProvider())
            {
                var list = dp.WJ_News.Where(m => true);
                if (filter.Title.IsNotNullOrWhiteSpace())
                {
                    list = list.Where(m => m.Title.Contains(filter.Title));
                }
                if (filter.Remark.IsNotNullOrWhiteSpace())
                {
                    list = list.Where(m => m.Remark.Contains(filter.Remark));
                }
                if (filter.NewsType.IsNotNullAndCountGtZero())
                {
                    list = list.Where(m => filter.NewsType.Contains(m.NewsType.Value));
                }
                total = list.Count();
                var dic = dp.System_DicItem.Where(m => m.GroupCode == "NewsType").ToList();
                var listLoc = Mapper.Map<List<WJ_NewsModel>>(list.OrderBy(m => !m.IsTop).ThenByDescending(m => m.Sort).ThenByDescending(m => m.CreateTime).Skip(filter.Skip).Take(filter.PageSize).ToList());
                listLoc.ForEach(m => m.NewsTypeText = dic.FirstOrDefault(x => x.Id == m.NewsType).ItemDesc);
                return listLoc;
            }
        }

        public WJ_NewsModel GetNewsModel(int id)
        {
            using (DataProvider dp = new DataProvider())
            {
                return Mapper.Map<WJ_NewsModel>(dp.WJ_News.FirstOrDefault(m => m.Id == id));
            }
        }

        public bool DeleteNews(List<int> ids)
        {
            using (DataProvider dp = new DataProvider())
            {
                try
                {
                    dp.WJ_News.RemoveRange(dp.WJ_News.Where(m => ids.Contains(m.Id)));
                    dp.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion

        #region 招商渠道
        public bool AddInvestment(WJ_InvestmentModel model,string rootPath)
        {
            using (DataProvider dp = new DataProvider())
            {

                if (model.Id.HasValue)
                {
                    WJ_Investment entity = dp.WJ_Investment.FirstOrDefault(m => m.Id == model.Id.Value);
                    entity.Title = model.Title;
                    entity.Brief = model.Brief;
                    entity.MinMoney = model.MinMoney;
                    entity.MaxMoney = model.MaxMoney;
                    entity.InvContent = model.InvContent;
                    entity.Aera = model.Aera;
                    entity.ComName = model.ComName;
                    entity.ComAddress = model.ComAddress;
                    entity.IsTop = model.IsTop;
                    entity.Sort = model.Sort;
                    entity.CoverImg = model.CoverImg;
                    if (entity.CoverImg.IsNotNullOrWhiteSpace())
                    {
                        string newPath = FileHelper.GetNewFile("/Upload/NewsCover/", entity.CoverImg);
                        FileHelper.CutFile(rootPath + entity.CoverImg, rootPath + newPath);
                        entity.CoverImg = newPath;
                    }
                    entity.UpdateTime = DateTime.Now;
                }
                else
                {
                    WJ_Investment entity = Mapper.Map<WJ_Investment>(model);
                    if (entity.CoverImg.IsNotNullOrWhiteSpace())
                    {
                        string newPath = FileHelper.GetNewFile("/Upload/NewsCover/", entity.CoverImg);
                        FileHelper.CutFile(rootPath + entity.CoverImg, rootPath + newPath);
                        entity.CoverImg = newPath;
                    }
                    entity.CreateTime = DateTime.Now;
                    entity.PublishTime = DateTime.Now;
                    dp.WJ_Investment.Add(entity);
                }
                try
                {
                    dp.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }


        public List<WJ_InvestmentModel> GetInvestmentList(WJ_InvestmentFilter filter, out int total)
        {
            using (DataProvider dp = new DataProvider())
            {
                var list = dp.WJ_Investment.Where(m => true);
                if (filter.Title.IsNotNullOrWhiteSpace())
                {
                    list = list.Where(m => m.Title.Contains(filter.Title));
                }
                if (filter.Brief.IsNotNullOrWhiteSpace())
                {
                    list = list.Where(m => m.Brief.Contains(filter.Brief));
                }
                total = list.Count();
                var listLoc = Mapper.Map<List<WJ_InvestmentModel>>(list.OrderBy(m => !m.IsTop).ThenByDescending(m => m.Sort).ThenByDescending(m => m.CreateTime).Skip(filter.Skip).Take(filter.PageSize).ToList());
                return listLoc;
            }
        }

        public WJ_InvestmentModel GetInvestmentModel(int id)
        {
            using (DataProvider dp = new DataProvider())
            {
                return Mapper.Map<WJ_InvestmentModel>(dp.WJ_Investment.FirstOrDefault(m => m.Id == id));
            }
        }

        public bool DeleteInvestment(List<int> ids)
        {
            using (DataProvider dp = new DataProvider())
            {
                try
                {
                    dp.WJ_Investment.RemoveRange(dp.WJ_Investment.Where(m => ids.Contains(m.Id)));
                    dp.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
