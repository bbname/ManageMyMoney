function EditBankAccountBalance(urlPostActionToSave, accountBalance, userId, isPermissionForEdit) {

    if (isPermissionForEdit) {
        SaveChangedBankAccountBalance(urlPostActionToSave, accountBalance, userId);
    }
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

function GetBankAccountBalanceEditTranasction(firstAmount, currentAmount) {
    firstAmount = firstAmount.replace(',', '.');
    currentAmount = currentAmount.replace(',', '.');
    var balance = $('#BankAccountBalance').text().trim();
    balance = balance.replace(',', '.');

    var amountDifference = parseFloat(firstAmount) - parseFloat(currentAmount);
    amountDifference = amountDifference.toFixed(2);

    var balanceToUpdate = parseFloat(balance) - parseFloat(amountDifference);
    balanceToUpdate = balanceToUpdate.toFixed(2);
    balanceToUpdate = balanceToUpdate.toString().replace('.', ',');

    return balanceToUpdate;
}

function GetBankAccountBalanceDeleteTransaction(amount) {
    amount = amount.replace(',', '.');

    var balance = $('#BankAccountBalance').text().trim();
    balance = balance.replace(',', '.');

    var balanceAfterUpdate = parseFloat(balance) + (parseFloat(amount) * -1);
    balanceAfterUpdate = balanceAfterUpdate.toFixed(2);
    balanceAfterUpdate = balanceAfterUpdate.toString().replace('.', ',');

    return balanceAfterUpdate;
}