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
using MMM.ModelBinders.BankAccount;
using MMM.ModelBinders.Transaction;
using MMM.Service.Interfaces;
using MMM.ViewModels.BankAccountViewModel;
using PagedList;

namespace MMM.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class BankAccountController : Controller
    {
        private readonly IReadBankAccount _readBankAccount;
        private readonly IWriteBankAccount _writeBankAccount;
        private readonly IReadUser _readUser;

        public BankAccountController(IReadBankAccount readBankAccount, IWriteBankAccount writeBankAccount, IReadUser readUser)
        {
            this._readBankAccount = readBankAccount;
            this._writeBankAccount = writeBankAccount;
            this._readUser = readUser;
        }


        [HttpPost]
        public ActionResult UpdateBankAccountBalance(int id, string userId, decimal balance)
        {
            var status = false;

            if (id > 0 && User.Identity.GetUserId() == userId && Request.IsAjaxRequest()
                && _readBankAccount.IsBankAccountCorrect(id, userId))
            {
                var bankAccount = _readBankAccount.GetBankAccountById(id);
                bankAccount.Balance = balance;
                _writeBankAccount.Edit(bankAccount);
                status = true;
            }

            return new JsonResult() { Data = new { status = status} };
        }

        [HttpGet]
        public ActionResult Index()
        {
                var userId = User.Identity.GetUserId();
                var bankAccounts = _readBankAccount.GetAllBankAccountsByUserId(userId);
                var currencyLogic = new CurrencyLogic();
                var binder = new ToBankAccountListViewModel();
                var listAccountViewModel = binder.GetListViewModel(bankAccounts, currencyLogic);

                // For the reflection binder, maybe another time..
                //var accountTest = _readBankAccount.GetBankAccountById(accounts.ElementAt(0).Id);
                //var bindViewModel = new BindModelToViewModel<BankAccountListViewModel, BankAccount>(new BankAccountListViewModel(), accountTest);
                //var bankAccountViewModel = bindViewModel.BindViewModelByModelWithout("Transactions","Created", "Currency");

                return View(listAccountViewModel);

        }

        [HttpGet]
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
                    var bankAccount = _readBankAccount.GetBankAccountById(id.Value);
                    var currencyLogic = new CurrencyLogic();
                    var binder = new ToBankAccountDetailsViewModel();
                    var viewModel = binder.GetViewModel(bankAccount, currencyLogic);

                    return View(viewModel);
                }

                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Nie posiadasz takiego konta.");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new BankAccountCreateViewModel
            {
                UserId = User.Identity.GetUserId()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BankAccountCreateViewModel viewModel)
        {
            if (ModelState.IsValid && User.Identity.GetUserId() == viewModel.UserId)
            {
                var binder = new FromBankAccountCreateViewModel();
                var user = _readUser.GetUserById(viewModel.UserId);
                var model = binder.GetBankAccount(viewModel, user);
                _writeBankAccount.Create(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
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
                    var bankAccount = _readBankAccount.GetBankAccountById(id.Value);
                    var binder = new ToBankAccountEditViewModel();
                    var viewModel = binder.GetViewModel(bankAccount);

                    return View(viewModel);
                }

                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Nie posiadasz takiego konta.");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BankAccountEditViewModel viewModel)
        {
            if (ModelState.IsValid && User.Identity.GetUserId() == viewModel.UserId)
            {
                var binder = new FromBankAccountEditViewModel();
                var user = _readUser.GetUserById(viewModel.UserId);
                var model = binder.GetBankAccount(viewModel, user);
                _writeBankAccount.Edit(model);

                return RedirectToAction("Details", new {id = viewModel.Id});
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
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
                    var bankAccount = _readBankAccount.GetBankAccountById(id.Value);
                    var binder = new ToBankAccountDeleteViewModel();
                    var currencyLogic = new CurrencyLogic();
                    var viewModel = binder.GetViewModel(bankAccount, currencyLogic);

                    return View(viewModel);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Nie posiadasz takiego konta");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string userId)
        {
            if (User.Identity.GetUserId() == userId)
            {
                _writeBankAccount.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete", new {id = id});
            }
        }
    }
}
