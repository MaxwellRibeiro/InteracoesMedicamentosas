using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteracoesMedicamentosas.Context;
using InteracoesMedicamentosas.Models;

namespace InteracoesMedicamentosas.Controllers
{
    public class ProdutoController : Controller
    {
        private EFContext Context = new EFContext();
        // GET: Produto
        public ActionResult Index()
        {
            List<Produto> ListaProdutos = Context.Produtos.ToList();
            return View(ListaProdutos);
        }

    }
}