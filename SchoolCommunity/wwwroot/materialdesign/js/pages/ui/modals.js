$(function () {
    $('.js-modal-buttons .btn').on('click', function () {
        var color = $(this).data('color');

        /*** Implementa��o Padr�o do Framework  ***/
        //$('#mdModal .modal-content').removeAttr('class').addClass('modal-content modal-col-' + color);
        //$('#mdModal').modal('show');

        /*** Minha Implementa��o ***/
        $('#idModalPerguntar .modal-content').removeAttr('class').addClass('modal-content modal-col-' + color);
        $('#idModalPerguntar').modal('show');

    });
});