$(document).ready(function () {
    $.ajax({
        url: '/AddFriend/GetCategories',
        type: 'post',
        success: function (data) {
            if (data.length != 0) {
                var s = '<option value="-1">Select Category</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].Key + '">' + data[i].Value + '</option>'
                    $('#selectionFor').html(s);
                }
            }
            else {
                $('#selectionFor').empty();
                var s = '<option value="-1">Select Category</option>';
                $('#selectionFor').html(s);
            }
        }
    });

    $('#selectionFor').on("change", function () {
        var selectionID = $('#selectionFor').val();

        $('#ClubList').css("display", "none");
        $('#studentDepartmentList').css("display", "none");
        $('#studentCRNList').css("display", "none");
        $('#studentLectureList').css("display", "none");
        $('#studentFacultyList').css("display", "none");

        if (selectionID == 0) {
            $('#studentFacultyList').css("display", "block");

            $.ajax({
                url: '/AddFriend/GetFaculty',
                type: 'post',
                success: function (data) {
                    if (data.length != 0) {

                        var s = '<option value="-1">Select Faculty</option>';
                        for (var i = 0; i < data.length; i++) {
                            s += '<option value="' + data[i].ID + '">' + data[i].name + '</option>';
                        }

                        $('#studentFacultyList').html(s);
                    } else {
                        $('#studentFacultyList').empty();
                        var s = '<option value="-1">Select Faculty</option>';
                        $('#studentFacultyList').html(s);
                    }
                }
            });
        } else if (selectionID == 1) {
            $('#ClubList').css("display", "block");

            $.ajax({
                url: '/AddFriend/GetClubs',
                type: 'post',
                success: function (data) {
                    if (data.length != 0) {

                        var s = '<option value="-1">Select Club</option>';
                        for (var i = 0; i < data.length; i++) {
                            s += '<option value="' + data[i].ID + '">' + data[i].name + '</option>';
                        }

                        $('#ClubList').html(s);
                    } else {
                        $('#ClubList').empty();
                        var s = '<option value="-1">Select Club</option>';
                        $('#ClubList').html(s);
                    }
                }
            });
        }
    });


    $('#studentFacultyList').on("change", function () {

        var facultyID = $('#studentFacultyList').val();

        $('#ClubList').css("display", "none");

        $('#studentDepartmentList').css("display", "none");
        $('#studentLectureList').css("display", "none");
        $('#studentCRNList').css("display", "none");

        $.ajax({
            url: '/AddFriend/GetDepartment',
            type: 'post',
            data: {
                facultyID
            },
            dataType: 'json',
            success: function (data) {
                if (data.length != 0) {

                    var s = '<option value="-1">Select Department</option>';
                    for (var i = 0; i < data.length; i++) {

                        s += '<option value="' + data[i].ID + '">' + data[i].name + '</option>'
                    }
                    $('#studentDepartmentList').css("display", "block");
                    $('#studentDepartmentList').html(s);

                }
                else {
                    $('#studentDepartmentList').empty();
                    var s = '<option value="-1">Select Department</option>';
                    $('#studentDepartmentList').html(s);
                }
            }
        });
    })

    $('#studentDepartmentList').on("change", function () {
        var departmentID = $('#studentDepartmentList').val();

        $('#ClubList').css("display", "none");

        $('#studentLectureList').css("display", "none");
        $('#studentCRNList').css("display", "none");

        $.ajax({
            url: '/AddFriend/GetLecture',
            type: 'post',
            data: {
                departmentID
            },
            dataType: 'json',
            success: function (data) {
                if (data.length != 0) {

                    var s = '<option value="-1">Select Lecture</option>';
                    for (var i = 0; i < data.length; i++) {

                        s += '<option value="' + data[i].ID + '">' + data[i].name + '</option>'
                    }
                    $('#studentLectureList').css("display", "block");
                    $('#studentLectureList').html(s);

                }
                else {
                    $('#studentLectureList').empty();
                    var s = '<option value="-1">Select Lecture</option>';
                    $('#studentLectureList').html(s);
                }
            }
        });
    })

    $('#studentLectureList').on("change", function () {

        var lectureID = $('#studentLectureList').val();

        $('#ClubList').css("display", "none");

        $('#studentCRNList').css("display", "none");

        $.ajax({
            url: '/AddFriend/GetCRN',
            type: 'post',
            data: {
                lectureID
            },
            dataType: 'json',
            success: function (data) {
                if (data.length != 0) {

                    var s = '<option value="-1">Select CRN</option>';
                    for (var i = 0; i < data.length; i++) {

                        s += '<option value="' + data[i].ID + '">' + data[i].code + '</option>'
                    }
                    $('#studentCRNList').css("display", "block");
                    $('#studentCRNList').html(s);

                }
                else {
                    $('#studentCRNList').empty();
                    var s = '<option value="-1">Select CRN</option>';
                    $('#studentCRNList').html(s);
                }
            }
        });
    })

   


    $('#FindButton').click(function () {
        var CategoryID = $('#selectionFor').val();

        if (CategoryID == 0) {
            var CRNID = $('#studentCRNList').val();

            $.ajax({
                url: '/AddFriend/GetStudent',
                type: 'post',
                data: {
                    CRNID
                },
                dataType: 'json',
                success: function (data) {
                    if (data.length != 0) {
                        var s = "";
                        for (var i = 0; i < data.length; i++) {
                            s += '<div class="card" style="width: 10rem; ">';
                            s += '<img class="card-img-top" src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Card image cap" style="width:150px">'; //idden gelenler alınacak
                            s += '<div class="card-body">';
                            s += '<p class="card-text" id=' + data[i].ID + '>' + data[i].stud_name + '</p >';
                            s += '<div><button type="AddButton" onclick="addFriend(data[i].ID)" class="btn btn-primary">Add Friend</button></div></div></div>';
                            
                           
                        }
                        $('#studentList').css("display", "block");
                        $('#studentList').html(s);

                    }
                    else {
                        $('#studentList').empty();
                        var s = 'There is no student for this filter';
                        $('#studentList').html(s);
                    }
                }
            });
        }

        else if (CategoryID == 1) {
            var clubID = $('#ClubList').val();

            $.ajax({
                url: '/AddFriend/GetClubStudent',
                type: 'post',
                data: {
                    clubID
                },
                dataType: 'json',
                success: function (data) {
                    if (data.length != 0) {
                        var s = "";
                        for (var i = 0; i < data.length; i++) {
                            s += '<div class="card" style="width: 10rem;">';
                            s += '<img class="card-img-top" src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Card image cap">'; //idden gelenler alınacak
                            s += '<div class="card-body">';
                            s += '<p class="card-text" value=' + data[i].ID + '>' + data[i].stud_name + '</p >';
                            s += '<div><button type="Button" onclick="addFriend('+data[i].ID+',this)"  class="btn btn-primary">Add Friend</button></div></div></div>';
                           
                        }
                        $('#studentList').css("display", "block");
                        $('#studentList').html(s);

                    }
                    else {
                        $('#studentList').empty();
                        var s = 'There is no student for this filter';
                        $('#studentList').html(s);
                    }
                }
            });
        }
    })
});

function addFriend(ID,button) {

        $.ajax({
            url: '/AddFriend/AddFriend',
            type: 'post',
            data: {
                ID
            },
            dataType: 'json',
            success: function (data) {
                if (data == true) {
                    button.innerHTML = "Has been added";  //İleriki aşamalarda onay sorulacak
                    button.className = "btn btn-success";
                    button.disabled = true;     
                }
            }
        });

    }
