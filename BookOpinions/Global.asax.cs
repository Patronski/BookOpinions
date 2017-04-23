using AutoMapper;
using BookOpinions.App_Start;
using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookOpinions
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEnginesConfiguration.RegisterViewEngines(ViewEngines.Engines);
            this.RegisterMapper();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMapper()
        {
            Mapper.Initialize(e =>
            {
                //e.CreateMap<AddBookBindingModel, Book>()
                //.ForMember(b => b.Authors, ce => ce.MapFrom(vm => new Author
                //{
                //    Name = vm.AuthorName,
                //}))
                //.ForMember(b => b.Rating, ce => ce.MapFrom(vm => vm.Grade));
                    
            });
        }
    }
}
