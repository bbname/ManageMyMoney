function EditBankAccountBalance(urlPostActionToSave, accountBalance, userId) {
    SaveChangedBankAccountBalance(urlPostActionToSave, accountBalance, userId);
}

function SaveChangedBankAccountBalance(urlPostActionToSave, accountBalance, userId) {
    $.ajax({
        url: urlPostActionToSave,
        type: 'POST',
        data: {
            id: $bankAccountId,
            userId: userId,
            balance: accountBalance
        },
        success: function (dataBack) {
            if (dataBack.status) {
                $('#BankAccountBalance').effect("highlight", 10000);
                $('#BankAccountBalance').text(accountBalance);
            }
        },
        error: function () {
            alert('Coś poszło nie tak przy updateowaniu salda konta.');
        }
    });
}