using System.Data.Entity.ModelConfiguration;

namespace MMM.Model.Configurations
{
    public class BankAccountConfiguration : EntityTypeConfiguration<BankAccount>
    {
        public BankAccountConfiguration()
        {
            Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(b => b.Balance)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(b => b.Currency)
                .IsRequired();

            Property(b => b.Created)
                .IsRequired();
        }
    }
}