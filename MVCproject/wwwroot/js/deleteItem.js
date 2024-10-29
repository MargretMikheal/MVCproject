
$(document).ready(function () {
    $('.js-delete').on('click', function (e) {
        e.preventDefault(); 
        var btn = $(this);

        console.log(btn.data('id')); 
    });
});
