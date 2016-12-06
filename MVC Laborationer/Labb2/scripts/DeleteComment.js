$(document).ready(function () {
        
    $("#DeleteButton").click(function (e) {
        e.preventDefault();
        

        var CommentId = $(this).attr("data-commentId");
        alert(CommentId)
        var PhotoId = $(this).attr("data-photoId");

        alert("Test")
        $.ajax({
            
            url: "/Comment/DeleteComment",
            data: {
                commentId: CommentId,
                photoId: PhotoId
            },
            typ: "POST"
        }).success(function () {
            alert("Test2")
            $.ajax({
                url: "/Comment/ViewComments",
                data: {photoId: PhotoId},
                contentType: "application/html;charset=utf-8",
                type: "GET",
                dataType: "html"
            }).success(function (result) {
                $("#ShowCommentsId").html(result);
            });

        });

    });
});