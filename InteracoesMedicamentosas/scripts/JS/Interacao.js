function SalvarInteracao() {

    //debugger;

    //Produto
    var produto = $("#Produto").val();

    //Cliente
    var reacao = $("#Reacao").val();


    //Gravar
    var url = "/Interacao/Create";

    $.ajax({
        url: url
        , type: "POST"
        , datatype: "json"
        , data: { InteracaoId: 0, ReacaoId: reacao, ProdutoId: produto }
        , success: function (data) {
            debugger;
            if (data.Resultado > 0) {
                ListarItens(data.Resultado);
            }
        }
    });
}

function ListarItens(idPedido) {

    var url = "/Itens/ListarItens";

    $.ajax({
        url: url
        , type: "GET"
        , data: { id: idPedido }
        , datatype: "html"
        , success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });

}