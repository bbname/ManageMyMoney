function PagingListener(urlGetAction, bankAccountId) {
    $('#pagingSystem').on('click', 'a', function (e) {
        //debugger;
        e.preventDefault();
        
        var pageNr = GetPageNumber($(this).attr('href'));
        var transactionsListDiv = $('#TransactionsList');

        LoadTransactions(transactionsListDiv, urlGetAction, bankAccountId, pageNr);
    });
}


function GetPageNumber(ahref) {
    var pageNr = ahref.split('?page=').pop();

    return pageNr;
}

//function CheckIsActive(ahref) {
//    ahref.parent()
//}