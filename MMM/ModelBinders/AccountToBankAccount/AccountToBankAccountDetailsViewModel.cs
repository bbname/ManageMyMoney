using MMM.BussinesLogic;
using MMM.Model;
using MMM.ModelBinders.Transaction;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class AccountToBankAccountDetailsViewModel
    {
        public BankAccountDetailsViewModel GetBankAccount(Account bankAccount, CurrencyLogic currencyLogic)
        {
            var viewModel = new BankAccountDetailsViewModel()
            {
                Id = bankAccount.Id,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                Currency = currencyLogic.GetCurrencyIconById(bankAccount.Currency),
                User = bankAccount.User,
                SelectedItemsForPageId = 3
            };

            return viewModel;
        }
    }
}