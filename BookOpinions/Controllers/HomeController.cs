﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.Controllers
{
    public class HomeController : Controller
    {
        //избираш си категория на книга измежду много
        // търсене по заглавие или автор
        // както и пример с картинки от популярни книги в момента
        // моя профил за логнат или 
        public ActionResult Index()
        {
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