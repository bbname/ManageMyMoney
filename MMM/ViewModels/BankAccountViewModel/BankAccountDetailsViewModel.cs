using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MMM.Model;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Stan")]
        public decimal Balance { get; set; }
        [Display(Name = "Waluta")]
        public string Currency { get; set; }
        public virtual IEnumerable<TransactionListViewModel> Transactions { get; set; }
        public virtual User User { get; set; }
    }
}