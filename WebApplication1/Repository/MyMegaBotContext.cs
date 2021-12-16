using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Repository.Entity;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication1.Repository
{
    public partial class MyMegaBotContext : DbContext 
    {

        public MyMegaBotContext(DbContextOptions<MyMegaBotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommandEntity> CommandEntities { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#pragma warning disable CS1030 // #warning directive
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=ANDROMEDA_NOTEB\\ZN_SQL_SERVER;Database=MyMegaBot;Trusted_Connection=True;");
        //#pragma warning restore CS1030 // #warning directive
        //            }
        //        }

        //        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //        {
        //            modelBuilder.Entity<CommandEntity>(entity =>
        //            {
        //                entity.HasKey(e => e.CommandId);

        //                entity.Property(e => e.Author)
        //                    .IsRequired()
        //                    .HasMaxLength(15);

        //                entity.Property(e => e.CommandAnswer).IsRequired();

        //                entity.Property(e => e.CommandTrigger).IsRequired();

        //                entity.Property(e => e.CreateDate).HasColumnType("datetime");

        //                entity.Property(e => e.ScriptName)
        //                    .IsRequired()
        //                    .HasMaxLength(50);

        //                entity.Property(e => e.SourceNames).IsRequired();
        //            });

        //            OnModelCreatingPartial(modelBuilder);
        //        }

        //        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
