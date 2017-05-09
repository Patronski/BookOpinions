using BookOpinions.Models.ViewModels.Home;
using System.Collections.Generic;

namespace BookOpinions.Services.Contracts
{
    public interface IHomeService
    {
        IEnumerable<SimpleBookViewModel> GetPopularBooks();
    }
}
