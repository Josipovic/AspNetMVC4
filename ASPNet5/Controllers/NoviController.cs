using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNet5.Models;

namespace ASPNet5.Controllers
{
    public class NoviController : Controller
    {
        private ArticleExContext db = new ArticleExContext();

        // GET: Novi
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Novi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleEx articleEx = db.Articles.Find(id);
            if (articleEx == null)
            {
                return HttpNotFound();
            }
            return View(articleEx);
        }

        // GET: Novi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Novi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ImageURL,Text,Author,PublishTime,Published")] ArticleEx articleEx)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(articleEx);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articleEx);
        }

        // GET: Novi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleEx articleEx = db.Articles.Find(id);
            if (articleEx == null)
            {
                return HttpNotFound();
            }
            return View(articleEx);
        }

        // POST: Novi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ImageURL,Text,Author,PublishTime,Published")] ArticleEx articleEx)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articleEx).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articleEx);
        }

        // GET: Novi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleEx articleEx = db.Articles.Find(id);
            if (articleEx == null)
            {
                return HttpNotFound();
            }
            return View(articleEx);
        }

        // POST: Novi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticleEx articleEx = db.Articles.Find(id);
            db.Articles.Remove(articleEx);
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
