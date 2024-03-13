using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pizzeria.Models
{
    public partial class DbConnection : DbContext
    {
        public DbConnection()
            : base("name=DbConnection")
        {
        }

        public virtual DbSet<DettaglioOrdine> DettaglioOrdine { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordini>()
                .HasMany(e => e.DettaglioOrdine)
                .WithRequired(e => e.Ordini)
                .HasForeignKey(e => e.IdOrdini)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.DettaglioOrdine)
                .WithRequired(e => e.Prodotti)
                .HasForeignKey(e => e.IdProdotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
