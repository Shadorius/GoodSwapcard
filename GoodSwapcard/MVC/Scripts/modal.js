//Code JS de la partie User
$(document).on("click", ".open-DeleteUserDialog", function () {
    var currentUserId = $(this).data('id');
    console.log(currentUserId);
    $('#DeleteButton').attr("onclick", "location.href='/Utilisateur/Delete/" + currentUserId+"'");
});

//Code JS et Ajax de la partie Société
$(document).on("click", ".open-DeleteSocietyDialog", function () {
    var currentSocietyId = $(this).data('id');
    $('#DeleteButton').attr("onclick", "location.href='/Society/Delete/" + currentSocietyId + "'");
});

var TeamDetailPostBackURL = '/Society/Details';
$(function () {
    $(".open-DetailsSocietyDialog").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: TeamDetailPostBackURL,
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