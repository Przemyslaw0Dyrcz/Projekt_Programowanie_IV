namespace ProjektProgramowanie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PłytaZFilmem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PłytaZFilmem()
        {
            Wypożyczenie = new HashSet<Wypożyczenie>();
        }

        [Key]
        public int IDplyty { get; set; }

        public int IdFilmu { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual Film Film { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypożyczenie> Wypożyczenie { get; set; }
    }
}
