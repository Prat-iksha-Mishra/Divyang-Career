(function ($) {
    'use strict';

    var defaults = {
        background: '#000',
        color: '#fff',
        rounded: true,
        width: '45px',
        height: '44px',
        bottom: '200px',
        right: '25px',
        windowScrollShow: 400,
        speed: 800,
        customHtml: '',
        mobileOnly: false,
        zIndex: 999,
    };

    $.fn.gotop = function (options) {
        var opts = $.extend(true, {}, defaults, options)
            , isMobile = $.fn.gotop.isMobile()
            , $el = this;
        return this.each(function () {
            $el.hide();
            if (opts.rounded == true) {
                $el.css('border-radius', '50%');
            }

            $el.css({
                cursor: 'pointer',
                position: 'fixed',
                'align-items': 'center',
                'justify-content': 'center',
                background: opts.background,
                color: opts.color,
                width: opts.width,
                height: opts.height,
                bottom: opts.bottom,
                right: opts.right
            });

            if (opts.customHtml != '') {
                $el.append(opts.customHtml);
            } else {
                $el.append('&uarr;');
            }

            $el.click(function (e) {
                e.preventDefault();
                $('html, body').animate({ scrollTop: 0 }, opts.speed);
            });

            if (opts.mobileOnly == true) {
                if (isMobile) {
                    $(window).scroll(function () {
                        $.fn.gotop.showButton($el, opts.windowScrollShow);
                    });
                } else {
                    return false;
                }
            }
            else {
                $(window).scroll(function () {
                    $.fn.gotop.showButton($el, opts.windowScrollShow);
                });
            }
        });
    };

    $.fn.gotop.isMobile = function () {
        return /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);
    }

    $.fn.gotop.showButton = function (element, windowScrollHeight) {

        if ($(window).scrollTop() > windowScrollHeight) {
            element.fadeIn(400)
                .css('display', 'flex');
        } else {
            element.fadeOut(400);
        }
    }

}(jQuery));