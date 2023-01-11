using Microsoft.EntityFrameworkCore;

namespace UsersCrud_Back.Features.UsersModule.Users.Data.DTOs
{
    public class Country
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<User> Usuarios { get; set; }

        public static void ConfigureMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Paises");
                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired();
                entity.Property(e => e.Name)
                    .HasColumnName("Description")
                    .IsRequired();
            });
        }
    }
}
