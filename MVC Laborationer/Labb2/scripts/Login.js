$(document).ready(function() {

    $("#loginButton").click(function(e) {

        e.preventDefault();

        var account = {
            Mail: $("#Mail").val(),
            Password: $("#Password").val()
        }

        $.ajax({
            url: "/Account/Login",
            type: "POST",
            data: account,
            beforeSend: function () {
                $("#spinner").fadeIn();
            }


        }).success(function() {
            $("#spinner").fadeOut();
            window.location.href = "/Account/LoggedIn";

        });
    });


});