namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOPIC")]
    public partial class TOPIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOPIC()
        {
            POSTs = new HashSet<POST>();
        }

        [Key]
        public int IdTopic { get; set; }

        [Required]
        [StringLength(255)]
        public string NameTopic { get; set; }

        [Required]
        [StringLength(255)]
        public string Slug { get; set; }

        public int IdUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POST> POSTs { get; set; }

        public virtual USER USER { get; set; }
    }
}
