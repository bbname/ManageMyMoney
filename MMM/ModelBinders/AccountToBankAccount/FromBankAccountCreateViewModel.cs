using System;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class FromBankAccountCreateViewModel
    {
        public BankAccount GetBankAccount(BankAccountCreateViewModel viewModel, User user)
        {
            var bankAccount = new BankAccount
            {
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