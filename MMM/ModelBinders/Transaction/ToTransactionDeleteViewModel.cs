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
                BankAccountId = transaction.Account.Id,
                UserId = transaction.Account.User.Id,
                Name = transaction.Name,
                Amount = transaction.Amount,
                AccountBalance = transaction.AccountBalance,
                SetDate = transaction.SetDate,
                Currency = currencyLogic.GetCurrencyIconById(transaction.Account.Currency)
            };

            return viewModel;
        }
    }
}