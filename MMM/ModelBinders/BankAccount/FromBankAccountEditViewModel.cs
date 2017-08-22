using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.BankAccount
{
    public class FromBankAccountEditViewModel
    {
        public Model.BankAccount GetBankAccount(BankAccountEditViewModel viewModel, User user)
        {
            var bankAccount = new Model.BankAccount()
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