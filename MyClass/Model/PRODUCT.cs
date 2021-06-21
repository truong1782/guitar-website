namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }

        [Key]
        public int IdProduct { get; set; }

        public int IdCategory { get; set; }

        [StringLength(255)]
        public string Img { get; set; }

        [Required]
        [StringLength(255)]
        public string NameProduct { get; set; }

        [StringLength(255)]
        public string Slug { get; set; }

        [StringLength(500)]
        public string Detail { get; set; }

        public double PriceBuy { get; set; }

        [Required]
        [StringLength(255)]
        public string MetaKey { get; set; }

        [Required]
        [StringLength(255)]
        public string MetaDesc { get; set; }

        public int? Created_By { get; set; }

        public DateTime? Created_At { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}
