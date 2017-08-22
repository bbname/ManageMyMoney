using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Microsoft.AspNet.Identity;
using MMM.BussinesLogic;
using MMM.Infrastructure;
using MMM.ModelBinders.Transaction;
using MMM.Service.Interfaces;
using MMM.ViewModels.TransactionViewModel;
using PagedList;

namespace MMM.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "Admin, User")]
    public class TransactionController : Controller
    {
        private readonly IReadBankAccount _readBankAccount;
        private readonly IReadTransaction _readTransaction;
        private readonly IWriteTransaction _writeTransaction;
        public TransactionController(IReadBankAccount readBankAccount, IReadTransaction readTransaction, IWriteTransaction writeTransaction)
        {
            this._readBankAccount = readBankAccount;
            this._readTransaction = readTransaction;
            this._writeTransaction = writeTransaction;
        }

        [HttpGet]
        public ActionResult LoadTransactionBySearchName(string name, string bankAccountId)
        {
            if (Request.IsAjaxRequest() && !String.IsNullOrEmpty(bankAccountId) && !String.IsNullOrEmpty(name))
            {
                var currencyLogic = new CurrencyLogic();
                var binder = new ToTransactionListViewModel();

                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId);
                var transaction = _readTransaction.GetTransactionByName(name, bankAccountId);

                var viewModelTransaction =
                    binder.GetTransactions(transaction, currencyLogic.GetCurrencyIconById(bankAccount.Currency)).ToPagedList(1,1);

                return PartialView("TransactionList", viewModelTransaction);
            }

            return new JsonResult()
            {
                Data = "Wystąpił błąd podczas operacji wczytywania transakcji po nazwie.",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpGet]
        public ActionResult AutocompleteSearchTransaction(string searchText, string bankAccountId)
        {
            if (Request.IsAjaxRequest() && !String.IsNullOrEmpty(bankAccountId) && !String.IsNullOrEmpty(searchText))
            {
                var results = _readTransaction.GetTransactionNamesBySimilarName(bankAccountId, searchText);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            return Json("Coś poszło nie tak przy wyszukiwaniu.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTransactionsBySearchNameFilters(string bankAccountId, string name ,string fromDate, string toDate,
            int? selectedItemsForPage, int? selectedFilterId, int page = 1)
        {
            if (!String.IsNullOrEmpty(bankAccountId) && !String.IsNullOrEmpty(name))
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId);
                var binder = new ToTransactionListViewModel();
                var currencyLogic = new CurrencyLogic();
                var filterLogic = new FiltersLogic();
                var filterName = "";
                var filterValue = "";
                var fromDateConverted = filterLogic.GetDateTimeByDateStringWithDots(fromDate);
                var toDateConverted = filterLogic.GetEndDateTimeDateStringWithDots(toDate);
                filterLogic.GetFilterNameFilterValueById(selectedFilterId, out filterName, out filterValue);
                var itemsForPage = filterLogic.GetItemsForPageById(selectedItemsForPage);


                var transactions = _readTransaction.GetSearchTransactionsByFilters(bankAccountId, fromDateConverted, toDateConverted, filterName, filterValue, name);
                var viewModelTransactions = binder.GetTransactions(transactions,
                    currencyLogic.GetCurrencyIconById(bankAccount.Currency)).ToPagedList(page, itemsForPage);

                return PartialView("TransactionList", viewModelTransactions);
            }
            else
            {
                return new JsonResult
                {
                    Data = "Wystąpił błąd podczas operacji.",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpGet]
        //public ActionResult GetTransactionsByBankAccountIdFilters(int? bankAccountId, DateTime? fromDate, DateTime? toDate, int? selectedItemsForPage, int? selectedFilterId)
        public ActionResult GetTransactionsByBankAccountIdFilters(string bankAccountId, string fromDate, string toDate, int? selectedItemsForPage, int? selectedFilterId, int page = 1)
        {
            if (String.IsNullOrEmpty(bankAccountId))
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId);
                var binder = new ToTransactionListViewModel();
                var currencyLogic = new CurrencyLogic();
                var filterLogic = new FiltersLogic();
                var filterName = "";
                var filterValue = "";
                var fromDateConverted = filterLogic.GetDateTimeByDateStringWithDots(fromDate);
                var toDateConverted = filterLogic.GetEndDateTimeDateStringWithDots(toDate);
                filterLogic.GetFilterNameFilterValueById(selectedFilterId, out filterName, out filterValue);
                var itemsForPage = filterLogic.GetItemsForPageById(selectedItemsForPage);

                var transactions = _readTransaction.GetTransactionsByFilters(bankAccountId, fromDateConverted, toDateConverted, filterName, filterValue);
                var viewModelTransactions = binder.GetTransactions(transactions,
                    currencyLogic.GetCurrencyIconById(bankAccount.Currency)).ToPagedList(page, itemsForPage);

                return PartialView("TransactionList", viewModelTransactions);
            }
            else
            {
                return new JsonResult
                {
                    Data = "Wystąpił błąd podczas operacji.",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

        }

        [HttpPost]
        public ActionResult UpdateBalanceInNewerTransactions(DateTime setDateChangedTransaction, string bankAccountId, decimal differenceAmount, string editedTranasctionId = null)
        {
            var status = false;

            if (Request.IsAjaxRequest() && !String.IsNullOrEmpty(bankAccountId))
            {
                _writeTransaction.UpdateTransactionsBalanceForNewer(setDateChangedTransaction, bankAccountId, differenceAmount, editedTranasctionId);
                status = true;
            }

            return new JsonResult() { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult GetTransactionsByBankAccountId(string bankAccountId, int page = 1, int selectedItemsForPage = 1)
        {
            if (!String.IsNullOrEmpty(bankAccountId))
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId);
                var binder = new ToTransactionListViewModel();
                var currencyLogic = new CurrencyLogic();
                var filterLogic = new FiltersLogic();
                var itemsForPage = filterLogic.GetItemsForPageById(selectedItemsForPage);
                var viewModelTransactions = binder.GetTransactions(bankAccount.Transactions,
                    currencyLogic.GetCurrencyIconById(bankAccount.Currency)).ToPagedList(page, itemsForPage);

                return PartialView("TransactionList", viewModelTransactions);
            }
            else
            {
                return new JsonResult
                {
                    Data = "Wystąpił błąd podczas operacji.",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(string id, string bankAccountId)
        {

            if (Request.IsAjaxRequest() && !String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(bankAccountId))
            {
                var transaction = _readTransaction.GetTransactionById(id, bankAccountId);
                var binder = new ToTransactionDetailsViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModel = binder.GetViewModel(transaction, currencyLogic);

                return PartialView("Details", viewModel);
            }
            
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cos poszło nie tak przy details.");
        }

        [HttpGet]
        public ActionResult Create(string bankAccountId, string userId)
        {
            if (User.Identity.GetUserId() == userId && !String.IsNullOrEmpty(bankAccountId))
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId);
                var binder = new ToTransactionCreateViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModel = binder.GetViewModel(bankAccount, currencyLogic);

                return PartialView("Create", viewModel);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreateViewModel viewModel)
        {
            var status = false;
            if (ModelState.IsValid && Request.IsAjaxRequest())
            {
                var bankAccount = _readBankAccount.GetBankAccountById(viewModel.BankAccountId);
                var binder = new FromTransactionCreateViewModel();
                var transaction = binder.GetTransaction(viewModel, bankAccount);
                _writeTransaction.Create(transaction);
                status = true;

                return new JsonResult(){ Data = new {status = status} };
            }
            else
            {
                return new JsonResult() { Data = new { status = status } };
            }
        }

        [HttpGet]
        public ActionResult Edit(string id, string bankAccountId, string userId)
        {
            if (Request.IsAjaxRequest() && !String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(bankAccountId))
            {
                var tranasction = _readTransaction.GetTransactionById(id);
                var binder = new ToTransactionEditViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModel = binder.GetViewModel(tranasction, currencyLogic);

                return PartialView("Edit", viewModel);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(TransactionEditViewModel viewModel)
        {
            var status = false;

            if (ModelState.IsValid && User.Identity.GetUserId() == viewModel.UserId && Request.IsAjaxRequest()
                && _readTransaction.IsTransactionCorrect(viewModel.Id, viewModel.BankAccountId, viewModel.UserId))
            {
                var binder = new FromTransactionEditViewModel();
                var bankAccount = _readBankAccount.GetBankAccountById(viewModel.BankAccountId);
                var model = binder.GetTransaction(viewModel, bankAccount);
                _writeTransaction.Edit(model);
                status = true;

                return new JsonResult() { Data = new { status = status } };
            }

            return new JsonResult() { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(string id, string bankAccountId)
        {
            if (Request.IsAjaxRequest() && !String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(bankAccountId))
            {
                var tranasction = _readTransaction.GetTransactionById(id);
                var binder = new ToTransactionDeleteViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModel = binder.GetTransaction(tranasction, currencyLogic);

                return PartialView("Delete", viewModel);

            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(string id, string bankAccountId, string userId)
        {
            var status = false;

            if (!String.IsNullOrEmpty(id) && !String.IsNullOrEmpty(bankAccountId) && User.Identity.GetUserId() == userId 
                && Request.IsAjaxRequest() && _readTransaction.IsTransactionCorrect(id, bankAccountId, userId))
            {
                var transaction = _readTransaction.GetTransactionById(id);
                _writeTransaction.Delete(transaction);
                status = true;
            }

            return new JsonResult() { Data = new { status = status } };

        }
    }
}
