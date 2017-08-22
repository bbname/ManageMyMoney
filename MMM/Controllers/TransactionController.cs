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
        public ActionResult LoadTransactionBySearchName(string name, int? bankAccountId)
        {
            if (Request.IsAjaxRequest() && bankAccountId != null && !String.IsNullOrEmpty(name))
            {
                var currencyLogic = new CurrencyLogic();
                var binder = new ToTransactionListViewModel();

                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId.Value);
                var transaction = _readTransaction.GetTransactionByName(name, bankAccountId.Value);

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
        public ActionResult AutocompleteSearchTransaction(string searchText, int? bankAccountId)
        {
            if (Request.IsAjaxRequest() && bankAccountId != null && !String.IsNullOrEmpty(searchText))
            {
                var results = _readTransaction.GetTransactionNamesBySimilarName(bankAccountId.Value, searchText);

                return Json(results, JsonRequestBehavior.AllowGet);
            }
            return Json("Coś poszło nie tak przy wyszukiwaniu.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTransactionsBySearchNameFilters(int? bankAccountId, string name ,string fromDate, string toDate,
            int? selectedItemsForPage, int? selectedFilterId, int page = 1)
        {
            if (bankAccountId != null && !String.IsNullOrEmpty(name))
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId.Value);
                var binder = new ToTransactionListViewModel();
                var currencyLogic = new CurrencyLogic();
                var filterLogic = new FiltersLogic();
                var filterName = "";
                var filterValue = "";
                var fromDateConverted = filterLogic.GetDateTimeByDateStringWithDots(fromDate);
                var toDateConverted = filterLogic.GetEndDateTimeDateStringWithDots(toDate);
                filterLogic.GetFilterNameFilterValueById(selectedFilterId, out filterName, out filterValue);
                var itemsForPage = filterLogic.GetItemsForPageById(selectedItemsForPage);


                var transactions = _readTransaction.GetSearchTransactionsByFilters(bankAccountId.Value, fromDateConverted, toDateConverted, filterName, filterValue, name);
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
        public ActionResult GetTransactionsByBankAccountIdFilters(int? bankAccountId, string fromDate, string toDate, int? selectedItemsForPage, int? selectedFilterId, int page = 1)
        {
            if (bankAccountId != null)
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId.Value);
                var binder = new ToTransactionListViewModel();
                var currencyLogic = new CurrencyLogic();
                var filterLogic = new FiltersLogic();
                var filterName = "";
                var filterValue = "";
                var fromDateConverted = filterLogic.GetDateTimeByDateStringWithDots(fromDate);
                var toDateConverted = filterLogic.GetEndDateTimeDateStringWithDots(toDate);
                filterLogic.GetFilterNameFilterValueById(selectedFilterId, out filterName, out filterValue);
                var itemsForPage = filterLogic.GetItemsForPageById(selectedItemsForPage);

                var transactions = _readTransaction.GetTransactionsByFilters(bankAccountId.Value, fromDateConverted, toDateConverted, filterName, filterValue);
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
        public ActionResult UpdateBalanceInNewerTransactions(DateTime setDateChangedTransaction, int? bankAccountId, decimal differenceAmount, int? editedTranasctionId = null)
        {
            var status = false;

            if (Request.IsAjaxRequest() && bankAccountId != null)
            {
                _writeTransaction.UpdateTransactionsBalanceForNewer(setDateChangedTransaction, bankAccountId.Value, differenceAmount, editedTranasctionId);
                status = true;
            }

            return new JsonResult() { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult GetTransactionsByBankAccountId(int? bankAccountId, int page = 1, int selectedItemsForPage = 1)
        {
            if (bankAccountId != null)
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId.Value);
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
        public ActionResult Details(int? id, int bankAccountId)
        {

            if (Request.IsAjaxRequest() && id != null)
            {
                var transaction = _readTransaction.GetTransactionById(id.Value, bankAccountId);
                var binder = new ToTransactionDetailsViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModel = binder.GetViewModel(transaction, currencyLogic);

                return PartialView("Details", viewModel);
            }
            
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cos poszło nie tak przy details.");
        }

        [HttpGet]
        //public ActionResult Create(int bankAccountId, string userId, decimal currentBankAccountBalance, string currency)
        public ActionResult Create(int bankAccountId, string userId)
        {
            if (User.Identity.GetUserId() == userId)
            {
                var bankAccount = _readBankAccount.GetBankAccountById(bankAccountId);
                var binder = new ToTransactionCreateViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModel = binder.GetViewModel(bankAccount, currencyLogic);

                //var viewModel = new TransactionCreateViewModel
                //{
                //    BankAccountId = bankAccountId,
                //    UserId = userId,
                //    AccountBalance = currentBankAccountBalance,
                //    Currency = currency,
                //    SetDate = DateTime.Now
                //};

                //return PartialView(viewModel);
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
        public ActionResult Edit(int? id, int bankAccountId, string userId)
        {
            if (id != null && Request.IsAjaxRequest()
                && _readTransaction.IsTransactionCorrect(id.Value, bankAccountId, userId))
            {
                var tranasction = _readTransaction.GetTransactionById(id.Value);
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
        public ActionResult Delete(int? id, int bankAccountId)
        {
            if (id != null && Request.IsAjaxRequest())
            {
                var tranasction = _readTransaction.GetTransactionById(id.Value);
                var binder = new ToTransactionDeleteViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModel = binder.GetTransaction(tranasction, currencyLogic);

                return PartialView("Delete", viewModel);

            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, int bankAccountId, string userId)
        {
            var status = false;

            if (id != 0 && bankAccountId != 0 && User.Identity.GetUserId() == userId && Request.IsAjaxRequest()
                && _readTransaction.IsTransactionCorrect(id, bankAccountId, userId))
            {
                var transaction = _readTransaction.GetTransactionById(id);
                _writeTransaction.Delete(transaction);
                status = true;
            }

            return new JsonResult() { Data = new { status = status } };

        }
    }
}
