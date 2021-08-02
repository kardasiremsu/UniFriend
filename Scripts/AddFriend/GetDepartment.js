$(document).ready(function () {
    $("#facultyList").on("change", function () {
        var facultyID = $("#facultyList").val();
        $.ajax({
            url: 'AddFriend/GetDepartment',
            type: 'post',
            data: {
                facultyID
            },
            dataType: 'json',
            success: function (data) {
                if (data.length > 0) {
                    var s = '<option selected>-Select Department<option>';
                    for (int i = 0; i < data.length; i++) {
            s += '<option value="' + data[i].ID + '">' + data[i].name + '</option>';
        }
        $('#studentDepartmentList').html(s);
    } 
                else {
                    $('#studentDepartmentList').empty();
                    var s = '<option value="-1">-Select Department-</option>';
                    $('#studentDepartmentList').html(s);
                }
            }
        });
    })
});