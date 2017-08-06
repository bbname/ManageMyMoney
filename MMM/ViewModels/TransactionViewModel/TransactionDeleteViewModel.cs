using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MMM.ViewModels.TransactionViewModel
{
    public class TransactionDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }
        [Display(Name = "Saldo")]
        public decimal AccountBalance { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.DateTime)]
        public DateTime SetDate { get; set; }
        [Display(Name = "Waluta")]
        [HiddenInput(DisplayValue = false)]
        public string Currency { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int BankAccountId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}