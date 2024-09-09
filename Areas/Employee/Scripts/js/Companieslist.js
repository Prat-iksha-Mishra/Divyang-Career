$(document).ready(function () {
    $('body').on('click', '#btncancel', function () {
        $('.lightbgcolor').hide();
    })
    $('body').on('click', '#btndelete', function () {
        var id = $(this).attr('value');
        $('#hdcompanyid').val(id);
        $('.lightbgcolor').show();
    })
    $('body').on('click', '#btnyesdelete', function () {
        var CompanyId = $('#hdcompanyid').val();
        $.ajax({
            url: '../Companies/DeleteCompany',
            type: 'POST',
            data: { CompanyId: CompanyId },
            success: function (response) {
                if (response.result.ReturnMessage == 'Success') {
                    location.reload();
                } else {
                    alert('An error occurred while deleting the item.');
                    $('.lightbgcolor').hide();
                }
            },
            error: function () {
                alert('Failed to delete the item.');
                $('.lightbgcolor').hide();
            }
        });
    })
})