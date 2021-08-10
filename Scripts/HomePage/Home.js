$(document).ready(function () {
    $.ajax({
        url: '/Home/ReturnFlow',
        type: 'post',
        success: function (data) {
            var str = "";
            if (data.length != 0) {
                for (var i = 0; i < data.length; i++) {
                    str += '<div class="card" style="background-color:gainsboro; border-radius:10px; padding:7px">';
                    str += '<h5 class="card-header">' + data[i].AuthorID + '</h5>';
                    str += '<div class="card-body">';
                    str += '<p class="card-text">' + data[i].text + '</p>';
                    if (data[i].File != null) {
                        str += '<a href="#" class="btn btn-primary">Photo</a>';
                    }
                    if (data[i].likes != null) {
                        str += '<div class="col-xs-12 col-sm-6"><p>Likes: ' + data[i].likes.length + '</p></div>';
                    }
                    if (data[i].comments != null) {
                        str += '<div class="col-xs-12 col-sm-6"><p>Comments:</p>';
                        data[i].comments.forEach((comment) => {
                            str += '<p>' + comment.text + '</p>';
                        });
                        str += '</div>';
                    }
                    str += '</div><div class="card-footer text-muted">' + data[i].date + '</div></div><br/>';
                }

                $('#postFlow').html(str);
            } else {
                str = 'There is no post';
                $('#postFlow').html(str);
            }
        }
    });

    $("#postButton").click(function () {
        var text = $("#text").val();

        $.ajax({
            url: '/Home/AddPost',
            type: 'post',
            data: {
                text
            },
            dataType: 'json'
        });
    });
});