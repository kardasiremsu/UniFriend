$(document).ready(function () {
    $.ajax({
        url: '/Home/ReturnFlow',
        type: 'post',
        success: function (data) {
            var s = "";
            if (data.length != 0) {
                for (int i = 0; i < data.length; i++){
                    
                }
            }
            else {
                $('#postFlow').empty();
                var s = 'There is no post';
                $('#postFlow').html(s);
            }
        }
    });


});