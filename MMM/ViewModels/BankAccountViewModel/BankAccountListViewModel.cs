using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MMM.BussinesLogic;

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
        public string Currency { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}