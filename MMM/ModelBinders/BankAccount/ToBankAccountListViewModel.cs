using System.Collections.Generic;
using MMM.BussinesLogic;
using MMM.Model;
using MMM.ViewModels.BankAccountViewModel;

namespace MMM.ModelBinders.BankAccount
{
    public class ToBankAccountListViewModel
    {
        public IList<BankAccountListViewModel> GetListViewModel(IEnumerable<Model.BankAccount> bankAccounts, CurrencyLogic currencyLogic)
        {
            IList<BankAccountListViewModel> listAccountViewModel = new List<BankAccountListViewModel>();

            foreach (var bankAccount in bankAccounts)
            {
                listAccountViewModel.Add(new BankAccountListViewModel()
                {
                    Id = bankAccount.Id,
                    Name = bankAccount.Name,
                    Balance = bankAccount.Balance,
                    Currency = currencyLogic.GetCurrencyIconById(bankAccount.Currency),
                    UserId = bankAccount.User.Id
                });
            }

            return listAccountViewModel;
        }
    }
}