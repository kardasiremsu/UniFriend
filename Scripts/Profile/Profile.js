$(document).ready(function () {
    $('#editModal').on('shown.bs.modal', function () {
        $.ajax({
            url: '/AddFriend/GetFaculty',
            type: 'post',
            success: function (data) {
                if (data.length != 0) {
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

    $.ajax({
        url: '/Profile/GetStudentLectures',
        type: 'post',
        success: function (data) {
            var str = "";
            if (data.length != 0) {
                data.forEach((lecture) => {
                    str += '<p style="border: 1px solid black; padding: 10px">' +
                        lecture.name +
                        '<i class="fas fa-trash" style="margin: 10px" onClick="deleteLecture(' + lecture.ID + ', this)"></i><i id="undo" class="fas fa-undo" style="display: none;"></i></p>';
                });

                $('#myLectures').html(str);
            } else {
                str = "There are no lectures.";
                $('#myLectures').html(str);
            }
        }
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
                var str = "";

                data.forEach((lecture) => {
                    str += '<div class="row">';
                    str += '<div class="col-sm-10">' + lecture.name + '</div>';
                    str += '<div class="col-sm-2"><button class="btn btn-success" onClick="addLecture(' + lecture.ID + ', this)">Add</button></div>';
                    str += '</div><br />';
                });

                $('#searchedLectures').html(str);
            }
        }
    });
}

function addLecture(lectureID, button) {
    $.ajax({
        url: '/Profile/AddLecture',
        type: 'post',
        data: {
            lectureID
        },
        dataType: 'json',
        success: function (data) {
            if (data === true) {
                button.innerHTML = "Added";
                button.className = "btn btn-warning";
                button.disabled = true;
            }
        }
    });
}


function deleteLecture(lectureID, button) {
    $.ajax({
        url: '/Profile/DeleteLecture',
        type: 'post',
        data: {
            lectureID
        },
        dataType: 'json',
        success: function (data) {
            if (data === true) {
                button.innerHTML = "Deleted";
                button.className = "btn btn-danger";
                button.disabled = true;
            }
        }
    });
}
