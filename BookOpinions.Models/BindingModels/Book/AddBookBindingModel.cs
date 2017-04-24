using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOpinions.Models.BindingModels.Book
{
    public class AddBookBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Display(Name = "Image Url", ShortName = "Url")]
        public string ImageUrl { get; set; }

        [Display(Name = "Authors separated by comma(,)", ShortName = "Author")]
        public string AuthorName { get; set; }
    }
}
