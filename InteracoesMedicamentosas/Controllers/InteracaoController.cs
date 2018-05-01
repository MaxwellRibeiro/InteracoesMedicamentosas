using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InteracoesMedicamentosas.Context;
using InteracoesMedicamentosas.Models;
using Microsoft.SqlServer.Server;

namespace InteracoesMedicamentosas.Controllers
{
    public class InteracaoController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Interacao
        public ActionResult Index()
        {
            var interacoes =
                context.Interacoes.Include(p => p.Produto).Include(r => r.Reacao).OrderBy(i => i.InteracaoId);
            return View(interacoes);
        }

        // GET: Interacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interacao interacao = context.Interacoes.Where(p => p.InteracaoId == id).Include
                (p => p.Produto).Include(r => r.Reacao).First();

            if (interacao == null)
            {
                return HttpNotFound();
            }

            return View(interacao);
        }

        // GET: Interacao/Create
        public ActionResult Create()
        {
            ViewBag.Produtos = context.Produtos.OrderBy(p => p.Nome).ToList();
            ViewBag.Reacoes = context.Reacoes.OrderBy(p => p.Nome).ToList();
            return View();
        }

        // POST: Interacao/Create
        [HttpPost]
        public ActionResult Create(Interacao interacao)
        {
            try
            {
                context.Interacoes.Add(interacao);
                context.SaveChanges();
            }
            catch
            {
                return Json(new { Resultado = 0 }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Resultado = interacao.InteracaoId }, JsonRequestBehavior.AllowGet);
        }

        // GET: Interacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interacao interacao = context.Interacoes.Find(id);

            if (interacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(context.Produtos.OrderBy(p => p.Nome), "ProdutoId", "Nome");
            ViewBag.ReacaoId = new SelectList(context.Reacoes.OrderBy(p => p.Nome), "ReacaoId", "Nome");

            return View(interacao);
        }

        // POST: Interacao/Edit/5
        [HttpPost]
        public ActionResult Edit(Interacao interacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(interacao).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(interacao);
            }
            catch
            {
                return View(interacao);
            }
        }

        // GET: Interacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interacao interacao = context.Interacoes.Where(p => p.InteracaoId == id).Include(p => p.Produto).Include(r => r.Reacao).First();
            if (interacao == null)
            {
                return HttpNotFound();
            }

            return View(interacao);
        }

        // POST: Interacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Interacao venda = context.Interacoes.Find(id);
                if (venda != null)
                {
                    context.Interacoes.Remove(venda);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
