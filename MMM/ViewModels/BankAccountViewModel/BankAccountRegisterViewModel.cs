using System.ComponentModel.DataAnnotations;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountRegisterViewModel
    {
        [Required]
        [Display(Name = "Nazwa konta")]
        public string Name { get; set; }
        [Display(Name = "Saldo początkowe")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Balance { get; set; }
        [Required]
        [Display(Name = "Waluta")]
        public int Currency { get; set; }

    }
}