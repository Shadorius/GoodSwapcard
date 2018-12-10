$(document).on("click", ".open-DeleteUserDialog", function () {
    var currentUserId = $(this).data('id');
    console.log(currentUserId);
    $('#DeleteButton').attr("onclick", "location.href='/Utilisateur/Delete/" + currentUserId+"'");
});