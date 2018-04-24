using System.Collections.Generic;

namespace InteracoesMedicamentosas.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; } //Importante -> Não apagar ou re-nomerar...
        public string Nome { get; set; } //Importante -> Não apagar ou re-nomerar...
        public int Tipo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Interacao> Interacoes { get; set; } //Importante -> Não apagar ou re-nomerar...
    }
}