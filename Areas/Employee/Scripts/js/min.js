
jQuery(document).ready(function ($) {

    $('ul.tabs li').click(function () {
        var tab_id = $(this).attr('data-tab');
        $('ul.tabs li').removeClass('current');
        $('.tab-content').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })

    $('ul.tabs li').click(function () {
        var tab_id = $(this).attr('data-tab');
        $('ul.tabs li').removeClass('current');
        $('.tab-contents').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })

    $(".toggle-password").click(function () {
        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $($(this).attr("toggle"));
        if (input.attr("type") == "password") {
            input.attr("type", "text");
        } else {
            input.attr("type", "password");
        }
    });

    $(".ZoomSettings").click(function () {
        $(".lightbgcolor").show();
    });
    $(".btn-close").click(function () {
        $(".lightbgcolor").hide();
    });
    $(".Canclebutton").click(function () {
        $(".lightbgcolor").hide();
    });

    $('.left-side-menu').click(function () {
        $('.left-side-menu li.active').removeClass('active');
        $(this).addClass('active');
    });


    $(function () {
        var code = "";
        $('#mobile').val(code);
        $('#mobile').intlTelInput({
            autoHideDialCode: true,
            autoPlaceholder: "ON",
            dropdownContainer: document.body,
            formatOnDisplay: true,
            initialCountry: "us",
            placeholderNumberType: "MOBILE",
            preferredCountries: ['us', 'gb', 'in'],
            separateDialCode: true
        });
        $('#btn-submit').on('click', function () {
            var code = $("#mobile").intlTelInput("getSelectedCountryData").dialCode;
            var phoneNumber = $('#mobile').val();
            document.getElementById("code").innerHTML = code;
            document.getElementById("mobile-number").innerHTML = phoneNumber;
        });
    });


    function CustomizationPlugin(editor) {
    }
    ClassicEditor
    .create(document.querySelector('#editor'), {
        extraPlugins: [CustomizationPlugin]
    })
    .then(newEditor => {
        window.editor = newEditor;
        CKEditorInspector.attach(newEditor, {
            isCollapsed: true
        });
    })
    .catch(error => {
        console.error(error);
    });


    /*upload image*/

    var btn_save = $(".save-profile"),
        btn_edit = $(".edit-profile"),
        img_object = $(".img-object"),
        overlay = $(".media-overlay"),
        media_input = $("#media-input");

    btn_save.hide(0);
    overlay.hide(0);

    btn_edit.on("click", function () {
        $(this).hide(0);
        overlay.fadeIn(300);
        btn_save.fadeIn(300);
    });
    btn_save.on("click", function () {
        $(this).hide(0);
        overlay.fadeOut(300);
        btn_edit.fadeIn(300);
    });

    media_input.change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                img_object.attr("src", e.target.result);
            };

            reader.readAsDataURL(this.files[0]);
        }
    });


  /*upload image*/


});

function toggleNav() {
    const sidebar = document.getElementById("mySidebar");
    const main = document.getElementById("main");
    sidebar.classList.toggle("closed");
    if (window.innerWidth <= 768) {
        sidebar.classList.toggle("open");
    }
}