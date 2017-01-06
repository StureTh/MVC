var interval;
var ID = $("#DisplayPhotoId").children("img").attr("id");
alert(ID);

$(function UpdateComments() {

    $.ajax({
        url: "/Comment/ViewComments",
        data: { photoId: ID },
        contentType: "application/html; charset=utf-8",
        type: "GET",
        dataType: "html"


    }).success(function(result) {

        $("div#ShowCommentsId").html(result);

        interval = setTimeout(UpdateComments, 10000);
    });
});