using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lesson01.Models.Data
{
    public partial class DBBanDanContext : DbContext
    {
        public DBBanDanContext()
            : base("name=DBBanDanContext")
        {
        }

        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CONTACT> CONTACTs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDER_DETAIL> ORDER_DETAIL { get; set; }
        public virtual DbSet<POST> POSTs { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SLIDER> SLIDERs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TOPIC> TOPICs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.PRODUCTs)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<CONTACT>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.ORDER_DETAIL)
                .WithRequired(e => e.ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT>()
                .HasMany(e => e.ORDER_DETAIL)
                .WithRequired(e => e.PRODUCT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.USERs)
                .WithRequired(e => e.ROLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOPIC>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<TOPIC>()
                .HasMany(e => e.POSTs)
                .WithRequired(e => e.TOPIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.ORDERs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.POSTs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.SLIDERs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.TOPICs)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
