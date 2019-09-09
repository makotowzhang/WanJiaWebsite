using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WJ_ColumeModel
    {
        public Guid Id { get; set; }
        public string ColumeName { get; set; }
        public string ColumeUrl { get; set; }
        public Guid? ParentId { get; set; }
        public int? Sort { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDel { get; set; }
        public Guid? CreateUser { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }

        public List<WJ_ColumeModel> Children { get;set;}
    }
}
