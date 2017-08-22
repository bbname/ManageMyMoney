function TransactionCreateOpenModalListener(urlGetAction, bankAccountId, userId) {
    $('#TransactionListFilters').on('click',
        '#CreateTransaction',
        function() {
            GetTransactionCreateData(urlGetAction, bankAccountId, userId);
        });
}

function LoadDataIntoModalCreateAndOpen(data) {
    $('#ModalCreateTransaction .modal-dialog').html(data);
    $('#ModalCreateTransaction').modal('show');
}

function TransactionDetailsOpenModalListener(urlGetAction, bankAccountId) {
    $('.panel-heading, .transaction-info').on('click',
        '.transaction-header-title, .transaction-body',
        function() {
            GetTransactionDetailsData(urlGetAction, $(this).attr('id'), bankAccountId);
        });
}

function LoadDataIntoModalDetailsAndOpen(data) {
    $('#ModalDetailsTransaction .modal-dialog').html(data);
    $('#ModalDetailsTransaction').modal('show');
}

function TransactionEditOpenModalListener(urlGetAction, bankAccountId, userId) {
    $('.panel-heading').on('click',
        '.transaction-header-edit',
        function () {
            GetTransactionEditData(urlGetAction, $(this).attr('id'), bankAccountId, userId);
        });
}

function LoadDataIntoModalEditAndOpen(data) {
    $('#ModalEditTransaction .modal-dialog').html(data);
    $('#ModalEditTransaction').modal('show');
}

function TransactionDeleteOpenModalListener(urlGetAction, bankAccountId) {
    $('.panel-heading').on('click',
        '.transaction-header-remove',
        function () {
            GetTransactionDeleteData(urlGetAction, $(this).attr('id'), bankAccountId);
        });
}

function LoadDataIntoModalDeleteAndOpen(data) {
    $('#ModalDeleteTransaction .modal-dialog').html(data);
    $('#ModalDeleteTransaction').modal('show');
}