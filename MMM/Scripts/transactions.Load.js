$(document).ready(function() {
    LoadTransactions();
});

function LoadTransactions(bankAccountId, userId, outputDiv) {
    outputDiv.addClass("loader");

    $.ajax({
        url: '/Transaction/GetTransactionsByBankAccountId',
        type: 'GET',
        data: {
            bankAccountId: bankAccountId,
            userId: userId
        },
        dataType: 'json',
        success: function (d) {
            outputDiv.html(d);
            d = stringify({ 'd': d });
            $.ajax(
                {
                    url: '/Transaction/TransactionList',
                    type: 'POST',
                    data: d,
                    datatype: 'json',
                    success: function(da) {
                        outputDiv.html(da);
                    },
                    error: function() {
                        alert('W zapętleniu ajaxa coś nie pykło.');
                    }
                });
        },
        error: function() {
            outputDiv.html('Coś poszło nie tak przy wczytywaniu danych.');
        }
    });
}