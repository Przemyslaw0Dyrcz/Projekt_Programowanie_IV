namespace ProjektProgramowanie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klient")]
    public partial class Klient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klient()
        {
            Wypożyczenie = new HashSet<Wypożyczenie>();
        }

        [Key]
        public int IDklienta { get; set; }

        [Required]
        [StringLength(50)]
        public string Imie { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Required]
        [StringLength(20)]
        public string Pin { get; set; }

        [Required]
        [StringLength(20)]
        public string NrTelefonu { get; set; }

        [Required]
        [StringLength(200)]
        public string Adres { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Required]
        [StringLength(20)]
        public string Pesel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypożyczenie> Wypożyczenie { get; set; }
    }
}
