//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvsStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERILER()
        {
            this.TBLSATISLARs = new HashSet<TBLSATISLAR>();
        }
    
        public int MUSTERIID { get; set; }

        [Required(ErrorMessage = "Please enter a valid name..")]
        [StringLength(50, ErrorMessage ="Please enter a shorter name.")]
        public string MUSTERIAD { get; set; }

        [Required(ErrorMessage = "Please enter a valid lastname..")]
        [StringLength(50, ErrorMessage = "Please enter a shorter lastname.")]
        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSATISLAR> TBLSATISLARs { get; set; }
    }
}
