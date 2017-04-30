namespace BookOpinions.Models.ViewModels.Book
{
    using BookOpinions.Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AboutBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public Author Author { get; set; }
        public Rating Rating { get; set; }
    }
}
