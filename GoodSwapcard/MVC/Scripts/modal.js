//Code JS de la partie User
$(document).on("click", ".open-DeleteUserDialog", function () {
    var currentUserId = $(this).data('id');
    console.log(currentUserId);
    $('#DeleteButton').attr("onclick", "location.href='/Utilisateur/Delete/" + currentUserId+"'");
});

//Details
var DetailsUserBackURL = '/Utilisateur/Details';
$(function () {
    $(".open-DetailsUserDialog").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        console.log(id)
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: DetailsUserBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                $('#myModalUserContent').html(data);
                $('#myModalUser').modal(options);
                $('#myModalUser').modal('show');
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

    $("#closbtn").click(function () {
        $('#myModalUser').modal('hide');
    });
});

var EditUserBackURL = '/Utilisateur/Edit';
$(".open-EditUserDialog").click(function () {
    var $buttonClicked = $(this);
    var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "GET",
        url: EditUserBackURL,
        contentType: "application/json",
        data: { "Id": id },
        datatype: "json",
        success: function (data) {
            console.log(data);
            $('#myModalUserContent').html(data);
            $('#myModalUser').modal(options);
            $('#myModalUser').modal('show');
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
});

$("#closbtn").click(function () {
    $('#myModalUser').modal('hide');
});

function OpenEditUser(id) {
    console.log(id);
    $.ajax({
        type: "GET",
        url: EditUserBackURL,
        contentType: "application/json",
        data: { "Id": id },
        datatype: "json",
        success: function (data) {
            $('#myModalUserContent').html(data);
            //$('#myModalUser').modal(options);
            $('#myModalUser').modal('show');
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
};


//Code JS et Ajax de la partie Société
//Delete
$(document).on("click", ".open-DeleteSocietyDialog", function () {
    var currentSocietyId = $(this).data('id');
    $('#DeleteButton').attr("onclick", "location.href='/Society/Delete/" + currentSocietyId + "'");
});

//Details
var DetailsBackURL = '/Society/Details';
$(function () {
    $(".open-DetailsSocietyDialog").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: DetailsBackURL,
            contentType: "application/json; charset=utf-8",
            data: { "Id": id },
            datatype: "json",
            success: function (data) {
                $('#myModalSocietyContent').html(data);
                $('#myModalSociety').modal(options);
                $('#myModalSociety').modal('show');
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

    $("#closbtn").click(function () {
        $('#myModalSociety').modal('hide');
    });
});

//Edit
var EditBackURL = '/Society/Edit';
$(".open-EditSocietyDialog").click(function () {
    var $buttonClicked = $(this);
    var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "GET",
        url: EditBackURL,
        contentType: "application/json",
        data: { "Id": id },
        datatype: "json",
        success: function (data) {
            $('#myModalSocietyContent').html(data);
            $('#myModalSociety').modal(options);
            $('#myModalSociety').modal('show');
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
});

$("#closbtn").click(function () {
    $('#myModalSociety').modal('hide');
});

function OpenEdit(id) {
    console.log(id);
    $.ajax({
        type: "GET",
        url: EditBackURL,
        contentType: "application/json",
        data: { "Id": id },
        datatype: "json",
        success: function (data) {
            $('#myModalSocietyContent').html(data);
            $('#myModalSociety').modal(options);
            $('#myModalSociety').modal('show');
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
};
