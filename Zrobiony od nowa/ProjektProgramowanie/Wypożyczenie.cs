namespace ProjektProgramowanie
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Wypożyczenie
    {
        [Key]
        public int IDwypożyczenia { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataWypożyczenia { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataZwrotu { get; set; }

        public int IDklienta { get; set; }

        public int IDplyty { get; set; }

        public virtual Klient Klient { get; set; }

        public virtual PłytaZFilmem PłytaZFilmem { get; set; }
    }
}
