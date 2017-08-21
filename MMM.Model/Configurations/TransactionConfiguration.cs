using System.Data.Entity.ModelConfiguration;

namespace MMM.Model.Configurations
{
    public class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.Amount)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(t => t.AccountBalance)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(t => t.SetDate)
                .IsRequired();

            Property(t => t.Description)
                .HasMaxLength(1500)
                .IsOptional();

        }
    }
}