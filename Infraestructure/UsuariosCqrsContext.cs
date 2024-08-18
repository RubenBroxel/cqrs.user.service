using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Users.Service.Infraestructure;

public partial class UsuariosCqrsContext : DbContext
{
    public UsuariosCqrsContext()
    {
    }

    public UsuariosCqrsContext(DbContextOptions<UsuariosCqrsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__645723A668DA8039");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F3A55C7F7E").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
