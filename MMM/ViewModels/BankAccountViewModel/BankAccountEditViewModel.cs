using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Web.Mvc;
using MMM.Infrastructure;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountEditViewModel
    {
        public BankAccountEditViewModel()
        {
            _listCurrencies = Infrastructure.Currencies.listCurrencies;
        }

        private readonly List<Currency> _listCurrencies;
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nazwa konta")]
        [MaxLength(18)]
        public string Name { get; set; }
        [Display(Name = "Saldo początkowe")]
        [UIHint("EditorForDecimals")]
        public decimal Balance { get; set; }
        [Required]
        [Display(Name = "Waluta")]
        public int SelectedCurrencyId { get; set; }
        public IEnumerable<SelectListItem> Currencies
        {
            get { return new SelectList(_listCurrencies, "Id", "IconCode"); }
        }
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime Created { get; set; }
    }
}