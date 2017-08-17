function GetCurrentPageNumber() {
    debugger;
    var currentPageNr = $('#pagingSystem .pagination .active a').text().trim();

    return currentPageNr;
}

function PagingListener(urlGetAction, bankAccountId) {
    $('#pagingSystem').on('click', 'a', function (e) {
        e.preventDefault();
        
        if (!CheckIsActive($(this))) {
            var pageNr = GetPageNumberFromHref($(this).attr('href'));
            var transactionsListDiv = $('#TransactionsList');
            //LoadTransactions(transactionsListDiv, urlGetAction, bankAccountId, pageNr);
            LoadTransactionsFilters(transactionsListDiv, urlGetAction, bankAccountId, pageNr);
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