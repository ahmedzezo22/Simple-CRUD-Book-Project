using CRUDProj.Models;
using CRUDProj.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CRUDProj.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context;

        // GET: Books
        public BooksController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var books = context.books.Include(m=>m.Category).ToList();
            return View(books);
        }
        [HttpGet]
        public ActionResult AddBook()
        {

            var BookModel = new BookViewModel
            {

                Categories = context.categories.Where(m => m.IsActive == true).ToList()
            };
            return View(BookModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                  Title=viewModel.Title,
                  Description=viewModel.Description,
                  CategoryId=viewModel.CategoryId,
                  Author=viewModel.Author
                };
                context.books.Add(book);
                context.SaveChanges();
            }
            return RedirectToAction("Index","Books");
        }
     
        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var book = context.books.Find(id);
            if (book == null)
            {
                return null;
            }
            var Bookmodel = new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                CategoryId=book.CategoryId,
                Categories = context.categories.Where(z=>z.IsActive).ToList()
            };

            return View(Bookmodel);
        }
        [HttpPost]
       public ActionResult EditBook(int id ,BookViewModel viewModel)
        {
            var book = context.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                book.Author = viewModel.Author;
                book.Title = viewModel.Title;
                book.Description = viewModel.Description;
                book.CategoryId = viewModel.CategoryId;
            }
           
            context.SaveChanges();
                return RedirectToAction("Index", "Books");
            
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var book = context.books.Find(id);
            if (book == null)
            {
                return null;
            }
            context.books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index", "Books");
        }
    }
}