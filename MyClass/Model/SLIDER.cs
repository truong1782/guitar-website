namespace MyClass.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDER")]
    public partial class SLIDER
    {
        [Key]
        public int IdSlider { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(255)]
        public string Img { get; set; }

        public DateTime? DateCreate { get; set; }

        public int? IdUser { get; set; }

        public virtual USER USER { get; set; }
    }
}
