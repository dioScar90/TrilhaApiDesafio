// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#status_search").change(function () {
    $("#por_id, #por_titulo, #por_descricao, #por_data, #por_status").hide();
    $("#id_tarefa, #titulo_tarefa, #descricao_tarefa, #data_tarefa").val("");
    $("#status_tarefa").prop("selectedIndex", 0);

    let idx = this.selectedIndex;

    switch (idx) {
        case 1 :
            // $("#id_tarefa").attr("placeholder", "Informe o número do Id").focus();
            $("#id_tarefa").val("3");
            $("#por_id").show();
            break;
        case 2 :
            $("#titulo_tarefa").attr("placeholder", "Escreva o título").focus();
            $("#por_titulo").show();
            $("#titulo_tarefa").focus();
            break;
        case 3 :
            $("#descricao_tarefa").attr("placeholder", "Escreva a descrição").focus();
            $("#por_descricao").show();
            $("#descricao_tarefa").focus();
            break;
        case 4 :
            $("#por_data").show();
            break;
        case 5 :
            $("#por_status").show();
            break;
        default:
            $("#por_id, #por_titulo_descricao, #por_data, #por_status").hide();
    }
 });