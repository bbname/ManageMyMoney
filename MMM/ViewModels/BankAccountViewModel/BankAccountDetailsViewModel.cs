using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MMM.Infrastructure;
using MMM.Model;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ViewModels.BankAccountViewModel
{
    public class BankAccountDetailsViewModel
    {
        public BankAccountDetailsViewModel()
        {
            this._listFiltersForWeb = Infrastructure.FiltersForWeb.listFiltersForWeb;
            this._listItemsForPage = Infrastructure.ItemsForPage.listItemsForPage;
        }

        private readonly List<FilterForWeb> _listFiltersForWeb;
        private readonly List<ItemForPage> _listItemsForPage;

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
        [Display(Name = "Filtr")]
        public int SelectedFilterId { get; set; }
        public IEnumerable<SelectListItem> FiltersForWeb
        {
            get { return new SelectList(_listFiltersForWeb, "Id", "SelectValue"); }
        }
        public int SelectedItemsForPageId { get; set; }
        public IEnumerable<SelectListItem> ItemsForPage
        {
            get { return new SelectList(_listItemsForPage, "Id", "SelectValue"); }
        }
    }
}