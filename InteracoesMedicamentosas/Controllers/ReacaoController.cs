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

        //public ActionResult Consulta()
        //{

        //    ViewBag.Reacoes = Context.Reacoes.OrderBy(p => p.Nome).ToList();
        //    return View();
        //    int i = 0;
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Reacao reacao = Context.Reacoes.Find(id);
        //    if (reacao == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    //ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome");
        //    ViewBag.Reacoes = new SelectList(Context.Reacoes.OrderBy(p => p.Nome), "ReacaoId", "Nome", i);
        //    return View();

        //    //var consulta = Context.Interacoes.Include(p => p.Produto).Include(r => r.Reacao).Where(c => c.ReacaoId == i);
        //    //return View(consulta);
        //}

        //// GET: Reacao/Consulta/
        //public ActionResult Consulta()
        //{
        //    ViewBag.Reacoes = Context.Reacoes.OrderBy(p => p.Nome).ToList();
        //    return View();
        //}

        //// GET: Reacao/ConsultaNova
        //public ActionResult ConsultaNova(string Pesquisa ="")
        //{
        //    List<Interacao> ListaInteracao = Context.Interacoes.ToList();
        //    return View(ListaInteracao);

        //    var q = Context.Interacoes.AsQueryable();
        //    if (!string.IsNullOrEmpty(Pesquisa))
        //        q = q.Where(c => c.Reacao.Nome.Contains(Pesquisa));
        //    q = q.OrderBy(c => c.Reacao.Nome);         

        //}



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

        [HttpPost]
        public ActionResult Voltar()
        {
            return RedirectToAction("Index");
        }


    }
}
