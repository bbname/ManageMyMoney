using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class FromBankAccountEditViewModel
    {
        public BankAccount GetBankAccount(BankAccountEditViewModel viewModel, User user)
        {
            var bankAccount = new BankAccount()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Balance = viewModel.Balance,
                Currency = viewModel.SelectedCurrencyId,
                Created = viewModel.Created,
                User = user
            };

            return bankAccount;
        }
    }
}