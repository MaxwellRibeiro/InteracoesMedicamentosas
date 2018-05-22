using InteracoesMedicamentosas.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteracoesMedicamentosas.Models;

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

        // GET: Reacao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reacao/Create
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

        // GET: Reacao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reacao/Edit/5
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

        // GET: Reacao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reacao/Delete/5
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
