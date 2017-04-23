namespace BookOpinions.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Book
    {
        public Book()
        {
            this.Authors = new HashSet<Author>();
            this.Opinions = new HashSet<Opinion>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Image Image { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }
    }
}
