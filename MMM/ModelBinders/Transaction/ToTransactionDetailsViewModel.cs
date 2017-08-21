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
                Name = transaction.Name,
                Amount = transaction.Amount,
                AccountBalance = transaction.AccountBalance,
                SetDate = transaction.SetDate,
                Description = transaction.Description,
                Currency = currencyLogic.GetCurrencyIconById(transaction.BankAccount.Currency),
                BankAccountId = transaction.BankAccount.Id,
                UserId = transaction.BankAccount.User.Id
            };

            return viewModel;
        }
    }
}