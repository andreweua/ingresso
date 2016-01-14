$(document).ready(function () {
    $(".cpf").mask("999.999.999-99");
    $(".cep").mask("99999-999");
    $(".datepicker").datetimepicker({
        locale: 'pt-br',
        format: 'L',
        showClose: true,
        showClear: true,
        toolbarPlacement: 'top'
    });
});
