using System.ComponentModel.DataAnnotations;

namespace BookOpinions.Models.BindingModels.Book
{
    public class AddBookBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorName { get; set; }
    }
}
