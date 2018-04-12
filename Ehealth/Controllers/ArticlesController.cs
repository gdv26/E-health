using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Ehealth.Models;
using Ehealth.ViewModels;

namespace Ehealth.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext _context;

        public ArticlesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var articles = _context.Articles.Include(m => m.ArticleType).ToList();

            return View(articles);
        }

        public ViewResult New()
        {
            var articleTypes = _context.ArticleTypes.ToList();

            var viewModel = new ArticleFormViewModel
            {
                ArticleTypes = articleTypes
            };

            return View("ArticleForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var article = _context.Articles.SingleOrDefault(c => c.Id == id);

            if (article == null)
                return HttpNotFound();

            var viewModel = new ArticleFormViewModel
            {
                Article = article,
                ArticleTypes = _context.ArticleTypes.ToList()
            };

            return View("ArticleForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var article = _context.Articles.Include(m => m.ArticleType).SingleOrDefault(m => m.Id == id);

            if (article == null)
                return HttpNotFound();

            return View(article);

        }


        // GET: Article/Random
        public ActionResult Random()
        {
            var article = new Article() { Name = "ArticolActivitate!" };
            var users = new List<User>
            {
                new User { Name = "User 1" },
                new User { Name = "User 2" }
            };

            var viewModel = new RandomArticleViewModel
            {
                Article = article,
                Users = users
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Article article)
        {
            if (article.Id == 0)
            {
                article.DateAdded = DateTime.Now;
                _context.Articles.Add(article);
            }
            else
            {
                var articleInDb = _context.Articles.Single(m => m.Id == article.Id);
                articleInDb.Name = article.Name;
                articleInDb.ArticleTypeId = article.ArticleTypeId;
                articleInDb.ReleaseDate = article.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Articles");
        }
    }
}