using System;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class BankAccountCreateViewModelToAccount
    {
        public Account GetAccount(BankAccountCreateViewModel viewModel, User user)
        {
            var account = new Account
            {
                Name = viewModel.Name,
                Balance = viewModel.Balance,
                Currency = viewModel.SelectedCurrencyId,
                Created = DateTime.Now,
                User = user
            };

            return account;
        }
    }
}