using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class BankAccountEditViewModelToAccount
    {
        public Account GetAccount(BankAccountEditViewModel viewModel, User user)
        {
            var account = new Account()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Balance = viewModel.Balance,
                Currency = viewModel.SelectedCurrencyId,
                Created = viewModel.Created,
                User = user
            };

            return account;
        }
    }
}