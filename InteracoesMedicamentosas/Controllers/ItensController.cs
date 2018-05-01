using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteracoesMedicamentosas.Context;

namespace InteracoesMedicamentosas.Controllers
{
    public class ItensController : Controller
    {
        private EFContext context = new EFContext();

        public ActionResult ListarItens(int id)
        {
            var interacoes = context.Interacoes.Include(p => p.Produto).Include(r => r.Reacao).OrderBy(i => i.InteracaoId);
            return PartialView(interacoes);
        }
    }
}