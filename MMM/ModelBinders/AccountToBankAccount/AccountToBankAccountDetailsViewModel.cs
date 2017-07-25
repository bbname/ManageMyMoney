using MMM.BussinesLogic;
using MMM.Model;
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
                Transactions = bankAccount.Transactions,
                User = bankAccount.User
            };

            return viewModel;
        }
    }
}