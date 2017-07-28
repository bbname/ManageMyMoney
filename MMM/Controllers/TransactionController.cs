using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MMM.Service.Interfaces;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.Controllers
{
    [Authorize(Roles = "Admin, User")]
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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View();
        }

        [HttpGet]
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

        [HttpPost]
        public ActionResult Create(TransactionCreateViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transaction/Edit/5
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

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction/Delete/5
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
