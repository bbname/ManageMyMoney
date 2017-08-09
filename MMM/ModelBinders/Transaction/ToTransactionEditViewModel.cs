using MMM.BussinesLogic;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class ToTransactionEditViewModel
    {
        public TransactionEditViewModel GetViewModel(Model.Transaction transaction, CurrencyLogic currencyLogic)
        {
            var viewModel = new TransactionEditViewModel()
            {
                Id = transaction.Id,
                Name = transaction.Name,
                Balance = transaction.Amount,
                AccountBalance = transaction.AccountBalance,
                SetDate = transaction.SetDate,
                Currency = currencyLogic.GetCurrencyIconById(transaction.Account.Currency),
                BankAccountId = transaction.Account.Id,
                UserId = transaction.Account.User.Id
            };

            return viewModel;
        }
    }
}