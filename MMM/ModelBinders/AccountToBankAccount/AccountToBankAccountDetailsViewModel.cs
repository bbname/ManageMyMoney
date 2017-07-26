using MMM.BussinesLogic;
using MMM.Model;
using MMM.ModelBinders.Transaction;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class AccountToBankAccountDetailsViewModel
    {
        public BankAccountDetailsViewModel GetBankAccount(Account bankAccount, CurrencyLogic currencyLogic, ToTransactionListViewModel binderTransaction)
        {
            var viewModel = new BankAccountDetailsViewModel()
            {
                Id = bankAccount.Id,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                Currency = currencyLogic.GetCurrencyIconById(bankAccount.Currency),
                Transactions = binderTransaction.GetTransactions(bankAccount.Transactions, currencyLogic.GetCurrencyIconById(bankAccount.Currency)),
                User = bankAccount.User
            };

            return viewModel;
        }
    }
}