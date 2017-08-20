function SearchTransactionListener(urlGetSearchTransactionAction, urlLoadTransactionBySearchName, bankAccountId) {
    $('#SearchTransaction').on('#SearchTransactionByName input',
        function() {
            SearchTransaction(urlGetSearchTransactionAction, urlLoadTransactionBySearchName, bankAccountId);
        });
}

function SearchTransactionsFiltersBtnListener(urlLoadTransactionsFiltersBySearchName, bankAccountId, page) {
    $('#SearchTransaction').on('click',
        '#SearchTransactionsByNameBtn',
        function () {
            $search = true;
            SearchTransactionsFilters(urlLoadTransactionsFiltersBySearchName, bankAccountId, page);
        });
}

function SearchTransactionsFilters(urlLoadTransactionsFiltersBySearchName, bankAccountId) {
    if (!CheckIfSearchIsEmpty()) {
        LoadTransactionsFiltersBySearchName(urlLoadTransactionsFiltersBySearchName,
            bankAccountId);
        AddSearchToFiltersIds(GetFilterInputs());
    }
}

function SearchTransaction(urlGetSearchTransactionAction, urlLoadTransactionBySearchName, bankAccountId) {
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

function GetFilterInputs() {
    var filterInputs = $('#SelectedItemsForPageId');
    filterInputs = filterInputs.add($('#SelectedFilterId'));

    return filterInputs;
}

function GetSearchFilterInputs() {
    var filterInputs = $('#SearchSelectedItemsForPageId');
    filterInputs = filterInputs.add($('#SearchSelectedFilterId'));

    return filterInputs;
}

function AddSearchToFiltersIds(filterInputs) {
    filterInputs.each(function() {
        var currentInput = $(this);
        var currentInputId = currentInput.attr('id');
        var changedInputId = 'Search' + currentInputId;
        currentInput.attr('id', changedInputId);
    });
}

function RemoveSearchFromFiltersIds(filterInputs) {
    filterInputs.each(function () {
        var currentInput = $(this);
        var currentInputId = currentInput.attr('id');
        var changedInputId = currentInputId.replace('Search', '');
        currentInput.attr('id', changedInputId);
    });
}

function LoadTransactionBtnListener(urlLoadTransactionsFilters, bankAccountId) {
    $('#SearchTransactionReset').on('click',
        '#LoadTransactionBtn',
        function () {
            $search = false;
            HideSearchTransactionReset();
            RemoveSearchFromFiltersIds(GetSearchFilterInputs());
            LoadTransactionsFilters($('#TransactionsList'), urlLoadTransactionsFilters, bankAccountId);
        });
}

function ClearSearchInput() {
    $('#SearchTransactionByName').val('');
}

function HideSearchTransactionReset() {
    $('#SearchTransactionReset').css('display', 'none');
    ClearSearchInput();
}

function ShowSearchTransactionReset() {
    $('#SearchTransactionReset').css('display', 'inline-block');
}

function CheckIfSearchIsEmpty() {
    var isEmpty = false;

    if ($('#SearchTransactionByName').val().length === 0) {
        isEmpty = true;
    }

    return isEmpty;
}


function CheckIfSearch() {
    var isSearch = false;

    if ($search
        && $('#SearchTransactionReset').css('display') != 'none'
        && $('#SearchSelectedFilterId').length > 0
        && $('#SearchSelectedItemsForPageId').length > 0) {
        isSearch = true;
    }

    return isSearch;
}