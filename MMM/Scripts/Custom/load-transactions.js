﻿function LoadTransactionsFiltersBySearchName(urlLoadTransactionsFiltersBySearchName, bankAccountId, page = 1) {
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

//function SearchDateFromToFilterListener(urlGetAction, bankAccountId) {
//    $('#TransactionListFilters').on('change',
//        '#SearchFromDate, #SearchToDate',
//        function () {
//            SearchDateFromToCheck(urlGetAction, bankAccountId);
//        });
//}

//function SearchDateFromToCheck(urlGetAction, bankAccountId) {
//    var searchDateFrom = $('#SearchFromDate');
//    var searchDateTo = $('#SearchToDate');

//    if (searchDateFrom.val() && searchDateTo.val()) {
//        LoadTransactionsFiltersBySearchName(urlGetAction, bankAccountId);
//    }
//}

function SearchLoadTransactionsFiltersListener(urlGetAction, bankAccountId) {
    $('#TransactionListFilters').on('change',
        '#SearchSelectedItemsForPageId, #SearchSelectedFilterId',
        function () {
            LoadTransactionsFiltersBySearchName(urlGetAction, bankAccountId);
        });
}

function DateFromToCheckIfSearch() {
    debugger;
    var isSearch = false;

    if ($search
        && $('#SearchTransactionReset').css('display') != 'none'
        && $('#SearchSelectedFilterId').length > 0
        && $('#SearchSelectedItemsForPageId').length > 0) {
        isSearch = true;
    }

    return isSearch;
}

function ClearDateFromToInputsListener() {
    $('#TransactionListFilters').on('click',
        '#ClearFromToDateBtn',
        function () {
            ClearDateFromToInputs();
        });
}

function ClearDateFromToInputs() {
    $('#FromDate').val('');
    $('#ToDate').val('');
}

function DateFromToFilterListener(outputDiv, urlGetAction, urlGetSearchAction, bankAccountId) {
    $('#TransactionListFilters').on('change',
        '#FromDate, #ToDate',
        function () {
            if (DateFromToCheckIfSearch()
                && DateFromToCheckInputs()) {
                LoadTransactionsFiltersBySearchName(urlGetSearchAction, bankAccountId);
            }
            else {
                //DateFromToCheck(outputDiv, urlGetAction, bankAccountId);
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

//function DateFromToCheck(outputDiv, urlGetAction, bankAccountId) {
//    var dateFrom = $('#FromDate');
//    var dateTo = $('#ToDate');

//    if (dateFrom.val() && dateTo.val()) {
//        LoadTransactionsFilters(outputDiv, urlGetAction, bankAccountId);
//    }
//}

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