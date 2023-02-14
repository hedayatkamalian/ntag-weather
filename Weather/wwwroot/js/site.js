// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$('.basicAutoComplete').autoComplete({
//    //resolverSettings: {
//    //    url: 'weatherController/index'
//    //}
//});


function doit()
{
    $('.basicAutoSelect').typeahead({
        minLength: 1,
        source: function (request, response) {
            $.ajax({
                url: "/api/cities/",
                data: {
                    "q": request
                },
                type: "GET",
                contentType: "json",
                success: function (data) {
                    items = [];
                    map = {};
                    $.each(data, function (i, item) {
                        var id = item.Name;
                        var name = item.Name;
                        map[name] = {
                            id: id,
                            name: name
                        };
                        items.push(name);
                    });
                    response(items);
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        updater: function (item) { }
    })
}

$(document).ready(function () {

    //$('.basicAutoSelect').autoComplete({
    //    resolverSettings: {
    //        url: '/api/cities',

    //    }
    //});
    doit();
})

