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

function ChangeAccountBalanceListener() {
    $(document).on('change',
        '#Balance',
        function(balance) {
            //alert($(this).val());
            ChangeAccountBalance();
        });
}

function ChangeAccountBalance() {
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

        SetAccountBalanceInputValue(accountBalanceInput, result);
    }
}

function SetAccountBalanceInputValue(accountBalanceInput, valueToReplace) {
    //var accountBalanceInputVal = accountBalanceInput.val();
    var valueToSet = '@Model.AccountBalance';

    if (!(valueToReplace.indexOf('@Model.Currency') >= 0)) {
        valueToReplace += ' @Model.Currency';
        valueToSet = valueToReplace;
    }

    accountBalanceInput.val(valueToSet);
}

function GetAccountBalanceInputValue(accountBalanceInput) {
    var accountBalanceInputVal = accountBalanceInput.val();
    var valueToReturn = accountBalanceInputVal;

    if (accountBalanceInputVal.indexOf('@Model.Currency') >= 0) {
        var accountBalanceInputReplaceVal = accountBalanceInputVal.replace('@Model.Currency', '');
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

function SaveEditTransaction() {
    //alert('W AJAXIE');
    var viewModel = {
        Id: $('#Id').val().trim(),
        Name: $('#Name').val().trim(),
        Balance: $('#Balance').val().trim(),
        //AccountBalance: $('#AccountBalance').val().trim(),
        AccountBalance: GetAccountBalanceInputValue($('#AccountBalance')),
        SetDate: $('#SetDate').val().trim(),
        BankAccountId: $('#BankAccountId').val().trim(),
        UserId: $('#UserId').val().trim()
    };

    viewModel.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();

    $.ajax({
        url: '@Url.Action("Edit", "Transaction")',
        type: 'POST',
        dataType: 'json',
        data: viewModel,
        success: function(dataBack) {
            if (dataBack.status) {
                $('#Name').val('');
                $('#Balance').val('');
                //EditBankAccountBalance(GetAccountBalanceInputValue($('#AccountBalance')));
                $('#AccountBalance').val('');
                $('#SetDate').val('');
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
//    debugger;
//    $("#ModalContent").on('click', '#EditTransactionBtn', function (e) {
//        e.preventDefault();
//        EditTransaction();
//    });
//}

function EditTransactionListener() {
    $(document).on('click', '#EditTransactionBtn', function (e) {
        e.preventDefault();
        EditTransaction();
    });
}

function EditTransaction() {
    debugger;
    var button = $('#EditTransactionBtn');
    if (!(AreFieldsFilled())) {
        button.attr('data-dismiss', '');
        ValidationMessage();
        // alert("Nie wypełnione");
    }
    else {
        if (!(button.attr('data-dismiss').length > 0)) {
            button.attr('data-dismiss', 'modal');
            //alert("Wypełnione");
        }
        SaveEditTransaction();
    }
}

function AreFieldsFilled() {
    var valueToReturn = false;
    //var collectionOfInputs = $('#InputsToEdit :input');
    $('#InputsToEdit :input').each(function() {
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

function LoadValidation() {
    $(document).change(function () {
        $.validator.unobtrusive.parse("#ModalEditTransaction");
    });
}

function ValidationMessage() {
    debugger;
    var validationDiv = $('#ValidationInfo');
    // 1 cuz of button
    if (!(validationDiv.has('#ValidationInfoSpan').length > 0)) {
        validationDiv.prepend("<span id='ValidationInfoSpan' class='col-xs-6 col-md-6 text-danger'> Uzupełnij wszystkie pola!</span>");
    }
}

function BalanceControl() {
    var balance = $('#Balance');
    var onlyIntsRegExp = new RegExp('^(-?)[0-9]+$');

    balance.on('change',
        '#Balance',
        function() {
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

    //balance.change(function () {
    //    if (onlyIntsRegExp.test(balance.val())) {
    //        balance.val(balance.val() + ",00");
    //    }
    //    else if (balance.val().indexOf('.') !== -1) {
    //        balance.val(balance.val().replace('.', ','));
    //    }
    //    else {
    //        balance.val();
    //    }
    //});
}