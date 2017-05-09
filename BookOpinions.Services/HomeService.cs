namespace BookOpinions.Services
{
    using BookOpinions.Models.ViewModels.Home;
    using BookOpinions.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : Service, IHomeService
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
