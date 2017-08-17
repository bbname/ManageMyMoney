function LoadTransactionBtnListener(urlLoadTransactionsFilters, bankAccountId) {
    $('#SearchTransactionReset').on('click',
        '#LoadTransactionBtn',
        function() {
            ClearSearchInput();
            HideSearchTransactionReset();
            LoadTransactionsFilters($('#TransactionsList'), urlLoadTransactionsFilters, bankAccountId);
        });
}

function ClearSearchInput() {
    $('#SearchTransactionByName').val('');
}

function HideSearchTransactionReset() {
    $('#SearchTransactionReset').css('display', 'none');
}

function ShowSearchTransactionReset() {
    $('#SearchTransactionReset').css('display', 'inline-block');
}

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