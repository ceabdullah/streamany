using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace streamany.Models
{
    public partial class streamanyContext : DbContext
    {
        public streamanyContext()
        {
        }

        public streamanyContext(DbContextOptions<streamanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> File { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=streamany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.FileAsByte).HasColumnName("fileAsByte");

                entity.Property(e => e.FileContentType)
                    .HasColumnName("fileContentType")
                    .HasMaxLength(20);

                entity.Property(e => e.FileExtension)
                    .HasColumnName("fileExtension")
                    .HasMaxLength(5);

                entity.Property(e => e.FileName)
                    .HasColumnName("fileName")
                    .HasMaxLength(50);
            });
        }
    }
}
