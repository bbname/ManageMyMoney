using MMM.Model;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class FromCreateViewModel
    {
        public Model.Transaction GetTransaction(TransactionCreateViewModel viewmodel, Account account)
        {
            var transaction = new Model.Transaction
            {
                Name = viewmodel.Name,
                Amount = viewmodel.Balance,
                AccountBalance = viewmodel.AccountBalance,
                SetDate = viewmodel.SetDate,
                Account = account
            };

            return transaction;
        }
    }
}