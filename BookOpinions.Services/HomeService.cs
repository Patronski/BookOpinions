﻿namespace BookOpinions.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookOpinions.Models.ViewModels.Home;

    public class HomeService : Service
    {
        public IEnumerable<PopularBookViewModel> GetPopularBooks()
        {
            var books = this.Context.Books.Take(10).Select(b=> new PopularBookViewModel
            {
                Id = b.Id,
                ImgUrl = b.Image.Url,
                Title = b.Title
            });
            
            return books;
        }
    }
}