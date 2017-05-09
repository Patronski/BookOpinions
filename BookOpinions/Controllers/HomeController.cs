using BookOpinions.Models.ViewModels.Home;
using BookOpinions.Services;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.Controllers
{
    public class HomeController : BaseController
    {
        private HomeService service;
        public HomeController()
        {
            this.service = new HomeService();
        }

        //избираш си категория на книга измежду много
        // търсене по заглавие или автор
        // както и пример с картинки от популярни книги в момента
        // моя профил за логнат или 
        [HandleError()]
        [Route]
        [Route("index")]
        [Route("home/index")]
        public ActionResult Index()
        {
            //var usename = this.User.Identity.Name;
            var vm = "viewmodel";
            if (vm == null)
            {
                return this.HttpNotFound();
            }

            IEnumerable<SimpleBookViewModel> vms = this.service.GetPopularBooks();

            return View(vms);
        }

        [HandleError()]
        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HandleError()]
        [Route("contacts")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HandleError()]
        [Route("upload")]
        public ActionResult UploadFile()
        {
            return this.View();
        }

        [HandleError()]
        [HttpPost]
        [Route("upload")]
        [ActionName("UploadFile")]
        public ActionResult Upload()
        {
            HttpPostedFileBase file = this.Request.Files[0];
            string fileName = Path.GetFileName(file.FileName);
            string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
            file.SaveAs(path);

            return this.RedirectToAction("index");
        }
    }
}