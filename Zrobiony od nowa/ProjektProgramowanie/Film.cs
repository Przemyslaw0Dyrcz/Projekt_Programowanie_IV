namespace ProjektProgramowanie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            PłytaZFilmem = new HashSet<PłytaZFilmem>();
        }

        [Key]
        public int IdFilmu { get; set; }

        [Required]
        [StringLength(200)]
        public string Tytuł { get; set; }

        [Required]
        [StringLength(200)]
        public string Reżyser { get; set; }

        public int RokProdukcji { get; set; }

        public decimal CenaZaCykl { get; set; }

        public int IlośćSztuk { get; set; }

        public string Opis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PłytaZFilmem> PłytaZFilmem { get; set; }
    }
}
