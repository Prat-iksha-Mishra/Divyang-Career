
jQuery(document).ready(function ($) {
    "use strict";
    if ($('#tl-featured-slider1').length) {
        $('#tl-featured-slider1').owlCarousel({
            items: 1,
            loop: true,
            margin: 30,
            autoplay: true,
            autoplayTimeout: 3000,
            
            responsive: {
                0: {
                    items: 1,
                },
                768: {
                    items: 1,
                },
                992: {
                    items: 1,
                },
                1199: {
                    items: 1,
                }
            }
        });
    }

    if ($('#tl-featured-slider2').length) {
        $('#tl-featured-slider2').owlCarousel({
            items: 1,
            loop: true,
            margin: 50,
            autoplay: false,
            autoplayTimeout: 3000,

            responsive: {
                0: {
                    items: 1,
                },
                768: {
                    items: 2,
                },
                992: {
                    items: 3,
                },
                1199: {
                    items: 3,
                }
            }
        });
    }

    if ($('#tl-featured-slider3').length) {
        $('#tl-featured-slider3').owlCarousel({
            items: 1,
            loop: true,
            margin: 30,
            autoplay: true,
            autoplayTimeout: 800,

            responsive: {
                0: {
                    items: 4,
                },
                768: {
                    items: 5,
                },
                992: {
                    items: 7,
                },
                1199: {
                    items: 8,
                }
            }
        });
    }

    if ($('#tl-featured-slider4').length) {
        $('#tl-featured-slider4').owlCarousel({
            items: 1,
            loop: true,
            margin: 30,
            autoplay: true,
            autoplayTimeout: 3000,

            responsive: {
                0: {
                    items: 2,
                },
                768: {
                    items: 3,
                },
                992: {
                    items: 4,
                },
                1199: {
                    items: 4,
                }
            }
        });
    }

});
