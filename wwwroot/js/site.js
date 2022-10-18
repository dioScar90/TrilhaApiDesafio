// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#status_search").change(function () {
    $("#por_id, #por_titulo_descricao, #por_data, #por_status").hide();
    $("#id_tarefa, #tit_desc_tarefa, #data_tarefa").val("");
    $("#status_tarefa").prop("selectedIndex", 0);

    let idx = this.selectedIndex;

    switch (idx) {
        case 1 :
            $("#por_id").show();
            break;
        case 2 :
            $("#tit_desc_tarefa").attr("placeholder", "Escreva o título").focus();
            $("#por_titulo_descricao").show();
            $("#tit_desc_tarefa").focus();
            break;
        case 3 :
            $("#tit_desc_tarefa").attr("placeholder", "Escreva a descrição").focus();
            $("#por_titulo_descricao").show();
            $("#tit_desc_tarefa").focus();
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