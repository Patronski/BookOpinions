namespace BookOpinions.Models.BindingModels.Book
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentBindingModel
    {
        public string Comment { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
    }
}
