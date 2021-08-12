$(document).ready(function () {
   

    $("#postButton").click(function () {
        var text = $("#text").val();

        $.ajax({
            url: '/Home/AddPost',
            type: 'post',
            data: {
                text
            },
            dataType: 'json',
            success: function () {
                $('#postModal').hide();  
            }
        });
    });
});