using System.Data.Entity.ModelConfiguration;

namespace MMM.Model.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}