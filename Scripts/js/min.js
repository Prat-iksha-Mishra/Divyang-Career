
jQuery(document).ready(function ($) {

    $('ul.tabs li').click(function () {
        var tab_id = $(this).attr('data-tab');
        $('ul.tabs li').removeClass('current');
        $('.tab-content').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })


    $(".selectBox").on("click", function (e) {
        $(this).toggleClass("show");
        var dropdownItem = e.target;
        var container = $(this).find(".selectBox__value");
        container.text(dropdownItem.text);
        $(dropdownItem)
            .addClass("active")
            .siblings()
            .removeClass("active");
    });

    baguetteBox.run('.tz-gallery');

    $('.faqtab').on('click', function () {
        $('.faqtab').removeClass('active');
        $(this).addClass('active');
    })
    $('.col-group span').on('click', function () {
        $('.col-group span').removeClass('active');
        $(this).addClass('active');
    })

    //if (!$.browser.webkit) {
    //    $('.wrapper').html('<p>Sorry! Non webkit users. :(</p>');
    //}

    $('ul.login-tabs li').click(function () {
        var tab_id = $(this).attr('data-tab');
        $('ul.login-tabs li').removeClass('current');
        $('.tab-content').removeClass('current');
        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })

    $('ul.login-tabss li').click(function () {
        var tab_id = $(this).attr('data-tabs');
        $('ul.login-tabss li').removeClass('currents');
        $('.tab-contentss').removeClass('currents');
        $(this).addClass('currents');
        $("#" + tab_id).addClass('currents');
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
    

    $(function () {
        var code = "+91";
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


});

$(document).ready(function () {
    $(".hamburger").click(function () {
        $(this).toggleClass("is-active");
    });
    $(".hamburger").click(function () {
        $(".mobile-bd-color").toggle("");
    });
});

$(document).ready(function () {

    $(".listpng").click(function () {
        $(".mobile-filter").toggle();
    });

    $(".faqtab1").click(function () {
        $(".tabs1").show();
        $(".tabs2").hide();
    });
    $(".faqtab2").click(function () {
        $(".tabs2").show();
        $(".tabs1").hide();
    });


    $(".login-form-popup").click(function () {
        $(".lightbgcolor").toggle();
    });

    $(".btn-close").click(function () {
        $(".lightbgcolor").hide();
    });


    $(".btn-reset-password").click(function () {
        $(".Resetpassword").show();
        $(".tablogins").hide();
    });
    $(".back-to-login").click(function () {
        $(".Resetpassword").hide();
        $(".tablogins").show();
    });

    
    $(".newtab1").click(function () {
        $(".Resetpassword").hide();
        $(".otp-screen").show();
        
    });

    $(".newtab2").click(function () {
        $(".Resetpassword").hide();
        $(".otp-screen").hide();
        $(".password_reset").show();
    });

    $(".newtab3").click(function () {
        $(".Resetpassword").hide();
        $(".otp-screen").hide();
        $(".password_reset").hide();
        $(".reset-password-complete").show();
    });

    $(".newtab4").click(function () {
        $(".tablogins").show();
        $(".Resetpassword").hide();
        $(".otp-screen").hide();
        $(".password_reset").hide();
        $(".reset-password-complete").hide();
    });


    $("#tabslogins1").click(function () {
        $(".Resetpassword").hide();
        $(".tablogins").show();
        $(".password_reset").hide();
        $(".otp-screen").hide();
        $(".reset-password-complete").hide();
    });

    $("#tabslogins2").click(function () {
        $(".Resetpassword").hide();
        $(".tablogins").show();
        $(".otp-screen").hide();
        $(".password_reset").hide();
        $(".reset-password-complete").hide();
    });

    var otp_inputs = document.querySelectorAll(".otp__digit")
    var mykey = "0123456789".split("")
    otp_inputs.forEach((_) => {
        _.addEventListener("keyup", handle_next_input)
    })
    function handle_next_input(event) {
        let current = event.target
        let index = parseInt(current.classList[1].split("__")[2])
        current.value = event.key

        if (event.keyCode == 8 && index > 1) {
            current.previousElementSibling.focus()
        }
        if (index < 6 && mykey.indexOf("" + event.key + "") != -1) {
            var next = current.nextElementSibling;
            next.focus()
        }
        var _finalKey = ""
        for (let { value } of otp_inputs) {
            _finalKey += value
        }
        if (_finalKey.length == 6) {
            document.querySelector("#_otp").classList.replace("_notok", "_ok")
            document.querySelector("#_otp").innerText = _finalKey
        } else {
            document.querySelector("#_otp").classList.replace("_ok", "_notok")
            document.querySelector("#_otp").innerText = _finalKey
        }
    }

    document
    .querySelectorAll('.dropdown-menu .dropdown-toggle[href="#"]')
    .forEach(function (element) {
        element.addEventListener("click", function (event) {
            event.stopPropagation();
        });
    });

    $(document).scroll(function () {
        if ($(this).scrollTop() > 0) {
            $('header').css("position", "fixed").css("top", "0px").css("width", "100%").css("z-index", "999");
        } else {
            $('header').css("position", "static").css("top", "0px").css("width", "100%");
        }
    });

   
});


document.addEventListener("DOMContentLoaded", function () {
    function share() {
        this.classList.toggle('active');
        document.querySelector('.social').classList.toggle('active');
    }
    document.querySelector('.share').addEventListener('click', share);
});
