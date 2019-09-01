using Model.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_InvestmentModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string CoverImg { get; set; }
        public string MinMoney { get; set; }
        public string MaxMoney { get; set; }
        public int? Sort { get; set; }
        public string InvContent { get; set; }
        public string Aera { get; set; }
        public string ComName { get; set; }
        public string ComAddress { get; set; }
        public DateTime? PublishTime { get; set; }
        public bool? IsTop { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid CreateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUser { get; set; }
    }

    public class WJ_InvestmentFilter:PageModel
    {
        public string Title { get; set; }
        public string Brief { get; set; }
    }
}
