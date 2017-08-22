using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.BankAccount
{
    public class ToBankAccountEditViewModel
    {
        public BankAccountEditViewModel GetViewModel(Model.BankAccount bankAccount)
        {
            var viewModel = new BankAccountEditViewModel
            {
                Id = bankAccount.Id,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                SelectedCurrencyId = bankAccount.Currency,
                Created = bankAccount.Created,
                UserId = bankAccount.User.Id
            };

            return viewModel;
        }
    }
}