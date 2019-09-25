using ASPNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNet5.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article

        //tablicni prikaz svih clanaka
        public ActionResult Index()
        {
            ArticleExContext db = new ArticleExContext();
            var list = db.Articles.ToList();
            return View(list);
        }
        //action metoda za dodavanje novih clanaka
        //get metoda-prikazuje formu za dodavanje clanaka

        public ActionResult Create()
        {
 
            return View();
        }
        //post metoda-dohvaca podatke iz forme za unos novih clanaka
        //i sprema clanak u bazu
        [HttpPost]
        public ActionResult Create(ArticleEx article)
        {

            if (ModelState.IsValid)
            {
                ArticleExContext db = new ArticleExContext();
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //details action metoda-prikazuje detalje o pojedinom clanku
        public ActionResult Details(int? id)
        {

            if (id != null)
            {
                ArticleExContext db = new ArticleExContext();
                ArticleEx article = db.Articles.Find();
                if (article != null)
                {
                    return View(article);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        //delete action metoda -prikazuje detalje i trazi potvrdu brisanja
        //http get metoda
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                ArticleExContext db = new ArticleExContext();
                ArticleEx article = db.Articles.Find(id);
                if (article == null)
                {
                    return HttpNotFound();
                }
                return View(article);
            }

        }
        //post metoda za brisanje
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            ArticleExContext db = new ArticleExContext();
            ArticleEx article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");



        }

        //action metoda za uređivanje postojecih clanaka

        public ActionResult Edit(int? Id) {
            if (Id == null) {
                return HttpNotFound();
            }
            ArticleExContext db = new ArticleExContext();
            ArticleEx article = db.Articles.Find(Id);
            if (article == null) {
                return HttpNotFound();
            }
            return View(article);
        }
        //htttppost metoda za spremanje promjena koje smo
        //napravili na vec postojecem clanku
        [HttpPost]
        public ActionResult Edit(ArticleEx article) {
            if (ModelState.IsValid) {
                ArticleExContext db = new ArticleExContext();
                db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        public ActionResult AllArticles() {
            ArticleExContext db = new ArticleExContext();
            var list = db.Articles.Where(x => x.Published == true).OrderByDescending(y=>y.Id).ToList();


            return View(list);
        }


    }
}