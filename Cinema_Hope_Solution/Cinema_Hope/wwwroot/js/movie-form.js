$(document).ready(function () {
    $('#PosterUrl').on('change', function () {
        $('.movie-poster').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none');
    });
});