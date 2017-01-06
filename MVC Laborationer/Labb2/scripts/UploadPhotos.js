
$("form#upload").submit(function (e) {
    e.preventDefault();

    var formData = new FormData($(this)[0]);

    //var photoName = $("#photoName").val();
    //alert(formData);
    //var photodata = {
    //    Name: $("#photoName").val()
    //};
    //alert($("#photoName").val());
   
    $.ajax({
        url: "/Album/UploadToAlbum/",
        type: "POST",
        data: formData,
        beforeSend: function (){
            $("#spinner").fadeIn();
        },
        success: function (data) {
            $("#spinner").fadeOut();
            window.location.href = data + "?gid="+ $("#albumId").val();
        },
        cache: false,
        processData: false,
        contentType: false

    });
});

    
