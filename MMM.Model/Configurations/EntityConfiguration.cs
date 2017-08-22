using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MMM.Model.Configurations
{
    public class EntityConfiguration : EntityTypeConfiguration<Entity>
    {
        public EntityConfiguration()
        {
            Property(e => e.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(128);
        }
    }
}