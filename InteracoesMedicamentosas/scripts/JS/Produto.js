
function MostraInteracaoProduto() {

    debugger
    var ListaMedicamentosSelecionados = $("#CbMedicamento").val();

    var url = "/Produto/MostraInteracaoProduto/?ItensSelecionados=" + ListaMedicamentosSelecionados.join();

    $.ajax({

        type: "GET"
        , url: url
        , success: function (data) {

        }
    });
}