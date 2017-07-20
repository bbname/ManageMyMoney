using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using MMM.Model;
using MMM.Infrastructure;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountCreateViewModel
    {
        public BankAccountCreateViewModel()
        {
            _listCurrencies = Infrastructure.Currencies.listCurrencies;
            //_listCurrencies = new List<Currency>()
            //{
            //    new Currency {Id = 1, Name = "PLN", IconCode = "zł"},
            //    new Currency {Id = 2, Name = "USD", IconCode = "$"},
            //    new Currency {Id = 3, Name = "EUR", IconCode = "€"},
            //    new Currency {Id = 4, Name = "GBP", IconCode = "£"},
            //    new Currency {Id = 5, Name = "JPY", IconCode = "¥"}
            //};
            //Balance = 0;
        }

        private readonly List<Currency> _listCurrencies;
        [Required]
        [Display(Name = "Nazwa konta")]
        [MaxLength(18)]
        public string Name { get; set; }
        [Display(Name = "Saldo początkowe")]
        [UIHint("EditorForDecimals")]
        //[RegularExpression(@"^[0-9]+(\,[0-9]{1,2})$", ErrorMessage = "Liczymy do maksymalnie 2 cyfr po przecinku.")]
        public decimal Balance { get; set; }
        [Required]
        [Display(Name = "Waluta")]
        public int SelectedCurrencyId { get; set; }
        public IEnumerable<SelectListItem> Currencies
        {
            get { return new SelectList(_listCurrencies, "Id", "IconCode"); }
        }

    }
}