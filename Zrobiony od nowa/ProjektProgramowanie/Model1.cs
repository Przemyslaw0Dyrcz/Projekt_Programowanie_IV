using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProjektProgramowanie
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ProjektProgramowanie")
        {
        }

        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<PłytaZFilmem> PłytaZFilmem { get; set; }
        public virtual DbSet<Wypożyczenie> Wypożyczenie { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(e => e.CenaZaCykl)
                .HasPrecision(10, 2);
        }
    }
}
