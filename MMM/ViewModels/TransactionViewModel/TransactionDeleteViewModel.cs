using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MMM.ViewModels.TransactionViewModel
{
    public class TransactionDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }
        [Display(Name = "Saldo")]
        public decimal AccountBalance { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime SetDate { get; set; }
        [Display(Name = "Waluta")]
        public string Currency { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string BankAccountId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}