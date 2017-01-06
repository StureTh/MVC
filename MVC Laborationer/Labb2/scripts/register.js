$(document).ready(function() {

    $("#regUser").click(function(e) {
        e.preventDefault();

        var user = {
            
            UserName: $("#UserName").val(),
            Mail: $("#Mail").val(),
            Password: $("#Password").val(),
            ConfirmPassword: $("#ConfirmPassword").val()

            
        }

        $.ajax({
            url: "/Account/Register",
            data: user,
            type: "POST",
            beforeSend: function () {
                $("#spinner").fadeIn();
            }


        }).success(function() {
            $("#spinner").fadeOut();
            alert("Success!!");
        });

    });

});