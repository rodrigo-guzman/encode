namespace UsersCrud_Back.Features.UsersModule.Users.Data.DTOs
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public int? Phone { get; set; }

        public Country Country { get; set; }

        public string IdCountry { get; set; }

        public bool ReceiveInformation { get; set; }

        public static void ConfigureMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired();
                entity.Property(e => e.Name)
                    .HasColumnName("Nombre")
                    .IsRequired();
                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .IsRequired();
                entity.Property(e => e.BirthDate)
                    .HasColumnName("FechaNacimiento")
                    .IsRequired();
                entity.Property(e => e.Phone)
                    .HasColumnName("Telefono");
                entity.Property(e => e.IdCountry)
                     .HasColumnName("IdPaisResidencia")
                     .IsRequired();
                entity.Property(e => e.ReceiveInformation)
                    .HasColumnName("RecibirINformacion")
                    .IsRequired();
                entity.HasOne(e => e.Country)
                    .WithMany(e => e.Usuarios)
                    .HasForeignKey(e => e.IdCountry);
            });
        }
    }
}
