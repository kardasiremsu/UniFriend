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

function Like(postID) {
    $.ajax({
        url: '/Home/Like',
        type: 'post',
        data: {
            postID,
        },
      
    });
}

function addComment(postID) {
    var comment = $('#comment' + String(postID)).val();
    if (!comment == "") {
        $.ajax({
            url: '/Home/AddComment',
            type: 'post',
            data: {
                postID,
                comment
            }
           
        });
    }


}