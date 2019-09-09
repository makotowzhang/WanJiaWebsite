using Model.SystemModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_AppointmentModel
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
        public DateTime? OrderTime { get; set; }
        public string OrderMessage { get; set; }
        public string BelongType { get; set; }
        public int? TenderId { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUser { get; set; }
        public string TenderName { get; set; }
    }

    public class WJ_AppointmentFilter : PageModel
    {
        public string PersonName { get; set; }
        public string ContactTel { get; set; }
        public string ContactEmail { get; set; }
    }
}
