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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {
            Context.Produtos.Add(produto);
            Context.SaveChanges();
            return RedirectToAction("Index");
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

        public ActionResult Details(long? id)
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

        public ActionResult Delete(long? id)
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
        public ActionResult Delete(int id)
        {
            try
            {
                Produto produto = Context.Produtos.Find(id);
                if (produto != null)
                {
                    Context.Produtos.Remove(produto);
                    Context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Consulta()
        {
            List<Produto> ListaProdutos = Context.Produtos.ToList();
            return View(ListaProdutos);
        }


        [HttpGet]
        public string MostraInteracaoProduto(string ItensSelecionados)
        {    

            List<int> ListaMedicamentosSelecionado = new List<int>();
            List<Interacao> ListaInteracoes = new List<Interacao>();

            string[] ItensTratados = ItensSelecionados.Split(',');

            if (ItensTratados != null)
            {
                foreach (var objeto in ItensTratados)
                    ListaMedicamentosSelecionado.Add(Convert.ToInt32(objeto));
            }

            ListaInteracoes = Context.Interacoes.ToList();
            ListaInteracoes = (from objeto in ListaInteracoes where ListaMedicamentosSelecionado.Contains(objeto.ProdutoId) select objeto).ToList();

            var ListaAuxiliar = ListaInteracoes.Select(x => x.ReacaoId).Distinct().ToList();
            string reacao = "";

            foreach (var objeto in ListaAuxiliar)
            {

                if (ListaMedicamentosSelecionado != null)
                {

                    if (ListaInteracoes.Count() > 0 && ListaInteracoes.Where(x => x.ReacaoId == objeto).Count() == ListaMedicamentosSelecionado.Count())
                    {
                        reacao += ListaInteracoes.Where(x => x.ReacaoId == objeto).Select(x => x.Reacao.Descricao).FirstOrDefault();
                    }

                }

            }

            return reacao;
        }

    }
}