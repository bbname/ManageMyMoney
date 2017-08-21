using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class ToBankAccountDeleteViewModel
    {
        public BankAccountDeleteViewModel GetViewModel(BankAccount bankAccount, CurrencyLogic currencyLogic)
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