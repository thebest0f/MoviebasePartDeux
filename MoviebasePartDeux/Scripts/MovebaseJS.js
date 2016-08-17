$(document).ready(function () {


    $(function () {
        $("#txtSearch").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '/AutoComplete/GetMovieTitles',
                    data: { term: request.term },
                    dataType: "json",
                    type: "POST",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {label: item.MovieName, value: item.MovieName };
                        }))
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(errorThrown);
                    }
                });
            },
            minLength: 2
        });
    });

    $('#btnGoToMovie').click(function () {
        var text = $('#txtSearch').val();
        location.href = '/SingleMovie?MovieName='+text+'';
    });
});