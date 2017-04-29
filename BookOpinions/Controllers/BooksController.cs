using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;
using BookOpinions.Models.ViewModels.Home;
using BookOpinions.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class BookController : BaseController
    {
        private BookService service;
        public BookController()
        {
            this.service = new BookService();
        }
        // GET: Books
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddBookBindingModel bm)
        {
            if (ModelState.IsValid)
            {
                this.CurrentUser = UserManager.FindById(this.User.Identity.GetUserId());
                this.service.AddNewBook(bm, this.CurrentUser);

                return this.RedirectToAction("index", "home");
            }
            return this.RedirectToAction("add");
        }

        public ActionResult All()
        {
            IEnumerable<SimpleBookViewModel> vms = this.service.GetAllBooks();
            return View(vms);
        }
    }
}