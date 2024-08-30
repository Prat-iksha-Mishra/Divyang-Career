$(document).ready(function () {
    $('#UserTypes').val('Employer');
    $('body').on('click', '.button', function () {
        var code = $("#mobiles").intlTelInput("getSelectedCountryData").dialCode;
        var Mobile = $('#mobiles').val();
        $('#CountryCodes').val(code);
    })
})