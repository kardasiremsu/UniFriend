$(document).ready(function () {
    $.ajax({
        url: '/Clubs/GetClubs',
        type: 'post',
        success: function (data) {
            if (data.length != 0) {

                var s = '<option value="-1">Select Club</option>';
                for (var i = 0; i < data.length; i++) {

                    s += '<option value="' + data[i].ID + '">' + data[i].name + '</option>'
                    $('#ClubList').html(s);
                }
            }
            else {
                $('#ClubList').empty();
                var s = '<option value="-1">Select Club</option>';
                $('#ClubList').html(s);
            }
        }
    });



    $('#ClubList').on("change", function () {
        var clubID = $('#ClubList').val();
        $.ajax({
            url: '/Clubs/GetStudent',
            type: 'post',
            data: {
                clubID
            },
            dataType: 'json',
            success: function (data) {
                if (data.length != 0) {

                    var s = '<option value="-1">Select Student</option>';
                    for (var i = 0; i < data.length; i++) {

                        s += '<option value="' + data[i].ID + '">' + data[i].stud_name + '</option>'
                    }
                    $('#clubStudents').css("display", "block");
                    $('#clubStudents').html(s);

                }
                else {
                    $('#clubStudents').empty();
                    var s = '<option value="-1">Select Student</option>';
                    $('#clubStudents').html(s);
                }
            }
        });
    })
});
