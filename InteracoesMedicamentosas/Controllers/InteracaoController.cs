using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteracoesMedicamentosas.Context;

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Interacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interacao/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interacao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Interacao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interacao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Interacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
