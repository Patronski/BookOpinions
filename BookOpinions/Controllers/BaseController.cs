using BookOpinions.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookOpinions.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BookOpinionsContext context;

        //protected User CurrentUser { get; set; }

        public BaseController()
        {
            context = new BookOpinionsContext();
        }

        [NonAction]
        public void SystemSettings()
        {

        }
    }
}