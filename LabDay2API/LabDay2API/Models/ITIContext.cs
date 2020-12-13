namespace LabDay2API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ITIContext : DbContext
    {
        public ITIContext()
            : base("name=ITIContext")
        {
        }

        public virtual DbSet<TbCatalog> TbCatalogs { get; set; }
        public virtual DbSet<TbNew> TbNews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCatalog>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<TbCatalog>()
                .HasMany(e => e.TbNews)
                .WithOptional(e => e.TbCatalog)
                .HasForeignKey(e => e.Catalog_id);

            modelBuilder.Entity<TbNew>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<TbNew>()
                .Property(e => e.pref)
                .IsUnicode(false);

            modelBuilder.Entity<TbNew>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<TbNew>()
                .Property(e => e.photo)
                .IsUnicode(false);
        }
    }
}
