function SearchTransactionListener(urlGetSearchTransactionAction, urlLoadTransactionBySearchName, bankAccountId) {
    $('#SearchTransaction').on('#SearchTransactionByName input',
        function() {
            SearchTransactions(urlGetSearchTransactionAction, urlLoadTransactionBySearchName, bankAccountId);
        });
}

function SearchTransactions(urlGetSearchTransactionAction, urlLoadTransactionBySearchName, bankAccountId) {
    if (!CheckIfSearchIsEmpty()) {
        $.ajax({
            url: urlGetSearchTransactionAction,
            type: 'GET',
            data: {
                bankAccountId: bankAccountId,
                searchText: $('#SearchTransactionByName').val()
            },
            success: function(dataBack) {
                $('#SearchTransactionByName').autocomplete({
                    source: dataBack,
                    select: function(e, ui) {
                        var inputSearch = $(this);
                        inputSearch.val(ui.item.value);
                        LoadTransactionBySearchName(urlLoadTransactionBySearchName, inputSearch.val(), bankAccountId);
                    }
                });
            },
            error: function() {
                alert("Coś poszło nie tak przy serachu.");
            }
        });
    }
}

function CheckIfSearchIsEmpty() {
    var isEmpty = false;

    if ($('#SearchTransactionByName').val().length === 0) {
        isEmpty = true;
    }

    return isEmpty;
}