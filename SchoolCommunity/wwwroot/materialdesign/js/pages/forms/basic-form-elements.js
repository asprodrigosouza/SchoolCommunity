$(function () {
    //Textare auto growth
    autosize($('textarea.auto-growth'));

    //Datetimepicker plugin
    $('.datetimepicker').bootstrapMaterialDatePicker({
        format: 'dddd DD MMMM YYYY - HH:mm',
        clearButton: true,
        weekStart: 1
    });

    $('.datepicker').bootstrapMaterialDatePicker({
        //format: 'dddd DD MMMM YYYY',
        format: 'DD/MM/YYYY',
        clearButton: true,
        clearText: 'Limpar',
        cancelText: 'Cancelar',
        weekStart: 1,
        time: false
    });
    
    $('.timepicker').bootstrapMaterialDatePicker({
        format: 'HH:mm',
        clearButton: true,
        date: false
    });
});