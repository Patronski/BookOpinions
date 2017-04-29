namespace BookOpinions.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BookOpinions.Models.ViewModels.Home;

    public class HomeService : Service
    {
        public IEnumerable<SimpleBookViewModel> GetPopularBooks()
        {
            var books = this.Context.Books.Take(12).Select(b=> new SimpleBookViewModel
            {
                Id = b.Id,
                ImgUrl = b.Image.Url,
                Title = b.Title
            });
            
            return books;
        }
    }
}
