//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RaceStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addres
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addres()
        {
            this.Offices = new HashSet<Offices>();
        }
    
        public int AddresID { get; set; }
        public int Pindex { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Nunhome { get; set; }
        public int Numkv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Offices> Offices { get; set; }


        public string FullAddres => "г." +City + " ул."+Street + " Дом "+Nunhome + " Кв." +Numkv + " Индекс: "+Pindex;
    }
}