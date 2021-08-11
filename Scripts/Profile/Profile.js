
$(document).ready(function () {



    $('#editModal').on('shown.bs.modal', function () {
        $.ajax({
            url: '/AddFriend/GetFaculty',
            type: 'post',
            success: function (data) {
                if (data.length != 0) {
                    a = 'E';
                    $('#gender').html(a);
                    var s = '<option value="-1">Select Faculty</option>';
                    for (var i = 0; i < data.length; i++) {
                        s += '<option value="' + data[i].ID + '">' + data[i].name + '</option>';
                    }
                    $('#EditFacultyList').html(s);
                } else {
                    $('#EditFacultyList').empty();
                    var s = '<option value="-1">Select Faculty</option>';
                    $('#EditFacultyList').html(s);
                }
            }
        });
    });
});

function SearchLectures() {

    var text = $('#searchLectures').val();
    $.ajax({
        url: '/Profile/GetLectures',
        type: 'post',
        data: {
            text
        },
        dataType: 'json',
        success: function (data) {
            if (data.length != 0) {
                console.log(data);
            }

        }
    });
    }
