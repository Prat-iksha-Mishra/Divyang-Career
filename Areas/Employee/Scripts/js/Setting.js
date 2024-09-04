$(document).ready(function () {
    var code = "";
    $('#mobile2').val(code);
    $('#mobile2').intlTelInput({
        autoHideDialCode: true,
        autoPlaceholder: "ON",
        dropdownContainer: document.body,
        formatOnDisplay: true,
        initialCountry: "us",
        placeholderNumberType: "MOBILE2",
        preferredCountries: ['us', 'gb', 'in'],
        separateDialCode: true
    });
    $('#btn-submit').on('click', function () {
        var code = $("#mobile2").intlTelInput("getSelectedCountryData").dialCode;
        var phoneNumber = $('#mobile2').val();
        document.getElementById("code").innerHTML = code;
        document.getElementById("mobile-number").innerHTML = phoneNumber;
    });
    $('#images3').change(function () {
        var fileInput = this;
        var filePath = fileInput.value;
        var allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
        if (!allowedExtensions.exec(filePath)) {
            alert('Please upload a file with a .jpg, .jpeg, or .png extension.');
           // fileInput.value = ''; // Clear the input
            return false;
        }
    })
    $('body').on('click', '#btnsubmit', function () {
        var code = $("#mobile").intlTelInput("getSelectedCountryData").dialCode;
        var Mobile = $('#mobile').val();
        $('#EmployeeDetails_CountryCode').val(code);
        var File1 = $('#images3').val();
        if (File1 != '') {
            var fileExtension1 = ["jpg", "png", "jpeg"];
            if ($.inArray(File1.split('.').pop().toLowerCase(), fileExtension1) == -1) {
                alert('Please upload a file with a .jpg, .jpeg, or .png extension.');
                return false;
            }
        }
    })
})