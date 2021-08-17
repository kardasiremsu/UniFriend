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

        $.ajax({
            url: '/',
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
    //<i id="undo" class="fas fa-undo" style="display: none; margin:10px; padding:10px"></i>
    $.ajax({
        url: '/Profile/GetStudentLectures',
        type: 'post',
        success: function (data) {
            var str = "";
            if (data.length != 0) {
                data.forEach((lecture) => {
                    str += '<small><span class="border" style="margin: 10px; padding: 10px">' +
                        lecture.name +
                        '<i class="fas fa-trash" style="margin: 10px" onClick="deleteLecture(' + lecture.ID + ', this)"></i></span></small>';
                });

                $('#myLectures').html(str);
            } else {
                str = "There are no lectures.";
                $('#myLectures').html(str);
            }
        }
    });


$('#saveChanges').click(function () {
    var text = $('#changeName').val();
    $.ajax({
        url: '/Profile/ChangeName',
        type: 'post',
        data: {
            text
        },
       
    });
});



    $('#saveChangesLecture').click(function () {
        location.reload();

    });
});



function SearchDepartments() {
    var text = $('#searchDepartments').val();
    $.ajax({
        url: '/Profile/GetDepartments',
        type: 'post',
        data: {
            text
        },
        dataType: 'json',
        success: function (data) {
            if (data.length != 0) {
                var str = "";

                data.forEach((department) => {
                    str += '<div class="row mb-2">';
                    str += '<div class="col-sm-8">' + department.name + '</div>';
                    str += '<div class="col-sm-4"><button class="btn btn-success" onClick="addDepartment(' + department.ID + ', this)">Add</button></div>';
                    str += '</div>';
                });

                $('#searchedDepartments').html(str);
            }
        }
    });
}


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
                    str += '<div class="row mb-2">';
                    str += '<div class="col-sm-8">' + lecture.name + '</div>';
                    str += '<div class="col-sm-4"><button class="btn btn-success" onClick="addLecture(' + lecture.ID + ', this)">Add</button></div>';
                    str += '</div>';
                });

                $('#searchedLectures').html(str);
            }
        }
    });
}

function SearchFaculties() {
    var text = $('#searchFaculties').val();
    $.ajax({
        url: '/Profile/GetFaculties',
        type: 'post',
        data: {
            text
        },
        dataType: 'json',
        success: function (data) {
            if (data.length != 0) {
                var str = "";

                data.forEach((faculty) => {
                    str += '<div class="row mb-2">';
                    str += '<div class="col-sm-8">' + faculty.name + '</div>';
                    str += '<div class="col-sm-4"><button class="btn btn-success" onClick="addFaculty(' + faculty.ID + ', this)">Add</button></div>';
                    str += '</div>';
                });

                $('#searchedFaculties').html(str);
            }
        }
    });
}

function addFaculty(facultyID, button) {
    $.ajax({
        url: '/Profile/AddFaculty',
        type: 'post',
        data: {
            facultyID
        },
        dataType: 'json',
        success: function (data) {
            if (data === true) {
                button.innerHTML = "Added";
                button.className = "btn btn-info btn-sm";
                button.disabled = true;
            }
        }
    });
}

function addDepartment(departmentID, button) {
    $.ajax({
        url: '/Profile/AddDepartment',
        type: 'post',
        data: {
            departmentID
        },
        dataType: 'json',
        success: function (data) {
            if (data === true) {
                button.innerHTML = "Added";
                button.className = "btn btn-info btn-sm";
                button.disabled = true;
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
                button.className = "btn btn-info btn-sm";
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
                button.className = "btn btn-danger btn-sm";
               
                button.disabled = true;
                
            }
        }
    });
}
function deleteDepartment(departmentID, button) {
    $.ajax({
        url: '/Profile/DeleteDepartment',
        type: 'post',
        data: {
            departmentID
        },
        dataType: 'json',
        success: function (data) {
            if (data === true) {
                button.innerHTML = "Deleted";
                button.className = "btn btn-danger btn-sm";
                button.disabled = true;
            }
        }
    });
} function deleteFaculty(facultyID, button) {
    $.ajax({
        url: '/Profile/DeleteFaculty',
        type: 'post',
        data: {
            facultyID
        },
        dataType: 'json',
        success: function (data) {
            if (data === true) {
                button.innerHTML = "Deleted";
                button.className = "btn btn-danger btn-sm";
                button.disabled = true;
            }
        }
    });
}
$('.datepicker').datepicker({
  inline: true
});