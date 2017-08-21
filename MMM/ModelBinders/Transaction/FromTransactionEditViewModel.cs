using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class FromTransactionEditViewModel
    {
        public Model.Transaction GetTransaction(TransactionEditViewModel viewModel, BankAccount bankAccount)
        {
            var transaction = new Model.Transaction()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Amount = viewModel.Balance,
                AccountBalance = viewModel.AccountBalance,
                SetDate = viewModel.SetDate,
                BankAccount = bankAccount
            };

            return transaction;
        }
    }
}