using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TituloApp.Models;

namespace TituloApp.Controllers
{
    public class TitulosController : Controller
    {
        private transporte_tituloEntities db = new transporte_tituloEntities();

        // GET: Titulos
        public ActionResult Index()
        {
            return View(db.titulos.ToList());
        }

        // GET: Titulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            titulos titulos = db.titulos.Find(id);
            if (titulos == null)
            {
                return HttpNotFound();
            }
            return View(titulos);
        }

        // GET: Titulos/Create
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "OK", Value = "1", Selected = true });
            items.Add(new SelectListItem { Text = "CANCELADO", Value = "2" });
            items.Add(new SelectListItem { Text = "PENDENCIAS", Value = "3" });

            ViewBag.SituacaoTipo = items;

            return View();
        }

        // POST: Titulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero,data_emissao,situacao,cliente,observacao,Valor")] titulos titulos)
        {
            var last_titulo = db.titulos.Count()>0 ?
                (from r in db.titulos orderby r.titulo_id select r.titulo_id).Max()+1 : 1;
            
            titulos.titulo_id = last_titulo;

            if (ModelState.IsValid)
            {
                db.titulos.Add(titulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(titulos);
        }

        // GET: Titulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            titulos titulos = db.titulos.Find(id);
            if (titulos == null)
            {
                return HttpNotFound();
            }
            return View(titulos);
        }

        // POST: Titulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "titulo_id,numero,data_emissao,cliente,situacao,observacao")] titulos titulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titulos);
        }

        // GET: Titulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            titulos titulos = db.titulos.Find(id);
            if (titulos == null)
            {
                return HttpNotFound();
            }
            return View(titulos);
        }

        // POST: Titulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            titulos titulos = db.titulos.Find(id);
            db.titulos.Remove(titulos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
