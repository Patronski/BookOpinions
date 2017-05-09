namespace BookOpinions.Models.ViewModels.Home
{
    using BookOpinions.Models.EntityModels;

    public class SimpleBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public Author Author { get; set; }
        public int OpinionsCount { get; set; }
        public double Rating { get; set; }
    }
}
