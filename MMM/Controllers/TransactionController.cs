using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MMM.BussinesLogic;
using MMM.ModelBinders.Transaction;
using MMM.Service.Interfaces;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "Admin, User")]
    public class TransactionController : Controller
    {
        private readonly IReadBankAccount _readBankAccount;
        private readonly IReadTransaction _readTransaction;
        private IWriteTransaction _writeTransaction;
        public TransactionController(IReadBankAccount readBankAccount, IReadTransaction readTransaction, IWriteTransaction writeTransaction)
        {
            this._readBankAccount = readBankAccount;
            this._readTransaction = readTransaction;
            this._writeTransaction = writeTransaction;
        }

        //[System.Web.Mvc.HttpGet]
        //public JsonResult GetTransactionsByBankAccountId(int? bankAccountId, string userId)
        //{
        //    if (bankAccountId != null && !(String.IsNullOrEmpty(userId)))
        //    {
        //        var bankAccount = _readBankAccount.GetAccountById(bankAccountId.Value);
        //        var binder = new ToTransactionListViewModel();
        //        var currencyLogic = new CurrencyLogic();
        //        var viewModelTransactions = binder.GetTransactions(bankAccount.Transactions,
        //            currencyLogic.GetCurrencyIconById(bankAccount.Currency));

        //        return new JsonResult
        //        {
        //            Data = viewModelTransactions,
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }
        //    else
        //    {
        //        return new JsonResult
        //        {
        //            Data = "Wystąpił błąd podczas operacji.",
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }

        //}
        [System.Web.Mvc.HttpGet]
        public ActionResult GetTransactionsByBankAccountId(int? bankAccountId)
        {
            if (bankAccountId != null)
            {
                var bankAccount = _readBankAccount.GetAccountById(bankAccountId.Value);
                var binder = new ToTransactionListViewModel();
                var currencyLogic = new CurrencyLogic();
                var viewModelTransactions = binder.GetTransactions(bankAccount.Transactions,
                    currencyLogic.GetCurrencyIconById(bankAccount.Currency));

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

        //[System.Web.Mvc.HttpGet]
        //public ActionResult TransactionList(List<TransactionListViewModel> transanctionListViewModel)
        //{
        //    //IEnumerable<TransactionListViewModel> listViewModel = new List<TransactionListViewModel>();
        //    if (Request.IsAjaxRequest())
        //    {
        //        return PartialView("TransactionList", transanctionListViewModel);
        //    }

        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Coś poszło nie tak.");
        //}

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
        public ActionResult Create(int bankAccountId, string userId)
        {
            if (User.Identity.GetUserId() == userId)
            {
                var viewModel = new TransactionCreateViewModel
                {
                    BankAccountId = bankAccountId,
                    UserId = userId,
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
                var binder = new FromCreateViewModel();
                var transaction = binder.GetTransaction(viewModel, account);
                _writeTransaction.Create(transaction);
                status = true;

                return new JsonResult(){ Data = new {status = status} };
            }
            else
            {
                return new JsonResult() { Data = new { status = status } };
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Nie powiodło się dodawnaie.");
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
