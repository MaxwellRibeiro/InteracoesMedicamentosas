using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteracoesMedicamentosas.Models
{
    public class Interacao
    {
        public int InteracaoId { get; set; }

        public int ReacaoId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Reacao Reacao { get; set; }
        public virtual Produto Produto { get; set; }
    }
}