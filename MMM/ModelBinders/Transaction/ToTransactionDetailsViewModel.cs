using MMM.BussinesLogic;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class ToTransactionDetailsViewModel
    {
        public TransactionDetailsViewModel GetViewModel(Model.Transaction transaction, CurrencyLogic currencyLogic)
        {
            var viewModel = new TransactionDetailsViewModel
            {
                Id = transaction.Id,
                BankAccountId = transaction.BankAccount.Id,
                UserId = transaction.BankAccount.User.Id,
                Name = transaction.Name,
                Amount = transaction.Amount,
                AccountBalance = transaction.AccountBalance,
                SetDate = transaction.SetDate,
                Currency = currencyLogic.GetCurrencyIconById(transaction.BankAccount.Currency)
            };

            return viewModel;
        }
    }
}