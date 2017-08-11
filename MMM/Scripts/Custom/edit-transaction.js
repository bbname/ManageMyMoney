﻿
function EditTransactionListener(currency, urlPostActionToSave, urlGetActionLoadFilters) {
    $currencyVal = currency;
    $("#EditModalContent").on('click', '#EditTransactionBtn', function (e) {
        e.preventDefault();
        EditTransaction(urlPostActionToSave, urlGetActionLoadFilters);
    });
}

function LoadAmountValue(amount) {
    $amount = amount;
    $('#ModalEditTransaction #Balance').val(amount);
}

function ChangeEditAccountBalanceListener(accountBalanceVal, currency) {
    $(document).on('change',
        '#ModalEditTransaction #Balance',
        function(balance) {
            ChangeEditAccountBalance(accountBalanceVal, currency);
        });
}

function ChangeEditAccountBalance(accountBalanceVal, currency) {
    var amountInput = $('#ModalEditTransaction #Balance');
    var accountBalanceInput = $('#ModalEditTransaction #AccountBalance');

    if (CheckEditAmountInput(amountInput)) {
        var amountVal = amountInput.val();

        var firstAmountVal = $amount.replace(',', '.');
        amountVal = amountVal.replace(',', '.');
        accountBalanceVal = accountBalanceVal.replace(',', '.').trim();

        var firstResult = parseFloat(accountBalanceVal) - parseFloat(firstAmountVal);
        firstResult.toFixed(2);
        var result = parseFloat(firstResult) + parseFloat(amountVal);
        result = result.toFixed(2);

        result = result.toString().replace('.', ',');

        SetEditAccountBalanceInputValue(accountBalanceInput, result, accountBalanceVal, currency);
    }
}

function SetEditAccountBalanceInputValue(accountBalanceInput, valueToReplace, accountBalanceVal, currency) {
    var valueToSet = accountBalanceVal;

    if (!(valueToReplace.indexOf(currency) >= 0)) {
        valueToReplace += (' ' + currency);
        valueToSet = valueToReplace;
    }

    accountBalanceInput.val(valueToSet);
}

function GetEditAccountBalanceInputValue(accountBalanceInput) {
    var accountBalanceInputVal = accountBalanceInput.val();
    var valueToReturn = accountBalanceInputVal;

    if (accountBalanceInputVal.indexOf($currencyVal) >= 0) {
        var accountBalanceInputReplaceVal = accountBalanceInputVal.replace($currencyVal, '');
        valueToReturn = accountBalanceInputReplaceVal;
    }

    return valueToReturn;
}

function CheckEditAmountInput(amountInput) {
    var valueToReturn = false;
    var checkIfDecimal = new RegExp('^(-?)[0-9]+(\\,[0-9]{1,2})$');

    if (checkIfDecimal.test(amountInput.val())) {
        valueToReturn = true;
    }

    return valueToReturn;
}

function SaveEditTransaction(urlActionToEdit, urlGetActionLoadFilters) {
    var viewModel = {
        Id: $('#ModalEditTransaction #Id').val().trim(),
        Name: $('#ModalEditTransaction #Name').val().trim(),
        Balance: $('#ModalEditTransaction #Balance').val().trim(),
        AccountBalance: GetEditAccountBalanceInputValue($('#ModalEditTransaction #AccountBalance')),
        SetDate: $('#ModalEditTransaction #EditSetDate').val().trim(),
        BankAccountId: $('#ModalEditTransaction #BankAccountId').val().trim(),
        UserId: $('#ModalEditTransaction #UserId').val().trim()
    };

    viewModel.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();

    $.ajax({
        url: urlActionToEdit,
        type: 'POST',
        dataType: 'json',
        data: viewModel,
        success: function(dataBack) {
            if (dataBack.status) {
                $('#ModalEditTransaction #Name').val('');
                $('#ModalEditTransaction #Balance').val('');
                //EditBankAccountBalance(GetEditAccountBalanceInputValue($('#AccountBalance')));
                $('#ModalEditTransaction #AccountBalance').val('');
                $('#ModalEditTransaction #EditSetDate').val('');
                var transactionsDiv = $('#TransactionsList');
                LoadTransactionsFilters(transactionsDiv, urlGetActionLoadFilters, $('#ModalEditTransaction #BankAccountId').val().trim(),);
            }
        },
        error: function() {
            alert('Coś poszło nie tak przy wpisywaniu zmian transakcji do bazy danych.');
        }
    });

}

function EditTransaction(urlPostActionToSave, urlGetActionLoadFilters) {
    var button = $('#EditTransactionBtn');
    if (!(EditAreFieldsFilled())) {
        button.attr('data-dismiss', '');
        EditValidationMessage();
    }
    else {
        if (!(button.attr('data-dismiss').length > 0)) {
            button.attr('data-dismiss', 'modal');
        }
        SaveEditTransaction(urlPostActionToSave, urlGetActionLoadFilters);
    }
}

function EditAreFieldsFilled() {
    var valueToReturn = false;
    $('#ModalEditTransaction #InputsToEdit :input').each(function() {
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

function EditLoadValidation() {
    $(document).change(function () {
        $.validator.unobtrusive.parse("#ModalEditTransaction");
    });
}

function EditValidationMessage() {
    var validationDiv = $('#ModalEditTransaction #ValidationInfo');
    // 1 cuz of button
    if (!(validationDiv.has('#ValidationInfoSpan').length > 0)) {
        validationDiv.prepend("<span id='ValidationInfoSpan' class='col-xs-6 col-md-6 text-danger'> Uzupełnij wszystkie pola!</span>");
    }
}

function EditBalanceControl() {
    var balance = $('#ModalEditTransaction #Balance');
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