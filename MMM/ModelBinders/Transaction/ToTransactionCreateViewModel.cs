using MMM.BussinesLogic;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class ToTransactionCreateViewModel
    {
        public TransactionCreateViewModel GetViewModel(Model.BankAccount bankAccount, CurrencyLogic currencyLogic)
        {
            var viewModel = new TransactionCreateViewModel
            {
                AccountBalance = bankAccount.Balance,
                Currency = currencyLogic.GetCurrencyIconById(bankAccount.Currency),
                BankAccountId = bankAccount.Id,
                UserId = bankAccount.User.Id
            };

            return viewModel;
        }
    }
}