using Model.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_BuildingModel
    {
        public Guid Id { get; set; }
        public string ShortRemark { get; set; }
        public string ContactTel { get; set; }
        public string Address { get; set; }
        public string BuildName { get; set; }
        public int? Sort { get; set; }
        public int? StarsCount { get; set; }
        public string BuildIntro { get; set; }
        public DateTime? OpeningTime { get; set; }
        public string BuildPrice { get; set; }
        public Guid? BuildType { get; set; }
        public int? Households { get; set; }
        public string BelogEstate { get; set; }
        public int? Years { get; set; }
        public string SalesAddress { get; set; }
        public string AreaCovered { get; set; }
        public int? BuildingCount { get; set; }
        public string RenovationCondition { get; set; }
        public string GreeningRate { get; set; }
        public bool IsDel { get; set; }
        public Guid CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }

        public List<Guid> BuildTypeList { get; set; } = new List<Guid>();
        public List<Guid> BuildTagList { get; set; } = new List<Guid>();
        public List<Guid> BuildPropertyTypeLsit { get; set; } = new List<Guid>();

        public List<string> BuildTypeListText { get; set; } = new List<string>();
        public List<string> BuildTagListText { get; set; } = new List<string>();
        public List<string> BuildPropertyTypeLsitText { get; set; } = new List<string>();

        public List<string> BuildShowImage { get; set; } = new List<string>();
        public List<string> BuildAlbumList { get; set; } = new List<string>();
        public List<string> BuildHouseTypeList { get; set; } = new List<string>();
    }

    public class WJ_BuildingFilter : PageModel
    {
        public string BuildingName { get; set; }

        public List<Guid> BuildingType { get; set; }

        public List<Guid> BuildingTag { get; set; }
    }
}
