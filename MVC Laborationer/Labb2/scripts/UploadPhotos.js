
$("form#upload").submit(function (e) {
    e.preventDefault();

    var formData = new FormData($(this)[0]);

    var photoName = $("#photoName").val();
    alert(formData);
    var photodata = {
        Name: $("#photoName").val()
    };
    alert($("#photoName").val());
   
    $.ajax({
        url: "/Album/UploadToAlbum/",
        type: "POST",
        data: formData,
        success: function (data) {
            alert(data);
        },
        cache: false,
        processData: false,
        contentType: false

    });
});

    
