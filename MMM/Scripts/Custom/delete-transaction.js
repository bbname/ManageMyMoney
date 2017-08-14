function DeleteTransactionListener(urlPostActionToSave, id, bankAccountId, userId, urlGetActionLoadFilters, urlEditAccountBalanceAction, amount, urlEditTransactionsBalance, setDateChangedTransaction) {
    $(document).on('click', '#DeleteTransactionBtn', function (e) {
        e.preventDefault();
        DeleteTransaction(urlPostActionToSave, id, bankAccountId, userId, urlGetActionLoadFilters, urlEditAccountBalanceAction, amount, urlEditTransactionsBalance, setDateChangedTransaction);
    });
}

function DeleteTransaction(urlPostActionToSave, id, bankAccountId, userId, urlGetActionLoadFilters, urlEditAccountBalanceAction, amount, urlEditTransactionsBalance, setDateChangedTransaction) {
    var isPermissionToChangeBalance = !($('#ModalDeleteTransaction #DeleteChangeBankAccountBalance').is(':checked'));

    $.ajax({
        url: urlPostActionToSave,
        type: 'POST',
        data: {
            __RequestVerificationToken: $('input[name=____RequestVerificationToken]').val(),
            id: id,
            bankAccountId: bankAccountId,
            userId: userId
        },
        success: function (dataBack) {
            if (dataBack.status) {
                var tranasctionDiv = $('#TransactionsList');
                EditBankAccountBalance(urlEditAccountBalanceAction,
                    GetBankAccountBalanceDeleteTransaction(amount),
                    userId,
                    isPermissionToChangeBalance);
                // LoadTransaction as well in EditNewerTransaction...
                EditNewerTransactionsBalance(urlEditTransactionsBalance,
                    setDateChangedTransaction,
                    bankAccountId,
                    GetDifferenceAmountDeleteTransaction(amount),
                    isPermissionToChangeBalance,
                    tranasctionDiv,
                    urlGetActionLoadFilters
                );
                //LoadTransactionsFilters(tranasctionDiv, urlGetActionLoadFilters, bankAccountId);
            }
        },
        error: function () {
            alert('Coś poszło nie tak przy usuwaniu transakcji.');
        }
    });
}