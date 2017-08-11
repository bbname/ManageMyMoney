function DeleteTransactionListener(urlPostActionToSave, id, bankAccountId, userId, urlGetActionLoadFilters) {
    $(document).on('click', '#DeleteTransactionBtn', function (e) {
        e.preventDefault();
        DeleteTransaction(urlPostActionToSave, id, bankAccountId, userId, urlGetActionLoadFilters);
    });
}

function DeleteTransaction(urlPostActionToSave, id, bankAccountId, userId, urlGetActionLoadFilters) {

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
                LoadTransactionsFilters(tranasctionDiv, urlGetActionLoadFilters, bankAccountId);
            }
        },
        error: function () {
            alert('Coś poszło nie tak przy usuwaniu transakcji.');
        }
    });
}