
$(document).ready(function () {

    $("#search").typeahead({
        hint: true,
        highlight: true,
        minLength: 3,
        limit:1,
        source: function (request, response) {
            $.ajax({
                url: '/api/cities/by-name',
                data: { "name": request },
                dataType: "json",
                type: "GET",

                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    items = [];
                    map = {};
                    $.each(data, function (i, item) {
                        map[item.name] = { id: item.id, name: item.name };
                        items.push(item.name);
                    });
                    response(items);
                },
                error: function (response) {
                    console.write(response.responseText);
                },
                failure: function (response) {
                    console.write(response.responseText);
                }
            });
        },
        updater: function (item) {

            getWeatherDataByCityId(map[item].id);
            return item;
        }
    });



    $('#map').locationpicker({
        location: { latitude: 50.9848, longitude: 11.0299 },
        radius: 10,
        inputBinding: {
            latitudeInput: $('#location-lat'),
            longitudeInput: $('#location-lng'),
        },
        enableAutocomplete: true,
        onchanged: function (currentLocation, radius, isMarkerDropped) {

        }
    });

})

function getWeatherDataByCityId(id) {

    $.ajax({
        url: '/api/weather/by-city-id',
        data: { "id": id },
        dataType: "json",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            updateData(data)
        },
        error: function (response) {
            console.write(response.responseText);
        },
        failure: function (response) {
            console.write(response.responseText);
        }
    });

}

function getWeatherDataByLocation(location) {

    $.ajax({
        url: '/api/weather/by-location',
        data: { "latitude": location.latitude, "longtitude": location.longtitude },
        dataType: "json",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            updateData(data)
        },
        error: function (response) {
            console.write(response.responseText);
        },
        failure: function (response) {
            console.write(response.responseText);
        }
    });

}

function updateData(data) {

    $('#result-table').collapse('show');
    Object.keys(data).map((k) => {

        if (k !== 'icon') {
            $('#result-' + k).html(data[k])
        }
        else {
            $('#result-icon').attr('src', 'http://openweathermap.org/img/wn/' + data[k] + '@2x.png');
        }
    })
}

function openModal() {
    $("#mapModal").modal('show')
}

function closeModal() {
    $("#mapModal").modal('hide');
}

function locationChoosed() {

    let currentLocation =
    {
        latitude: Number.parseFloat($('#location-lat').val()),
        longtitude: Number.parseFloat($('#location-lng').val())
    }
    
    closeModal()
    getWeatherDataByLocation(currentLocation)
}

