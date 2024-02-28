using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WsApiexamen.Models;

public partial class BdiExamenContext : DbContext
{
    public BdiExamenContext()
    {
    }

    public BdiExamenContext(DbContextOptions<BdiExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblExaman> TblExamen { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//       => optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=BdiExamen;Persist Security Info=False;User ID=sa;Password=x3w576m!;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=False;Connection Timeout=60;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblExaman>(entity =>
        {
            entity.HasKey(e => e.IdExamen).HasName("PK__tblExame__E569399BD79E87A3");

            entity.ToTable("tblExamen");

            entity.Property(e => e.IdExamen).HasColumnName("idExamen");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
