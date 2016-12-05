$(document).ready(function() {
    $("#PostCommentBtn").click(function(e) {
        e.preventDefault();

        var commentTextBox = $("textarea#CommentComment");
        var ID = $("#DisplayPhotoId").children("img").attr("id");


        var commentModel = {
            CommentComment: commentTextBox.val()

        };

        $.ajax({
            url: "/Comment/PostComment/",
            data: {
                comment: commentModel,
                photoId: ID
            },
            type: "POST",
            success: function(data) {


                $.ajax({
                    url: "/Comment/ViewComments",
                    data: { photoId: ID },
                    contentType: "application/html; charset=utf-8",
                    type: "GET",
                    dataType: "html"


                }).success(function(result) {
                    $("div#ShowCommentsId").html(result);

                    commentTextBox.val("");

                });
            }
    });

    });
});