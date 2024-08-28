$(document).ready(function () {
    $('#UserType').val('Candidate');
    $('body').on('click', '.DivyangType', function () {
        var Type = $(this).attr('value');
        $('#UserType').val(Type);
    })
    $('body').on('click', '.button', function () {
        var code = $("#mobile").intlTelInput("getSelectedCountryData").dialCode;
        var Mobile = $('#mobile').val();
        $('#CountryCode').val(code);
    })
})