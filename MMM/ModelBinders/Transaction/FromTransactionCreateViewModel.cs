using MMM.Model;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class FromTransactionCreateViewModel
    {
        public Model.Transaction GetTransaction(TransactionCreateViewModel viewmodel, BankAccount bankAccount)
        {
            var transaction = new Model.Transaction
            {
                Name = viewmodel.Name,
                Amount = viewmodel.Balance,
                AccountBalance = viewmodel.AccountBalance,
                SetDate = viewmodel.SetDate,
                BankAccount = bankAccount
            };

            return transaction;
        }
    }
}