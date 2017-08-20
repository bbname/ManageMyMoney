function SelectProperLoadTransactions(urlGetActionFilters, urlGetActionFiltersBySearch, bankAccountId, currentPage = 1) {
    if (CheckIfSearch()) {
        LoadTransactionsFiltersBySearchName(urlGetActionFiltersBySearch, bankAccountId, currentPage);
    }
    else {
        LoadTransactionsFilters($('#TransactionsList'), urlGetActionFilters, bankAccountId, currentPage);
    }
}

function LoadTransactionsFiltersBySearchName(urlLoadTransactionsFiltersBySearchName, bankAccountId, page = 1) {
    $search = true;
    var outputDiv = $('#TransactionsList');
    outputDiv.wrap("<div id='TransactionListLoad'></div>");
    var loader = $('#TransactionListLoad');
    outputDiv.css('opacity', '0.0');
    loader.addClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
    if ($('#SearchSelectedItemsForPageId').length > 0
        && $('#SearchSelectedFilterId').length > 0) {
        $.ajax({
            url: urlLoadTransactionsFiltersBySearchName,
            type: 'GET',
            data: {
                bankAccountId: bankAccountId,
                name: $('#SearchTransactionByName').val(),
                toDate: $('#ToDate').val().trim(),
                fromDate: $('#FromDate').val().trim(),
                selectedItemsForPage: $('#SearchSelectedItemsForPageId').val().trim(),
                selectedFilterId: $('#SearchSelectedFilterId').val().trim(),
                page: page
            },
            success: function (data) {
                loader.removeClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
                outputDiv.unwrap();
                outputDiv.css('opacity', '1.0');
                outputDiv.html(data);
                ShowSearchTransactionReset();
            },
            error: function () {
                alert('Nie zadziałało odnalezienie wielu transakcji po nazwie.');
            }
        }); 
    }
    else {
        $.ajax({
            url: urlLoadTransactionsFiltersBySearchName,
            type: 'GET',
            data: {
                bankAccountId: bankAccountId,
                name: $('#SearchTransactionByName').val(),
                selectedItemsForPage: $('#SelectedItemsForPageId').val().trim(),
                page: page
            },
            success: function (data) {
                loader.removeClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
                outputDiv.unwrap();
                outputDiv.css('opacity', '1.0');
                outputDiv.html(data);
                ShowSearchTransactionReset();
            },
            error: function () {
                alert('Nie zadziałało odnalezienie wielu transakcji po nazwie.');
            }
        }); 
    }

}

function LoadTransactionBySearchName(urlGetAction, transactionName, bankAccountId) {
    var outputDiv = $('#TransactionsList');
    outputDiv.wrap("<div id='TransactionListLoad'></div>");
    var loader = $('#TransactionListLoad');
    outputDiv.css('opacity', '0.0');
    loader.addClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");

    $.ajax({
        url: urlGetAction,
        type: 'GET',
        data: {
            bankAccountId: bankAccountId,
            name: transactionName
        },
        success: function(data) {
            loader.removeClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
            outputDiv.unwrap();
            outputDiv.css('opacity', '1.0');
            outputDiv.html(data);
            ShowSearchTransactionReset();
        },
        error: function() {
            alert('Nie zadziałało odnalezienie transakcji po nazwie.');
        }
    });
}

function SearchLoadTransactionsFiltersListener(urlGetAction, bankAccountId) {
    $('#TransactionListFilters').on('change',
        '#SearchSelectedItemsForPageId, #SearchSelectedFilterId',
        function () {
            LoadTransactionsFiltersBySearchName(urlGetAction, bankAccountId);
        });
}

function ClearDateFromToInputsListener(urlGetActionFilters, urlGetActionFiltersBySearch, bankAccountId) {
    $('#TransactionListFilters').on('click',
        '#ClearFromToDateBtn',
        function () {
            ClearDateFromToInputs(urlGetActionFilters, urlGetActionFiltersBySearch, bankAccountId);
        });
}

function ClearDateFromToInputs(urlGetActionFilters, urlGetActionFiltersBySearch, bankAccountId) {
    var wereFilled = DateFromToCheckInputs();
    $('#FromDate').val('');
    $('#ToDate').val('');

    if (wereFilled) {
        SelectProperLoadTransactions(urlGetActionFilters, urlGetActionFiltersBySearch, bankAccountId);
    }
}

function DateFromToFilterListener(outputDiv, urlGetAction, urlGetSearchAction, bankAccountId) {
    $('#TransactionListFilters').on('change',
        '#FromDate, #ToDate',
        function () {
            if (CheckIfSearch()
                && DateFromToCheckInputs()) {
                LoadTransactionsFiltersBySearchName(urlGetSearchAction, bankAccountId);
            }
            else {
                if (DateFromToCheckInputs()) {
                    LoadTransactionsFilters(outputDiv, urlGetAction, bankAccountId);
                }
            }
        });
}

function DateFromToCheckInputs() {
    var dateFrom = $('#FromDate');
    var dateTo = $('#ToDate');
    var areFilled = false;

    if (dateFrom.val() && dateTo.val()) {
        areFilled = true;
    }

    return areFilled;
}

function LoadTransactionsFiltersListener(outputDiv, urlGetAction, bankAccountId) {
    $('#TransactionListFilters').on('change',
        '#SelectedItemsForPageId, #SelectedFilterId',
        function () {
            LoadTransactionsFilters(outputDiv, urlGetAction, bankAccountId);
        });
}

function LoadTransactionsFilters(outputDiv, urlGetAction, bankAccountId, page = 1) {
    $search = false;

    outputDiv.wrap("<div id='TransactionListLoad'></div>");
    var loader = $('#TransactionListLoad');
    outputDiv.css('opacity', '0.0');
    loader.addClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
    $.ajax({
        url: urlGetAction,
        type: 'GET',
        data: {
            bankAccountId: bankAccountId,
            toDate: $('#ToDate').val().trim(),
            fromDate: $('#FromDate').val().trim(),
            selectedItemsForPage: $('#SelectedItemsForPageId').val().trim(),
            selectedFilterId: $('#SelectedFilterId').val().trim(),
            page: page
        },
        success: function (dataBack) {
            loader.removeClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
            outputDiv.unwrap();
            outputDiv.css('opacity', '1.0');
            outputDiv.html(dataBack);
            HideSearchTransactionReset();
        },
        error: function () {
            alert('Coś poszło nie tak przy pobieraniu danych poprzez filtry.');
        }
    });
}


function LoadTransactions(outputDiv, urlGetAction, bankAccountId, page = 1) {
    outputDiv.wrap("<div id='TransactionListLoad'></div>");
    var loader = $('#TransactionListLoad');
    outputDiv.css('opacity', '0.0');
    loader.addClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
    var selectedIdItemsForPage = $('#SelectedItemsForPageId').val().trim();

    $.ajax({
        url: urlGetAction,
        type: 'GET',
        data: {
            bankAccountId: bankAccountId,
            page: page,
            selectedItemsForPage: selectedIdItemsForPage
        },
        success: function (data) {
            loader.removeClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
            outputDiv.unwrap();
            outputDiv.css('opacity', '1.0');
            outputDiv.html(data);
        },
        error: function () {
            alert('Nie zadziałało pageowanie.');
        }
    });
}