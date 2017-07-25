using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MMM.ViewModels.TransactionViewModel
{
    public class TransactionListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }
        [Display(Name = "Saldo")]
        public decimal AccountBalance { get; set; }
        [Display(Name= "Data")]
        //[DataType(DataType.DateTime), DisplayFormat(DataFormatString = "dd.mm.yyyy hh:mm")]
        public DateTime Created { get; set; }
    }
}