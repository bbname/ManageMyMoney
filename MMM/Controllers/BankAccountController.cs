using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MMM.Service.Interfaces;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.Controllers
{
    public class BankAccountController : Controller
    {
        private IReadBankAccount _readBankAccount;
        public BankAccountController(IReadBankAccount readBankAccount)
        {
            this._readBankAccount = readBankAccount;
        }
        // GET: BankAccount
        public ActionResult Index()
        {
            var accounts = _readBankAccount.GetAllBankAccounts();
            List<BankAccountListViewModel> listAccountViewModel = new List<BankAccountListViewModel>();

            foreach (var account in accounts)
            {
                listAccountViewModel.Add(new BankAccountListViewModel()
                {
                    Id = account.Id,
                    Name = account.Name,
                    Balance = account.Balance,
                    Currency = account.Currency
                });
            }

            return View(listAccountViewModel);
        }

        // GET: BankAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            return View();
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
