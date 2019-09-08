using Model.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_JobModel
    {
        public int? Id { get; set; }
        public string PositionName { get; set; }
        public string Ability { get; set; }
        public string WorkPlace { get; set; }
        public string JobRequirements { get; set; }
        public bool? IsImportant { get; set; }
        public int? Sort { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
    }

    public class WJ_JobFilter : PageModel
    {
        public string PositionName { get; set; }
        public string Ability { get; set; }
        public string WorkPlace { get; set; }
    }
}
