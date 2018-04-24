using System.Collections.Generic;

namespace InteracoesMedicamentosas.Models
{
    public class Reacao
    {
        public int ReacaoId { get; set; } //Importante -> Não apagar ou re-nomerar...
        public string Nome { get; set; } //Importante -> Não apagar ou re-nomerar...
        public string Descricao { get; set; }

        public virtual ICollection<Interacao> Interacoes { get; set; } //Importante -> Não apagar ou re-nomerar...
    }
}