//$(document).ready(function () {
//    LoadValidation();
//    EditTransactionListener();
//    BalanceControl();
//    ChangeAccountBalanceListener();

//    $(function () {
//        $("#SetDate").datetimepicker({
//            showAnim: 'slideDown',
//            oneLine: true,
//            dateFormat: 'dd.mm.yy',
//            controlType: 'select',
//            timeFormat: 'HH:mm'
//        });
//    });
//});


//function ChangeAccountBalanceListener() {
//    $('#ModalContent').on('change',
//        '#Balance',
//        function(balance) {
//            //alert($(this).val());
//            ChangeAccountBalance();
//        });
//}

function LoadAmountValue(amount) {
    $amount = amount;
    $('#ModalEditTransaction #Balance').val(amount);
}

function ChangeEditAccountBalanceListener(accountBalanceVal, currency) {
    $(document).on('change',
        '#ModalEditTransaction #Balance',
        function(balance) {
            //alert($(this).val());
            ChangeEditAccountBalance(accountBalanceVal, currency);
        });
}

function ChangeEditAccountBalance(accountBalanceVal, currency) {
    debugger;
    $currencyVal = currency;
    var amountInput = $('#ModalEditTransaction #Balance');
    var accountBalanceInput = $('#ModalEditTransaction #AccountBalance');

    if (CheckAmountInput(amountInput)) {
        var amountVal = amountInput.val();
        //var accountBalanceVal = GetAccountBalanceInputValue(accountBalanceInput);
        //var accountBalanceVal = '@*@Model.AccountBalance*@';

        //var accountBalanceVal = $('#ModalEditTransaction #AccountBalance').val().trim();

        var firstAmountVal = $amount.replace(',', '.');
        amountVal = amountVal.replace(',', '.');
        accountBalanceVal = accountBalanceVal.replace(',', '.').trim();

        var firstResult = parseFloat(accountBalanceVal) - parseFloat(firstAmountVal);
        firstResult.toFixed(2);
        //var result = parseFloat(accountBalanceVal) + parseFloat(amountVal);
        var result = parseFloat(firstResult) + parseFloat(amountVal);
        result = result.toFixed(2);

        result = result.toString().replace('.', ',');

        SetAccountBalanceInputValue(accountBalanceInput, result, accountBalanceVal, currency);
    }
}

function SetAccountBalanceInputValue(accountBalanceInput, valueToReplace, accountBalanceVal, currency) {
    //var accountBalanceInputVal = accountBalanceInput.val();
    //var valueToSet = '@Model.AccountBalance';
    var valueToSet = accountBalanceVal;

    if (!(valueToReplace.indexOf(currency) >= 0)) {
        valueToReplace += (' ' + currency);
        valueToSet = valueToReplace;
    }

    accountBalanceInput.val(valueToSet);
}

function GetAccountBalanceInputValue(accountBalanceInput) {
    var accountBalanceInputVal = accountBalanceInput.val();
    var valueToReturn = accountBalanceInputVal;

    if (accountBalanceInputVal.indexOf($currencyVal) >= 0) {
        var accountBalanceInputReplaceVal = accountBalanceInputVal.replace($currencyVal, '');
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

function SaveEditTransaction(urlActionToEdit) {
    //alert('W AJAXIE');
    debugger;
    var viewModel = {
        Id: $('#ModalEditTransaction #Id').val().trim(),
        Name: $('#ModalEditTransaction #Name').val().trim(),
        Balance: $('#ModalEditTransaction #Balance').val().trim(),
        //AccountBalance: $('#AccountBalance').val().trim(),
        AccountBalance: GetAccountBalanceInputValue($('#ModalEditTransaction #AccountBalance')),
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
                //EditBankAccountBalance(GetAccountBalanceInputValue($('#AccountBalance')));
                $('#ModalEditTransaction #AccountBalance').val('');
                $('#ModalEditTransaction #EditSetDate').val('');
                var transactionsDiv = $('#TransactionsList');
                LoadTransactionsFilters(transactionsDiv);
                //LoadTransactions(transactionsDiv);
            }
        },
        error: function() {
            alert('Coś poszło nie tak przy wpisywaniu zmian transakcji do bazy danych.');
        }
    });

}


//function EditTransactionListener() {
//    $("#ModalEditTransaction").on('click', '#EditTransactionBtn', function (e) {
//        debugger;
//        e.preventDefault();
//        EditTransaction();
//    });
//}

//function EditTransactionListener() {
//    $(document).on('click', '#EditTransactionBtn', function (e) {
//        e.preventDefault();
//        EditTransaction();
//    });
//}

function EditTransaction(urlPostActionToSave) {
    debugger;
    var button = $('#EditTransactionBtn');
    if (!(EditAreFieldsFilled())) {
        button.attr('data-dismiss', '');
        EditValidationMessage();
        // alert("Nie wypełnione");
    }
    else {
        if (!(button.attr('data-dismiss').length > 0)) {
            button.attr('data-dismiss', 'modal');
            //alert("Wypełnione");
        }
        SaveEditTransaction(urlPostActionToSave);
    }
}

function EditAreFieldsFilled() {
    var valueToReturn = false;
    //var collectionOfInputs = $('#InputsToEdit :input');
    $('#ModalEditTransaction #InputsToEdit :input').each(function() {
        var element = $(this);
        if (!(element.val().length > 0)) {
            //alert('- ' + element.val().length);
            valueToReturn = false;
            return false;
        }
        else {
            //alert(element.val().length);
            valueToReturn = true;
        }
    });
    return valueToReturn;
}

//function LoadValidation() {
//    $('#ModalContent').change(function () {
//        $.validator.unobtrusive.parse("#ModalEditTransaction");
//    });
//}

function EditLoadValidation() {
    $(document).change(function () {
        $.validator.unobtrusive.parse("#ModalEditTransaction");
    });
}

function EditValidationMessage() {
    debugger;
    var validationDiv = $('#ModalEditTransaction #ValidationInfo');
    // 1 cuz of button
    if (!(validationDiv.has('#ValidationInfoSpan').length > 0)) {
        validationDiv.prepend("<span id='ValidationInfoSpan' class='col-xs-6 col-md-6 text-danger'> Uzupełnij wszystkie pola!</span>");
    }
}

function EditBalanceControl() {
    var balance = $('#ModalEditTransaction #Balance');
    var onlyIntsRegExp = new RegExp('^(-?)[0-9]+$');

    //balance.on('change',
    //    '#Balance',
    //    function() {
    //        if (onlyIntsRegExp.test(balance.val())) {
    //            balance.val(balance.val() + ",00");
    //        }
    //        else if (balance.val().indexOf('.') !== -1) {
    //            balance.val(balance.val().replace('.', ','));
    //        }
    //        else {
    //            balance.val();
    //        }
    //    });

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