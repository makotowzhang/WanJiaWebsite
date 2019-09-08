using Model.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_TenderModel
    {
        public int? Id { get; set; }
        public string ProName { get; set; }
        public string ProAddress { get; set; }
        public DateTime? ProTime { get; set; }
        public int? Sort { get; set; }
        public string ProInfo { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
    }

    public class WJ_TenderFilter : PageModel
    {
        public string ProName { get; set; }
        public string ProAddress { get; set; }
    }
}
