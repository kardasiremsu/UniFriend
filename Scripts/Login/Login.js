$(document).ready(function () {
    $("#loginBtn").on("click", function () {

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
                    alert("Invalid Username/Password!");
                }
            }
        });
    });
    $("#registerBtn").on("click", function () {

        var mail = $("#mailRegister").val();
        var password1 = $("#password1").val();
        var password2 = $("#password2").val();
        if (password1 == password2) {
            $.ajax({
                url: '/Login/Register',
                type: 'post',
                data: {
                    mail,
                    password1
                },
                dataType: 'json',
                success: function (data) {

                    if (data != false) {
                        window.location.href = data;
                    }
                    else {
                        alert("Couldnt added");
                    }
                }
            });
        }
        else {
            alert("Your passwords does not match!");
        }        
    });

    $("#loginClick").on("click", function () {
        $("#loginContainer").css("display", "block");
        $("#registerContainer").css("display", "none");

    });

    $("#registerClick").click(function () {
        $("#loginContainer").css("display", "none");
        $("#registerContainer").css("display", "block");
    });
});
