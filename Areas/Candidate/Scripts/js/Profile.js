$(document).ready(function () {
    var UDIDYESNO = $('#UDIDOption').val();
    if (UDIDYESNO == '1') {
        $('#UDIDDIV').show();
        $('#UDIDUPLOADDIV').show();
    }
    else if (UDIDYESNO == '2') {
        $('#UDIDDIV').hide();
        $('#UDIDUPLOADDIV').hide();
    }
    else {
        $('#UDIDDIV').show();
        $('#UDIDUPLOADDIV').show();
    }
    ckeditordescription5();
    CKEDITOR.config.toolbar_desc = [['Bold', 'Italic', 'Underline', 'Link']];
    var CandidteDescription = $('#hfCompanyAboutUs').val();
    if (CandidteDescription != '') {
        CKEDITOR.instances['Aboutckeditor'].setData(CandidteDescription);
    }
    $('body').on('click', '#btnpublishbasic', function () {
        // Get the data from the CKEditor instance
        var descriptionData = CKEDITOR.instances['Aboutckeditor'].getData();
        $('#Description').val(descriptionData);
        // Get the selected country dial code using the intlTelInput plugin
        var countryCode = $("#mobile").intlTelInput("getSelectedCountryData").dialCode;
        $('#CountryCode').val(countryCode);
    })
    $('#DBO').datepicker();
    /*$('#Years').datepicker();*/
    $('#Years').datepicker({
        format: "yyyy",
        viewMode: "years",
        minViewMode: "years",
        autoclose: true
    });
    $('#CertificateYear').datepicker({
        format: "yyyy",
        viewMode: "years",
        minViewMode: "years",
        autoclose: true
    });
    $('#From').datepicker();
    $('#To').datepicker();
    $('#stateDropdown').change(function () {
        var StateId = $(this).val();
        if (StateId) {
            $.ajax({
                /* url: '@Url.Action("GetDistricByState", "Companies")',*/
                url: '../Profile/GetDistricByState',
                type: 'GET',
                data: { StateId: StateId },
                success: function (data) {
                    var cityDropdown = $('#DistricDropdown');
                    cityDropdown.empty(); // Clear the current options
                    cityDropdown.append($('<option value="" disabled Selected >Select district</option>'));
                    $.each(data, function (index, item) {
                        cityDropdown.append($('<option/>', {
                            value: item.Value,
                            text: item.Text
                        }));
                    });
                }
            });
        } else {
            $('#DistricDropdown').empty();
        }
    });
    $('#DistricDropdown').change(function () {
        var DistrictId = $(this).val();
        var StateId = $('[id*=stateDropdown] option:selected').val();
        if (DistrictId) {
            $.ajax({
                /* url: '@Url.Action("GetDistricByState", "Companies")',*/
                url: '../Profile/GetSubDistricByStateDistrict',
                type: 'GET',
                data: { DistrictId: DistrictId, StateId: StateId },
                success: function (data) {
                    var cityDropdown2 = $('#SubDistrictDropdown');
                    cityDropdown2.empty(); // Clear the current options
                    cityDropdown2.append($('<option value="" disabled Selected >Select subdistrict</option>'));
                    $.each(data, function (index, item) {
                        cityDropdown2.append($('<option/>', {
                            value: item.Value,
                            text: item.Text
                        }));
                    });
                }
            });
        } else {
            $('#SubDistrictDropdown').empty();
        }
    });
    $('#SubDistrictDropdown').change(function () {
        var SubDistrictId = $(this).val();
        var DistrictId = $('[id*=DistricDropdown] option:selected').val();
        var StateId = $('[id*=stateDropdown] option:selected').val();
        if (DistrictId) {
            $.ajax({
                /* url: '@Url.Action("GetDistricByState", "Companies")',*/
                url: '../Profile/GetCitiesBySubDistrict',
                type: 'GET',
                data: { DistrictId: DistrictId, StateId: StateId, SubDistrictId: SubDistrictId },
                success: function (data) {
                    var cityDropdown3 = $('#CitiesDropDown');
                    cityDropdown3.empty(); // Clear the current options
                    cityDropdown3.append($('<option value="" disabled Selected >Select cityvillage</option>'));
                    $.each(data, function (index, item) {
                        cityDropdown3.append($('<option/>', {
                            value: item.Value,
                            text: item.Text
                        }));
                    });
                }
            });
        } else {
            $('#CitiesDropDown').empty();
        }
    });
    $('#resume').change(function () {
        var fileUpload = $("#resume").get(0);
        var files = fileUpload.files;
        if (files.length > 0) {
            var fileName = files[0].name;
            $('#Uploadfilename').text('Upload file: '+fileName);
        } else {
            $('#Uploadfilename').text('Upload file: no file upload');
        }
    })
    $('#HighestEducationAttained').change(function () {
        var HighestEducationAttained = $(this).val();
        if (HighestEducationAttained) {
            $.ajax({
                /* url: '@Url.Action("GetDistricByState", "Companies")',*/
                url: '../Profile/GetEducationQualification',
                type: 'GET',
                data: { HighestEducationAttained: HighestEducationAttained },
                success: function (data) {
                    var cityDropdown = $('#EducationQualification');
                    cityDropdown.empty(); // Clear the current options
                    cityDropdown.append($('<option value="" disabled Selected >Select education</option>'));
                    $.each(data, function (index, item) {
                        cityDropdown.append($('<option/>', {
                            value: item.Value,
                            text: item.Text
                        }));
                    });
                }
            });
        } else {
            $('#EducationQualification').empty();
        }
    });
    $('#EducationQualification').change(function () {
        var EducationId = $(this).val();
        if (EducationId) {
            $.ajax({
                /* url: '@Url.Action("GetDistricByState", "Companies")',*/
                url: '../Profile/GetSpecializations',
                type: 'GET',
                data: { EducationId: EducationId },
                success: function (data) {
                    var cityDropdown = $('#Specializations');
                    cityDropdown.empty(); // Clear the current options
                    cityDropdown.append($('<option value="" disabled Selected >Select specialization</option>'));
                    $.each(data, function (index, item) {
                        cityDropdown.append($('<option/>', {
                            value: item.Value,
                            text: item.Text
                        }));
                    });
                }
            });
        } else {
            $('#Specializations').empty();
        }
    });
    $('#UDIDOption').change(function () {
        var Option = $(this).val();
        if (Option == '1') {
            $('#UDIDDIV').show();
            $('#UDIDUPLOADDIV').show();
        }
        else {
            $('#UDIDDIV').hide();
            $('#UDIDUPLOADDIV').hide();
        }
    })
    $('#UDIDCard').change(function () {
        var fileUpload = $("#UDIDCard").get(0);
        var files = fileUpload.files;
        if (files.length > 0) {
            var fileName = files[0].name;
            $('#UploadUDIDCard').text('Upload file: ' + fileName);
        } else {
            $('#UploadUDIDCard').text('Upload file: no file upload');
        }
    })
   
})
function ckeditordescription5() {
    CKEDITOR.replace('Aboutckeditor', {
        extraPlugins: 'wordcount',
        wordcount: {
            showParagraphs: true,
            showWordCount: false,
            showCharCount: true,
            countSpacesAsChars: false,
            countHTML: false,
            maxWordCount: -1,
            maxCharCount: 3000
        },
        toolbar: 'desc'
    });
}