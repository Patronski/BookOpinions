namespace BookOpinions.Models.ViewModels.Book
{
    using BookOpinions.Models.FunctionalityModels;
    using BookOpinions.Models.ViewModels.Home;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AllBooksViewModel
    {
        public IEnumerable<SimpleBookViewModel> Books { get; set; }
        public Pager Pager { get; set; }
        public string SortOrder { get; set; }
    }
}
