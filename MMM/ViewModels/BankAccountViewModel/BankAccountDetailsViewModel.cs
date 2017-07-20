using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MMM.Model;

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
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}