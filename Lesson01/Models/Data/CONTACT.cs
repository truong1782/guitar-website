namespace Lesson01.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTACT")]
    public partial class CONTACT
    {
        [Key]
        public int IdContact { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Detail { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        public DateTime? DateContact { get; set; }

        public int? Status { get; set; }

        public int? IdUser { get; set; }

        public virtual USER USER { get; set; }
    }
}
