using System;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.BankAccount
{
    public class FromBankAccountCreateViewModel
    {
        public Model.BankAccount GetBankAccount(BankAccountCreateViewModel viewModel, User user)
        {
            var bankAccount = new Model.BankAccount
            {
                Id = Guid.NewGuid().ToString(),
                Name = viewModel.Name,
                Balance = viewModel.Balance,
                Currency = viewModel.SelectedCurrencyId,
                Created = DateTime.Now,
                User = user
            };

            return bankAccount;
        }
    }
}