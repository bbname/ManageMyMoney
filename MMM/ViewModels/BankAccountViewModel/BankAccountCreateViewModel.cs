using System.ComponentModel.DataAnnotations;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountCreateViewModel
    {
        [Required]
        [Display(Name = "Nazwa konta")]
        public string Name { get; set; }
        [Display(Name = "Saldo początkowe")]
        public decimal Balance { get; set; }
        [Required]
        [Display(Name = "Waluta")]
        public int Currency { get; set; }

    }
}