using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteracoesMedicamentosas.Models;
using System.Data.Entity;
using System.Net;
using InteracoesMedicamentosas.Context;

namespace InteracoesMedicamentosas.Controllers
{
    public class ConsultaReacaoController : Controller
    {
        private EFContext Context = new EFContext();
        // GET: ConsultaReacao
        public ActionResult Index(string Pesquisa = "")
        {
            var interacoes = Context.Interacoes.Include(p => p.Produto).Include(r => r.Reacao).OrderBy(i => i.InteracaoId);

            //var q = Context.Interacoes.AsQueryable();
            var q = Context.Interacoes.Include(p => p.Produto).Include(r => r.Reacao);
            if (!string.IsNullOrEmpty(Pesquisa))
                q = q.Where(c => c.Reacao.Nome.Contains(Pesquisa));
                q = q.OrderBy(c => c.Reacao.Nome);

            //return View(interacoes);
            return View(q.ToList());

            
        }

        
    }
}
