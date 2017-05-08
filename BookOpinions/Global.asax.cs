using AutoMapper;
using BookOpinions.App_Start;
using BookOpinions.Models.BindingModels.Book;
using BookOpinions.Models.EntityModels;
using BookOpinions.Models.ViewModels.Book;
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
                e.CreateMap<Book, AddBookViewModel>();
                e.CreateMap<Book, AboutBookViewModel>()
                    .ForMember(dest => dest.Authors, opts => opts.MapFrom(
                        src => string.Join(", ", src.Authors.Select(author => author.Name))))
                    .ForMember(dest => dest.ImgUrl, opts => opts.MapFrom(
                        src => src.Image.Url))
                    .ForMember(dest => dest.TotalVoted, opts => opts.MapFrom(
                        src => src.Rating.Count))
                    .ForMember(dest => dest.FinalRating, opts => opts.MapFrom(
                        src => src.Rating.Sum(r => r.Rate) / (double)src.Rating.Count()));
                e.CreateMap<CommentBindingModel, Opinion>();
            });
        }
    }
}
