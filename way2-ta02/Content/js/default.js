$(function ($) {
    var fancyOptions = {
        openEffect: 'elastic',
        closeEffect: 'fade',
        openSpeed: 400,
        closeSpeed: 200,
        overlayShow: true,
        maxWidth: 768,
        maxHeight: 440,
        fitToView: true,
        autoSize: true,
        type: 'iframe',
        helpers: {
            overlay: {
                locked: false
            }
        }
    };

    $('.repositories a').fancybox(fancyOptions);

    $("select[name='searchType']").selectpicker({ style: 'btn-hg btn-primary', menuStyle: 'dropdown-inverse' });
});