using System.Collections.Generic;
using MMM.BussinesLogic;
using MMM.ViewModels.TransactionViewModel;

namespace MMM.ModelBinders.Transaction
{
    public class ToTransactionListViewModel
    {
        public IList<TransactionListViewModel> GetTransactions(IEnumerable<Model.Transaction> transactions, string currency)
        {
            IList<TransactionListViewModel> listTransactionViewModel = new List<TransactionListViewModel>();

            foreach (var transaction in transactions)
            {
                listTransactionViewModel.Add(new TransactionListViewModel()
                {
                    Id = transaction.Id,
                    Name = transaction.Name,
                    Amount = transaction.Amount,
                    AccountBalance = transaction.AccountBalance,
                    Created = transaction.Created,
                    Currency = currency
                });
            }

            return listTransactionViewModel;
        }
    }
}