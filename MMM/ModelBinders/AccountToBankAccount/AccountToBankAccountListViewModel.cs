using System.Collections.Generic;
using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.AccountToBankAccount
{
    public class AccountToBankAccountListViewModel
    {
        public IList<BankAccountListViewModel> GetBankAccounts(IEnumerable<Account> accounts, CurrencyLogic currencyLogic)
        {
            IList<BankAccountListViewModel> listAccountViewModel = new List<BankAccountListViewModel>();

            foreach (var account in accounts)
            {
                listAccountViewModel.Add(new BankAccountListViewModel()
                {
                    Id = account.Id,
                    Name = account.Name,
                    Balance = account.Balance,
                    Currency = currencyLogic.GetCurrencyIconById(account.Currency),
                    UserId = account.User.Id
                });
            }

            return listAccountViewModel;
        }
    }
}