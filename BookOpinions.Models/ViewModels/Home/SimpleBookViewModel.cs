namespace BookOpinions.Models.ViewModels.Home
{
    using BookOpinions.Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
