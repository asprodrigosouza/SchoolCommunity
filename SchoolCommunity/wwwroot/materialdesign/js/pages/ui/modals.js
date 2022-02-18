$(function () {
    $('.js-modal-buttons .btn').on('click', function () {
        var color = $(this).data('color');

        /*** Implementação Padrão do Framework  ***/
        //$('#mdModal .modal-content').removeAttr('class').addClass('modal-content modal-col-' + color);
        //$('#mdModal').modal('show');

        /*** Minha Implementação ***/
        $('#idModalPerguntar .modal-content').removeAttr('class').addClass('modal-content modal-col-' + color);
        $('#idModalPerguntar').modal('show');

    });
});