//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class WJ_EnterpriseInfo
    {
        public int Id { get; set; }
        public string InfoType { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string InfoTime { get; set; }
        public string InfoDesc { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<System.Guid> CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.Guid> UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}