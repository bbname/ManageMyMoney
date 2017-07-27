using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class AccountToBankAccountEditViewModel
    {
        public BankAccountEditViewModel GetBankAccount(Account account)
        {
            var bankAccount = new BankAccountEditViewModel
            {
                Id = account.Id,
                Name = account.Name,
                Balance = account.Balance,
                SelectedCurrencyId = account.Currency,
                UserId = account.User.Id
            };

            return bankAccount;
        }
    }
}