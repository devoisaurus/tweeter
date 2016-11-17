$("#register - username").focusout(function () {
    $.ajax({
        url: "/api/TwitUsername/" + $(this).val(),
        method: 'GET'
    }).success(function (response) {
        console.log(response);
    }).fail(function (error) {
        console.log(error);
    });
});