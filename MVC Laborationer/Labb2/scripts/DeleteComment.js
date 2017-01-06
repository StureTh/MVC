$(document).ready(function () {
        
    $("#DeleteButton").click(function (e) {
        e.preventDefault();
        

        var CommentId = $(this).attr("data-commentId");
       
        var PhotoId = $(this).attr("data-photoId");

       
        $.ajax({
            
            url: "/Comment/DeleteComment",
            data: {
                commentId: CommentId,
                photoId: PhotoId
            },
            type: "POST"
        }).success(function () {
            
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