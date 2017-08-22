using System;
using MMM.Model;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class FromTransactionCreateViewModel
    {
        public Model.Transaction GetTransaction(TransactionCreateViewModel viewmodel, Model.BankAccount bankAccount)
        {
            var transaction = new Model.Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Name = viewmodel.Name,
                Amount = viewmodel.Balance,
                AccountBalance = viewmodel.AccountBalance,
                SetDate = viewmodel.SetDate,
                Description = viewmodel.Description,
                BankAccount = bankAccount
            };

            return transaction;
        }
    }
}