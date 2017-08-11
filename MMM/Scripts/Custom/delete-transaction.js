function DeleteTransactionListener(urlPostActionToSave, id, bankAccountId, userId) {
    $(document).on('click', '#DeleteTransactionBtn', function (e) {
        e.preventDefault();
        DeleteTransaction(urlPostActionToSave, id, bankAccountId, userId);
    });
}

function DeleteTransaction(urlPostActionToSave, id, bankAccountId, userId) {

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
                LoadTransactionsFilters(tranasctionDiv);
            }
        },
        error: function () {
            alert('Coś poszło nie tak przy usuwaniu transakcji.');
        }
    });
}