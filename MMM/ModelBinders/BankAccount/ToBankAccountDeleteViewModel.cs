using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.BankAccount
{
    public class ToBankAccountDeleteViewModel
    {
        public BankAccountDeleteViewModel GetViewModel(Model.BankAccount bankAccount, CurrencyLogic currencyLogic)
        {
            var viewModel = new BankAccountDeleteViewModel
            {
                Id = bankAccount.Id,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                Currency = currencyLogic.GetCurrencyIconById(bankAccount.Currency),
                Created = bankAccount.Created,
                UserId = bankAccount.User.Id
            };

            return viewModel;
        }
    }
}