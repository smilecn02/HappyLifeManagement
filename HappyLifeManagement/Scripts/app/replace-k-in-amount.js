(function () {
    $(function () {
        //Utility when input amount of money.
        $('#Amount').on('blur', function () {
            $(this).val($(this).val().replace('k', '000')
                                     .replace('K', '000'));
        });
    })
})();