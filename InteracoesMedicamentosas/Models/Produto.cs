using System.Collections.Generic;

namespace InteracoesMedicamentosas.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; } //Importante -> Não apagar ou re-nomerar...
        public string Nome { get; set; } //Importante -> Não apagar ou re-nomerar...

        public virtual ICollection<Interacao> Interacoes { get; set; } //Importante -> Não apagar ou re-nomerar...
    }
}