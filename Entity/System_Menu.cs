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
    
    public partial class System_Menu
    {
        public System.Guid Id { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string MenuType { get; set; }
        public string ActionCode { get; set; }
        public string ActionDesc { get; set; }
        public string IconClass { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
        public Nullable<bool> IsDel { get; set; }
        public Nullable<System.Guid> CreateUser { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.Guid> UpdateUser { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
