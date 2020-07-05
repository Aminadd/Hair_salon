
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Frizerski_salon.Data
{
    public class FrizerskiContext : DbContext
    {
        public DbSet<Klijent> Klijentt { get; set; }
        public DbSet<Termin> Terminn { get; set; }
        public DbSet<Usluga> Uslugaa { get; set; }
        public DbSet<Zaposleni> Zaposlenii { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klijent>().HasKey(k => new { k.IDKlijent });
            modelBuilder.Entity<Termin>().HasKey(t => new { t.IDTermin });
            modelBuilder.Entity<Usluga>().HasKey(u => new { u.IDUsluga });
            modelBuilder.Entity<Zaposleni>().HasKey(z => new { z.IDZaposleni });

            modelBuilder.Entity<Usluga>().Property(u => u.imeiprezime).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Usluga>().Property(u => u.cena).IsRequired();
            modelBuilder.Entity<Usluga>().Property(u => u.vrsta_usluge).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Usluga>().Property(u => u.imeFrizera).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Klijent>().Property(k => k.ime).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Klijent>().Property(k => k.prezime).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Klijent>().Property(k => k.JMBG).IsRequired().HasMaxLength(13);
            modelBuilder.Entity<Klijent>().Property(k => k.brTel).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Klijent>().Property(k => k.tipKose).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Klijent>().Property(k => k.duzinaKose).IsRequired();
            modelBuilder.Entity<Klijent>().Property(k => k.preparatiZaPranje).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Klijent>().Property(k => k.oblikovanjeKose).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Termin>().Property(t => t.imeiprezime).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Termin>().Property(t => t.vreme).IsRequired();

            modelBuilder.Entity<Zaposleni>().Property(z => z.ime).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Zaposleni>().Property(z => z.prezime).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Zaposleni>().Property(z => z.brTelefona).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Zaposleni>().Property(z => z.JMBG).IsRequired().HasMaxLength(13);
            modelBuilder.Entity<Zaposleni>().Property(z => z.korisnickoIme).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Zaposleni>().Property(z => z.sifra).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Zaposleni>().Property(z => z.tipZaposlenog).IsRequired().HasMaxLength(1);


            modelBuilder.Entity<Termin>().HasRequired(t => t.Klijent).WithMany(k => k.Termins).HasForeignKey(t => t.KlijentID);
            modelBuilder.Entity<Termin>().HasRequired(t => t.Usluga).WithMany(u => u.Termins).HasForeignKey(t => t.UslugaID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
