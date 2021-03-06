﻿function LoadCurrentBankAccountBalanceListener(modelAccountBalanceValue, modelCurrency) {
    $('#TransactionListFilters').on('click',
        '#CreateTransaction',
        function() {
            LoadCurrentBankAccountBalance(modelAccountBalanceValue, modelCurrency);
        });
}

function LoadCurrentBankAccountBalance(modelAccountBalanceValue, modelCurrency) {
    SetAccountBalanceInputValue($('#AccountBalance'),
        $('#BankAccountBalance').text().trim(),
        modelAccountBalanceValue,
        modelCurrency);
}

function ChangeAccountBalanceListener(modelAccountBalanceValue, modelCurrency) {
    $('#ModalContent').on('change',
        '#Balance',
        function () {
            ChangeAccountBalance(modelAccountBalanceValue, modelCurrency);
        });
}

function ChangeAccountBalance(modelAccountBalanceValue, modelCurrency) {
    $currencyValue = modelCurrency;
    var amountInput = $('#Balance');
    var accountBalanceInput = $('#AccountBalance');

    if (CheckAmountInput(amountInput)) {
        var amountVal = amountInput.val();
        //var accountBalanceVal = GetAccountBalanceInputValue(accountBalanceInput);
        //var accountBalanceVal = '@*@Model.AccountBalance*@';
        var accountBalanceVal = $('#BankAccountBalance').text().trim();

        amountVal = amountVal.replace(',', '.');
        accountBalanceVal = accountBalanceVal.replace(',', '.').trim();

        var result = parseFloat(accountBalanceVal) + parseFloat(amountVal);
        result = result.toFixed(2);

        result = result.toString().replace('.', ',');

        SetAccountBalanceInputValue(accountBalanceInput, result, modelAccountBalanceValue, modelCurrency);
    }
}

function SetAccountBalanceInputValue(accountBalanceInput, valueToReplace, modelAccountBalanceValue, modelCurrency) {
    if (modelCurrency == '&#163;') {
        modelCurrency = decodeURI('%C2%A3');
    }
    else if (modelCurrency == '&#165;') {
        modelCurrency = decodeURI('%C2%A5');
    }

    //var accountBalanceInputVal = accountBalanceInput.val();
    var valueToSet = modelAccountBalanceValue;

    if (!(valueToReplace.indexOf(modelCurrency) >= 0)) {
        valueToReplace += (' ' + modelCurrency);
        valueToSet = valueToReplace;
    }

    accountBalanceInput.val(valueToSet);
}

function GetAccountBalanceInputValue(accountBalanceInput) {
    var accountBalanceInputVal = accountBalanceInput.val();
    var valueToReturn = accountBalanceInputVal;

    if ($currencyValue == '&#163;') {
        $currencyValue = decodeURI('%C2%A3');
    }
    else if ($currencyValue == '&#165;') {
        $currencyValue = decodeURI('%C2%A5');
    }

    if (accountBalanceInputVal.indexOf($currencyValue) >= 0) {
        var accountBalanceInputReplaceVal = accountBalanceInputVal.replace($currencyValue, '');
        valueToReturn = accountBalanceInputReplaceVal;
    }

    return valueToReturn;
}

function CheckAmountInput(amountInput) {
    var valueToReturn = false;
    var checkIfDecimal = new RegExp('^(-?)[0-9]+(\\,[0-9]{1,2})$');

    if (checkIfDecimal.test(amountInput.val())) {
        valueToReturn = true;
    }

    return valueToReturn;
}

function SaveTransaction(urlActionToAdd, urlActionToEditBankAccount, urlGetActionLoadFilters, urlGetActionLoadFiltersBySearchName) {
    //alert('W AJAXIE');
    var viewModel = {
        Name: $('#Name').val().trim(),
        Balance: $('#Balance').val().trim(),
        //AccountBalance: $('#AccountBalance').val().trim(),
        AccountBalance: GetAccountBalanceInputValue($('#AccountBalance')),
        SetDate: $('#SetDate').val().trim(),
        Description: $('#Description').val().trim(),
        BankAccountId: $('#BankAccountId').val().trim(),
        UserId: $('#UserId').val().trim()
    };

    viewModel.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();

    $.ajax({
        url: urlActionToAdd,
        type: 'POST',
        dataType: 'json',
        data: viewModel,
        success: function (dataBack) {
            if (dataBack.status) {
                $('#Name').val('');
                $('#Balance').val('');
                EditBankAccountBalance(urlActionToEditBankAccount, GetAccountBalanceInputValue($('#AccountBalance')), $('#UserId').val().trim(), true);
                $('#SetDate').val('');
                $('#Description').val('');
                SelectProperLoadTransactions(urlGetActionLoadFilters,
                    urlGetActionLoadFiltersBySearchName,
                    $('#BankAccountId').val().trim(),
                    GetCurrentPageNumber());
            }
        },
        error: function () {
            alert('Coś poszło nie tak przy wpisywaniu transakcji do bazy danych.');
        }
    });

}

function AddTransactionListener(urlPostActionToSave, urlPostActionToEditBankAccount, urlGetActionLoadFilters, urlGetActionLoadFiltersBySearchName) {
    $("#ModalContent").on('click', '#AddTransactionBtn', function (e) {
        e.preventDefault();
        AddTransaction(urlPostActionToSave, urlPostActionToEditBankAccount, urlGetActionLoadFilters, urlGetActionLoadFiltersBySearchName);
    });
}

function AddTransaction(urlPostActionToSave, urlPostActionToEditBankAccount, urlGetActionLoadFilters, urlGetActionLoadFiltersBySearchName) {
    var button = $('#AddTransactionBtn');
    if (!(AreFieldsFilled())) {
        button.attr('data-dismiss', '');
        ValidationMessage();
    }
    else {
        if (!(button.attr('data-dismiss').length > 0)) {
            button.attr('data-dismiss', 'modal');
        }
        SaveTransaction(urlPostActionToSave, urlPostActionToEditBankAccount, urlGetActionLoadFilters, urlGetActionLoadFiltersBySearchName);
    }
}

function AreFieldsFilled() {
    var valueToReturn = false;
    $('#InputsToEdit :input').each(function () {
        var element = $(this);
        if (!(element.val().length > 0)) {
            valueToReturn = false;
            return false;
        }
        else {
            valueToReturn = true;
        }
    });
    return valueToReturn;
}

function LoadValidation() {
    $('#ModalContent').change(function () {
        $.validator.unobtrusive.parse("#ModalCreateTransaction");
    });
}

function ValidationMessage() {
    var validationDiv = $('#ValidationInfo');
    // 1 cuz of button
    if (!(validationDiv.has('#ValidationInfoSpan').length > 0)) {
        validationDiv.prepend("<span id='ValidationInfoSpan' class='col-xs-6 col-md-6 text-danger'> Uzupełnij wszystkie pola!</span>");
    }
}

function BalanceControl() {
    var balance = $('#Balance');
    var onlyIntsRegExp = new RegExp('^(-?)[0-9]+$');
    balance.change(function () {
        if (onlyIntsRegExp.test(balance.val())) {
            balance.val(balance.val() + ",00");
        }
        else if (balance.val().indexOf('.') !== -1) {
            balance.val(balance.val().replace('.', ','));
        }
        else {
            balance.val();
        }
    });
}