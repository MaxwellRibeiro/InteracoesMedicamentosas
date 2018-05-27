//function SalvarReacao() {

//    debugger;

//    Produto
//    var produto = $("#Produto").val();

//    Cliente
//    var reacao = $("#Reacao").val();

//    Gravar
//    var url = "/Reacao/Consultar";

//    $.ajax({
//        url: url
//        , type: "POST"
//        , datatype: "json"
//        , data: { InteracaoId: 0, ReacaoId: reacao, ProdutoId: produto }
//        , success: function (data) {
//            //debugger;
//            if (data.Resultado > 0) {
//                M.toast({ html: 'Interação Salvo com Sucesso!' })
//                //ListarItens(data.Resultado);
//            } else {
//                M.toast({ html: 'Não foi Possivel Alterar Interação!' });
//            }
//        }

//    });
//}

//function AlterarInteracao(id) {

//    //debugger;

//    //Produto
//    var produto = $("#Produto").val();

//    //Cliente
//    var reacao = $("#Reacao").val();


//    //Gravar
//    var url = "/Interacao/Edit";

//    $.ajax({
//        url: url
//        , type: "POST"
//        , datatype: "json"
//        , data: { InteracaoId: id, ReacaoId: reacao, ProdutoId: produto }
//        , success: function (data) {
//            //debugger;
//            if (data.Resultado > 0) {
//                M.toast({ html: 'Interação Alterada com Sucesso!' });
//                Voltar();
//            } else {
//                M.toast({ html: 'Não foi Possivel Alterar Interação!' });
//            }
//        }
//    });
//}

function Voltar() {

    var url = "/Reacao/Voltar";

    $.ajax({
        url: url
        , type: "POST"
        , data: {}
        , datatype: "html"
    });
}

function ListarItens(idPedido) 
{

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