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
                Id = transaction.Id
            };

            return viewModel;
        }
    }
}