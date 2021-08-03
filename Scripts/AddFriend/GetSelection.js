$(document).ready(function () {

    $('#facultyList').on("change", function () {

        var facultyID = $('#facultyList').val();

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
        var facultyID = $('#facultyList').val();
        var departmentID = $('#studentDepartmentList').val();
        $.ajax({
            url: '/AddFriend/GetLecture',
            type: 'post',
            data: {
                facultyID,
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
        var facultyID = $('#facultyList').val();
        var departmentID = $('#studentDepartmentList').val();
        var lectureID = $('#studentLectureList').val();
        $.ajax({
            url: '/AddFriend/GetCRN',
            type: 'post',
            data: {
                facultyID,
                departmentID,
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

    $('#studentCRNList').on("change", function () {
        var facultyID = $('#facultyList').val();
        var departmentID = $('#studentDepartmentList').val();
        var lectureID = $('#studentLectureList').val();
        var CRNID = $('#studentCRNList').val();
        $.ajax({
            url: '/AddFriend/GetStudent',
            type: 'post',
            data: {
                facultyID,
                departmentID,
                lectureID,
                CRNID
            },
            dataType: 'json',
            success: function (data) {
                if (data.length != 0) {

                    var s = '<option value="-1">Select Student</option>';
                    for (var i = 0; i < data.length; i++) {

                        s += '<option value="' + data[i].ID + '">' + data[i].stud_name + '</option>'
                    }
                    $('#studentList').css("display", "block");
                    $('#studentList').html(s);

                }
                else {
                    $('#studentList').empty();
                    var s = '<option value="-1">Select Student</option>';
                    $('#studentList').html(s);
                }
            }
        });
    })

    $('#studentList').on("change",
        function () {
        $('#AddButton').css("display", "block");
    });

    $('#AddButton').click(function() {
        var StudentID = $('#studentList').val();
        $.ajax({
            url: '/AddFriend/AddFriend',
            type: 'post',
            data: {     
                StudentID
            },
            dataType: 'bool',
            success: function (data) {
                if (data) {

                    var s = "You Have A New Friend";
                    
                    $('#addmessage').css("display", "block");
                    $('#addmessage').html(s);

                    
                }
                else {
                    var s = "Couldn't Added";

                    $('#addmessage').css("display", "block");
                    $('#addmessage').html(s);
                }
            }
        });
    })

});
