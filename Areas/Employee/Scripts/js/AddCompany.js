
$(document).ready(function () {
    $('#FoundedIn').Monthpicker();
   
    ckeditordescription5();
    CKEDITOR.config.toolbar_desc = [['Bold', 'Italic', 'Underline', 'Link']];
/*    $('#stateDropdown option:first').attr('disabled', true).attr('selected', true);*/
   
    $('#stateDropdown').change(function () {
        var StateId = $(this).val();

        if (StateId) {
            $.ajax({
                /* url: '@Url.Action("GetDistricByState", "Companies")',*/
                url:'../Companies/GetDistricByState',
                type: 'GET',
                data: { StateId: StateId },
                success: function (data) {
                    var cityDropdown = $('#DistricDropdown');
                    cityDropdown.empty(); // Clear the current options
                    cityDropdown.append($('<option value="" disabled Selected >Select a district</option>'));
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
    $('body').on('click', '.civi-button', function () {
        var code = $("#mobile").intlTelInput("getSelectedCountryData").dialCode;
        var Mobile = $('#mobile').val();
        $('#PhoneCountryCode').val(code);
        var test = CKEDITOR.instances['Aboutckeditor'].getData();
        if (test == '') {
            alert('Enter company about');
            return false;
        }
        else {
            $('#CompanyAboutUs').val(test);
        }
        
    })
    var CompanyAbout = $('#hfCompanyAboutUs').val();
    //if (CompanyCategories == '') {
    //     $('#CompanyCategories  option:first').attr('disabled', true).attr('selected', true);
    //}
    if (CompanyAbout != '') {
        CKEDITOR.instances['Aboutckeditor'].setData(CompanyAbout);
    }
    
    var fileArr = [];
    $('#images').change(function () {
        var fileInput = this;
        var filePath = fileInput.value;
        var file = fileInput.files[0];
        var allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
        var maxSizeInBytes = 800 * 1024; // 800KB
        if (!allowedExtensions.exec(filePath)) {
            alert('Please upload a file with a .jpg, .jpeg, or .png extension.');
            return false;
        }
        if (file.size > maxSizeInBytes) {
            alert('Please upload a file smaller than 800KB.');
            return false;
        }
        $('#ShowLogo').html("");
        var total_file = document.getElementById("images").files;
        if (!total_file.length) return;
        for (var i = 0; i < total_file.length; i++) {
             {
                fileArr.push(total_file[i]);
                $('#ShowLogo').append("<img src = '" + URL.createObjectURL(event.target.files[i]) + "'>");
            }
        }
    })
    $('#images2').change(function () {
        var fileInput = this;
        var filePath = fileInput.value;
        var file = fileInput.files[0];
        var allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
        var maxSizeInBytes = 800 * 1024; // 800KB
        if (!allowedExtensions.exec(filePath)) {
            alert('Please upload a file with a .jpg, .jpeg, or .png extension.');
            return false;
        }
        if (file.size > maxSizeInBytes) {
            alert('Please upload a file smaller than 800KB.');
            return false;
        }
        // Validate image dimensions
        var img = new Image();
        img.onload = function () {
            if (img.width < 1920 || img.height < 400) {
                alert('Please upload an image with dimensions 1920px width and 400px height or greater.');
                return false;
            }
        };
    })
    $('#images3').change(function () {
        var fileInput = this;
        var filePath = fileInput.value;
        var file = fileInput.files[0];
        var allowedExtensions = /(\.jpg|\.jpeg|\.png)$/i;
        var maxSizeInBytes = 800 * 1024; // 800KB
        if (!allowedExtensions.exec(filePath)) {
            alert('Please upload a file with a .jpg, .jpeg, or .png extension.');
            return false;
        }
        if (file.size > maxSizeInBytes) {
            alert('Please upload a file smaller than 800KB.');
            return false;
        }
    })
    $('body').on('keyup', '#CompanyName', function () {
        var CompanyName = $('#CompanyName').val();
        $('#ShowCompanyName').html(CompanyName);
    })
    $('body').on('change', '#stateDropdown', function () {
        var State = $('[id*=stateDropdown] option:selected').text();
        $('#ShowLocation').html('<i class="fa fa-map-marker" aria-hidden="true"></i> ' + State);
    })
    var local = $('[id*=stateDropdown] option:selected').text();
    $('#ShowLocation').html('<i class="fa fa-map-marker" aria-hidden="true"></i> ' + local);
});
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
            maxCharCount: 1260
        },
        toolbar: 'desc'
    });
}