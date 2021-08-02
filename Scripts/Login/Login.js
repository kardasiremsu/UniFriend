$(document).ready(function () {
    $("#loginBtn").on("click",function () {

        var mail = $("#mail").val();
        var password = $("#password").val();

        $.ajax({
            url: '/Login/LoginCheck',
            type: 'post',
            data: {
                mail,
                password
            },
            dataType: 'json',
            success: function (data) {

                if (data != false) {
                    window.location.href = data;
                }
                else {
                    alert("Invalid Username/Password!")
                }
            }
        });
    });
});

