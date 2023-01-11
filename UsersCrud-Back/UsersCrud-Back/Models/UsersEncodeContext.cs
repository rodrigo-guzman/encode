using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UsersCrud_Back.Features.UsersModule.Users.Data.DTOs;

namespace UsersCrud_Back.Models;

public partial class UsersEncodeContext : DbContext
{
    public virtual DbSet<Actividade> Actividades { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source=DESKTOP-AK95NHM;Initial Catalog=UsersEncode;Integrated Security=True;Encrypt=False");

        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var connectionString = configuration.GetConnectionString("UsersEncodeLocal");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividade>(entity =>
        {
            entity.HasKey(e => e.IdActividad);

            entity.Property(e => e.IdActividad)
                .ValueGeneratedNever()
                .HasColumnName("Id_actividad");
            entity.Property(e => e.Actividad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("Create_date");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Actividades)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Actividades_Usuarios");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripción)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdPaisResidencia)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPaisResidenciaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPaisResidencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Paises");
        });

        OnModelCreatingPartial(modelBuilder);

        User.ConfigureMapping(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
