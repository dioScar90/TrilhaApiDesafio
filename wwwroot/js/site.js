// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#status_search").change(function () {
    $("#por_titulo, #por_data, #por_status").hide();
    $("#titulo_tarefa, #data_tarefa").val("");
    $("#status_tarefa").prop("selectedIndex", 0);

    let idx = this.selectedIndex;

    switch (idx) {
        case 1:
            $("#titulo_tarefa").attr("placeholder", "Escreva o título");
            $("#por_titulo").show();
            $("#titulo_tarefa").focus();
            break;
        case 2:
            $("#por_data").show();
            break;
        case 3:
            $("#por_status").show();
            break;
        default:
            $("#por_titulo, #por_data, #por_status").hide();
    }
 });