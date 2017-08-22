using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountDeleteViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Stan")]
        public decimal Balance { get; set; }
        [Display(Name = "Waluta")]
        public string Currency { get; set; }
        [Display(Name = "Utworzono")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

    }
}