using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Library.Model
{
    public partial class LibraryModel : DbContext
    {
        public LibraryModel()
            : base("name=LibraryModel")
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Issuance_Books> Issuance_Books { get; set; }
        public virtual DbSet<LBC> LBC { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Readers> Readers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasMany(e => e.Issuance_Books)
                .WithRequired(e => e.Books)
                .HasForeignKey(e => e.Books_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LBC>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.LBC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Issuance_Books)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Publisher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Readers>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Readers)
                .HasForeignKey(e => e.Readers_id)
                .WillCascadeOnDelete(false);
        }
    }
}
