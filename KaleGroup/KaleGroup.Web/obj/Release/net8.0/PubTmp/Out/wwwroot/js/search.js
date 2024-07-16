const search = {
    variables: {
        nodeId: 0,
        searchUrl: ''
    },
    init: function (variables) {
        search.variables = variables;
        search.initDesktopSearch();
        search.initMobileSearch();
    },
    initDesktopSearch: function () {

        let searchTimer;
        let variables = search.variables;
        let searchBox = $('.search-box');
        let searchTextInput = $(searchBox.find('input[name=searchText]'));
        let allResultsButton = $(searchBox.find("#all-results"));
        let searchResultContainer = $(searchBox.find('#search-results'));

        searchTextInput.keyup(function () {
            clearInterval(searchTimer);
            const searchText = $(this).val();

            if (searchText.length < 3) {
                searchResultContainer.html("");
                allResultsButton.addClass("d-none");
                return;
            }

            searchTimer = setInterval(function () {

                $.get(variables.searchUrl, {searchText: searchText, nodeId: variables.nodeId},
                    function (response) {
                        searchResultContainer.html(response);
                        allResultsButton.removeClass("d-none");
                    });

                clearInterval(searchTimer);
            }, 100);
        });
    },
    initMobileSearch: function () {

        let searchTimer;
        let variables = search.variables;
        let searchBox = $('.search-box-mobile');
        let searchTextInput = $(searchBox.find('input[name=searchText]'));
        let allResultsButton = $(searchBox.find("#all-results-mobile"));
        let searchResultContainer = $(searchBox.find('#search-results-mobile'));

        searchTextInput.keyup(function () {
            clearInterval(searchTimer);
            const searchText = $(this).val();

            if (searchText.length < 3) {
                searchResultContainer.html("");
                allResultsButton.addClass("d-none");
                return;
            }

            searchTimer = setInterval(function () {

                $.get(variables.searchUrl, {searchText: searchText, nodeId: variables.nodeId},
                    function (response) {
                        searchResultContainer.html(response);
                        allResultsButton.removeClass("d-none");
                    });

                clearInterval(searchTimer);
            }, 100);
        });
    }
};