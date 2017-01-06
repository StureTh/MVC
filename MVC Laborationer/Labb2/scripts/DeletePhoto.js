$(document).ready(function() {

    $("#DeletePhotoButton").click(function(e) {
        e.preventDefault();

        var ID = $("#DisplayPhotoId").children("img").attr("id");
       

        $.ajax({
            url: "/Gallery/DeletePhoto",
            data: {
                PhotoId: ID
            },
            type: "POST"


        }).success(function() {

            window.location.href = "/Gallery/Index";
        });

    });


});