using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PDKS_Code_First.Entity
{
    public partial class PDKSCodeFirstContext : DbContext
    {
        public PDKSCodeFirstContext()
            : base("name=PDKSCodeFirstContext")
        {
        }

        public virtual DbSet<Departmanlar> Departmanlar { get; set; }
        public virtual DbSet<IzinTakip> IzinTakip { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<PersonelCocuk> PersonelCocuk { get; set; }
        public virtual DbSet<PersonelEgitim> PersonelEgitim { get; set; }
        public virtual DbSet<PersonelKiyafet> PersonelKiyafet { get; set; }
        public virtual DbSet<PersonelOzlukBilgileri> PersonelOzlukBilgileri { get; set; }
        public virtual DbSet<PersonelPuantaj> PersonelPuantaj { get; set; }
        public virtual DbSet<PersonelSaglikDurumlari> PersonelSaglikDurumlari { get; set; }
        public virtual DbSet<SistemeKayitOlabilecekler> SistemeKayitOlabilecekler { get; set; }
        public virtual DbSet<PersonelBelgeler> PersonelBelgeler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departmanlar>()
                .HasMany(e => e.PersonelKiyafet)
                .WithRequired(e => e.Departmanlar)
                .HasForeignKey(e => e.DepartmanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departmanlar>()
                .HasMany(e => e.PersonelOzlukBilgileri)
                .WithRequired(e => e.Departmanlar)
                .HasForeignKey(e => e.DepartmanId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.TcNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Kullanicilar>()
                .Property(e => e.SicilNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .Property(e => e.TcKimlik)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .Property(e => e.KurumSicilNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .Property(e => e.EsiTc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .HasMany(e => e.IzinTakip)
                .WithRequired(e => e.PersonelOzlukBilgileri)
                .HasForeignKey(e => e.PersonelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .HasMany(e => e.PersonelCocuk)
                .WithRequired(e => e.PersonelOzlukBilgileri)
                .HasForeignKey(e => e.PersonelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .HasMany(e => e.PersonelEgitim)
                .WithRequired(e => e.PersonelOzlukBilgileri)
                .HasForeignKey(e => e.PersonelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .HasMany(e => e.PersonelKiyafet)
                .WithRequired(e => e.PersonelOzlukBilgileri)
                .HasForeignKey(e => e.PersonelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .HasMany(e => e.PersonelPuantaj)
                .WithRequired(e => e.PersonelOzlukBilgileri)
                .HasForeignKey(e => e.PersonelId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonelOzlukBilgileri>()
                .HasMany(e => e.PersonelSaglikDurumlari)
                .WithRequired(e => e.PersonelOzlukBilgileri)
                .HasForeignKey(e => e.PersonelId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PersonelOzlukBilgileri>()
               .HasMany(e => e.PersonelBelgeler)
               .WithRequired(e => e.PersonelOzlukBilgileri)
               .HasForeignKey(e => e.PersonelId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<SistemeKayitOlabilecekler>()
                .Property(e => e.TcNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SistemeKayitOlabilecekler>()
                .Property(e => e.SicilNo)
                .IsFixedLength()
                .IsUnicode(false);
          
        }
    }
}
