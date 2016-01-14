using System.Data.Entity.ModelConfiguration;

namespace Ingresso.Data.Classes
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.DocumentNumber)
                .IsRequired();

            Property(u => u.BirthDate)
                .IsRequired();

            Property(u => u.Gender)
                .IsRequired();

            Property(u => u.AddressDescription)
                .IsRequired()
                .HasMaxLength(200);

            Property(u => u.AddressNumber)
                .IsRequired()
                .HasMaxLength(20);

            Property(u => u.AddressComplement)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.AddressZipCode)
                .IsRequired()
                .HasMaxLength(10);

            Property(u => u.AddressNeighborhood)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.AddressCity)
                .IsRequired()
                .HasMaxLength(200);

            Property(u => u.AddressState)
                .IsRequired()
                .HasMaxLength(100);

            ToTable("AspNetUsers");
        }
    }
}
