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
    
    public partial class Cloth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cloth()
        {
            this.Catalog = new HashSet<Catalog>();
        }
    
        public long ID_Cloth { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long ID_Provider { get; set; }
        public int Remains { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Catalog> Catalog { get; set; }
        public virtual Provider Provider { get; set; }
    }
}