using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Stan")]
        public decimal Balance { get; set; }
        [Display(Name = "Waluta")]
        public int Currency { get; set; }
    }
}