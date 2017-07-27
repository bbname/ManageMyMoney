using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class AccountToBankAccountDeleteViewModel
    {
        public BankAccountDeleteViewModel GetBankAccount(Account account, CurrencyLogic currencyLogic)
        {
            var bankAccount = new BankAccountDeleteViewModel
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
                Currency = currencyLogic.GetCurrencyIconById(account.Currency),
                Created = account.Created,
                UserId = account.User.Id
            };

            return bankAccount;
        }
    }
}