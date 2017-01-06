$(document).ready(function() {

    $("#newAlbumButton").click(function(e) {
        e.preventDefault();

        var album = {
            AlbumName: $("#AlbumName").val()
    }


        $.ajax({
            url: "/Album/NewAlbum",
            type: "POST",
            data: album,
            beforeSend: function () {
                $("#spinner").fadeIn();
            }


        }).success(function () {
            $("#spinner").fadeOut();
            window.location.href = "/Gallery/Index";
        });


    });


});