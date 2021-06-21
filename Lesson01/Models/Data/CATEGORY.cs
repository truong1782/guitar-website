namespace Lesson01.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORY()
        {
            PRODUCTs = new HashSet<PRODUCT>();
        }

        [Key]
        public int IdCategory { get; set; }

        [Required]
        [StringLength(500)]
        public string NameCategory { get; set; }

        [Required]
        [StringLength(500)]
        public string Slug { get; set; }

        [Required]
        [StringLength(155)]
        public string MetaKey { get; set; }

        [Required]
        [StringLength(155)]
        public string MetaDesc { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Created_At { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }
    }
}
