using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = Context.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(produto).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

    }
}