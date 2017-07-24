using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using Microsoft.AspNet.Identity;
using MMM.BussinesLogic;
using MMM.Infrastructure;
using MMM.Model;
using MMM.ModelBinders;
using MMM.ModelBinders.AccountToBankAccount;
using MMM.Service.Interfaces;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class BankAccountController : Controller
    {
        private IReadBankAccount _readBankAccount;
        private IWriteBankAccount _writeBankAccount;
        public BankAccountController(IReadBankAccount readBankAccount, IWriteBankAccount writeBankAccount)
        {
            this._readBankAccount = readBankAccount;
            this._writeBankAccount = writeBankAccount;
        }
        // GET: BankAccount
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var accounts = _readBankAccount.GetAllBankAccountsByUserId(userId);
                var currencyLogic = new CurrencyLogic();
                var binder = new AccountToBankAccountListViewModel();
                var listAccountViewModel = binder.GetBankAccounts(accounts, currencyLogic);

                // For the reflection binder, maybe another time..
                //var accountTest = _readBankAccount.GetAccountById(accounts.ElementAt(0).Id);
                //var bindViewModel = new BindModelToViewModel<BankAccountListViewModel, Account>(new BankAccountListViewModel(), accountTest);
                //var bankAccountViewModel = bindViewModel.BindViewModelByModelWithout("Transactions","Created", "Currency");

                return View(listAccountViewModel);
            }

            return View("Login");

        }

        // GET: BankAccount/Details/5
        public ActionResult Details(int id)
        {
            var bankAccount = _readBankAccount.GetAccountById(id);
            var currencyLogic = new CurrencyLogic();
            var viewModel = new BankAccountDetailsViewModel()
            {
                Id = bankAccount.Id,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                Currency = currencyLogic.GetCurrencyIconById(bankAccount.Currency),
                Transactions = bankAccount.Transactions
            };

            return View(viewModel);
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            var model = new BankAccountCreateViewModel();
            return View(model);
        }

        // POST: BankAccount/Create
        [HttpPost]
        public ActionResult Create(BankAccountCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: BankAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankAccount/Edit/5
        [HttpPost]
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

        // GET: BankAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankAccount/Delete/5
        [HttpPost]
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
