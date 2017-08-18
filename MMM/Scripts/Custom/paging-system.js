function GetCurrentPageNumber() {
    var currentPageNr = $('#pagingSystem .pagination .active a').text().trim();

    return currentPageNr;
}

function PagingListener(urlGetAction, urlGetActionSearch, bankAccountId) {
    $('#pagingSystem').on('click', 'a', function (e) {
        e.preventDefault();
        
        if (!CheckIsActive($(this))) {
            var pageNr = GetPageNumberFromHref($(this).attr('href'));
            var transactionsListDiv = $('#TransactionsList');
            //LoadTransactions(transactionsListDiv, urlGetAction, bankAccountId, pageNr);
            if (!$search) {
                LoadTransactionsFilters(transactionsListDiv, urlGetAction, bankAccountId, pageNr);
            }
            else {
                LoadTransactionsFiltersBySearchName(urlGetActionSearch,
                    $('#SearchTransactionByName').val(),
                    bankAccountId,
                    pageNr);
            }
        }

    });
}

function GetPageNumberFromHref(ahref) {
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