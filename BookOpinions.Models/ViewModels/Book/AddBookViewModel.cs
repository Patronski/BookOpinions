namespace BookOpinions.Models.ViewModels.Book
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddBookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Image Url", ShortName = "Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Authors separated by comma(,)", ShortName = "Author")]
        public string AuthorName { get; set; }
    }
}
