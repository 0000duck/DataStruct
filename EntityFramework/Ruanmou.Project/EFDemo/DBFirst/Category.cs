//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFDemo.DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.JD_Commodity_017 = new HashSet<JD_Commodity_017>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public Nullable<int> CategoryLevel { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Nullable<int> State { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JD_Commodity_017> JD_Commodity_017 { get; set; }
    }

    public partial class Category
    {
        public void SHow() { }
    }
}
