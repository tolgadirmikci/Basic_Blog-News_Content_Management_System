using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using NewsContentManagement.Models;
using NewsContentManagement.Data;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;

namespace NewsContentManagement.Controllers
{
    public class HomeController : Controller
    {
        private NewsCMContext db = new NewsCMContext();


        //Home Controller üzerindeki Action'lar...

        public ActionResult Index(int Page=1)
        {

            var news = db.News.OrderByDescending(m => m.Id).ToPagedList(Page, 6);
            return View(news);
        }

        //Anaysafadaki Post Kartların'dan Haber'in Detayına Gitme
        public ActionResult NewsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            News news = db.News.Find(id);
            if (news==null)
            {
                return HttpNotFound();
            }

            ViewData["categories"] = db.Categories.ToList();//

            return View(news);
        }

        //  NewsDetails Post Methodu///Yorumlar vb process için
        [HttpPost]
        public ActionResult NewsDetails(string commentText, int id)
        {
            Comment comments = new Comment();
            if (commentText==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (commentText != null)
            {
               
                comments.NewsId = id;
                comments.commentContent = commentText;
                comments.Date = DateTime.Now;
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }



        //Detay Sayfasından Kategori Filtreleme
        public ActionResult NewsFilter(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var news = from n in db.News
                       where n.CategoryId == id
                       select n;

            if (news==null)
            {
                return HttpNotFound();
            }

            return View(news.ToList());
        }

        [Authorize(Roles = "Admin")]
        //Admin Panel Index Action->View
        public ActionResult AdminLayoutTest()
        {
            var news = db.News.Count();
            ViewData["totalNews"] = news;
            var category = db.Categories.Count();
            ViewData["totalCategory"] = category;
            var author = db.Authors.Count();
            ViewData["totalAuthor"] = author;
            var comment = db.Comments.Count();
            ViewData["totalComment"] = comment;
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}