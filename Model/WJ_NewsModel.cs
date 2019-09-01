using Model.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_NewsModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Remark { get; set; }
        public string PubUser { get; set; }
        public int ViewTimes { get; set; }
        public Guid? NewsType { get; set; }
        public bool? IsTop { get; set; }
        public int? Sort { get; set; }
        public string CoverImg { get; set; }
        public string NewsContent { get; set; }
        public bool IsDel { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUser { get; set; }

        public string NewsTypeText { get; set; }
    }

    public class WJ_NewsModelFilter : PageModel
    { 
        public string Title { get; set; }

        public string Remark { get; set; }

        public List<Guid> NewsType { get; set; }
    }
}
