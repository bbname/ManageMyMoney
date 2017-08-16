﻿function PagingListener(urlGetAction, bankAccountId) {
    $('#pagingSystem').on('click', 'a', function (e) {
        e.preventDefault();
        
        if (!CheckIsActive($(this))) {
            var pageNr = GetPageNumber($(this).attr('href'));
            var transactionsListDiv = $('#TransactionsList');
            LoadTransactions(transactionsListDiv, urlGetAction, bankAccountId, pageNr);
        }

    });
}


function GetPageNumber(ahref) {
    var pageNr = ahref.split('?page=').pop();

    return pageNr;
}

function CheckIsActive(ahref) {
    var isActive = false;

    if (ahref.parent(".active").length) {
        isActive = true;
    }

    return isActive;
}