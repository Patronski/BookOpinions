using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;
using BookOpinions.Services;
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
        public void Add(AddBookBindingModel bm)
        {
            bm.AuthorName = "Ivan Vazov";
            bm.Grade = 4;
            bm.ImageUrl = "url//";
            bm.Opinion = "mnogo dobra";
            bm.Title = "Опълченците на Шипка";
            if (ModelState.IsValid)
            {
                this.service.AddNewBook(bm);
            }
        }
    }
}