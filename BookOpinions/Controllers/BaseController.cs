using BookOpinions.Data;
using BookOpinions.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

        protected UserManager<ApplicationUser> UserManager { get; set; }

        protected ApplicationUser CurrentUser { get; set; }

        public BaseController()
        {
            context = new BookOpinionsContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.context));
        }

        [NonAction]
        public void SystemSettings()
        {

        }
    }
}