using MMM.BussinesLogic;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class ToTransactionDeleteViewModel
    {
        public TransactionDeleteViewModel GetTransaction(Model.Transaction transaction, CurrencyLogic currencyLogic)
        {
            var viewModel = new TransactionDeleteViewModel
            {
                Id = transaction.Id,
                Name = transaction.Name,
                Amount = transaction.Amount,
                AccountBalance = transaction.AccountBalance,
                SetDate = transaction.SetDate,
                Currency = currencyLogic.GetCurrencyIconById(transaction.BankAccount.Currency),
                BankAccountId = transaction.BankAccount.Id,
                UserId = transaction.BankAccount.User.Id
            };

            return viewModel;
        }
    }
}