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

        public string ImageUrl { get; set; }

        public string AuthorName { get; set; }

        public string Opinion { get; set; }

        [Range(1, 5)]
        public int? Grade { get; set; }
    }
}
