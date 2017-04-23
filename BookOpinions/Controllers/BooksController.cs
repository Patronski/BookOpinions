using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Add()
        {
            return View();
        }
    }
}