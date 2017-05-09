using System.ComponentModel.DataAnnotations;

namespace BookOpinions.Models.EntityModels
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}
