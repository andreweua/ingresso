using System.Data.Entity.ModelConfiguration;

namespace Ingresso.Data.Classes
{
    public class ItemConfig : EntityTypeConfiguration<Item>
    {
        public ItemConfig()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.Price)
                .IsRequired();

            Property(u => u.Image)
                .IsRequired();

            ToTable("Items");
        }
    }
}
