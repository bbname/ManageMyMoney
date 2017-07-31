using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class FromCreateViewModel
    {
        public Model.Transaction GetTransaction(TransactionCreateViewModel viewmodel)
        {
            var transaction = new Model.Transaction
            {
                Name = viewmodel.Name,
                Amount = viewmodel.Balance,
                AccountBalance = viewmodel.AccountBalance,
                Created = viewmodel.SetDate
            };
        }
    }
}