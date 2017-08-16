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

        [HttpPost]
        public ActionResult UpdateBalanceInNewerTransactions(DateTime setDateChangedTransaction, int? bankAccountId, decimal differenceAmount, int? editedTranasctionId = null)
        {
            var status = false;

            if (Request.IsAjaxRequest()  && bankAccountId != null)
            {
                _writeTransaction.UpdateTransactionsBalanceForNewer(setDateChangedTransaction, bankAccountId.Value, differenceAmount, editedTranasctionId);
                status = true;
            }

            return new JsonResult(){ Data = new { status = status} };
        }

        [HttpGet]
        //public ActionResult GetTransactionsByBankAccountIdFilters(int? bankAccountId, DateTime? fromDate, DateTime? toDate, int? selectedItemsForPage, int? selectedFilterId)
        public ActionResult GetTransactionsByBankAccountIdFilters(int? bankAccountId, string fromDate, string toDate, int? selectedItemsForPage, int? selectedFilterId, int page = 1)
        {
            if (bankAccountId != null)
            {
                var bankAccount = _readBankAccount.GetAccountById(bankAccountId.Value);
                var binder = new ToTransactionListViewModel();
                var currencyLogic = new CurrencyLogic();
                var filterLogic = new FiltersLogic();
                var filterName = "";
                var filterValue = "";
                var fromDateConverted = filterLogic.GetDateTimeByDateStringWithDots(fromDate);
                var toDateConverted = filterLogic.GetEndDateTimeDateStringWithDots(toDate);
                filterLogic.GetFilterNameFilterValueById(selectedFilterId, out filterName, out filterValue);
                var itemsForPage = filterLogic.GetItemsForPageById(selectedItemsForPage);

                var transactions = _readTransaction.GetTransactionsByFilters(bankAccountId.Value, fromDateConverted, toDateConverted,
                    itemsForPage, filterName, filterValue);
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

        [System.Web.Mvc.HttpGet]
        public ActionResult GetTransactionsByBankAccountId(int? bankAccountId, int page = 1, int selectedItemsForPage = 1)
        {
            if (bankAccountId != null)
            {
                var bankAccount = _readBankAccount.GetAccountById(bankAccountId.Value);
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

        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Details(int? id)
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Create(int bankAccountId, string userId, decimal accountBalance, string currency)
        {
            if (User.Identity.GetUserId() == userId)
            {
                var viewModel = new TransactionCreateViewModel
                {
                    BankAccountId = bankAccountId,
                    UserId = userId,
                    AccountBalance = accountBalance,
                    Currency = currency,
                    SetDate = DateTime.Now
                };

                return PartialView(viewModel);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreateViewModel viewModel)
        {
            var status = false;
            if (ModelState.IsValid && Request.IsAjaxRequest())
            {
                var account = _readBankAccount.GetAccountById(viewModel.BankAccountId);
                var binder = new FromTransactionCreateViewModel();
                var transaction = binder.GetTransaction(viewModel, account);
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

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(TransactionEditViewModel viewModel)
        {
            var status = false;

            if (ModelState.IsValid && User.Identity.GetUserId() == viewModel.UserId && Request.IsAjaxRequest()
                && _readTransaction.IsTransactionCorrect(viewModel.Id, viewModel.BankAccountId, viewModel.UserId))
            {
                var binder = new FromTransactionEditViewModel();
                var account = _readBankAccount.GetAccountById(viewModel.BankAccountId);
                var model = binder.GetTransaction(viewModel, account);
                _writeTransaction.Edit(model);
                status = true;

                return new JsonResult() { Data = new { status = status } };
            }

            return new JsonResult() { Data = new { status = status } };
        }

        // GET: Transaction/Delete/5
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

        // POST: Transaction/Delete/5
        [System.Web.Mvc.HttpPost]
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
