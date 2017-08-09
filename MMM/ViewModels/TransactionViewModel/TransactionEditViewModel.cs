using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MMM.ViewModels.TransactionViewModel
{
    public class TransactionEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        [MaxLength(18)]
        public string Name { get; set; }
        [Display(Name = "Kwota")]
        [UIHint("EditorForDecimals")]
        public decimal Balance { get; set; }
        //public decimal Amount { get; set; }
        [Display(Name = "Saldo")]
        //[HiddenInput(DisplayValue = false)]
        public decimal AccountBalance { get; set; }
        [Display(Name = "Data")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime SetDate { get; set; }
        [Display(Name = "Waluta")]
        public string Currency { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int BankAccountId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}