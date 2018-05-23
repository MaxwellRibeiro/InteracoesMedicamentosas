using InteracoesMedicamentosas.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteracoesMedicamentosas.Models;
using System.Data.Entity;
using System.Net;

namespace InteracoesMedicamentosas.Controllers
{
    public class ReacaoController : Controller
    {
        private EFContext Context = new EFContext();

        // GET: Reacao
        public ActionResult Index()
        {
            

            List<Reacao> ListaReacoes = Context.Reacoes.ToList();
            return View(ListaReacoes);
           
        }

        public ActionResult Consulta(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reacao reacao = Context.Reacoes.Find(id);
            if (reacao == null)
            {
                return HttpNotFound();
            }

            //ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome");
            ViewBag.Reacoes = new SelectList(Context.Reacoes.OrderBy(p => p.Nome),"ReacaoId","Nome",reacao.ReacaoId);

            var consulta = Context.Interacoes.Include(p => p.Produto).Include(r => r.Reacao).Where(c => c.ReacaoId == reacao.ReacaoId);
            return View(consulta);
        }


        // GET: Reacao/Details/5                 
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reacao reacao = Context.Reacoes.Find(id);
            if (reacao == null)
            {
                return HttpNotFound();
            }
            return View(reacao);           
        }
      
        // GET: Reacao/Create                   
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reacao/Create
        [HttpPost]
        public ActionResult Create(Reacao reacao)
        {
            Context.Reacoes.Add(reacao);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Reacao/Edit/5             CRIAR A VIEW
        public ActionResult Edit(int? id)
        {
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reacao reacao = Context.Reacoes.Find(id);
            if (reacao == null)
            {
                return HttpNotFound();
            }
            return View(reacao);
        }

        // POST: Reacao/Edit/5
        [HttpPost]
        public ActionResult Edit(Reacao reacao)
        {
           if (ModelState.IsValid)
            {
                Context.Entry(reacao).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reacao);
        }

        // GET: Reacao/Delete/5                           CRIAR A VIEW
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reacao reacao = Context.Reacoes.Find(id);
            if (reacao == null)
            {
                return HttpNotFound();
            }
            return View(reacao);
        }

        // POST: Reacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {         

            Reacao reacao = Context.Reacoes.Find(id);
            Context.Reacoes.Remove(reacao);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
