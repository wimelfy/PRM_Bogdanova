//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR3_Bogdanova.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Catalog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalog()
        {
            this.Order = new HashSet<Order>();
        }
    
        public long ID_Catalog { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size_range { get; set; }
        public long ID_Accessories { get; set; }
        public long ID_Cloth { get; set; }
    
        public virtual Accessories Accessories { get; set; }
        public virtual Cloth Cloth { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
