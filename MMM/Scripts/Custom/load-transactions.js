﻿function LoadTransactions(outputDiv, urlGetAction) {
    outputDiv.wrap("<div id='TransactionListLoad'></div>");
    var loader = $('#TransactionListLoad');
    outputDiv.css('opacity', '0.0');
    loader.addClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
    $.get(
        urlGetAction,
        function (data) {
            loader.removeClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
            outputDiv.unwrap();
            outputDiv.css('opacity', '1.0');
            outputDiv.html(data);
        });
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

function DateFromToFilterListener(outputDiv, urlGetAction, bankAccountId) {
    $('#TransactionListFilters').on('change',
        '#FromDate, #ToDate',
        function () {
            DateFromToCheck(outputDiv, urlGetAction, bankAccountId);
        });
}

function DateFromToCheck(outputDiv, urlGetAction, bankAccountId) {
    var dateFrom = $('#FromDate');
    var dateTo = $('#ToDate');

    if (dateFrom.val() && dateTo.val()) {
        LoadTransactionsFilters(outputDiv, urlGetAction, bankAccountId);
    }
}

function LoadTransactionsFiltersListener(outputDiv, urlGetAction, bankAccountId) {
    $('#TransactionListFilters').on('change',
        '#SelectedItemsForPageId, #SelectedFilterId',
        function () {
            LoadTransactionsFilters(outputDiv, urlGetAction, bankAccountId);
        });
}

function LoadTransactionsFilters(outputDiv, urlGetAction, bankAccountId) {
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
            selectedFilterId: $('#SelectedFilterId').val().trim()
        },
        success: function (dataBack) {
            loader.removeClass("loader col-xs-offset-6 col-sm-offset-6 col-md-offset-6");
            outputDiv.unwrap();
            outputDiv.css('opacity', '1.0');
            outputDiv.html(dataBack);
        },
        error: function () {
            alert('Coś poszło nie tak przy pobieraniu danych poprzez filtry.');
        }
    });
}