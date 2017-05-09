namespace BookOpinions.Models.ViewModels.Book
{
    using BookOpinions.Models.FunctionalityModels;
    using BookOpinions.Models.ViewModels.Home;
    using System.Collections.Generic;

    public class AllBooksViewModel
    {
        public IEnumerable<SimpleBookViewModel> Books { get; set; }
        public Pager Pager { get; set; }
        public string SortOrder { get; set; }
        public string Search { get; set; }
    }
}
