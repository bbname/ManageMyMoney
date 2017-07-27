using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using MMM.ModelBinders.Transaction;
using MMM.Service.Interfaces;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class BankAccountController : Controller
    {
        private readonly IReadBankAccount _readBankAccount;
        private IWriteBankAccount _writeBankAccount;
        private readonly IReadUser _readUser;

        public BankAccountController(IReadBankAccount readBankAccount, IWriteBankAccount writeBankAccount, IReadUser readUser)
        {
            this._readBankAccount = readBankAccount;
            this._writeBankAccount = writeBankAccount;
            this._readUser = readUser;
        }
        // GET: BankAccount
        public ActionResult Index()
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

        // GET: BankAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Nie podano zadnego konta.");
            }
            else
            {
                var userIdIdentity = User.Identity.GetUserId();
                var userId = "";

                try
                {
                    userId = _readBankAccount.GetUserIdByBankAccountId(id.Value);
                }
                catch (NullReferenceException)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Nie znaleziono takiego konta.");
                }

                if (userIdIdentity == userId)
                {
                    var bankAccount = _readBankAccount.GetAccountById(id.Value);
                    var currencyLogic = new CurrencyLogic();
                    var binder = new AccountToBankAccountDetailsViewModel();
                    var binderTransaction = new ToTransactionListViewModel();
                    var viewModel = binder.GetBankAccount(bankAccount, currencyLogic, binderTransaction);

                    return View(viewModel);
                }

                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Nie posiadasz takiego konta.");
            }
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            var model = new BankAccountCreateViewModel
            {
                UserId = User.Identity.GetUserId()
            };
            return View(model);
        }

        // POST: BankAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BankAccountCreateViewModel viewModel)
        {
            if (ModelState.IsValid && User.Identity.GetUserId() == viewModel.UserId)
            {
                var binder = new BankAccountCreateViewModelToAccount();
                var user = _readUser.GetUserById(viewModel.UserId);
                var model = binder.GetAccount(viewModel, user);
                _writeBankAccount.Create(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
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
