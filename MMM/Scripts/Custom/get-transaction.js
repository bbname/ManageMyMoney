function GetTransactionDetailsData(urlGetAction, transactionId, bankAccountId) {
    $.ajax({
        url: urlGetAction,
        type: 'GET',
        data: {
            id: transactionId,
            bankAccountId: bankAccountId
        },
        success: function(dataBack) {
            LoadDataIntoModalDetailsAndOpen(dataBack);
        },
        error: function() {
            alert('Coś poszło nie tak przy pobieraniu danych na temat transakcji.');
        }
    });
}

function GetTransactionEditData(urlGetAction, transactionId, bankAccountId, userId) {
    $.ajax({
        url: urlGetAction,
        type: 'GET',
        data: {
            id: transactionId,
            bankAccountId: bankAccountId,
            userId: userId
        },
        success: function (dataBack) {
            LoadDataIntoModalEditAndOpen(dataBack);
        },
        error: function () {
            alert("Coś poszło nie tak przy pobieraniu danych na temat transakcji.");
        }
    });
}

function GetTransactionDeleteData(urlGetAction, transactionId, bankAccountId) {
    $.ajax({
        url: urlGetAction,
        type: 'GET',
        data: {
            id: transactionId,
            bankAccountId: bankAccountId
        },
        success: function (dataBack) {
            LoadDataIntoModalDeleteAndOpen(dataBack);
        },
        error: function () {
            alert("Coś poszło nie tak przy pobieraniu danych na temat transakcji.");
        }
    });
}