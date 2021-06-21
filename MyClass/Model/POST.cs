namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POST")]
    public partial class POST
    {
        [Key]
        public int IdPost { get; set; }

        public int IdUser { get; set; }

        public int IdTopic { get; set; }

        [StringLength(500)]
        public string Slug { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Img { get; set; }

        [StringLength(255)]
        public string Sumary { get; set; }

        [StringLength(100)]
        public string PostType { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Detail { get; set; }

        public DateTime? DateCreate { get; set; }

        public virtual TOPIC TOPIC { get; set; }

        public virtual USER USER { get; set; }
    }
}
