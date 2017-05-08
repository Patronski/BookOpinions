namespace BookOpinions.Models.ViewModels.Book
{
    using BookOpinions.Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AboutBookViewModel
    {
        public AboutBookViewModel()
        {
            this.Opinions = new HashSet<Opinion>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public string ImgUrl { get; set; }

        public string Authors { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual ICollection<Opinion> Opinions { get; set; }

        public virtual double FinalRating { get; set; }
        public virtual int TotalVoted { get; set; }
    }
}
