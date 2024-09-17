

jQuery(document).ready(function ($) {
    
    $(".hamburger").click(function () {
        $(this).toggleClass("is-active");
    });
    $(".hamburger").click(function () {
        $(".mobile-bd-color").toggle("");
    });

    $(".chat-list a").click(function () {
        $(".chatbox").addClass('showbox');
        return false;
    });

    $(".chat-icon").click(function () {
        $(".chatbox").removeClass('showbox');
    });

    var url = window.location;
    if (url == '') {
        $('ul.left-side-menu li a').removeClass('active');
        $(this).addClass('active');
    }
    else if (url == '') {
        $('ul.left-side-menu li a').removeClass('active');
        $(this).addClass('active');
    }
    else {
        $('ul.left-side-menu li a').removeClass('active');
        $('ul.left-side-menu a').each(function () {
            if (this.href == url) {
                $(this).addClass('active');
            }
        });
    }

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

    $(".mettings").click(function () {
        $(".lightbgcolor").show();
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
      /*  console.error(error);*/
    });

    /*upload image*/
    $(document).ready(function () {
        var fileArr = [];
        $("#images").change(function () {
            if (fileArr.length > 0) fileArr = [];

            $('#image_preview').html("");
            var total_file = document.getElementById("images").files;
            if (!total_file.length) return;
            for (var i = 0; i < total_file.length; i++) {
                if (total_file[i].size > 1048576) {
                    return false;
                } else {
                    fileArr.push(total_file[i]);
                    $('#image_preview').append("<div class='img-div' id='img-div" + i + "'><img src='" + URL.createObjectURL(event.target.files[i]) + "' class='image' title='" + total_file[i].name + "'><div class='middle'><button id='action-icon' value='img-div" + i + "' class='btn btn-danger' role='" + total_file[i].name + "'><i class='fa fa-trash'></i></button></div></div>");
                }
            }
        });

        $('body').on('click', '#action-icon', function (evt) {
            var divName = this.value;
            var fileName = $(this).attr('role');
            $(`#${divName}`).remove();

            for (var i = 0; i < fileArr.length; i++) {
                if (fileArr[i].name === fileName) {
                    fileArr.splice(i, 1);
                }
            }
            document.getElementById('images').files = FileListItem(fileArr);
            evt.preventDefault();
        });



        var fileArr = [];
        $("#images2").change(function () {
            if (fileArr.length > 0) fileArr = [];

            $('#image_preview2').html("");
            var total_file = document.getElementById("images2").files;
            if (!total_file.length) return;
            for (var i = 0; i < total_file.length; i++) {
                if (total_file[i].size > 1048576) {
                    return false;
                } else {
                    fileArr.push(total_file[i]);
                    $('#image_preview2').append("<div class='img-div2' id='img-div2" + i + "'><img src='" + URL.createObjectURL(event.target.files[i]) + "' class='image2' title='" + total_file[i].name + "'><div class='middle2'><button id='action-icon2' value='img-div2" + i + "' class='btn btn-danger' role='" + total_file[i].name + "'><i class='fa fa-trash'></i></button></div></div>");
                }
            }
        });

        $('body').on('click', '#action-icon2', function (evt) {
            var divName = this.value;
            var fileName = $(this).attr('role');
            $(`#${divName}`).remove();

            for (var i = 0; i < fileArr.length; i++) {
                if (fileArr[i].name === fileName) {
                    fileArr.splice(i, 1);
                }
            }
            document.getElementById('images2').files = FileListItem(fileArr);
            evt.preventDefault();
        });


        var fileArr = [];
        $("#images3").change(function () {
            if (fileArr.length > 0) fileArr = [];

            $('#image_preview3').html("");
            var total_file = document.getElementById("images3").files;
            if (!total_file.length) return;
            for (var i = 0; i < total_file.length; i++) {
                if (total_file[i].size > 1048576) {
                    return false;
                } else {
                    fileArr.push(total_file[i]);
                    $('#image_preview3').append("<div class='img-div3' id='img-div3" + i + "'><img src='" + URL.createObjectURL(event.target.files[i]) + "' class='image3' title='" + total_file[i].name + "'><div class='middle3'><button id='action-icon3' value='img-div3" + i + "' class='btn btn-danger' role='" + total_file[i].name + "'><i class='fa fa-trash'></i></button></div></div>");
                }
            }
        });

        $('body').on('click', '#action-icon3', function (evt) {
            var divName = this.value;
            var fileName = $(this).attr('role');
            $(`#${divName}`).remove();

            for (var i = 0; i < fileArr.length; i++) {
                if (fileArr[i].name === fileName) {
                    fileArr.splice(i, 1);
                }
            }
            document.getElementById('images3').files = FileListItem(fileArr);
            evt.preventDefault();
        });


       

        
    });
    /*upload image*/

    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })

  
});

function toggleNav() {
    const sidebar = document.getElementById("mySidebar");
    const main = document.getElementById("main");
    sidebar.classList.toggle("closed");
    if (window.innerWidth <= 768) {
        sidebar.classList.toggle("open");
    }

}








