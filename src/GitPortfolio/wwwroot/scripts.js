$(document).ready(function () {
    $('#junior').mouseover(function () {
        console.log('mouse');
        $('#other-links').toggleClass("hide show");
    })
})