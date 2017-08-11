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